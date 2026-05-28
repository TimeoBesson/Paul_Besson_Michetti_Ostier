using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeCommandes
    {
        private ObservableCollection<Commande> lesCommandes;

        public ChargeCommandes()
        {
            try
            {
                this.LesCommandes = new ObservableCollection<Commande>(new Commande().FindAll());
                //foreach (Commande s in this.LesCommandes)
                //{
                //    s.UnClient = LesClients.FirstOrDefault(c => c.IdClient == s.IdClient);


                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
                //    ErrorMessage = "Impossible de charger les données. Voir votre admin.";
            }


        }

        public ObservableCollection<Commande> LesCommandes
        {
            get
            {
                return this.lesCommandes;
            }

            set
            {
                this.lesCommandes = value;
            }
        }
    }
}
