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
                this.LesAllergenes = new ObservableCollection<Allergene>(new Allergene().FindAll());

                //ChargeRecettesAllergenes chargeRecettesAllergenes = new ChargeRecettesAllergenes();
                //foreach (Allergene p in this.LesAllergenes)
                //{
                //    p.IdAllergene = chargeRecettesAllergenes..FirstOrDefault(r => r.IdAllergene == p.IdAllergene);
                //}
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
