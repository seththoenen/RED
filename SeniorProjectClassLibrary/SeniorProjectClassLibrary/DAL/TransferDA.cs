using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SeniorProject
{
    public class TransferDA
    {
        public static string saveTransfer(Transfer transfer) 
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
            int invCount = 0;
            try
            {
                string sqlCommand = "INSERT INTO Transfers (Date, Whereto, Notes) " +
                    "VALUES (@Date, @Whereto, @Notes)";

                dbCmd.CommandText = sqlCommand;

                //dbCmd.Parameters.AddWithValue("Name", transfer.Name);
                dbCmd.Parameters.AddWithValue("Date", transfer.Date);
                dbCmd.Parameters.AddWithValue("Whereto", transfer.Where);
                dbCmd.Parameters.AddWithValue("Notes", transfer.Notes);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                int transferID = TransferDA.getTransferID(dbCmd, transfer.Name);

                for (int i = 0; i < transfer.Inventory.Count; i++)
                {
                    string serialNo = transfer.Inventory[i].ToString();
                    if (ComputerDA.computerExist(dbCmd, serialNo) == true || EquipmentDA.equipmentExist(dbCmd, serialNo) == true)
                    {
                        if (ComputerDA.computerTransferred(dbCmd, serialNo) == false)
                        {
                            int invId = 0;
                            invId = ComputerDA.getInvID(dbCmd, serialNo);
                            if (invId < 1)
                            {
                                invId = EquipmentDA.getInvID(dbCmd, serialNo);
                            }
                            GroupDA.removeLinks(dbCmd, invId);
                            ComputerDA.transferComputer(dbCmd, invId);

                            MonitorDA.deleteMonitors(dbCmd, invId);
                            LicenseDA.removeLicenses(dbCmd, invId);


                            sqlCommand = "INSERT INTO TransferInventory (TransID, InvID) " +
                            "VALUES (@TransID, @InvID)";

                            dbCmd.CommandText = sqlCommand;

                            dbCmd.Parameters.AddWithValue("TransID", transferID);
                            dbCmd.Parameters.AddWithValue("InvID", invId);

                            dbCmd.ExecuteNonQuery();
                            dbCmd.Parameters.Clear();
                            invCount++;
                        }
                        else
                        {
                            message.Append("Inventory item with Serial Number " + serialNo + " is already transferred and has not been added to this transfer.<bR>");
                        }
                    }
                    else
                    {
                        message.Append("Inventory with Serial Number " + serialNo + " does not exist and has not been added to this transfer.<bR>");
                    }
                        
                }
                if (invCount == 0)
                {
                    message.Append("There were no current inventory items on this transfer, therefore the transfer has not been created.");
                    transaction.Rollback();
                }
                else
                {
                    transaction.Commit();
                    message.Append("Operation Successful!");
                }
                dbConn.Close();
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }
            return message.ToString();
        }

        public static bool transferExist(SqlCommand cmd, string transferName) 
        {

            SqlDataReader dbReader;

            string sql;

            sql = "SELECT * FROM Transfers WHERE Name = @TransferName";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("TransferName", transferName);

            dbReader = cmd.ExecuteReader();

            int transferID = 0;

            while (dbReader.Read())
            {
                transferID = Convert.ToInt32(dbReader["TransID"]);
            }
            dbReader.Close();

            if (transferID > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int getTransferID(SqlCommand cmd, string transferName) 
        {

            SqlDataReader dbReader;
            string sql;

            sql = "SELECT TransID FROM Transfers";

            cmd.CommandText = sql;

            dbReader = cmd.ExecuteReader();

            int transferID = 0;

            while (dbReader.Read())
            {
                transferID = Convert.ToInt32(dbReader["TransID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return transferID;
        }

    }
}
