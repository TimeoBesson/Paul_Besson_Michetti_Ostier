using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeRecettesAllergenes
    {
        private ObservableCollection<RecetteAllergene> lesRecettesAllergenes;
        private ObservableCollection<Recette> lesRecettes;
        private ObservableCollection<Allergene> lesAllergenes;

        public ChargeRecettesAllergenes()
        {
            try
            {
                this.LesRecettesAllergenes = new ObservableCollection<RecetteAllergene>(new RecetteAllergene().FindAll());

                //ChargeRecettes chargeRecettes = new ChargeRecettes();
                //foreach (Allergene p in this.LesAllergenes)
                //{
                //    p. = chargeRecettes.Les.FirstOrDefault(r => r.IdRecette == p.IdRecette);
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
                return this.LesRecettes;
            }

            set
            {
                this.LesRecettes = value;
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
