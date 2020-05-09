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
    public class TeisejaiRepository
    {
        // All teisejai list
        public List<TeisejaiViewModel> getTeisejai()
        {
            List<TeisejaiViewModel> teisejai = new List<TeisejaiViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = @"select * from teisėjai";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                teisejai.Add(new TeisejaiViewModel
                {
                    Amzius=Convert.ToInt32(item["Amžius"]),
                    Asmens_Kodas=Convert.ToInt32(item["Asmens_Kodas"]),
                    Patirtis=Convert.ToInt32(item["Patirtis"]),
                    Pavarde=item["Pavardė"].ToString(),
                    Vardas=item["Vardas"].ToString()
                });
            }
            return teisejai;
        }

        // Get teisejas by id
        public TeisejaiEditViewModeL getTeisejas(int id)
        {
            TeisejaiEditViewModeL teisejas = new TeisejaiEditViewModeL();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = "SELECT * FROM teisėjai WHERE Asmens_Kodas=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                teisejas.Asmens_Kodas = Convert.ToInt32(item["Asmens_Kodas"]);
                teisejas.Patirtis = Convert.ToInt32(item["Patirtis"]);
                teisejas.Pavarde = item["Pavardė"].ToString();
                teisejas.Vardas = item["Vardas"].ToString();
                teisejas.Amzius = Convert.ToInt32(item["Amžius"]);
            }

            return teisejas;
        }

        // Delete teisejas
        public void deleteTeisejas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection SqlConn = new MySqlConnection(conn);
            string query = $"DELETE FROM teisėjai where Asmens_Kodas={id}";
            MySqlCommand comm = new MySqlCommand(query, SqlConn);
            SqlConn.Open();
            comm.ExecuteNonQuery();
            SqlConn.Close();
        }

        // Edit teisejas
        public bool editTeisejas(TeisejaiEditViewModeL teisejas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(conn);
            string query = "UPDATE teisėjai SET Vardas=?teisejoVardas," +
                " Pavardė=?teisejoPavarde," +
                " Patirtis=?teisejoPatirtis, " +
                " Amžius=?teisejoAmzius" +
                " where Asmens_Kodas=" + teisejas.Asmens_Kodas;
            MySqlCommand comm = new MySqlCommand(query, MySqlConn);
            comm.Parameters.Add("?teisejoVardas", MySqlDbType.VarChar).Value = teisejas.Vardas;
            comm.Parameters.Add("?teisejoPavarde", MySqlDbType.VarChar).Value = teisejas.Pavarde;
            comm.Parameters.Add("?teisejoPatirtis", MySqlDbType.Int32).Value = teisejas.Patirtis;
            comm.Parameters.Add("?teisejoAmzius", MySqlDbType.Int32).Value = teisejas.Amzius;
            MySqlConn.Open();
            comm.ExecuteNonQuery();
            MySqlConn.Close();

            return true;
        }
    }
}