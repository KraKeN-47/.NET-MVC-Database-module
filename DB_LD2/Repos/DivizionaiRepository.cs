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
    public class DivizionaiRepository
    {
        public List<DivizionasViewModel> getDivizionai()
        {
            List<DivizionasViewModel> divizionai = new List<DivizionasViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string query = @"select * from divizionai";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                divizionai.Add(new DivizionasViewModel
                {
                    ID = Convert.ToInt32(item["id_Divizionai"]),
                    Name = item["name"].ToString()
                });
            }
            return divizionai;
        }
    }
}