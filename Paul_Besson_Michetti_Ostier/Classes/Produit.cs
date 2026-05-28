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
        private Recette uneRecette;

        public Produit(int idProduit, int idRecette, bool estIndisponible, int nbParts, decimal prix)
        {
            this.IdProduit = idProduit;
            this.IdRecette = idRecette;
            this.EstIndisponible = estIndisponible;
            this.NbParts = nbParts;
            this.Prix = prix;
        }

        public Produit(int idProduit, Recette uneRecette, bool estIndisponible, int nbParts, decimal prix)
        {
            this.IdProduit = idProduit;
            this.UneRecette = uneRecette;
            this.EstIndisponible = estIndisponible;
            this.NbParts = nbParts;
            this.Prix = prix;
        }

        public Produit()
        {
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

        public Recette UneRecette
        {
            get
            {
                return this.uneRecette;
            }

            set
            {
                this.uneRecette = value;
            }
        }

        public int IdRecette
        {
            get
            {
                return this.idRecette;
            }

            set
            {
                this.idRecette = value;
            }
        }

        public void AjouterProduit()
        {
            
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into produit (recette_id,est_indisponible,nb_parts,prix) values (@recette_id,@est_indisponible,@nb_parts,@prix) RETURNING produit_id"))
            {
                cmdInsert.Parameters.AddWithValue("recette_id", this.IdRecette);
                cmdInsert.Parameters.AddWithValue("est_indisponible", this.EstIndisponible);
                cmdInsert.Parameters.AddWithValue("nb_parts", this.NbParts);
                cmdInsert.Parameters.AddWithValue("prix", this.Prix);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdProduit = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from produit where produit_id = @idproduit;"))
            {
                cmdSelect.Parameters.AddWithValue("idproduit", this.IdProduit);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdRecette = (int)dt.Rows[0]["recette_id"];
                this.EstIndisponible = (bool)dt.Rows[0]["est_indisponible"];
                this.NbParts = (int)dt.Rows[0]["nb_parts"];
                this.Prix = (decimal)dt.Rows[0]["prix"];
            }
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

        public List<Produit> FindAll()
        {
            List<Produit> lesProduits = new List<Produit>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from produit;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesProduits.Add(new Produit((int)dt.Rows[0]["produit_id"],
                                                (int)dt.Rows[0]["recette_id"],
                                                (bool)dt.Rows[0]["est_indisponible"],
                                                (int)dt.Rows[0]["nb_parts"],
                                                (decimal)dt.Rows[0]["prix"]));
            }
            return lesProduits;
        }

        public List<Produit> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from produit where produit_id =@idproduit;"))
            {
                cmdUpdate.Parameters.AddWithValue("idproduit", this.IdProduit);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Produit Produit &&
                   this.IdProduit == Produit.IdProduit;
        }

        public void ModifierProduit()
        {
        }

        public void RendreProduitIndisponible()
        {
        }

    }
}

