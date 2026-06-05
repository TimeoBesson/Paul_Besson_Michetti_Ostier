using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using Npgsql;

namespace Paul_Besson_Michetti_Ostier.Classes
{

    public class DataAccess
    {
        
        private static string connectionString;
        private static NpgsqlConnection connection;

        static DataAccess()
        {
        }

        public static void Connexion(string login, string password)
        {
            connectionString = "Host=srv-peda-new;Port=5433;Username=" + login + ";Password=" + password + ";Database=ostiera_sae201;Options='-c search_path=sae201'";
            try
            {
                connection = new NpgsqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Pb à la connexion  \n");
                throw;
            }
        }

    
        public static NpgsqlConnection GetConnection()
        {

            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)

                try
                {
                    connection.Open(); 
                }
                catch (Exception ex)
                {
                    LogError.Log(ex, "Pb à la connexion  \n");
                    throw;
                }
        
            return connection;
        }

      
        public static DataTable ExecuteSelect(NpgsqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            try
            { 
                cmd.Connection = GetConnection();
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex) {
                LogError.Log(ex, "Pb de executeSelect \n" + cmd.CommandText);
                throw;
            }

            return dataTable;
        }

        public static int ExecuteInsert(NpgsqlCommand cmd)
        {
            int nb = 0;
            try
            {
                cmd.Connection = GetConnection();
                nb = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Pb de executeInsert \n" + cmd.CommandText);
                throw;
            }
            return nb;

        }




        //  pour requêtes UPDATE, DELETE
        public static int ExecuteSet(NpgsqlCommand cmd)
        {
            int nb = 0;
            try
            {
                cmd.Connection = GetConnection();
                nb = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Pb de executeSet \n" + cmd.CommandText);
                throw;
            }
            return nb;

        }

        // pour requêtes avec une seule valeur retour  (ex : 1 colonne, ou COUNT, SUM) 
        public static string ExecuteSelectOneValue(NpgsqlCommand cmd)
        {
            object res = null;
            try
            {
                cmd.Connection = GetConnection();
                res = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Pb de ExecuteSelectOneValue \n" + cmd.CommandText);
                throw;
            }
            return res.ToString();

        }

        //  Fermer la connexion 
        public static void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}



