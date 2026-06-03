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
        private ObservableCollection<RecetteAllergene> lesRecettesAllergenes;

        public ChargeRecettes()
        {
            try
            {
                this.LesRecettesAllergenes = new ObservableCollection<RecetteAllergene>(new RecetteAllergene().FindAll());

                //ChargeRecettes chargeRecettes = new ChargeRecettes();
                //foreach (RecetteAllergene p in this.LesRecettesAllergenes)
                //{
                //    p.UneRecette = chargeRecettes.LesRecettes.FirstOrDefault(r => r.IdRecette == p.IdRecette);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
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

        public ObservableCollection<RecetteAllergene> LesRecettesAllergenes
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
