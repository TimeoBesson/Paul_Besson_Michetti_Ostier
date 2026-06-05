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
            ButSuivantIndisponible();
        }

        private void ButSuivantDisponible()
        {
            fondSuivant.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321716"));
            fondSuivant.Opacity = 1;
            butSuivant.IsEnabled = true;
        }

        private void ButSuivantIndisponible()
        {
            fondSuivant.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A2C2A"));
            fondSuivant.Opacity = 0.3;
            butSuivant.IsEnabled = false;
        }

        private void butMoins_Click(object sender, RoutedEventArgs e)
        {
            labelNbPersonnes.Content = int.Parse(labelNbPersonnes.Content.ToString()) - 1;
        }

        private void butPlus_Click(object sender, RoutedEventArgs e)
        {
            labelNbPersonnes.Content = int.Parse(labelNbPersonnes.Content.ToString()) + 1;
        }
    }
}
