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
    /// Logique d'interaction pour UCRechercherClient.xaml
    /// </summary>
    public partial class UCRechercherClient : UserControl
    {
        public UCRechercherClient()
        {
            InitializeComponent();
        }

        private void tbRecherche_GotFocus(object sender, RoutedEventArgs e)
        {
            labelRecherche.Content = String.Empty;
        }

        private void tbRecherche_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbRecherche.Text))
                labelRecherche.Content = "Rechercher par nom, téléphone ...";
        }
    }
}
