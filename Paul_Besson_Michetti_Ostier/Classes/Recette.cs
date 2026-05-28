using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public enum Allergene
    {
      
    }
    public enum CategorieRecette
    {

    }
    public class Recette : ICrud<Recette>
    { 
        private int idRecette;
        private string nomRecette;
        private string descriptionRecette;
        private int idCategorieRecette;
        private CategorieRecette categorieRecette;

        public Recette(int idRecette, string nomRecette, string descriptionRecette,  CategorieRecette categorieRecette)
        {
            this.IdRecette = idRecette;
            this.NomRecette = nomRecette;
            this.DescriptionRecette = descriptionRecette;
            
            this.CategorieRecette = categorieRecette;
        }

        public Recette(int idRecette, string nomRecette, string descriptionRecette, int idCategorieRecette)
        {
            this.IdRecette = idRecette;
            this.NomRecette = nomRecette;
            this.DescriptionRecette = descriptionRecette;
            this.idCategorieRecette = idCategorieRecette;
        }

        public Recette()
        {
            this.nomRecette = "";
            this.descriptionRecette = "";
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

        public string NomRecette
        {
            get
            {
                return this.nomRecette;
            }

            set
            {
                this.nomRecette = value;
            }
        }

        public string DescriptionRecette
        {
            get
            {
                return this.descriptionRecette;
            }

            set
            {
                this.descriptionRecette = value;
            }
        }

        

        public CategorieRecette CategorieRecette
        {
            get
            {
                return this.categorieRecette;
            }

            set
            {
                this.categorieRecette = value;
            }
        }

        public int IdCategorieRecette
        {
            get
            {
                return this.idCategorieRecette;
            }

            set
            {
                this.idCategorieRecette = value;
            }
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into recette (categorie_id, recette_nom,recette_description) values (@idcategorierecette,@nomrecette,@descriptionrecette)"))
            {
                
            }
            this.IdRecette = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from recette where recette_id =@idrecette;"))
            {
                cmdSelect.Parameters.AddWithValue("idrecette", this.IdRecette);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdRecette = (int)dt.Rows[0]["recette_id"];
                this.NomRecette = (string)dt.Rows[0]["recette_nom"];
                this.DescriptionRecette = (string)dt.Rows[0]["recette_description"];
                this.IdCategorieRecette = (int)dt.Rows[0]["categorie_id"];
                
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update recette set categorie_id = @idcategorierecette, recette_nom = @nomrecette,recette_description = @desciptionrecette where recette_id = @idrecette;"))
            {
                cmdUpdate.Parameters.AddWithValue("idrecette", this.IdRecette);
                cmdUpdate.Parameters.AddWithValue("nomrecette", this.NomRecette);
                cmdUpdate.Parameters.AddWithValue("descriptionrecette", this.DescriptionRecette);
                cmdUpdate.Parameters.AddWithValue("idcategorierecette", this.IdCategorieRecette);
                
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<Recette> FindAll()
        {
            List<Recette> lesRecettes = new List<Recette>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from recette ;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesRecettes.Add(new Recette((int)dr["recette_id"],
                                                (string)dr["recette_nom"],
                                                (string)dr["recette_description"],
                                                (int)dr["categorie_id"]));
            }
            return lesRecettes;
        }

        public List<Recette> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from recette where recette_id = @idrecette;"))
            {
                cmdUpdate.Parameters.AddWithValue("idrecette", this.IdRecette);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Recette Recette &&
                   this.IdRecette == Recette.IdRecette;
        }
    }
}
