using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Console
{
    class db_connect
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

            tengistrengur = "server=" + server + ";userid=" + uid + ";password=" + password + ";database=" + database;
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

        public string CreateUser(string kennitala, string nafn, string kenni)
        {
            string faersla = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "INSERT INTO users (id, kennitala, nafn, kenni, admin) VALUES ('NULL', '" + kennitala + "', '" + nafn + "', '" + kenni + "', 'no');";
                nySQLskipun = new SqlCommand(fyrirspurn, sqltenging);
                sqlLesari = nySQLskipun.ExecuteReader();
                CloseConnection();
                return faersla;
            }
            return faersla;
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
    }
}

