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
    public class Commande : ICrud<Commande>
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
        private Client unClient;
        private int idClient;
        private CategorieEvenement categorieEvenement;
        private int idCategorieEvenement;

        public Commande(int idCommande, CategorieEvenement categorieEvenement, Client unClient, DateOnly dateCreation, DateOnly dateRetrait, decimal accompte, bool estPrete, bool estRecuperee, decimal total, DateOnly dateEvenement, int nbPersonne)
        {
            this.IdCommande = idCommande;
            this.CategorieEvenement = categorieEvenement;
            this.UnClient = unClient;
            this.DateCreation = dateCreation;
            this.DateRetrait = dateRetrait;
            this.Accompte = accompte;
            this.EstPrete = estPrete;
            this.EstRecuperee = estRecuperee;
            this.Total = total;
            this.DateEvenement = dateEvenement;
            this.NbPersonne = nbPersonne;
        }

        public Commande(int idCommande, int idCategorieEvenement, int idClient, DateOnly dateCreation, DateOnly dateRetrait, decimal accompte, bool estPrete, bool estRecuperee, decimal total, DateOnly dateEvenement, int nbPersonne)
        {
            this.IdCommande = idCommande;
            this.IdCategorieEvenement = idCategorieEvenement;
            this.IdClient = idClient;
            this.DateCreation = dateCreation;
            this.DateRetrait = dateRetrait;
            this.Accompte = accompte;
            this.EstPrete = estPrete;
            this.EstRecuperee = estRecuperee;
            this.Total = total;
            this.DateEvenement = dateEvenement;
            this.NbPersonne = nbPersonne;
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

        public int IdCategorieEvenement
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

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into commande (categorie_evenement_id,client_id,date_creation,date_retrait,acompte,est_prete,est_recuperee,total,date_evenement,nb_personne) values (@categorie_evenement_id,@client_id,@date_creation,@date_retrait,@acompte,@est_prete,@est_recuperee,@total,@date_evenement,@nb_personne) RETURNING commande_id"))
            {
                cmdInsert.Parameters.AddWithValue("categorie_evenement_id", this.IdCategorieEvenement);
                cmdInsert.Parameters.AddWithValue("client_id", this.IdClient);
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
            using (var cmdSelect = new NpgsqlCommand("select * from  commande  where commande_id =@idcommande;"))
            {
                cmdSelect.Parameters.AddWithValue("idcommande", this.IdCommande);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.CategorieEvenement = (CategorieEvenement)dt.Rows[0]["categorie_evenement_id"];
                this.UnClient.IdClient = (int)dt.Rows[0]["client_id"];
                this.DateCreation = (DateOnly)dt.Rows[0]["date_creation"];
                this.DateRetrait = (DateOnly)dt.Rows[0]["date_retrait"];
                this.Accompte = (decimal)dt.Rows[0]["acompte"];
                this.EstPrete = (bool)dt.Rows[0]["est_prete"];
                this.EstRecuperee = (bool)dt.Rows[0]["est_recuperee"];
                this.Total = (decimal)dt.Rows[0]["total"];
                this.DateEvenement = (DateOnly)dt.Rows[0]["date_evenement"];
                this.NbPersonne = (int)dt.Rows[0]["nb_personne"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update commande set categorie_evenement_id = @categorie_evenement_id, client_id = @client_id, date_creation = @date_creation, date_retrait = @dateretrait, acompte = @acompte, est_prete = @est_prete, est_recuperee = @est_recuperee, total = @total, date_evenement = @date_evenement, nb_personne = @nb_personne where commande_id = @commande_id;"))
            {
                cmdUpdate.Parameters.AddWithValue("categorie_evenement_id", this.IdCategorieEvenement);
                cmdUpdate.Parameters.AddWithValue("client_id", this.IdClient);
                cmdUpdate.Parameters.AddWithValue("date_creation", this.DateCreation);
                cmdUpdate.Parameters.AddWithValue("date_retrait", this.DateRetrait);
                cmdUpdate.Parameters.AddWithValue("acompte", this.Accompte);
                cmdUpdate.Parameters.AddWithValue("est_prete", this.EstPrete);
                cmdUpdate.Parameters.AddWithValue("est_recuperee", this.EstRecuperee);
                cmdUpdate.Parameters.AddWithValue("total", this.Total);
                cmdUpdate.Parameters.AddWithValue("date_evenement", this.DateEvenement);
                cmdUpdate.Parameters.AddWithValue("nb_personne", this.NbPersonne);
                cmdUpdate.Parameters.AddWithValue("commande_id", this.IdCommande);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from commande ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande((int)dt.Rows[0]["commande_id"],
                                                  (int)dt.Rows[0]["categorie_evenement_id"],
                                                  (int)dt.Rows[0]["client_id"],
                                                  (DateOnly)dt.Rows[0]["date_creation"],
                                                  (DateOnly)dt.Rows[0]["date_retrait"],
                                                  (decimal)dt.Rows[0]["acompte"],
                                                  (bool)dt.Rows[0]["est_prete"],
                                                  (bool)dt.Rows[0]["est_recuperee"],
                                                  (decimal)dt.Rows[0]["total"],
                                                  (DateOnly)dt.Rows[0]["date_evenement"],
                                                  (int)dt.Rows[0]["nb_personne"]));
            }
            return lesCommandes;
        }

        public List<Commande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from commande where commande_id =@commande_id;"))
            {
                cmdUpdate.Parameters.AddWithValue("commande_id", this.IdCommande);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Commande Commande &&
                   this.IdCommande == Commande.IdCommande;
        }
    }
}
