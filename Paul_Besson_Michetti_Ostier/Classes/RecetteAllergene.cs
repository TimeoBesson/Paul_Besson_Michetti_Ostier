using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    internal class RecetteAllergene
    {
        private Recette uneRecette;
        private int idRecette;
        private Allergene unAllergene;
        private int idAllergene;

        public RecetteAllergene(int idRecette, int idAllergene)
        {
            this.IdRecette = idRecette;
            this.UneRecette = new Recette();
            this.UneRecette.IdRecette = idRecette;
            this.UneRecette.Read();
            this.IdAllergene = idAllergene;
            this.UnAllergene = new Allergene();
            this.UnAllergene.IdAllergene = idAllergene;
            this.UnAllergene.Read();
        }

        public RecetteAllergene(Recette uneRecette, Allergene unAllergene)
        {
            this.uneRecette = uneRecette;
            this.unAllergene = unAllergene;
        }

        public RecetteAllergene()
        {
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

        public int IdAllergene
        {
            get
            {
                return this.idAllergene;
            }

            set
            {
                this.idAllergene = value;
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

        public Allergene UnAllergene
        {
            get
            {
                return this.unAllergene;
            }

            set
            {
                this.unAllergene = value;
            }
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into recette_allergene (allergene_id, recette_id) values (@idallergene, @idrecette)"))
            {
                cmdInsert.Parameters.AddWithValue("idallergene", this.IdAllergene);
                cmdInsert.Parameters.AddWithValue("nomallergene", this.IdRecette);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdAllergene = nb;
            this.IdRecette += nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from recette_allergene where allergene_id = @idallergene and recette_id = @idrecette;"))
            {
                cmdSelect.Parameters.AddWithValue("idallergene", this.IdAllergene);
                cmdSelect.Parameters.AddWithValue("idrecette", this.IdRecette);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdAllergene = (int)dt.Rows[0]["allergene_id"];
                this.IdRecette = (int)dt.Rows[0]["recette_id"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update recette_allergene set allergene_id = @idallergene, allergene_nom = @nomallergene where allergene_id = @idallergene and recette_id = @idrecette;"))
            {
                cmdUpdate.Parameters.AddWithValue("idallergene", this.IdAllergene);
                cmdUpdate.Parameters.AddWithValue("idrecette", this.IdRecette);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<RecetteAllergene> FindAll()
        {
            List<RecetteAllergene> lesRecettesAllergenes = new List<RecetteAllergene>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from recette_allergene;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesRecettesAllergenes.Add(new RecetteAllergene((int)dr["recette_id"],
                                                                   (int)dr["allergene_id"]));
            }
            return lesRecettesAllergenes;
        }

        public List<RecetteAllergene> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from recette_allergene where allergene_id = @idallergene and recette_id = @idrecette;"))
            {
                cmdUpdate.Parameters.AddWithValue("idallergene", this.IdAllergene);
                cmdUpdate.Parameters.AddWithValue("idrecette", this.IdRecette);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is RecetteAllergene RecetteAllergene &&
                   this.IdAllergene == RecetteAllergene.IdAllergene &&
                   this.IdRecette == RecetteAllergene.IdRecette; ;
        }
    }
}
