using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public class Client : ICrud<Client>
    {
        private Client unClient;
        private int idClient;
        private string nom;
        private string prenom;
        private string numeroTelephone;
        private string mail;

        public Client(Client unClient, string nom, string prenom, string numeroTelephone, string mail)
        {
            this.UnClient = unClient;
            this.Nom = nom;
            this.Prenom = prenom;
            this.NumeroTelephone = numeroTelephone;
            this.Mail = mail;
        }

        public Client(int idClient, string nom, string prenom, string numeroTelephone, string mail)
        {
            this.IdClient = idClient;
            this.Nom = nom;
            this.Prenom = prenom;
            this.NumeroTelephone = numeroTelephone;
            this.Mail = mail;
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

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value;
            }
        }

        public string NumeroTelephone
        {
            get
            {
                return this.numeroTelephone;
            }

            set
            {
                this.numeroTelephone = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }

            set
            {
                this.mail = value;
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

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into client (nom,prenom,telephone,mail) values (@nom,@prenom,@telephone,@mail) RETURNING client_id"))
            {
                cmdInsert.Parameters.AddWithValue("nom", this.Nom);
                cmdInsert.Parameters.AddWithValue("prenom", this.Prenom);
                cmdInsert.Parameters.AddWithValue("telephone", this.NumeroTelephone);
                cmdInsert.Parameters.AddWithValue("mail", this.Mail);
                nb = DataAccess.ExecuteInsert(cmdInsert);
            }
            this.IdClient = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from  client  where client_id =@idclient;"))
            {
                cmdSelect.Parameters.AddWithValue("idclient", this.IdClient);

                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                this.Nom = (String)dt.Rows[0]["nom"];
                this.Prenom = (String)dt.Rows[0]["prenom"];
                this.NumeroTelephone = (String)dt.Rows[0]["telephone"];
                this.Mail = (String)dt.Rows[0]["mail"];


            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update client set nom = @nom , maitre = @maitre, poids = @poids where client_id =@idclient;"))
            {
                cmdUpdate.Parameters.AddWithValue("nom", this.Nom);
                cmdUpdate.Parameters.AddWithValue("prenom", this.Prenom);
                cmdUpdate.Parameters.AddWithValue("telephone", this.NumeroTelephone);
                cmdUpdate.Parameters.AddWithValue("mail", this.Mail);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }


        public List<Client> FindAll()
        {
            List<Client> lesClients = new List<Client>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from client;"))
            {
                DataTable dt = DataAccess.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesClients.Add(new Client((int)dt.Rows[0]["id_client"],
                                              (String)dt.Rows[0]["nom"],
                                              (String)dt.Rows[0]["prenom"],
                                              (String)dt.Rows[0]["telephone"],
                                              (String)dt.Rows[0]["mail"]));
            }
            return lesClients;
        }



        public List<Client> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from client where client_id = @idclient;"))
            {
                cmdUpdate.Parameters.AddWithValue("idclient", this.IdClient);
                return DataAccess.ExecuteSet(cmdUpdate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Client Client &&
                   this.IdClient == Client.IdClient;
        }
    }
}

