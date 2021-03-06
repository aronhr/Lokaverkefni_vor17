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
                        command.CommandText = "SELECT nafn,verd,vorunumer,strikamerki,byrgi,magn,kassakerfi FROM vorur";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var nafn = (reader.GetString(0));
                                var verd = (reader.GetInt32(1));
                                var vorunumer = (reader.GetInt32(2));
                                var strikamerki = (reader.GetInt32(3));
                                var byrgi = (reader.GetString(4));
                                var magn = (reader.GetInt32(5));
                                var kassakerfi = (reader.GetInt32(6));
                                listinn.Add(new Product { Name = nafn, Verd = verd.ToString(), Vorunumer = vorunumer.ToString(), Strikamerki = strikamerki.ToString(), Byrgi = byrgi.ToString(), Magn = magn.ToString(), Kassakerfi = kassakerfi.ToString() });
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
                                product = new Product { Name = nafn, Verd = verd.ToString(), Vorunumer = vorunumer.ToString() };
                            }
                        }
                    }
                }
            }
            return product;
        }

        public List<Product> GetVorurOnDeck()
        {
            List<Product> listinn = new List<Product>();
            var connection = Connect();
            if (connection != null)
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT nafn,verd,vorunumer FROM vorur WHERE kassakerfi = 1";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var nafn = (reader.GetString(0));
                                var verd = (reader.GetInt32(1));
                                var vorunumer = (reader.GetInt32(2));
                                listinn.Add(new Product { Name = nafn, Verd = verd.ToString(), Vorunumer = vorunumer.ToString() });
                            }
                        }
                    }
                }
            }
            return listinn;
        }

        public bool CreateUser(string kennitala, string nafn, string kenni)
        {

            var connection = Connect();
            if (connection != null)
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO users (kennitala, nafn, kenni) VALUES ('" + kennitala + "', '" + nafn + "', '" + kenni + "')";
                        try
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Success!");
                            return true;
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Error: " + e);
                            return false;
                        }
                    }
                }
            }
            return false;
        } // End CreateUser

        public bool AddProduct(string nafn, string vorunumer, string strikamerki, string byrgi, string magn, string verd, string kassakerfi)
        {
            var connection = Connect();
            if (connection != null)
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO vorur (nafn, vorunumer, strikamerki, byrgi, magn, verd, kassakerfi) VALUES ('" + nafn + "', '" + vorunumer + "', '" + strikamerki + "', '" + byrgi + "', '" + magn + "', '" + verd + "', '" + kassakerfi + "');";
                        try
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Success!");
                            return true;
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Error: " + e);
                            return false;
                        }
                    }

                }
            }
            return false;
        } // End AddProduct

        public bool AddKvittun(string kvittun, string verd)
        {
            var connection = Connect();
            if (connection != null)
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO kvittanir (verd, kvittun) VALUES ('" + verd + "', '" + kvittun + "');";
                        try
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Success!");
                            return true;
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Error: " + e);
                            return false;
                        }
                    }

                }
            }
            return false;
        } // End AddProduct
        #endregion
    }
}


