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
