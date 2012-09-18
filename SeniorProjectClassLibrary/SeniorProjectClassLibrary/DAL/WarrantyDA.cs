using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SeniorProject
{
    public class WarrantyDA
    {
        public static void addWarranty(SqlCommand cmd, int invID, Warranty warranty)
        {
            string sqlCommand = "INSERT INTO Warranty (InvID, Company, StartDate, EndDate, WarrantyType, Notes) VALUES (@InvID, @Company, @StartDate, @EndDate, @WarrantyType, @Notes)";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("InvID", invID);
            cmd.Parameters.AddWithValue("Company", warranty.Company);
            cmd.Parameters.AddWithValue("StartDate", warranty.StartDate);
            cmd.Parameters.AddWithValue("EndDate", warranty.EndDate);
            cmd.Parameters.AddWithValue("WarrantyType", warranty.WarrantyType);
            cmd.Parameters.AddWithValue("Notes", warranty.Notes);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static string addWarranty(int invID, Warranty warranty, string connectionString)
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;

            try
            {
                        //Insert Into Inventory Table
                string sqlCommand = "INSERT INTO Warranty (InvID, Company, StartDate, EndDate, WarrantyType, Notes) VALUES (@InvID, @Company, @StartDate, @EndDate, @WarrantyType, @Notes)";

                dbCmd.CommandText = sqlCommand;
                dbCmd.Parameters.AddWithValue("InvID", invID);
                dbCmd.Parameters.AddWithValue("Company", warranty.Company);
                dbCmd.Parameters.AddWithValue("StartDate", warranty.StartDate);
                dbCmd.Parameters.AddWithValue("EndDate", warranty.EndDate);
                dbCmd.Parameters.AddWithValue("WarrantyType", warranty.WarrantyType);
                dbCmd.Parameters.AddWithValue("Notes", warranty.Notes);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();    
                message.Append("Warranty added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string deleteWarrantyComputer(ArrayList serialNos,string connectionString)
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];

                    int invId = ComputerDA.getInvID(dbCmd, serialNo);
                        
                    string sqlCommand = "DELETE FROM Warranty WHERE InvID = @InvID";

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.Parameters.AddWithValue("InvID", invId);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Warranty deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string deleteWarrantyEquipment(ArrayList serialNos, string connectionString) 
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (string)serialNos[i];

                    int invId = EquipmentDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "DELETE FROM Warranty WHERE InvID = @InvID";

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.Parameters.AddWithValue("InvID", invId);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Warranty deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string addWarrantysComputer(ArrayList serialNos, Warranty warranty, string connectionString) 
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    String serialNo = (String)serialNos[i];

                    int invId = ComputerDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "INSERT INTO Warranty (InvID, Company, StartDate, EndDate, WarrantyType, Notes) VALUES (@InvID, @Company, @StartDate, @EndDate, @WarrantyType, @Notes)";

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.Parameters.AddWithValue("InvID", invId);
                    dbCmd.Parameters.AddWithValue("Company", warranty.Company);
                    dbCmd.Parameters.AddWithValue("StartDate", warranty.StartDate);
                    dbCmd.Parameters.AddWithValue("EndDate", warranty.EndDate);
                    dbCmd.Parameters.AddWithValue("WarrantyType", warranty.WarrantyType);
                    dbCmd.Parameters.AddWithValue("Notes", warranty.Notes);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Warranties added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string addWarrantysEquipment(ArrayList serialNos, Warranty warranty, string connectionString) 
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (string)serialNos[i];
                    
                    int invId = EquipmentDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "INSERT INTO Warranty (InvID, Company, StartDate, EndDate, WarrantyType, Notes) VALUES (@InvID, @Company, @StartDate, @EndDate, @WarrantyType, @Notes)";

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.Parameters.AddWithValue("InvID", invId);
                    dbCmd.Parameters.AddWithValue("Company", warranty.Company);
                    dbCmd.Parameters.AddWithValue("StartDate", warranty.StartDate);
                    dbCmd.Parameters.AddWithValue("EndDate", warranty.EndDate);
                    dbCmd.Parameters.AddWithValue("WarrantyType", warranty.WarrantyType);
                    dbCmd.Parameters.AddWithValue("Notes", warranty.Notes);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Warranties added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }
    }
}
