using Paul_Besson_Michetti_Ostier.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeProduits
    {
        private ObservableCollection<Produit> lesProduits;

        public ChargeProduits()
        {
            try
            {
                this.LesProduits = new ObservableCollection<Produit>(new Produit().FindAll());

                //ChargeRecettes chargeRecettes = new ChargeRecettes();
                //foreach (Produit p in this.LesProduits)
                //{
                //    p.UneRecette = chargeRecettes.LesRecettes.FirstOrDefault(r => r.IdRecette == p.IdRecette);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }

        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return this.lesProduits;
            }

            set
            {
                this.lesProduits = value;
            }
        }
    }
}

