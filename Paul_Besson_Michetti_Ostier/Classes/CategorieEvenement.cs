using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class CategorieEvenement : ICrud<CategorieEvenement>
    {
        private int idCategorie;
        private string nomCategorie;

        public CategorieEvenement(int idCategorie, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.NomCategorie = nomCategorie;
        }
        public CategorieEvenement()
        {
        }

        public int IdCategorie
        {
            get
            {
                return this.idCategorie;
            }

            set
            {
                this.idCategorie = value;
            }
        }

        public string NomCategorie
        {
            get
            {
                return this.nomCategorie;
            }

            set
            {
                this.nomCategorie = value;
            }
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into categorie_evenement (categorie_evenement_id, categorie_evenement_nom) values (@idcategorie, @nomcategorie)"))
            {
                cmdInsert.Parameters.AddWithValue("idcategorie", this.IdCategorie);
                cmdInsert.Parameters.AddWithValue("nomcategorie", this.NomCategorie);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdCategorie = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from categorie_evenement where categorie_evenement_id = @idcategorie;"))
            {
                cmdSelect.Parameters.AddWithValue("idCategorie", this.IdCategorie);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdCategorie = (int)dt.Rows[0]["categorie_evenement_id"];
                this.NomCategorie = (string)dt.Rows[0]["categorie_evenement_nom"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update categorie_evenement set categorie_evenement_nom = @nomcategorie where categorie_evenement_id = @idcategorie;"))
            {
                cmdUpdate.Parameters.AddWithValue("idcategorie", this.IdCategorie);
                cmdUpdate.Parameters.AddWithValue("nomcategorie", this.NomCategorie);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<CategorieEvenement> FindAll()
        {
            List<CategorieEvenement> lesCategories = new List<CategorieEvenement>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie_evenement;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCategories.Add(new CategorieEvenement((int)dr["categorie_evenement_id"],
                                                (string)dr["categorie_evenement_nom"]));
            }
            return lesCategories;
        }



        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from categorie_evenement where categorie_evenement_id = @idcategorie;"))
            {
                cmdUpdate.Parameters.AddWithValue("idcategorie", this.IdCategorie);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<CategorieEvenement> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
