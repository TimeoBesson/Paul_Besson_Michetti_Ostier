using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Produit : ICrud<Produit>
    {
        private int idProduit;
        private int idRecette;
        private bool estIndisponible;
        private int nbParts;
        private decimal prix;
        private Recette recette;

        public Produit(int idProduit, int idRecette, bool estIndisponible, int nbParts, decimal prix)
        {
            this.IdProduit = idProduit;
            this.IdRecette = idRecette;
            this.EstIndisponible = estIndisponible;
            this.NbParts = nbParts;
            this.Prix = prix;
        }

        public Produit(int idProduit, Recette recette, bool estIndisponible, int nbParts, decimal prix)
        {
            this.IdProduit = idProduit;
            this.Recette = recette;
            this.EstIndisponible = estIndisponible;
            this.NbParts = nbParts;
            this.Prix = prix;
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

        public int IdRecette
        {
            get
            {
                return this.IdRecette;
            }

            set
            {
                this.IdRecette = value;
            }
        }

        public void AjouterProduit()
        {
            
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into produit (categorie_evenement_id,client_id,date_creation,date_retrait,acompte,est_prete,est_recuperee,total,date_evenement,nb_personne) values (@categorie_evenement_id,@client_id,@date_creation,@date_retrait,@acompte,@est_prete,@est_recuperee,@total,@date_evenement,@nb_personne) RETURNING commande_id"))
            {
                cmdInsert.Parameters.AddWithValue("EST_INDISPONIBLE", this.EstIndisponible);
                cmdInsert.Parameters.AddWithValue("RECETTE_ID", this.IdRecette);
                cmdInsert.Parameters.AddWithValue("NB_PARTS", this.NbParts);
                cmdInsert.Parameters.AddWithValue("PRIX", this.Prix);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdProduit = nb;
            return nb;
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public List<Produit> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Produit> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void ModifierProduit()
        {
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void RendreProduitIndisponible()
        {
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}

