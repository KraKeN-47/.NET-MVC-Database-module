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
    public class ArenaRepository
    {
        // All arena list
        public List<ArenaViewModel> getArenos()
        {
            List<ArenaViewModel> arenos = new List<ArenaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = @"select * from arena";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                arenos.Add(new ArenaViewModel
                {
                    Miesto_ID = Convert.ToInt32((item["Miesto_ID"])),
                    Adresas = item["Adresas"].ToString(),
                    Talpa = Convert.ToInt32(item["Talpa"]),
                    Pavadinimas = item["Pavadinimas"].ToString(),
                    Miestas = item["Miestas"].ToString()
                });
            }
            return arenos;
        }

        // Get arena by id
        public ArenaEditViewModel getArena(int id)
        {
            ArenaEditViewModel arena = new ArenaEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = "SELECT * FROM arena WHERE Miesto_ID=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                arena.Miesto_ID = Convert.ToInt32(item["Miesto_ID"]);
                arena.Miestas = item["Miestas"].ToString();
                arena.Pavadinimas = item["Pavadinimas"].ToString();
                arena.Talpa = Convert.ToInt32(item["Talpa"]);
                arena.Adresas = item["Adresas"].ToString();
            }

            return arena;
        }

        // Delete by id
        public void deleteArena(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection SqlConn = new MySqlConnection(conn);
            string query = $"DELETE FROM arena where Miesto_ID={id}";
            MySqlCommand comm = new MySqlCommand(query, SqlConn);
            comm.Parameters.Add("Miesto_ID", MySqlDbType.Int32).Value = id;
            SqlConn.Open();
            comm.ExecuteNonQuery();
            SqlConn.Close();
        }

        // Return deletion message
        public string message(int id)
        {
            return string.Format($"Arena: {id} , ištrinta.");
        }

        // Edit arena
        public bool editArena(ArenaEditViewModel arena)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "UPDATE arena SET Miestas = ?arenosMiestas ," +
                " Adresas = ?arenosAdresas ," +
                " Pavadinimas = ?arenosPavadinimas ," +
                " Talpa = ?arenosTalpa " +
                "WHERE Miesto_ID= ?arenosMiesto_ID";
            MySqlCommand comm = new MySqlCommand(query, MySqlConn);
            comm.Parameters.Add("?arenosMiestas", MySqlDbType.VarChar).Value = arena.Miestas;
            comm.Parameters.Add("?arenosAdresas", MySqlDbType.VarChar).Value = arena.Adresas;
            comm.Parameters.Add("?arenosPavadinimas", MySqlDbType.VarChar).Value = arena.Pavadinimas;
            comm.Parameters.Add("?arenosTalpa", MySqlDbType.Int32).Value = arena.Talpa;
            comm.Parameters.Add("?arenosMiesto_ID", MySqlDbType.Int32).Value = arena.Miesto_ID;
            MySqlConn.Open();
            comm.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }

        // Insert Arena
        public bool addArena(ArenaEditViewModel newArena)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "INSERT INTO arena (Miestas , Pavadinimas, Talpa, Adresas, Miesto_ID )" +
                " Values(?Miestas , ?Pavadinimas, ?Talpa , ?Adresas, ?Miesto_ID)";
            MySqlCommand mySqlCommand = new MySqlCommand(query, MySqlConn);
            mySqlCommand.Parameters.Add("?Miestas", MySqlDbType.VarChar).Value = newArena.Miestas;
            mySqlCommand.Parameters.Add("?Pavadinimas", MySqlDbType.VarChar).Value = newArena.Pavadinimas;
            mySqlCommand.Parameters.Add("?Talpa", MySqlDbType.Int32).Value = newArena.Talpa;
            mySqlCommand.Parameters.Add("?Adresas", MySqlDbType.VarChar).Value = newArena.Adresas;
            mySqlCommand.Parameters.Add("?Miesto_ID", MySqlDbType.Int32).Value = newArena.Miesto_ID;
            MySqlConn.Open();
            mySqlCommand.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }

    }
}