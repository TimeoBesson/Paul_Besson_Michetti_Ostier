using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    internal class Allergene : ICrud<Allergene>
    {
        private int idAllergene;
        private string nomAllergene;

        public Allergene(int idAllergene, string nomAllergene)
        {
            this.IdAllergene = idAllergene;
            this.NomAllergene = nomAllergene;
        }

        public Allergene()
        {
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

        public string NomAllergene
        {
            get
            {
                return this.nomAllergene;
            }

            set
            {
                this.nomAllergene = value;
            }
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into allergene (allergene_id, allergene_nom) values (@idallergene, @nomallergene)"))
            {
                cmdInsert.Parameters.AddWithValue("idallergene", this.IdAllergene);
                cmdInsert.Parameters.AddWithValue("nomallergene", this.NomAllergene);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdAllergene = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from allergene where allergene_id = @idallergene;"))
            {
                cmdSelect.Parameters.AddWithValue("idallergene", this.IdAllergene);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdAllergene = (int)dt.Rows[0]["allergene_id"];
                this.NomAllergene = (string)dt.Rows[0]["allergene_nom"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update allergene set allergene_nom = @nom_allergene where allergene_id = @idallergene;"))
            {
                cmdUpdate.Parameters.AddWithValue("idallergene", this.IdAllergene);
                cmdUpdate.Parameters.AddWithValue("nomallergene", this.NomAllergene);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<Allergene> FindAll()
        {
            List<Allergene> lesAllergenes = new List<Allergene>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from allergene;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesAllergenes.Add(new Allergene((int)dr["allergene_id"],
                                                (string)dr["nom_allergene"]));
            }
            return lesAllergenes;
        }

        public List<Allergene> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from allergene where allergene_id = @idallergene;"))
            {
                cmdUpdate.Parameters.AddWithValue("idallergene", this.IdAllergene);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Allergene Allergene &&
                   this.IdAllergene == Allergene.IdAllergene;
        }
    }
}
