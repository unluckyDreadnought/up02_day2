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

        public static string[] IsUserExists(string login, string pswd)
        {
            MySqlConnection con = GetConnection();
            if (con == null) return null;
            pswd = Security.HashInput512(pswd);
            string query = $"select UserID from user where UserLogin = '{login}' and UserPassword = '{pswd}'; ";
            MySqlCommand com = new MySqlCommand(query, con);
            string[] data = null;
            try
            {
                DataTable dt = new DataTable();
                dt.Load(com.ExecuteReader());
                data = Db.DataTableToStringArray(dt);
            }
            catch (Exception e)
            {
                return null;
            }
            con.Close();
            return data;
        }

        public static DataTable GetProjects(string searchPattern = "")
        {
            string query = $@"select project.ProjectID, ProjectTitle, concat(UserSurname, ' ', substring(UserName, 1,1), '.', substring(UserPatronymic, 1,1)) as 'fio', StatusTitle,
case when ProjectFactEndDate is NULL then ProjectPlanEndDate
else ProjectFactEndDate
end as 'date',
case when ProjectCoefficient = 0 then concat(ProjectCost, ' | 0')
else concat(round(ProjectCost*(1+ProjectCoefficient/100),2), ' | ', round(ProjectCost-round(ProjectCost*(1+ProjectCoefficient/100),2),2))
end as 'cost'
from project
left join userproject on userproject.ProjectID = project.ProjectID and userproject.IsResponsible = 1
left join `user` on `user`.UserID = userproject.UserID
inner join `status` on `status`.StatusID = project.ProjectStatusID
where ProjectTitle like '%{searchPattern}%'; ";
            MySqlConnection con = GetConnection();
            if (con == null) return null;
            MySqlCommand com = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                using (var rdr = com.ExecuteReader())
                {
                    dt.Load(rdr);
                }
                total = GetTotalRowsCount(searchPattern);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public static (DataTable, int) GetProjects(string searchPattern = "", int page = 1)
        {
            string query = $@"select project.ProjectID, ProjectTitle, concat(UserSurname, ' ', substring(UserName, 1,1), '.', substring(UserPatronymic, 1,1)) as 'fio', StatusTitle,
case when ProjectFactEndDate is NULL then ProjectPlanEndDate
else ProjectFactEndDate
end as 'date',
case when ProjectCoefficient = 0 then concat(ProjectCost, ' | 0')
else concat(round(ProjectCost*(1+ProjectCoefficient/100),2), ' | ', round(ProjectCost-round(ProjectCost*(1+ProjectCoefficient/100),2),2))
end as 'cost'
from project
left join userproject on userproject.ProjectID = project.ProjectID and userproject.IsResponsible = 1
left join `user` on `user`.UserID = userproject.UserID
inner join `status` on `status`.StatusID = project.ProjectStatusID
where ProjectTitle like '%{searchPattern}%' limit 20 offset {(page-1)*20}; ";
            MySqlConnection con = GetConnection();
            if (con == null) return (null, -1);
            MySqlCommand com = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                using (var rdr = com.ExecuteReader())
                {
                    dt.Load(rdr);
                }
                total = GetTotalRowsCount(searchPattern);
            }
            catch (Exception)
            {
                return (null, -1);
            }
            finally
            {
                con.Close();
            }
            return (dt, total);
        }

        public static int GetTotalRowsCount(string searchPattern)
        {
            string query = $@"select count(project.ProjectID)
from project
left join userproject on userproject.ProjectID = project.ProjectID and userproject.IsResponsible = 1
left join `user` on `user`.UserID = userproject.UserID
inner join `status` on `status`.StatusID = project.ProjectStatusID
where ProjectTitle like '%{searchPattern}%'; ";
            MySqlConnection con = GetConnection();
            if (con == null) return -1;
            MySqlCommand com = new MySqlCommand(query, con);
            try
            {
                return Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable GetClients()
        {
            MySqlConnection con = GetConnection();
            if (con == null) return null;
            string query = @"select  
ClientID, case when ClientOrgTypeID is null then concat(ClientName) else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`, ClientPhone, ClientEmail, ClientPhoto
from client where ClientID > 1; ";
            MySqlCommand com = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(com.ExecuteReader());
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public static string[] GetClient(string clientId)
        {
            MySqlConnection con = GetConnection();
            if (con == null) return null;
            string query = $@"select  ClientID, 
case when ClientOrgTypeID is null then concat(ClientName) else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`, 
 ClientPhone, ClientEmail, ClientAddress
from client where ClientID = {clientId};";
            MySqlCommand com = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            string[] info = null;
            try
            {
                dt.Load(com.ExecuteReader());
                info = DataTableToStringArray(dt);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return info;
        }
    }
}
