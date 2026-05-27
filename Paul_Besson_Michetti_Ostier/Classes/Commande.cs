using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public enum CategorieEvenement
    {
        
    }
    public class Commande
    {
        private int idCommande;
        private DateOnly dateCreation;
        private DateOnly dateRetrait;
        private decimal accompte;
        private bool estPrete;
        private bool estRecuperee;
        private decimal total;
        private DateOnly dateEvenement;
        private int nbPersonne;
        private List<Contient> produits;
        private int idClient;
        private CategorieEvenement idCategorieEvenement;

        public Commande(int idCommande, DateOnly dateCreation, DateOnly dateRetrait, decimal accompte, bool estPrete, bool estRecuperee, decimal total, DateOnly dateEvenement, int nbPersonne, List<Contient> produits, int idClient, CategorieEvenement idCategorieEvenement)
        {
            this.IdCommande = idCommande;
            this.DateCreation = dateCreation;
            this.DateRetrait = dateRetrait;
            this.Accompte = accompte;
            this.EstPrete = estPrete;
            this.EstRecuperee = estRecuperee;
            this.Total = total;
            this.DateEvenement = dateEvenement;
            this.NbPersonne = nbPersonne;
            this.Produits = produits;
            this.IdClient = idClient;
            this.IdCategorieEvenement = idCategorieEvenement;
        }

        public int IdCommande
        {
            get
            {
                return this.idCommande;
            }

            set
            {
                this.idCommande = value;
            }
        }

        public DateOnly DateCreation
        {
            get
            {
                return this.dateCreation;
            }

            set
            {
                this.dateCreation = value;
            }
        }

        public DateOnly DateRetrait
        {
            get
            {
                return this.dateRetrait;
            }

            set
            {
                this.dateRetrait = value;
            }
        }

        public decimal Accompte
        {
            get
            {
                return this.accompte;
            }

            set
            {
                this.accompte = value;
            }
        }

        public bool EstPrete
        {
            get
            {
                return this.estPrete;
            }

            set
            {
                this.estPrete = value;
            }
        }

        public bool EstRecuperee
        {
            get
            {
                return this.estRecuperee;
            }

            set
            {
                this.estRecuperee = value;
            }
        }

        public decimal Total
        {
            get
            {
                return this.total;
            }

            set
            {
                this.total = value;
            }
        }

        public DateOnly DateEvenement
        {
            get
            {
                return this.dateEvenement;
            }

            set
            {
                this.dateEvenement = value;
            }
        }

        public int NbPersonne
        {
            get
            {
                return this.nbPersonne;
            }

            set
            {
                this.nbPersonne = value;
            }
        }

        public List<Contient> Produits
        {
            get
            {
                return this.produits;
            }

            set
            {
                this.produits = value;
            }
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

        public CategorieEvenement IdCategorieEvenement
        {
            get
            {
                return this.idCategorieEvenement;
            }

            set
            {
                this.idCategorieEvenement = value;
            }
        }

        public void ValiderCommande()
        {
        }
        public void ModifierCommande()
        {
        }
        public void FinaliserCommande()
        {
        }
    }
}
