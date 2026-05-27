using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Contient
    {
        private int quantite;
        private int estDecoupe;
        private Produit unProduit;
        private Commande uneCommande;

        public Contient(int quantite, int estDecoupe, Produit unProduit, Commande uneCommande)
        {
            this.Quantite = quantite;
            this.EstDecoupe = estDecoupe;
            this.UnProduit = unProduit;
            this.UneCommande = uneCommande;
        }

        public int Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                this.quantite = value;
            }
        }

        public int EstDecoupe
        {
            get
            {
                return this.estDecoupe;
            }

            set
            {
                this.estDecoupe = value;
            }
        }

        

        public Produit UnProduit
        {
            get
            {
                return this.unProduit;
            }

            set
            {
                this.unProduit = value;
            }
        }

        public Commande UneCommande
        {
            get
            {
                return this.uneCommande;
            }

            set
            {
                this.uneCommande = value;
            }
        }
    }
}
