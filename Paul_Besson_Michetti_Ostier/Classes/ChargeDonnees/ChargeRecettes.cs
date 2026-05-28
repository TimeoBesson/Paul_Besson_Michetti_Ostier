using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeRecettes
    {
            private ObservableCollection<Recette> lesRecettes;

        public ChargeRecettes()
        {
            try
            {
                this.LesRecettes = new ObservableCollection<Recette>(new Recette().FindAll());
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
        public ObservableCollection<Recette> LesRecettes
        {
            get
            {
                return this.lesRecettes;
            }

            set
            {
                this.lesRecettes = value;
            }
        }
    }
}
