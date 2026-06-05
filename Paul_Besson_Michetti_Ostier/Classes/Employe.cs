using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Employe : ICrud<Employe>
    {
        private string login;
        private string password;
        private string role;

        public Employe() 
        { 
        }

        public Employe(string login, string password, string role)
        {
            this.Login = login;
            this.Password = password;
            this.Role = role;
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
        public static bool VerificationConnexion(string login, string password)
        {
            try
            {
                DataAccess.Connexion(login, password);
                List<Employe> lesEmployes = new Employe().FindAll();
                Employe employe = lesEmployes.FirstOrDefault(e => e.Login == login && e.Password == password);
                return employe != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("La connexion a échouée", "Connexion échouée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static string RoleEmploye(string login)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("select role from employe where login = @login"))
                {
                    cmd.Parameters.AddWithValue("login", login);
                    string result = DataAccess.ExecuteSelectOneValue(cmd);
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L'employé n'a pas de role attribué", "Employé inconnu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return "null";
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
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from employe where login =@login;"))
            {
                cmdSelect.Parameters.AddWithValue("login", this.Login);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.Login = (string)dt.Rows[0]["login"];
                this.Password = (string)dt.Rows[0]["password"];
                this.Role = (string)dt.Rows[0]["role"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update employe set login = @login, password = @password, role = @role where login = @login;"))
            {
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
                    lesEmployes.Add(new Employe((string)dr["login"],
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
            using (var cmdUpdate = new NpgsqlCommand("delete from employe where login = @login;"))
            {
                cmdUpdate.Parameters.AddWithValue("login", this.Login);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Employe Employe &&
                   this.Login == Employe.Login;
        }
    }
}
