using DB_LD2.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace DB_LD2.Repos
{
    public class ŽaidėjaiRepository
    {
        // All žaidėjai list
        public List<ŽaidėjaiViewModel> getZaidejai()
        {
            List<ŽaidėjaiViewModel> žaidėjai = new List<ŽaidėjaiViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = @"select * from žaidėjai";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                žaidėjai.Add(new ŽaidėjaiViewModel
                {
                    Amzius = Convert.ToInt32(item["Amžius"]),
                    Zaidejo_Kodas = Convert.ToInt32(item["Žaidėjo_Kodas"]),
                    Patirtis = Convert.ToInt32(item["Patirtis"]),
                    Pavarde = item["Pavardė"].ToString(),
                    Vardas = item["Vardas"].ToString(),
                    Komandos_ID = Convert.ToInt32(item["fk_KomandosKomandos_ID"])
                });
            }
            return žaidėjai;
        }

        // Get žaidėjas by id
        public ŽaidėjaiEditViewModel getZaidejas(int id)
        {
            ŽaidėjaiEditViewModel zaidejas = new ŽaidėjaiEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = "SELECT * FROM žaidėjai WHERE Žaidėjo_Kodas=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                zaidejas.Zaidejo_Kodas = Convert.ToInt32(item["Žaidėjo_Kodas"]);
                zaidejas.Patirtis = Convert.ToInt32(item["Patirtis"]);
                zaidejas.Pavarde = item["Pavardė"].ToString();
                zaidejas.Vardas = item["Vardas"].ToString();
                zaidejas.Amzius = Convert.ToInt32(item["Amžius"]);
                zaidejas.Komandos_ID = Convert.ToInt32(item["fk_KomandosKomandos_ID"]);
            }

            return zaidejas;
        }

        // Delete žaidėjas
        public void deleteZaidejas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection SqlConn = new MySqlConnection(conn);
            string query = $"DELETE FROM žaidėjai where Žaidėjo_Kodas={id}";
            MySqlCommand comm = new MySqlCommand(query, SqlConn);
            SqlConn.Open();
            comm.ExecuteNonQuery();
            SqlConn.Close();
        }

        // Edit žaidėjas
        public bool editZaidejas(ŽaidėjaiEditViewModel žaidėjas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "UPDATE žaidėjai SET Vardas=?zaidejoVardas," +
                " Pavardė=?zaidejoPavarde," +
                " Patirtis=?zaidejoPatirtis, " +
                " Amžius=?zaidejoAmzius" +
                " where Žaidėjo_Kodas=" + žaidėjas.Zaidejo_Kodas;
            MySqlCommand comm = new MySqlCommand(query, MySqlConn);
            comm.Parameters.Add("?zaidejoVardas", MySqlDbType.VarChar).Value = žaidėjas.Vardas;
            comm.Parameters.Add("?zaidejoPavarde", MySqlDbType.VarChar).Value = žaidėjas.Pavarde;
            comm.Parameters.Add("?zaidejoPatirtis", MySqlDbType.Int32).Value = žaidėjas.Patirtis;
            comm.Parameters.Add("?zaidejoAmzius", MySqlDbType.Int32).Value = žaidėjas.Amzius;
            MySqlConn.Open();
            comm.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }

        // Create žaidėjas
        public bool createZaidejas(ŽaidėjaiEditViewModel žaidėjas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "INSERT INTO žaidėjai (Žaidėjo_Kodas , Pavardė, Amžius, Patirtis, Vardas, fk_KomandosKomandos_ID  )" +
                " Values(?Žaidėjo_Kodas , ?Pavardė, ?Amžius , ?Patirtis, ?Vardas, ?fk_Komandos_ID)";
            MySqlCommand mySqlCommand = new MySqlCommand(query, MySqlConn);
            mySqlCommand.Parameters.Add("?Vardas", MySqlDbType.VarChar).Value = žaidėjas.Vardas;
            mySqlCommand.Parameters.Add("?Patirtis", MySqlDbType.Int32).Value = žaidėjas.Patirtis;
            mySqlCommand.Parameters.Add("?Amžius", MySqlDbType.VarChar).Value = žaidėjas.Amzius;
            mySqlCommand.Parameters.Add("?fk_Komandos_ID", MySqlDbType.Int32).Value = žaidėjas.Komandos_ID;
            mySqlCommand.Parameters.Add("?Pavardė", MySqlDbType.VarChar).Value = žaidėjas.Pavarde;
            mySqlCommand.Parameters.Add("?Žaidėjo_Kodas", MySqlDbType.Int32).Value = žaidėjas.Zaidejo_Kodas;
            MySqlConn.Open();
            mySqlCommand.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }
    }
}