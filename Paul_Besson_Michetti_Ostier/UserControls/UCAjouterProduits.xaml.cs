using Paul_Besson_Michetti_Ostier.Classes;
using Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Paul_Besson_Michetti_Ostier.UserControls
{
    public partial class UCAjouterProduits : UserControl
    {
        public MainWindow main;

        public UCAjouterProduits()
        {
            InitializeComponent();
            this.DataContext = new ChargeAllergenes();
        }

        private void butenregistrer_Click(object sender, RoutedEventArgs e)
        {
            main = Application.Current.MainWindow as MainWindow;

            if (main != null &&
                main.ProduitenAjout != null &&
                main.ProduitenAjout.UneRecette != null)
            {
                main.ProduitenAjout.UneRecette.NomRecette = ProduitNomText.Text;
                main.ProduitenAjout.UneRecette.DescriptionRecette = recetteText.Text;

                var chargeAllerg = this.DataContext as ChargeAllergenes;
                if (chargeAllerg != null)
                {
                    var selectionnes = chargeAllerg.LesAllergenes
                        .Where(a => a.EstSelectionne)
                        .ToList();
                }
                
            }
        }
    }
}