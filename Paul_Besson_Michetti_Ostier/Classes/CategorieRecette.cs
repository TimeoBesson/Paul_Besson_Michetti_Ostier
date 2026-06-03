using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class CategorieRecette : ICrud<CategorieRecette>
    {
        private int idCategorie;
        private string nomCategorie;

        public CategorieRecette(int idCategorie, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.NomCategorie = nomCategorie;
        }
        public CategorieRecette() { }

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
            using (var cmdInsert = new NpgsqlCommand("insert into categorie (categorie_id, categorie_nom) values (@idcategorie, @nomcategorie)"))
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
            using (var cmdSelect = new NpgsqlCommand("select * from categorie where categorie_id = @idcategorie;"))
            {
                cmdSelect.Parameters.AddWithValue("categorie_id", this.IdCategorie);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdCategorie = (int)dt.Rows[0]["categorie_id"];
                this.NomCategorie = (string)dt.Rows[0]["categorie_nom"];
            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update categorie set categorie_nom = @nomcategorie where categorie_id = @idcategorie;"))
            {
                cmdUpdate.Parameters.AddWithValue("idcategorie", this.IdCategorie);
                cmdUpdate.Parameters.AddWithValue("nomcategorie", this.NomCategorie);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from categorie where categorie_id = @idcategorie;"))
            {
                cmdUpdate.Parameters.AddWithValue("idcategorie", this.IdCategorie);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<CategorieRecette> FindAll()
        {
            List<CategorieRecette> lesCategories = new List<CategorieRecette>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCategories.Add(new CategorieRecette((int)dr["categorie_id"],
                                                (string)dr["categorie_nom"]));
            }
            return lesCategories;
        }

        public List<CategorieRecette> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
