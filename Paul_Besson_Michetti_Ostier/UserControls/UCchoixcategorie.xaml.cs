using Paul_Besson_Michetti_Ostier.Classes;
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
    /// Logique d'interaction pour UCchoixcategorie.xaml
    /// </summary>
    public partial class UCchoixcategorie : UserControl
    {
        public UCchoixcategorie()
        {
            InitializeComponent();
            this.DataContext = new CategorieRecette().FindAll();
        }
    }
}
