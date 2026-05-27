using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Client
    {
        private int idClient;
        private string nom;
        private string prenom;
        private string numeroTelephone;
        private string mail;
        private List<Commande> commandes;

        public Client(int idClient, string nom, string prenom, string numeroTelephone, string mail, List<Commande> commandes)
        {
            this.IdClient = idClient;
            this.Nom = nom;
            this.Prenom = prenom;
            this.NumeroTelephone = numeroTelephone;
            this.Mail = mail;
            this.commandes = commandes;
            
        }

        public int IdClient
        {
            get
            {
                return this.idClient;
            }

            set
            {
                this.idClient = value;
            }
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value;
            }
        }

        public string NumeroTelephone
        {
            get
            {
                return this.numeroTelephone;
            }

            set
            {
                this.numeroTelephone = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }

            set
            {
                this.mail = value;
            }
        }

        public List<Commande> Commandes
        {
            get
            {
                return this.commandes;
            }

            set
            {
                this.commandes = value;
            }
        }
    }
}
