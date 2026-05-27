using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Produit
    {
        private int idProduit;
        private bool estIndisponible;
        private int nbParts;
        private decimal prix;
        private Recette recette;

        public Produit(int idProduit, bool estIndisponible, int nbParts, decimal prix,Recette recette)
        {
            this.IdProduit = idProduit;
            this.EstIndisponible = estIndisponible;
            this.NbParts = nbParts;
            this.Prix = prix;
            this.Recette = recette;
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

        public bool EstIndisponible
        {
            get
            {
                return this.estIndisponible;
            }

            set
            {
                this.estIndisponible = value;
            }
        }

        public int NbParts
        {
            get
            {
                return this.nbParts;
            }

            set
            {
                this.nbParts = value;
            }
        }

        public decimal Prix
        {
            get
            {
                return this.prix;
            }

            set
            {
                this.prix = value;
            }
        }

        public Recette Recette
        {
            get
            {
                return this.recette;
            }

            set
            {
                this.recette = value;
            }
        }

        public void AjouterProduit()
        {
            
        }
        public void ModifierProduit()
        {
        }
        public void RendreProduitIndisponible()
        {
        }

    }
}

