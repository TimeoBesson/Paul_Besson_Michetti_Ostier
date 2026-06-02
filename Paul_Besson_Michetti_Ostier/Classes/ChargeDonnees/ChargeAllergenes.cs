using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    internal class ChargeAllergenes
    {
        private ObservableCollection<Allergene> lesAllergenes;
        private ObservableCollection<RecetteAllergene> lesRecettesAllergenes;

        public ChargeAllergenes()
        {
            try
            {
                this.LesRecettesAllergenes = new ObservableCollection<RecetteAllergene>(new RecetteAllergene().FindAll());

                // Lier chaque produit à sa recette pour permettre le binding UneRecette.NomRecette
                ChargeAllergenes chargeAllergenes = new ChargeAllergenes();
                foreach (RecetteAllergene p in this.LesRecettesAllergenes)
                {
                    p.UnAllergene = chargeAllergenes.LesAllergenes.FirstOrDefault(r => r.IdAllergene == p.IdAllergene);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }
        public ObservableCollection<Allergene> LesAllergenes
        {
            get
            {
                return this.lesAllergenes;
            }

            set
            {
                this.lesAllergenes = value;
            }
        }

        internal ObservableCollection<RecetteAllergene> LesRecettesAllergenes
        {
            get
            {
                return this.lesRecettesAllergenes;
            }

            set
            {
                this.lesRecettesAllergenes = value;
            }
        }
    }
}
