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
            connexion.butConnexion.Click += VerifierConnexion;
        }

        public void VerifierConnexion(object sender, RoutedEventArgs e)
        {
            UCConnexion connexion = (UCConnexion)Window.Content;
            if (String.IsNullOrWhiteSpace(connexion.tbIdentifiant.Text) || String.IsNullOrWhiteSpace(connexion.pbMdp.Password))
            {
                MessageBox.Show("Veuillez remplir tous les champs pour vous connecter.", "Champs manquants", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Employe.Connexion(connexion.tbIdentifiant.Text, connexion.pbMdp.Password))
                    connexion.butConnexion.Click += AfficherGererCommandes;
            }
            AfficherConnexion();
        }

        public void AfficherGererCommandes(object sender, RoutedEventArgs e)
        {
            UCGererCommande gererCommandes = new UCGererCommande();
            Window.Content = gererCommandes;
        }
    }
}