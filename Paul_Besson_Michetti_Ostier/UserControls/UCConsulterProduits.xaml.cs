using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Paul_Besson_Michetti_Ostier.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UCConsulterProduits.xaml
    /// </summary>
    public partial class UCConsulterProduits : UserControl
    {
        public static readonly List<Grid> lePanier = new List<Grid>();

        public UCConsulterProduits()
        {
            InitializeComponent();
            this.DataContext = new ChargeProduits();
            unProduit.Visibility = Visibility.Collapsed;
            fondEnregistrerCommande.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A2C2A"));
            fondEnregistrerCommande.Opacity = 0.3;
            butEnregistrerCommande.IsEnabled = false;
        }

        private void tbNbParts_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox nbParts = (TextBox)sender;
            string text = "Nombre de parts : ";

            if (nbParts.Text == text + "10")
            {
                nbParts.Text = "Lots de 10 unités";
            }
            else if (nbParts.Text == text + "50")
            {
                nbParts.Text = "Lots de 50 unités";
            }
            else if (nbParts.Text == text + "1")
            {
                nbParts.Text = "L'unité";
            }
        }

        private void tbEstIndisponible_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox estIndisponible = (TextBox)sender;
            Grid gridAjouterALaCommande = (Grid)estIndisponible.Parent;

            if (estIndisponible.Text == "False")
            {
                estIndisponible.Text = "Ajouter à la commande";
            }
            else
            {
                estIndisponible.Text = "Indisponible";
                gridAjouterALaCommande.Opacity = 0.5;
                gridAjouterALaCommande.IsEnabled = false;
            }
        }

        private void butAjouterALaCommande_Click(object sender, RoutedEventArgs e)
        {
            Button boutonClique = (Button)sender;
            if (boutonClique.DataContext is Produit produitSelectionne)
            {
                string nom = produitSelectionne.UneRecette.NomRecette;
                decimal prix = produitSelectionne.Prix;
                int nbParts = produitSelectionne.NbParts;
                string categorie = produitSelectionne.UneRecette.UneCategorieRecette?.NomCategorie;
                fondEnregistrerCommande.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
                fondEnregistrerCommande.Opacity = 1;
                butEnregistrerCommande.IsEnabled = true;
                AjouterAuPanier(nom, prix, nbParts, categorie);
            }
        }

        private void AjouterAuPanier(string nom, decimal prix, int nbParts, string categorie)
        {
            fondEnregistrerCommande.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondEnregistrerCommande.Opacity = 1;
            butEnregistrerCommande.IsEnabled = true;
            string nomProduitPanier = nom.Replace(" ", "_").Replace("-", "_") + nbParts;

            Grid produitExistant = lePanier.FirstOrDefault(g => g.Name == nomProduitPanier);

            if (produitExistant != null)
            {
                TextBox tbQte = produitExistant.FindName("tbQuantite") as TextBox;
                TextBlock tbPrix = produitExistant.FindName("tbPrixTotalProduit") as TextBlock;

                if (tbQte != null && int.TryParse(tbQte.Text, out int qteActuelle))
                {
                    int nouvelleQte = qteActuelle + 1;
                    tbQte.Text = nouvelleQte.ToString();
                    if (tbPrix != null)
                        tbPrix.Text = (prix * nouvelleQte).ToString("0.00") + " €";
                }
            }
            else
            {
                Grid nouveauProduit = NouveauProduit();
                nouveauProduit.Name = nomProduitPanier;
                nouveauProduit.Visibility = Visibility.Visible;

                (nouveauProduit.FindName("tbNomRecettePanier") as TextBlock).Text = nom;
                (nouveauProduit.FindName("tbCategorieProduit") as TextBlock).Text = categorie;
                (nouveauProduit.FindName("tbPrixTotalProduit") as TextBlock).Text = prix.ToString("0.00") + " €";
                (nouveauProduit.FindName("tbQuantite") as TextBox).Text = "1";

                Button butMoins = nouveauProduit.FindName("butMoins") as Button;
                Button butPlus = nouveauProduit.FindName("butPlus") as Button;
                Button butSupprimer = nouveauProduit.FindName("butSupprimerProduit") as Button;

                butMoins.Click += (s, e) => ChangerQuantite(nouveauProduit, prix, -1);
                butPlus.Click += (s, e) => ChangerQuantite(nouveauProduit, prix, +1);
                butSupprimer.Click += (s, e) =>
                {
                    lePanier.Remove(nouveauProduit);
                    stackPanier.Children.Remove(nouveauProduit);
                    MettreAJourPrixTotal();
                    if (lePanier.Count == 0)
                    {
                        fondEnregistrerCommande.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A2C2A"));
                        fondEnregistrerCommande.Opacity = 0.3;
                        butEnregistrerCommande.IsEnabled = false;
                    }

                };

                lePanier.Add(nouveauProduit);
                stackPanier.Children.Add(nouveauProduit);
                MettreAJourPrixTotal();
            }
        }

        private Grid NouveauProduit()
        {
            fondEnregistrerCommande.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondEnregistrerCommande.Opacity = 1;
            butEnregistrerCommande.IsEnabled = true;
            string xaml = System.Windows.Markup.XamlWriter.Save(unProduit);
            System.IO.StringReader stringReader = new System.IO.StringReader(xaml);
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
            return (Grid)System.Windows.Markup.XamlReader.Load(xmlReader);
        }

        private void ChangerQuantite(Grid produit, decimal prixUnitaire, int delta)
        {
            fondEnregistrerCommande.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondEnregistrerCommande.Opacity = 1;
            butEnregistrerCommande.IsEnabled = true;
            TextBox tbQte = produit.FindName("tbQuantite") as TextBox;
            TextBlock tbPrix = produit.FindName("tbPrixTotalProduit") as TextBlock;

            if (tbQte != null && int.TryParse(tbQte.Text, out int qte))
            {
                int nouvelleQte = qte + delta;
                if (nouvelleQte < 1)
                    return;

                tbQte.Text = nouvelleQte.ToString();
                if (tbPrix != null)
                    tbPrix.Text = (prixUnitaire * nouvelleQte).ToString("0.00") + " €";
                MettreAJourPrixTotal();
            }
        }

        private void MettreAJourPrixTotal()
        {
            decimal total = 0;

            foreach (Grid produit in lePanier)
            {
                TextBlock tbPrix = produit.FindName("tbPrixTotalProduit") as TextBlock;
                if (tbPrix != null)
                {
                    string prixTexte = tbPrix.Text.Replace(" €", "");
                    if (decimal.TryParse(prixTexte, out decimal prixProduit))
                    {
                        total += prixProduit;
                    }
                }
            }
            tbPrixTotal.Text = total.ToString("0.00") + " €";
        }

        private void FiltrerProduits(string? categorie)
        {
            ChargeProduits data = (ChargeProduits)this.DataContext;

            if (categorie == null)
                data.LesProduits = new ObservableCollection<Produit>(data.TousLesProduits);
            else
                data.LesProduits = new ObservableCollection<Produit>(
                    data.TousLesProduits.Where(p =>
                        p.UneRecette.UneCategorieRecette?.NomCategorie == categorie));
        }

        private void butTous_Click(object sender, RoutedEventArgs e)
        {
            fondTous.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondPains.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondViennoiseries.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondGateaux.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            labelTous.Foreground = Brushes.White;
            labelPains.Foreground = Brushes.Black;
            labelViennoiseries.Foreground = Brushes.Black;
            labelGateaux.Foreground = Brushes.Black;
            FiltrerProduits(null);
        }
            
        private void butPains_Click(object sender, RoutedEventArgs e)
        {
            fondTous.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondPains.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondViennoiseries.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondGateaux.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            labelTous.Foreground = Brushes.Black;
            labelPains.Foreground = Brushes.White;
            labelViennoiseries.Foreground = Brushes.Black;
            labelGateaux.Foreground = Brushes.Black;
            FiltrerProduits("Pains");
        }
            
        private void butViennoiseries_Click(object sender, RoutedEventArgs e)
        {
            fondTous.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondPains.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondViennoiseries.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondGateaux.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            labelTous.Foreground = Brushes.Black;
            labelPains.Foreground = Brushes.Black;
            labelViennoiseries.Foreground = Brushes.White;
            labelGateaux.Foreground = Brushes.Black;
            FiltrerProduits("Viennoiseries");
        }

        private void butGateaux_Click(object sender, RoutedEventArgs e)
        {
            fondTous.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondPains.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondViennoiseries.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EAE8E3"));
            fondGateaux.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            labelTous.Foreground = Brushes.Black;
            labelPains.Foreground = Brushes.Black;
            labelViennoiseries.Foreground = Brushes.Black;
            labelGateaux.Foreground = Brushes.White;
            FiltrerProduits("Gâteaux");
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            lePanier.Clear();
            stackPanier.Children.Clear();
            MettreAJourPrixTotal();
        }
    }
}