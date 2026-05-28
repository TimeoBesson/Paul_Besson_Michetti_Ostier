using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
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
            try
            {
                this.ToutesLesRecettes = new ChargeRecettes();
                this.ToutLesClients = new ChargeClients();
                this.ToutesLesCommandes = new ChargeCommandes();
                this.TousLesProduits = new ChargeProduits();
                this.ToutesLesLignesCommandes = new ChargeLignesCommandes();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex, "Erreur de chargement : ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}