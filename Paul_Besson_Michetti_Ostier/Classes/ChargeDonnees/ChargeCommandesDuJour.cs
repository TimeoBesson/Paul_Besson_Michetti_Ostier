using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeCommandesDuJour : INotifyPropertyChanged
    {
        private ObservableCollection<Commandes> lesCommandesDuJour;
        private Commandes commandeSelectionnee;

        public ChargeCommandesDuJour()
        {
            try
            {
                this.LesCommandesDuJour = new ObservableCollection<Commandes>(new Commandes().FindAll(true));

                foreach (Commandes cmd in this.LesCommandesDuJour)
                {
                   
                    cmd.LesLignes = new LigneCommande().TrouverParCommande(cmd.IdCommande);
                }
            }
            catch (Exception ex)
            {
                        throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }
        public ObservableCollection<Commandes> LesCommandesDuJour
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

        public Commandes CommandeSelectionnee
        {
            get
            {
                return this.commandeSelectionnee;
            }

            set
            {
                this.commandeSelectionnee = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
