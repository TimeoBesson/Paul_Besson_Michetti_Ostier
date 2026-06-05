using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paul_Besson_Michetti_Ostier.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UCChoixEvenement.xaml
    /// </summary>
    public partial class UCChoixEvenement : UserControl
    {
        public static List<string> CouleurFond = new List<string>() { "#FFDAD7", "#D4E4F6", "#FFDDB0", "#DDF7E3", "#F3E0FF", "#FFF4C9", "#D8F5F2", "#FFE4F1", "#E7E3FF", "#FFE9D6", "#D9F2FF", "#E8F7D8", "#FDE2E4", "#FAEDCD", "#E0FBFC", "#F1E4D1", "#E4C1F9", "#CDEAC0", "#FFDAC1", "#BDE0FE" };
        public static List<string> CouleurInitiale = new List<string>() { "#2E1413", "#0D1D2A", "#281800", "#163020", "#2C163A", "#3A2E00", "#0F2E2B", "#4A1830", "#241A4D", "#4D2600", "#00334D", "#254000", "#5C1A1B", "#4D3B00", "#1A3A40", "#4A2C1A", "#3F1D56", "#254D1B", "#5C2B1A", "#1A365D" };
        private List<Client> tousLesClients;

        public UCChoixEvenement()
        {
            InitializeComponent();
            List<CategorieEvenement> toutesLesCategories = new CategorieEvenement().FindAll();
            cbCategorie.ItemsSource = toutesLesCategories;
            cbCategorie.SelectedIndex = 0;
            ButEnregistrerCommandeIndisponible();
        }

        private void ButEnregistrerCommandeDisponible()
        {
            if (fondSuivant == null || butEnregistrerCommande == null)
                return;

            fondSuivant.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondSuivant.Opacity = 1;
            butEnregistrerCommande.IsEnabled = true;
        }

        private void ButEnregistrerCommandeIndisponible()
        {
            if (fondSuivant == null || butEnregistrerCommande == null)
                return;

            fondSuivant.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A2C2A"));
            fondSuivant.Opacity = 0.3;
            butEnregistrerCommande.IsEnabled = false;
        }

        private void butMoins_Click(object sender, RoutedEventArgs e)
        {
            if (labelNbPersonnes.Text == "1")
                return;
            else
                labelNbPersonnes.Text = (int.Parse(labelNbPersonnes.Text.ToString()) - 1).ToString();
        }

        private void butPlus_Click(object sender, RoutedEventArgs e)
        {
            if (labelNbPersonnes.Text == "99")
                return;
            else
                labelNbPersonnes.Text = (int.Parse(labelNbPersonnes.Text.ToString()) + 1).ToString();
        }

        private void labelNbPersonnes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbCategorie.SelectedItem != null && labelNbPersonnes.Text != null && dpDateRetrait.SelectedDate != null)
                ButEnregistrerCommandeDisponible();
            else
                ButEnregistrerCommandeIndisponible();

            if (String.IsNullOrWhiteSpace(labelNbPersonnes.Text))
            {
                labelNbPersonnes.Text = "1";
                return;
            }
            else if (int.Parse(labelNbPersonnes.Text) <= 1)
                labelNbPersonnes.Text = "1";
            else if (int.Parse(labelNbPersonnes.Text) >= 99)
                labelNbPersonnes.Text = "99";
        }

        private void cbCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCategorie.SelectedItem != null && labelNbPersonnes.Text != null && dpDateRetrait.SelectedDate != null)
                ButEnregistrerCommandeDisponible();
            else
                ButEnregistrerCommandeIndisponible();
        }

        private void dpDateRetrait_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCategorie.SelectedItem != null && labelNbPersonnes.Text != null && dpDateRetrait.SelectedDate != null)
                ButEnregistrerCommandeDisponible();
            else
                ButEnregistrerCommandeIndisponible();
        }

        private void butEnregistrerCommande_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategorie.SelectedItem == null || dpDateRetrait.SelectedDate == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            CategorieEvenement categorie = (CategorieEvenement)cbCategorie.SelectedItem;
            Commande laCommande = MainWindow.CommandeEnCours;

            laCommande.IdCategorieEvenement = categorie.IdCategorie;
            laCommande.UneCategorieEvenement = categorie;
            laCommande.NbPersonne = int.Parse(labelNbPersonnes.Text);
            laCommande.DateRetrait = DateOnly.FromDateTime(dpDateRetrait.SelectedDate.Value);
            laCommande.DateCreation = DateOnly.FromDateTime(DateTime.Today);
            laCommande.EstPrete = false;
            laCommande.EstRecuperee = false;

            int idCommande = laCommande.Create();

            foreach (LigneCommande ligne in laCommande.LesLignes)
            {
                ligne.IdCommande = idCommande;
                ligne.IdProduit = ligne.UnProduit.IdProduit;
                ligne.Create();
            }

            foreach (LigneCommande ligne in laCommande.LesLignes)
            {
                ligne.IdCommande = idCommande;
                ligne.IdProduit = ligne.UnProduit.IdProduit;
                ligne.Create();
            }

            MainWindow.CommandeEnCours = new Commande();
            MainWindow.CommandeEnCours.LesLignes = new List<LigneCommande>();

            UCConsulterProduits.lePanier.Clear();
            MessageBox.Show("Commandes enregistrée avec succès !");
        }
    }
}
