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

        private static MySqlConnection GetConnection(bool dbNeeded = true)
        {
            string noDbSettings = string.Join(";", conStr.Split(';').Where(str => str[0] != 'd').ToArray());
            conStr = (dbNeeded) ? $"{noDbSettings};database=project_office" : noDbSettings;
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
            try
            {
                using (var rdr = com.ExecuteReader())
                {
                    dt.Load(rdr);
                }
                con.Close();
            }
            catch (Exception) {; }
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
            con.Close();
            return DataTableToMultyRowStrArray(dt);
        }

        public static string RepairDb()
        {
            MySqlConnection con = GetConnection(false);
            if (con == null) return null;
            string query = Resources.db_structure_empty_dump_v3;
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            con.Close();
            return "";
        }

        public static int ImportData(string table, params string[] values)
        {
            MySqlConnection con = GetConnection();
            if (con == null) return -1;
            string query = $"insert into {table} value ({string.Join(",", values)});";
            MySqlCommand com = new MySqlCommand(query, con);
            int n = 0;
            try
            {
                n = com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
            }
            con.Close();
            return n;
        }
    }
}
