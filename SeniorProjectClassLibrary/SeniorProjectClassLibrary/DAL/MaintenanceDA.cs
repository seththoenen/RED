using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SeniorProject
{
    public class MaintenanceDA
    {
        public static string addMaintenance(Maintenance maint) 
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
                string sqlCommand = "INSERT INTO Maintenance (InvID, Date, Maintenance) " +
                    "VALUES (@InvID, @Date, @Maintenance)";

                dbCmd.CommandText = sqlCommand;

                dbCmd.Parameters.AddWithValue("InvID", maint.InvID);
                dbCmd.Parameters.AddWithValue("Date", maint.Date);
                dbCmd.Parameters.AddWithValue("Maintenance", maint.Description);

                dbCmd.ExecuteNonQuery();
                transaction.Commit();
                dbConn.Close();
                message.Append("Maintenance added successfully<bR>");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString());
                transaction.Rollback();
            }
            return message.ToString();
        }

        public static string addMassMaintenanceComputer(ArrayList serialNos, Maintenance maint) 
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
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (string)serialNos[i];
                    int invID = ComputerDA.getInvID(dbCmd, serialNo);
                    string sqlCommand = "INSERT INTO Maintenance (InvID, Date, Maintenance) " +
                        "VALUES (@InvID, @Date, @Maintenance)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", invID);
                    dbCmd.Parameters.AddWithValue("Date", maint.Date);
                    dbCmd.Parameters.AddWithValue("Maintenance", maint.Description);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Maintenance added successfully!<bR>");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }
            return message.ToString();
        }

        public static string addMassMaintenanceEquipment(ArrayList serialNos, Maintenance maint) 
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
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (string)serialNos[i];

                    int invID = ComputerDA.getInvID(dbCmd, serialNo);
                    string sqlCommand = "INSERT INTO Maintenance (InvID, Date, Maintenance) " +
                        "VALUES (@InvID, @Date, @Maintenance)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", invID);
                    dbCmd.Parameters.AddWithValue("Date", maint.Date);
                    dbCmd.Parameters.AddWithValue("Maintenance", maint.Description);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Maintenance added successfully!<bR>");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }
            return message.ToString();
        }
    }
}
