using Paul_Besson_Michetti_Ostier.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeProduits : INotifyPropertyChanged
    {
        public List<Produit> TousLesProduits { get; set; }

        private ObservableCollection<Produit> lesProduits;
        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return lesProduits;
            }
            set
            {
                lesProduits = value;
                OnPropertyChanged(nameof(LesProduits));
            }
        }

        public ChargeProduits()
        {
            try
            {
                TousLesProduits = new Produit().FindAll();
                LesProduits = new ObservableCollection<Produit>(TousLesProduits);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

