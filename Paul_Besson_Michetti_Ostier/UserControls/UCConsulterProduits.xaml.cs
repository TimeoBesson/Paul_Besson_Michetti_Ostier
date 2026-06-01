using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;

namespace Paul_Besson_Michetti_Ostier.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UCConsulterProduits.xaml
    /// </summary>
    public partial class UCConsulterProduits : UserControl
    {
        public UCConsulterProduits()
        {
            InitializeComponent();
            this.DataContext = new ChargeProduits();
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
    }
}
