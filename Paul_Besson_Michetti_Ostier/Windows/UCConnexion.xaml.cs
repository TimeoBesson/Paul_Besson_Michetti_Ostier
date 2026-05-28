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

namespace Paul_Besson_Michetti_Ostier.Windows
{
    /// <summary>
    /// Logique d'interaction pour UCConnexion.xaml
    /// </summary>
    public partial class UCConnexion : UserControl
    {
        public UCConnexion()
        {
            InitializeComponent();
        }

        private void tbIdentifiant_GotFocus(object sender, RoutedEventArgs e)
        {
            labelIdentifiant.Content = string.Empty;
            imgIdentifiant.Opacity = 1;
            fondIdentifiant.Opacity = 1;
        }

        private void tbIdentifiant_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbIdentifiant.Text))
                labelIdentifiant.Content = "Identifiant";
            imgIdentifiant.Opacity = 0.5;
            fondIdentifiant.Opacity = 0.1;
        }

        private void pbIdentifiant_GotFocus(object sender, RoutedEventArgs e)
        {
            labelMdp.Content = string.Empty;
            imgMdp.Opacity = 1;
            fondMdp.Opacity = 1;
        }

        private void pbIdentifiant_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(pbIdentifiant.Password))
                labelMdp.Content = "••••••••";
            imgMdp.Opacity = 0.5;
            fondMdp.Opacity = 0.1;
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
