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
    /// Logique d'interaction pour UCGererProduits.xaml
    /// </summary>
    public partial class UCGererProduits : UserControl
    {
        public UCGererProduits()
        {
            InitializeComponent();
            this.DataContext = new Classes.ChargeDonnees.ChargeProduits();
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

        private void butAjout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
