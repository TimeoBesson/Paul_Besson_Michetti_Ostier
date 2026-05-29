using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Employe : ICrud<Employe>
    {
        private int idEmploye;
        private string login;
        private string password;
        private string role;

        public Employe() 
        { 
        }

        public Employe(int idEmploye, string login, string password, string role)
        {
            this.IdEmploye = idEmploye;
            this.Login = login;
            this.Password = password;
            this.Role = role;
        }

        public int IdEmploye
        {
            get
            { 
                return this.idEmploye; 
            }
            set
            { 
                this.idEmploye = value; 
            }
        }

        public string Login
        {
            get
            { 
                return this.login;
            }
            set
            { 
                this.login = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Role
        {
            get
            {
                return this.role;
            }

            set
            {
                this.role = value;
            }
        }

        /// <summary>
        /// Vérifie si le login et le mot de passe correspondent à un employe dans la base de données
        /// </summary>
        public static bool Connexion(string login, string password)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM employe WHERE login = @login AND password = @password"))
                {
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("password", password);
                    
                    string result = DataAccess.ExecuteSelectOneValue(cmd);
                    return int.Parse(result) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L'identifiant ou le mot de passe est incorrect", "Employé inconnu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into employe (login, password, role) values (@login ,@password, @role)"))
            {
                cmdInsert.Parameters.AddWithValue("login", this.Login);
                cmdInsert.Parameters.AddWithValue("password", this.Password);
                cmdInsert.Parameters.AddWithValue("role", this.Role);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdEmploye = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from employe where employe_id =@idemploye;"))
            {
                cmdSelect.Parameters.AddWithValue("idemploye", this.IdEmploye);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.IdEmploye = (int)dt.Rows[0]["employe_id"];
                this.Login = (string)dt.Rows[0]["login"];
                this.Password = (string)dt.Rows[0]["password"];
                this.Role = (string)dt.Rows[0]["role"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update employe set employe_id = @idemploye, login = @login, password = @password, role = @role where employe_id = @idemploye;"))
            {
                cmdUpdate.Parameters.AddWithValue("idemploye", this.IdEmploye);
                cmdUpdate.Parameters.AddWithValue("login", this.Login);
                cmdUpdate.Parameters.AddWithValue("password", this.Password);
                cmdUpdate.Parameters.AddWithValue("role", this.Role);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public List<Employe> FindAll()
        {
            List<Employe> lesEmployes = new List<Employe>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from employe;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesEmployes.Add(new Employe((int)dr["employe_id"],
                                                (string)dr["login"],
                                                (string)dr["password"],
                                                (string)dr["role"]));
            }
            return lesEmployes;
        }

        public List<Employe> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from employe where employe_id = @idemploye;"))
            {
                cmdUpdate.Parameters.AddWithValue("idemploye", this.IdEmploye);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Employe Employe &&
                   this.IdEmploye == Employe.IdEmploye;
        }
    }
}
