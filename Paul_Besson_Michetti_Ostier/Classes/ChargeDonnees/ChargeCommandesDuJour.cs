using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    internal class ChargeCommandesDuJour
    {
        private ObservableCollection<Commande> lesCommandesDuJour;

        public ChargeCommandesDuJour()
        {
            try
            {
                this.LesCommandesDuJour = new ObservableCollection<Commande>(new Commande().FindAll(true));
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }
        public ObservableCollection<Commande> LesCommandesDuJour
        {
            get
            {
                return this.lesCommandesDuJour;
            }

            set
            {
                this.lesCommandesDuJour = value;
            }
        }
    }
}
