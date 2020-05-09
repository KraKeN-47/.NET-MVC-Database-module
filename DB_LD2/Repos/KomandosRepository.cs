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
    public class KomandosRepository
    {
        // Get all komandos
        public List<KomandosViewModel> getKomandos()
        {
            List<KomandosViewModel> komandos = new List<KomandosViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = @"select * from komandos";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                komandos.Add(new KomandosViewModel
                {
                    Miestas = item["Miestas"].ToString(),
                    Divizionas = Convert.ToInt32(item["fk_Komandų_DivizionaiKonferencijos_ID"]),
                    Komandos_Pav = item["Komandos_Pav"].ToString(),
                    Komandos_ID = Convert.ToInt32(item["Komandos_ID"]),
                    Valstija = item["Valstija"].ToString()
                });
            }
            return komandos;
        }

        // Get komanda by id
        public KomandosEditViewModel getKomanda(int id)
        {
            KomandosEditViewModel komanda = new KomandosEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = "SELECT * FROM komandos WHERE Komandos_ID="+id;
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                komanda.Divizionas = Convert.ToInt32(item["fk_Komandų_DivizionaiKonferencijos_ID"]);
                komanda.Komandos_Pav = item["Komandos_Pav"].ToString();
                komanda.Miestas = item["Miestas"].ToString();
                komanda.Komandos_ID = Convert.ToInt32(item["Komandos_ID"]);
                komanda.Valstija = item["Valstija"].ToString();
            }

            return komanda;
        }

        // Delete by id
        public void deleteKomanda(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection SqlConn = new MySqlConnection(conn);
            string query = $"DELETE FROM komandos where Komandos_ID={id}";
            MySqlCommand comm = new MySqlCommand(query, SqlConn);
            comm.Parameters.Add("Miesto_ID", MySqlDbType.Int32).Value = id;
            SqlConn.Open();
            comm.ExecuteNonQuery();
            SqlConn.Close();
        }

        // Edit komanda
        public bool editKomanda(KomandosEditViewModel komanda)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "UPDATE komandos SET Komandos_Pav=?komandosPav," +
                " Miestas=?komandosMiestas," +
                " Valstija=?komandosValstija " +
                "WHERE Komandos_ID=" + komanda.Komandos_ID;
            MySqlCommand comm = new MySqlCommand(query, MySqlConn);
            comm.Parameters.Add("?komandosPav", MySqlDbType.VarChar).Value = komanda.Komandos_Pav;
            comm.Parameters.Add("?komandosMiestas", MySqlDbType.VarChar).Value = komanda.Miestas;
            comm.Parameters.Add("?komandosValstija", MySqlDbType.VarChar).Value = komanda.Valstija;
            MySqlConn.Open();
            comm.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }

        // Create komanda
        public bool createKomanda(KomandosEditViewModel naujaKomanda)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "INSERT INTO komandos ( Komandos_ID, Komandos_Pav, Miestas, Valstija, fk_Komandų_DivizionaiKonferencijos_ID )" +
                " Values(?Komandos_ID , ?Komandos_Pav, ?Miestas , ?Valstija, ?fk_Komandų_Divizionai)";
            MySqlCommand mySqlCommand = new MySqlCommand(query, MySqlConn);
            mySqlCommand.Parameters.Add("?Komandos_ID", MySqlDbType.Int32).Value = naujaKomanda.Komandos_ID;
            mySqlCommand.Parameters.Add("?Komandos_Pav", MySqlDbType.VarChar).Value = naujaKomanda.Komandos_Pav;
            mySqlCommand.Parameters.Add("?Miestas", MySqlDbType.VarChar).Value = naujaKomanda.Miestas;
            mySqlCommand.Parameters.Add("?Valstija", MySqlDbType.VarChar).Value = naujaKomanda.Valstija;
            mySqlCommand.Parameters.Add("?fk_Komandų_Divizionai", MySqlDbType.Int32).Value = naujaKomanda.Divizionas;
            MySqlConn.Open();
            mySqlCommand.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }
    }
}