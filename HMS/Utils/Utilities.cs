using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Odbc;

namespace HMS.Utils
{
    public class Utilities
    {
        public OleDbDataReader GetDataReader(string strSqlQuery, OleDbConnection conn)
        {OleDbDataReader result = null;
        try
        {

            OleDbCommand cmd = null;
            if ((conn != null) && (string.IsNullOrEmpty(strSqlQuery) == false))
            {
                cmd = new OleDbCommand(strSqlQuery, conn);
                conn.Open();
                result = cmd.ExecuteReader();

            }
        }
        catch (Exception ex)
        {
 
        }

            return result;
        }
        public OleDbConnection GetConnection()
        {
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source="+HMS.Properties.Resources.DBPath);
                //Microsoft.ACE.OLEDB.12.0;Data Source=Z:\HMS\ClinicDatabase.accdb;Persist Security
            }
            catch (Exception ex)
            {
 
            }
            return conn;
        }
        public bool DBClose(OleDbConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetID(string strTableName, string strIDColumnName)
        {
            string result = string.Empty;
            OleDbConnection conn = GetConnection();
            if (conn != null)
            {
                string sqlQuery = "SELECT * FROM " + strTableName + " ORDER BY " + strIDColumnName + ";";
                OleDbDataReader reader = GetDataReader(sqlQuery,conn);
               //result= reader[0].ToString();
                while (reader.Read())
                {
                    result = reader[strIDColumnName].ToString();
                    //break;
                }
            }
            if (string.IsNullOrEmpty(result) == false)
            {
                string temp = result.Substring(0, 1);
                result = result.Substring(0, 1)+(Convert.ToInt16(result.Substring(1, result.Length - 1)) + 1).ToString();
            }
            DBClose(conn);
            return result;
        }

    }
}
