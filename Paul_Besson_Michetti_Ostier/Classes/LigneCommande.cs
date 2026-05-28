using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class LigneCommande : ICrud<LigneCommande>
    {
        private int quantite;
        private bool estDecoupe;
        private Produit unProduit;
        private int idProduit; 
        private Commande uneCommande;
        private int idCommande;

        public LigneCommande(Commande uneCommande, Produit unProduit, int quantite, bool estDecoupe)
        {
            this.UneCommande = uneCommande;
            this.UnProduit = unProduit;
            this.Quantite = quantite;
            this.EstDecoupe = estDecoupe;
        }

        public LigneCommande(int idCommande, int idProduit, int quantite, bool estDecoupe)
        {
            this.IdCommande = idCommande;
            this.IdProduit = idProduit;
            this.Quantite = quantite;
            this.EstDecoupe = estDecoupe;
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

        public bool EstDecoupe
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

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into ligne_commande (commande_id,produit_id,quantite,est_decoupe) values (@commande_id,@produit_id,@quantite,@est_decoupe) RETURNING commande_id"))
            {
                cmdInsert.Parameters.AddWithValue("commande_id", this.IdCommande);
                cmdInsert.Parameters.AddWithValue("produit_id", this.IdProduit);
                cmdInsert.Parameters.AddWithValue("quantite", this.Quantite);
                cmdInsert.Parameters.AddWithValue("est_decoupe", this.EstDecoupe);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from ligne_commande where commande_id = @idcommande and produit_id = @idproduit;"))
            {
                cmdSelect.Parameters.AddWithValue("idcommande", this.IdCommande);
                cmdSelect.Parameters.AddWithValue("idproduit", this.IdProduit);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdCommande = (int)dt.Rows[0]["commande_id"];
                this.IdProduit = (int)dt.Rows[0]["produit_id"];
                this.Quantite = (int)dt.Rows[0]["quantite"];
                this.EstDecoupe = (bool)dt.Rows[0]["est_decoupe"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update ligne_commande set commande_id = @commande_id, produit_id = @produit_id, quantite = @quantite, est_decoupe = @est_decoupe;"))
            {
                cmdUpdate.Parameters.AddWithValue("commande_id", this.IdCommande);
                cmdUpdate.Parameters.AddWithValue("produit_id", this.IdProduit);
                cmdUpdate.Parameters.AddWithValue("quantite", this.Quantite);
                cmdUpdate.Parameters.AddWithValue("est_decoupe", this.EstDecoupe);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<LigneCommande> FindAll()
        {
            List<LigneCommande> lesLignesCommandes = new List<LigneCommande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from ligne_commande;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesLignesCommandes.Add(new LigneCommande((int)dt.Rows[0]["commande_id"],
                                                  (int)dt.Rows[0]["produit_id"],
                                                  (int)dt.Rows[0]["quantite"],
                                                  (bool)dt.Rows[0]["est_decoupe"]));
            }
            return lesLignesCommandes;
        }

        public List<LigneCommande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from ligne_commande where commande_id = @commande_id and produit_id = @produit_id;"))
            {
                cmdUpdate.Parameters.AddWithValue("commande_id", this.IdCommande);
                cmdUpdate.Parameters.AddWithValue("produit_id", this.IdCommande);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }
    }
}
