using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

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
            using (var cmdUpdate = new NpgsqlCommand("delete from Produit  where produit_id =@id;"))
            {
                cmdUpdate.Parameters.AddWithValue("id", this.IdProduit);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<Produit> FindAll()
        {
            List<Produit> lesProduits = new List<Produit>();

            return lesProduits;
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
            using (var cmdSelect = new NpgsqlCommand("select * from  Client  where idClient =@id;"))
            {
                cmdSelect.Parameters.AddWithValue("PRODUIT_ID", this.IdProduit);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdRecette = (int)dt.Rows[0]["RECETTE_ID"];
                this.EstIndisponible = (bool)dt.Rows[0]["EST_INDISPONIBLE"];
                this.NbParts = (int)dt.Rows[0]["NB_PARTS"];
                this.Prix = (decimal)dt.Rows[0]["PRIX"];


            }
        }

        public void RendreProduitIndisponible()
        {
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update Produits set recette_id =@idrecette ,  est_indisponible = @estindisponible,  nb_parts = @nbparts, prix= @prix  where idClient =@id;"))
            {
                cmdUpdate.Parameters.AddWithValue("nom", this.IdRecette);
                cmdUpdate.Parameters.AddWithValue("prenom", this.EstIndisponible);
                cmdUpdate.Parameters.AddWithValue("telephone", this.NbParts);
                cmdUpdate.Parameters.AddWithValue("mail", this.Prix);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }
    }
}

