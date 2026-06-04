using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeCategoriesRecettes
    {
        private ObservableCollection<CategorieRecette> categorieRecettes;
        public ChargeCategoriesRecettes()
        {
            try
            {
                this.CategorieRecettes = new ObservableCollection<CategorieRecette>(new CategorieRecette().FindAll());
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }
        public ObservableCollection<CategorieRecette> CategorieRecettes
        {
            get
            {
                return this.categorieRecettes;
            }

            set
            {
                this.categorieRecettes = value;
            }
        }
    }
}
