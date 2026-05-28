using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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
        private List<LigneCommande> produits;
        private Client unClient;
        private CategorieEvenement categorieEvenement;

        public Commande(int idCommande, DateOnly dateCreation, DateOnly dateRetrait, decimal accompte, bool estPrete, bool estRecuperee, decimal total, DateOnly dateEvenement, int nbPersonne, List<LigneCommande> produits, Client unClient, CategorieEvenement categorieEvenement)
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
            this.UnClient = unClient;
            this.CategorieEvenement = categorieEvenement;
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

        

        public CategorieEvenement CategorieEvenement
        {
            get
            {
                return this.categorieEvenement;
            }

            set
            {
                this.categorieEvenement = value;
            }
        }

        public Client UnClient
        {
            get
            {
                return this.unClient;
            }

            set
            {
                this.unClient = value;
            }
        }

        public List<LigneCommande> Produits
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

        public void ValiderCommande()
        {
        }
        public void ModifierCommande()
        {
        }
        public void FinaliserCommande()
        {
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into commandes (categorie_evenement_id,client_id,date_creation,date_retrait,acompte,est_prete,est_recuperee,total,date_evenement,nb_personne) values (@categorie_evenement_id,@client_id,@date_creation,@date_retrait,@acompte,@est_prete,@est_recuperee,@total,@date_evenement,@nb_personne) RETURNING commande_id"))
            {
                cmdInsert.Parameters.AddWithValue("categorie_evenement_id", this.CategorieEvenement);
                cmdInsert.Parameters.AddWithValue("client_id", this.UnClient.IdClient);
                cmdInsert.Parameters.AddWithValue("date_creation", this.DateCreation);
                cmdInsert.Parameters.AddWithValue("date_retrait", this.DateRetrait);
                cmdInsert.Parameters.AddWithValue("acompte", this.Accompte);
                cmdInsert.Parameters.AddWithValue("est_prete", this.EstPrete);
                cmdInsert.Parameters.AddWithValue("est_recuperee", this.EstRecuperee);
                cmdInsert.Parameters.AddWithValue("total", this.Total);
                cmdInsert.Parameters.AddWithValue("date_evenement", this.DateEvenement);
                cmdInsert.Parameters.AddWithValue("nb_personne", this.NbPersonne);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdCommande = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from  commandes  where idclient =@id;"))
            {
                cmdSelect.Parameters.AddWithValue("id", this.IdCommande);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.CategorieEvenement = (CategorieEvenement)dt.Rows[0]["nom"];
                this.UnClient.IdClient = (String)dt.Rows[0]["maitre"];
                this.DateCreation = (double)dt.Rows[0]["poids"];
                this.DateRetrait = (double)dt.Rows[0]["poids"];
                this.Accompte = (double)dt.Rows[0]["poids"];
                this.EstPrete = (double)dt.Rows[0]["poids"];
                this.EstRecuperee = (double)dt.Rows[0]["poids"];
                this.Total = (double)dt.Rows[0]["poids"];
                this.DateEvenement = (double)dt.Rows[0]["poids"];
                this.NbPersonne = (double)dt.Rows[0]["poids"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update commandes set nom =@nom ,  maitre = @maitre,  poids = @poids  where idclient =@id;"))
            {
                cmdUpdate.Parameters.AddWithValue("nom", this.Nom);
                cmdUpdate.Parameters.AddWithValue("maitre", this.Maitre);
                cmdUpdate.Parameters.AddWithValue("poids", this.Poids);
                cmdUpdate.Parameters.AddWithValue("id", this.Id);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<Client> FindAll()
        {
            List<Client> lesCommandes = new List<Client>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from commandes ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Client((int)dr["idclient"], (String)dr["nom"],
                    (String)dr["maitre"], (double)dr["poids"]));
            }
            return lesCommandes;
        }

        public List<Client> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from commandes  where idclient =@id;"))
            {
                cmdUpdate.Parameters.AddWithValue("id", this.Id);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }
    }
}
