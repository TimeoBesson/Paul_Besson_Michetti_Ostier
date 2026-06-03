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
        private ObservableCollection<Commande> lesCommandesDuJour;
        private Commande commandeSelectionnee;

        public ChargeCommandesDuJour()
        {
            try
            {
                this.LesCommandesDuJour = new ObservableCollection<Commande>(new Commande().FindAll(true));
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }
        public ObservableCollection<Commande> LesCommandesDuJour
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

        public Commande CommandeSelectionnee
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
