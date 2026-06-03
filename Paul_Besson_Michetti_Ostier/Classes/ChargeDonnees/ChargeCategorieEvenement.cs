
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeCategorieEvenement
    {
        private ObservableCollection<CategorieEvenement> lesCategoriesEvenements;

        public ChargeCategorieEvenement()
        {
            try
            {
                this.LesCategoriesEvenements = new ObservableCollection<CategorieEvenement>(new CategorieEvenement().FindAll());

            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }

        public ObservableCollection<CategorieEvenement> LesCategoriesEvenements
        {
            get
            {
                return this.lesCategoriesEvenements;
            }

            set
            {
                this.lesCategoriesEvenements = value;
            }
        }
    }
}
