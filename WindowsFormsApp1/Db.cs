using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public static class Db
    {
        private static string conStr = "host=localhost;user=root;password=root;database=project_office";

        private static MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection(conStr);
            try
            {
                con.Open();
                return con;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string[][] DataTableToMultyRowStrArray(DataTable dt)
        {
            List<string[]> res = new List<string[]>();
            int row = 0;
            while (row < dt.Rows.Count)
            {
                int col = 0;
                List<string> arr = new List<string>();
                while (col < dt.Columns.Count)
                { 
                    string value = (dt.Rows[row][col] != null && dt.Rows[row][col] != DBNull.Value) ? dt.Rows[row][col].ToString() : null;
                    arr.Add(value);
                    col++;
                }
                res.Add(arr.ToArray());
                row++;
            }
            return res.ToArray();
        }

        public static string[] DataTableToStringArray(DataTable dt)
        {
            List<string> res = new List<string>();
            int row = 0;
            while (row < dt.Rows.Count)
            {
                int col = 0;
                while (col < dt.Columns.Count)
                {
                    string value = (dt.Rows[row][col] != null && dt.Rows[row][col] != DBNull.Value) ? dt.Rows[row][col].ToString() : null;
                    res.Add(value);
                    col++;
                }
                row++;
            }
            return res.ToArray();
        }

        public static string[] GetTableNames()
        {
            MySqlConnection con = GetConnection();
            if (con == null) return null;
            string query = "show tables;";
            MySqlCommand com = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            using (var rdr = com.ExecuteReader())
            {
                dt.Load(rdr);
            }
            return DataTableToStringArray(dt);
        }

        public static string[][] GetTableDescription(string table)
        {
            MySqlConnection con = GetConnection();
            if (con == null) return null;
            string query = $"desc {table};";
            MySqlCommand com = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            using (var rdr = com.ExecuteReader())
            {
                dt.Load(rdr);
            }
            return DataTableToMultyRowStrArray(dt);
        }

        public static void RepairDb()
        {
            MySqlConnection con = GetConnection();
            if (con == null) return;
            string query = Resources.DB_STRUCTURE_DUMP;
            MySqlCommand com = new MySqlCommand(query, con);
            
        }
    }
}
