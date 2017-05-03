﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RetailServer.DBConnection
{
    class Database
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        string tengistrengur = null;
        string fyrirspurn = null;

        SqlConnection sqltenging;
        SqlCommand nySQLskipun;
        SqlDataReader sqlLesari = null;

        public void TengingVidGagnagrunn()
        {
            server = "lokaverkefni.tk";
            database = "store";
            uid = "forrit";
            password = "Bananabomba98";
            tengistrengur = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", server, database, uid, password);
            sqltenging = new SqlConnection(tengistrengur);
        }

        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public string CreateUsert(string kennitala, string nafn, string kenni)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "INSERT INTO users (kennitala, nafn, kenni) VALUES ('" + kennitala + "', '" + nafn + "', '" + kenni + "');";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public void CreateUser(string kennitala, string nafn, string kenni)
        {
            string cmdString = "INSERT INTO users (kennitala, nafn, kenni) VALUES (@val1, @va2, @val3)";
            using (SqlConnection conn = new SqlConnection(tengistrengur))
            {
                using (SqlCommand comm = new SqlCommand(cmdString))
                {
                    comm.Connection = conn;
                    //comm.CommandString = cmdString;
                    comm.Parameters.AddWithValue("@val1", kennitala);
                    comm.Parameters.AddWithValue("@val2", nafn);
                    comm.Parameters.AddWithValue("@val3", kenni);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        // do something with the exception
                        // don't hide it
                    }
                }
            }
        }



        public List<string> LesaNotendur()
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT id, kennitala, nafn, kenni FROM users";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    for (int i = 0; i < sqlLesari.FieldCount; i++)
                    {
                        lina += (sqlLesari.GetValue(i).ToString()) + ":";
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        // Spurning hvort að við notum þetta???
        public string GetPassword(string id)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT lykilorð FROM starfsmenn WHERE id = '" + id + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public string GetVara(string strikamerki)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT strikamerki FROM vorur WHERE strikamerki = '" + strikamerki + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public string GetVaraVerd(string strikamerki)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT verd FROM vorur WHERE strikamerki = '" + strikamerki + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public string vorunumer(int vorunumer)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT vorunumer FROM vorur WHERE vorunumer ='" + vorunumer + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public string vorunumer_verd(int vorunumer)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT vorunumer FROM vorur WHERE vorunumer ='" + vorunumer + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public List<string> Voruleit()
        {
            List<string> faerslur = new List<string>();
            string lina = null;

            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT vorunumer, nafn, verd FROM vorur";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    for (int i = 0; i < sqlLesari.FieldCount; i++)
                    {
                        lina += (sqlLesari.GetValue(i).ToString()) + ":";
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        public List<string> voruleit_name(string name_of_product)
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT vorunumer, nafn, verd FROM vorur WHERE nafn LIKE '%" + name_of_product + "%'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    for (int i = 0; i < sqlLesari.FieldCount; i++)
                    {
                        lina += (sqlLesari.GetValue(i).ToString()) + ":";
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        public string GetProductFromVorunumer(string vorunumer)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT nafn FROM vorur WHERE vorunumer = '" + vorunumer + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        public string GetVaraVerdFromVorunumer(string vorunumer)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT verd FROM vorur WHERE vorunumer = '" + vorunumer + "'";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                while (sqlLesari.Read())
                {
                    faersla = (sqlLesari.GetValue(0).ToString());
                }
                CloseConnection();
                return faersla;
            }
            return faersla;
        }

        #region Product fetching
        public MySqlConnection Connect()
        {
            MySqlConnection connection = new MySqlConnection("Server=lokaverkefni.tk;Database=store;uid=forrit;Pwd=Bananabomba98;");
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                return null;
            }
            return connection;
        }

        public List<Product> GetAllarVorur()
        {
            List<Product> listinn = new List<Product>();
            var connection = Connect();
            if (connection != null)
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT nafn,verd,vorunumer FROM vorur";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var nafn = (reader.GetString(0));
                                var verd = (reader.GetInt32(1));
                                var vorunumer = (reader.GetInt32(2));
                                listinn.Add(new Product { Name = nafn, Price = verd, ID = vorunumer.ToString() });
                            }
                        }
                    }
                }
            }
            return listinn;
        }

        public Product GetEinaVoru(string vorunumer)
        {
            Product product = null;
            var connection = Connect();
            if (connection != null)
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT nafn,verd FROM vorur WHERE vorunumer = '" + vorunumer + "'";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var nafn = (reader.GetString(0));
                                var verd = (reader.GetInt32(1));
                                product = new Product { Name = nafn, Price = verd, ID = vorunumer.ToString() };
                            }
                        }
                    }
                }
            }
            return product;
        }
        #endregion
    }
}

