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
    public class ChargeCommandes : INotifyPropertyChanged
    {
        private ObservableCollection<Commandes> lesCommandes;
        private Commandes commandeSelectionnee;

        public ChargeCommandes()
        {
            try
            {
                this.LesCommandes = new ObservableCollection<Commandes>(new Commandes().FindAll());
                foreach (Commandes cmd in this.LesCommandes)
                {

                    cmd.LesLignes = new LigneCommande().TrouverParCommande(cmd.IdCommande);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }

        public ObservableCollection<Commandes> LesCommandes
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
