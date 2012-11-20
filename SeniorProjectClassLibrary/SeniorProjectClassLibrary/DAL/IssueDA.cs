using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
{
    class IssueDA
    {
        public static string saveIssue(Issue issue)
        {
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;
            StringBuilder message = new StringBuilder();

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            try
            {
                //Insert into Issues table
                string sqlCommand = "INSERT INTO Issues (datecreated, description, status, submittedby, type, title) " +
                    "VALUES (@datecreated, @description, @status, @submittedby, @type, @title)";

                dbCmd.CommandText = sqlCommand;
                dbCmd.Parameters.AddWithValue("datecreated", issue.DateCreated);
                dbCmd.Parameters.AddWithValue("description", issue.Description);
                dbCmd.Parameters.AddWithValue("status", issue.Status);
                dbCmd.Parameters.AddWithValue("submittedby", issue.SubmittedBy);
                dbCmd.Parameters.AddWithValue("type", issue.Type);
                dbCmd.Parameters.AddWithValue("title", issue.Title);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();
                message.Append("Issue created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString());
                transaction.Rollback();
            }
            return message.ToString();
        }

        public static Issue getIssue(int issueID)
        {
            SqlConnection dbConn;
            SqlCommand dbCmd;
            SqlDataReader dbReader;
            string sConnection;
            string sql;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();

            sql = "SELECT datecreated, description, status, dateclosed, submittedby, type, reply,title FROM Issues "+
                "WHERE id = @id";

            dbCmd = new SqlCommand();
            dbCmd.CommandText = sql;
            dbCmd.Parameters.AddWithValue("@id", issueID);
            dbCmd.Connection = dbConn;

            dbReader = dbCmd.ExecuteReader();
            Issue issue = new Issue();
            while (dbReader.Read())
            {
                issue.DateCreated = Convert.ToDateTime(dbReader["datecreated"]);
                issue.Description = dbReader["description"].ToString();
                issue.Status = dbReader["status"].ToString();
                if (dbReader["dateclosed"] == DBNull.Value)
                {
                    issue.DateClosed = null;
                }
                else
                {
                    issue.DateClosed = Convert.ToDateTime(dbReader["dateclosed"]);
                }
                issue.SubmittedBy = dbReader["submittedby"].ToString();
                issue.Type = dbReader["dateclosed"].ToString();
                issue.Reply = dbReader["reply"].ToString();
                issue.Title  = dbReader["title"].ToString();
            }
            dbReader.Close();
            dbCmd.Parameters.Clear();

            return issue;
        }

        public static Issue updateIssue(Issue issue)
        {
            SqlConnection dbConn;
            SqlCommand dbCmd;
            string sConnection;
            string sql;

            try
            {
                sConnection = GlobalVars.ConnectionString;
                dbConn = new SqlConnection(sConnection);
                dbConn.Open();

                sql = "UPDATE Issues SET datecreated = @datecreated, description = @description, status = @status, dateclosed = @dateclosed, submittedby = @submittedby" +
                    ", type = @type, reply = @reply, title = @title WHERE id = @id";

                dbCmd = new SqlCommand();
                dbCmd.CommandText = sql;
                dbCmd.Parameters.AddWithValue("id", issue.ID);
                dbCmd.Parameters.AddWithValue("datecreated", issue.DateCreated);
                dbCmd.Parameters.AddWithValue("description", issue.Description);
                dbCmd.Parameters.AddWithValue("status", issue.Status);
                if (issue.DateClosed == null)
                {
                    dbCmd.Parameters.AddWithValue("dateclosed", DBNull.Value);
                }
                else
                {
                    dbCmd.Parameters.AddWithValue("dateclosed", issue.DateClosed);
                }
                dbCmd.Parameters.AddWithValue("submittedby", issue.SubmittedBy);
                dbCmd.Parameters.AddWithValue("type", issue.Type);
                dbCmd.Parameters.AddWithValue("reply", issue.Reply);
                dbCmd.Parameters.AddWithValue("title", issue.Title);

                dbCmd.Connection = dbConn;

                dbCmd.ExecuteNonQuery();

                dbCmd.Parameters.Clear();
                dbConn.Close();

                return issue;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
    }
}
