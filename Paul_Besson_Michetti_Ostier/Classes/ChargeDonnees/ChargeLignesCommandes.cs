using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeLignesCommandes
    {
        private ObservableCollection<LigneCommande> lesLignesCommandes;

        public ChargeLignesCommandes()
        {
            try
            {
                this.LesLignesCommandes = new ObservableCollection<LigneCommande>(new LigneCommande().FindAll());
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }

        public ObservableCollection<LigneCommande> LesLignesCommandes
        {
            get
            {
                return this.lesLignesCommandes;
            }

            set
            {
                this.lesLignesCommandes = value;
            }
        }
    }
}
