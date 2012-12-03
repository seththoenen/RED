using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
{
    public class SettingsDA
    {
        public static string saveSetting(string value, string type) 
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            try
            {
                string sqlCommand = "INSERT INTO Settings (value, type) " +
                    "VALUES (@value, @type)";

                dbCmd.CommandText = sqlCommand;
                dbCmd.Parameters.AddWithValue("value", value);
                dbCmd.Parameters.AddWithValue("type", type);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();
                message.Append("Operation successfull!<bR>");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string deleteSetting(int id) 
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            try
            {
                string sqlCommand = "DELETE FROM Settings WHERE id = @id";

                dbCmd.CommandText = sqlCommand;
                dbCmd.Parameters.AddWithValue("id", id);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();
                message.Append("Operation successfull!<bR>");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static List<string> getAuthUsers()
        {
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;
            SqlDataReader dbReader;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            try
            {
                string sqlCommand = "SELECT value FROM Settings WHERE Type = 'AuthUser'";

                dbCmd.CommandText = sqlCommand;

                dbReader = dbCmd.ExecuteReader();
                dbCmd.Parameters.Clear();

                List<string> authUsers = new List<string>();
                while (dbReader.Read())
                {
                    authUsers.Add(dbReader["value"].ToString());
                }
                dbConn.Close();

                return authUsers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
                return null;
            }
        }
    }
}
