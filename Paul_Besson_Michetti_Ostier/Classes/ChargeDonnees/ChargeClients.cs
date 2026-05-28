using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Paul_Besson_Michetti_Ostier.Classes.ChargeDonnees
{
    public class ChargeClients
    {
        private ObservableCollection<Client> clients;

        public ChargeClients()
        {
            
            try
            {
                this.Clients = new ObservableCollection<Client>(new Client().FindAll());        
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de charger les données. Voir votre admin.", ex);
                //    ErrorMessage = "Impossible de charger les données. Voir votre admin.";
            }
        }
        public ObservableCollection<Client> Clients
        {
            get
            {
                return this.clients;
            }

            set
            {
                this.clients = value;
            }
        }
    }
}
