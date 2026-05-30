using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
using Paul_Besson_Michetti_Ostier.UserControls;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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
        public ChargeClients ToutLesClients { get; set; }
        public ChargeCommandes ToutesLesCommandes { get; set; }
        public ChargeProduits TousLesProduits { get; set; }
        public ChargeLignesCommandes ToutesLesLignesCommandes { get; set; }
        public ChargeRecettes ToutesLesRecettes { get; set; }
        public MainWindow()
        {
            InitializeComponent();
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
            //connexion.butConnexion.Click += VerifierConnexion;
            connexion.butConnexion.Click += AfficherGererCommandes;
        }

        public void RetourConnexion(object sender, RoutedEventArgs e)
        {
            AfficherConnexion();
        }

        public void VerifierRole()
        {
            UCConnexion connexion = (UCConnexion)Window.Content;
            string role = Employe.RoleEmploye(connexion.tbIdentifiant.Text);
            if (role == "patissier")
            {
                connexion.butConnexion.Click += AfficherCommandesDuJour;
            }
            else if (role == "vendeur")
            {
                connexion.butConnexion.Click += AfficherGererCommandes;
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
                    VerifierRole();
                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        public void AfficherGererCommandes(object sender, RoutedEventArgs e)
        {
            UCGererCommande gererCommandes = new UCGererCommande();
            Window.Content = gererCommandes;
            gererCommandes.butDeconnecter.Click += RetourConnexion;
        }

        public void AfficherCommandesDuJour(object sender, RoutedEventArgs e)
        {
            UCCommandesDuJour commmandeDuJour = new UCCommandesDuJour();
            Window.Content = commmandeDuJour;
            commmandeDuJour.butDeconnecter.Click += RetourConnexion;
        }
    }
}