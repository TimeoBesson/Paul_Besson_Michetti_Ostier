using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
using Paul_Besson_Michetti_Ostier.UserControls;
using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paul_Besson_Michetti_Ostier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChargeClients TousLesClients { get; set; }
        public ChargeCommandes ToutesLesCommandes { get; set; }
        public ChargeProduits TousLesProduits { get; set; }
        public ChargeLignesCommandes ToutesLesLignesCommandes { get; set; }
        public ChargeRecettes ToutesLesRecettes { get; set; }
        public ChargeCategoriesRecettes ToutesLesCategoriesRecettes { get; set; }
        public ChargeCategorieEvenement ToutesLesCategoriesEvenement { get; set; }
        public ChargeRecettesAllergenes ToutesLesRecettesAllergenes { get; set; }
        public ChargeAllergenes TousLesAllergenes { get; set; }

        public Produit ProduitenAjout = new Produit();


        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            CultureInfo Culture = Thread.CurrentThread.CurrentUICulture;
            this.Language = XmlLanguage.GetLanguage(Culture.Name);
            AfficherConnexion();
        }

        public void AfficherConnexion()
        {
            UCConnexion connexion;
            if (Window.Content is UCConnexion)
                connexion = (UCConnexion)Window.Content;
            else
            {
                connexion = new UCConnexion();
                Window.Content = connexion;
            }
            connexion.butConnexion.Click += VerifierConnexion;
        }

        public void RetourConnexion(object sender, RoutedEventArgs e)
        {
            AfficherConnexion();
        }

        public void VerifierRole(object sender, RoutedEventArgs e)
        {
            UCConnexion connexion = (UCConnexion)Window.Content;
            string role = Employe.RoleEmploye(connexion.tbIdentifiant.Text);
            if (role == "patissier")
            {
                WindowState = WindowState.Maximized;
                AfficherGererCommandes(sender, e);
            }
            else if (role == "vendeur")
            {
                WindowState = WindowState.Maximized;
                AfficherCommandesDuJour(sender, e);
            }
        }

        public void VerifierConnexion(object sender, RoutedEventArgs e)
        {
            UCConnexion connexion = (UCConnexion)Window.Content;
            if (String.IsNullOrWhiteSpace(connexion.tbIdentifiant.Text) || String.IsNullOrWhiteSpace(connexion.pbMdp.Password))
            {
                MessageBox.Show("Veuillez remplir tous les champs pour vous connecter.", "Champs manquants", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (Employe.Connexion(connexion.tbIdentifiant.Text, connexion.pbMdp.Password))
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    VerifierRole(sender, e);
                }
                else
                    MessageBox.Show("L'identifiant ou le mot de passe est incorrect", "Employé inconnu", MessageBoxButton.OK, MessageBoxImage.Warning);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        public void AfficherGererCommandes(object sender, RoutedEventArgs e)
        {
            UCGererCommandes gererCommandes = new UCGererCommandes();
            Window.Content = gererCommandes;
            gererCommandes.butGererProduits.Click += AfficherGererProduits;
            gererCommandes.butDeconnecter.Click += RetourConnexion;
        }

        public void AfficherGererProduits(object sender, RoutedEventArgs e)
        {
            UCGererProduits gererProduits = new UCGererProduits();
            Window.Content = gererProduits;
            gererProduits.butGererCommandes.Click += AfficherGererCommandes;
            gererProduits.butDeconnecter.Click += RetourConnexion;
            gererProduits.butAjoutProduit.Click += AfficherAjouterProduit;
        }

        public void AfficherCommandesDuJour(object sender, RoutedEventArgs e)
        {
            UCCommandesDuJour commandesDuJour = new UCCommandesDuJour();
            Window.Content = commandesDuJour;
            commandesDuJour.butConsulterProduits.Click += AfficherConsulterProduits;
            commandesDuJour.butRechercherClient.Click += AfficherRechercherClient;
            commandesDuJour.butDeconnecter.Click += RetourConnexion;
        }

        public void AfficherConsulterProduits(object sender, RoutedEventArgs e)
        {
            UCConsulterProduits consulterProduits = new UCConsulterProduits();
            Window.Content = consulterProduits;
            consulterProduits.butCommandesDuJour.Click += AfficherCommandesDuJour;
            consulterProduits.butRechercherClient.Click += AfficherRechercherClient;
            consulterProduits.butDeconnecter.Click += RetourConnexion;
            consulterProduits.butEnregistrerCommande.Click += AfficherCreerCommande;
        }

        public void AfficherCreerCommande(object sender, RoutedEventArgs e)
        {
            UCCreerCommande creerCommande = new UCCreerCommande();
            Window.Content = creerCommande;

            decimal total = 0;
            foreach (Grid produit in UCConsulterProduits.lePanier)
            {
                TextBlock tbPrix = produit.FindName("tbPrixTotalProduit") as TextBlock;
                if (tbPrix != null)
                {
                    string prixTexte = tbPrix.Text.Replace(" €", "");
                    if (decimal.TryParse(prixTexte, out decimal prixProduit))
                        total += prixProduit;
                }
            }

            if (UCConsulterProduits.lePanier.Count == 0)
            {
                MessageBox.Show("Le panier est vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            creerCommande.butDeconnecter.Click += RetourConnexion;
        }

        public void AfficherRechercherClient(object sender, RoutedEventArgs e)
        {
            UCRechercherClient rechercherClient = new UCRechercherClient();
            Window.Content = rechercherClient;
            rechercherClient.butCommandesDuJour.Click += AfficherCommandesDuJour;
            rechercherClient.butConsulterProduits.Click += AfficherConsulterProduits;
            rechercherClient.butDeconnecter.Click += RetourConnexion;
        }

        public void AfficherAjouterProduit(object sender, RoutedEventArgs e)
        {
            UCAjouterProduits ajouterProduit = new UCAjouterProduits();
            Window.Content = ajouterProduit;
            ajouterProduit.butDeconnecter.Click += RetourConnexion;
            ajouterProduit.butannuler.Click += AfficherGererProduits;
        }
    }
}