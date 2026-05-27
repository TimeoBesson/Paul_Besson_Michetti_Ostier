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
        private int idProduit;
        private int idCommande;

        public Contient(int quantite, int estDecoupe, int idProduit, int idCommande)
        {
            this.Quantite = quantite;
            this.EstDecoupe = estDecoupe;
            this.IdProduit = idProduit;
            this.IdCommande = idCommande;
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

        public int IdProduit
        {
            get
            {
                return this.idProduit;
            }

            set
            {
                this.idProduit = value;
            }
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
    }
}
