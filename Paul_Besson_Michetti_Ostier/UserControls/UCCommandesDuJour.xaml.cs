using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour UCCommandeDuJour.xaml
    /// </summary>
    public partial class UCCommandesDuJour : UserControl
    {
        public UCCommandesDuJour()
        {
            InitializeComponent();
            ChargeClients client = new ChargeClients();
            ChargeCategorieEvenement categorieEvenement = new ChargeCategorieEvenement();
            ChargeCategoriesRecettes categoriesRecettes = new ChargeCategoriesRecettes();
            ChargeAllergenes allergenes = new ChargeAllergenes();
            ChargeRecettes recettes = new ChargeRecettes();
            ChargeRecettesAllergenes recettesAllergenes = new ChargeRecettesAllergenes();
            ChargeProduits produits = new ChargeProduits();
            ChargeLignesCommandes lignesCommandes = new ChargeLignesCommandes();
 
            this.DataContext = new ChargeCommandesDuJour(); 
        }

        private void ckEstRecupere_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;


            if (cb != null && cb.DataContext is Commande commandeModifiee)
            {
                try
                {

                    commandeModifiee.UpdateEstRecupere();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sauvegarde du statut : " + ex.Message,
                                    "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);


                    cb.IsChecked = !cb.IsChecked;
                }
            }
        }
    }
}
