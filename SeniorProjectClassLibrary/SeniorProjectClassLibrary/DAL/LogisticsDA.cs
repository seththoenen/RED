using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SeniorProject
{
    public class LogisticsDA
    {
        public static void removeLogistics(SqlCommand cmd, int invID) 
        {

            String sqlCommand = "UPDATE Logistics SET Status = @Status, EndDate = @EndDate WHERE InvID = @InvID";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("InvID", invID);
            cmd.Parameters.AddWithValue("Status", "Inactive");
            cmd.Parameters.AddWithValue("EndDate", DateTime.Now.ToShortDateString());

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        public static void addLogistics(SqlCommand cmd, Computer comp) 
        {

            String sqlCommand = "INSERT INTO Logistics (InvID, Building, Room, PrimaryUser, Name, StartDate, Status) " +
                            "VALUES (@InvID, @Building, @Room, @PrimaryUser, @Name, @StartDate, @Status)";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("InvID", comp.InvID);
            cmd.Parameters.AddWithValue("Building", comp.CurrentLocation.Building);
            cmd.Parameters.AddWithValue("Room", comp.CurrentLocation.Room);
            cmd.Parameters.AddWithValue("PrimaryUser", comp.CurrentLocation.PrimaryUser);
            cmd.Parameters.AddWithValue("Name", comp.CurrentLocation.Name);
            cmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("Status", "Active");

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        public static void addLogistics(SqlCommand cmd, Equipment equip) 
        {

            String sqlCommand = "INSERT INTO Logistics (InvID, Building, Room, PrimaryUser, Name, StartDate, Status) " +
                            "VALUES (@InvID, @Building, @Room, @PrimaryUser, @Name, @StartDate, @Status)";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("InvID", equip.InvID);
            cmd.Parameters.AddWithValue("Building", equip.CurrentLocation.Building);
            cmd.Parameters.AddWithValue("Room", equip.CurrentLocation.Room);
            cmd.Parameters.AddWithValue("PrimaryUser", equip.CurrentLocation.PrimaryUser);
            cmd.Parameters.AddWithValue("Name", equip.CurrentLocation.Name);
            cmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("Status", "Active");

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        public static string massUpdateLogisticsComputer(ArrayList compSerialNos, Logistics logs, string connectionString) 
        {
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;
            StringBuilder message = new StringBuilder();

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            dbCmd.Connection = dbConn;

            for (int i = 0; i < compSerialNos.Count; i++)
            { 
                string compSerialNo = compSerialNos[i].ToString();

                if (ComputerDA.computerExist(dbCmd, compSerialNo) == false)
                {
                    message.Append("Computer with Serial Number " + compSerialNo + " does not exist.<bR>");
                }
                else 
                {
                    int compID = ComputerDA.getInvID(dbCmd, compSerialNo);
                    Computer comp = new Computer();
                    comp = ComputerDA.getComputer(dbCmd, compSerialNo);

                    LogisticsDA.removeLogistics(dbCmd, compID);

                    try
                    {
                        string sqlCommand = "INSERT INTO Logistics (InvID, Building, Room, PrimaryUser, Name, StartDate, Status) VALUES " + 
                            "(@InvID, @Building, @Room, @PrimaryUser, @Name, @StartDate, @Status)";

                        dbCmd.CommandText = sqlCommand;

                        if (logs.Building == "")
                        {
                            dbCmd.Parameters.AddWithValue("Building", comp.CurrentLocation.Building);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("Building", logs.Building);
                        }

                        if (logs.Room == "")
                        {
                            dbCmd.Parameters.AddWithValue("Room", comp.CurrentLocation.Room);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("Room", logs.Room);
                        }

                        if (logs.PrimaryUser == "")
                        {
                            dbCmd.Parameters.AddWithValue("PrimaryUser", comp.CurrentLocation.PrimaryUser);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("PrimaryUser", logs.PrimaryUser);
                        }

                        if (logs.Name == "")
                        {
                            dbCmd.Parameters.AddWithValue("Name", comp.CurrentLocation.Name);
                        }
                        else 
                        {
                            dbCmd.Parameters.AddWithValue("Name", logs.Name);
                        }

                        dbCmd.Parameters.AddWithValue("InvID", compID);
                        dbCmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
                        dbCmd.Parameters.AddWithValue("Status", "Active");

                        dbCmd.ExecuteNonQuery();
                        dbCmd.Parameters.Clear();
                        
                        message.Append("Logistics uppdated successfully for computer with serial number " + compSerialNo + "!<bR>");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        message.Append(ex.ToString());
                        transaction.Rollback();
                    }
                }
            }
            transaction.Commit();
            dbConn.Close();
            return message.ToString();
        }

        public static string massUpdateLogisticsEquipment(ArrayList compSerialNos, Logistics logs, string connectionString) 
        {
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;
            StringBuilder message = new StringBuilder();

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            dbCmd.Connection = dbConn;

            for (int i = 0; i < compSerialNos.Count; i++)
            {
                string equipSerialNo = compSerialNos[i].ToString();

                if (EquipmentDA.equipmentExist(dbCmd, equipSerialNo) == false)
                {
                    message.Append("Equipment with Serial Number " + equipSerialNo + " does not exist.<bR>");
                }
                else
                {
                    int equipID = EquipmentDA.getInvID(dbCmd, equipSerialNo);
                    Equipment equip = new Equipment();
                    equip = EquipmentDA.getEquipment(dbCmd, equipSerialNo);

                    LogisticsDA.removeLogistics(dbCmd, equipID);

                    try
                    {
                        string sqlCommand = "INSERT INTO Logistics (InvID, Building, Room, PrimaryUser, Name, StartDate, Status) VALUES " +
                            "(@InvID, @Building, @Room, @PrimaryUser, @Name, @StartDate, @Status)";

                        dbCmd.CommandText = sqlCommand;

                        if (logs.Building == "")
                        {
                            dbCmd.Parameters.AddWithValue("Building", equip.CurrentLocation.Building);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("Building", logs.Building);
                        }

                        if (logs.Room == "")
                        {
                            dbCmd.Parameters.AddWithValue("Room", equip.CurrentLocation.Room);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("Room", logs.Room);
                        }

                        if (logs.PrimaryUser == "")
                        {
                            dbCmd.Parameters.AddWithValue("PrimaryUser", equip.CurrentLocation.PrimaryUser);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("PrimaryUser", logs.PrimaryUser);
                        }

                        if (logs.Name == "")
                        {
                            dbCmd.Parameters.AddWithValue("Name", equip.CurrentLocation.Name);
                        }
                        else
                        {
                            dbCmd.Parameters.AddWithValue("Name", logs.Name);
                        }

                        dbCmd.Parameters.AddWithValue("InvID", equipID);
                        dbCmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
                        dbCmd.Parameters.AddWithValue("Status", "Active");

                        dbCmd.ExecuteNonQuery();
                        dbCmd.Parameters.Clear();

                        message.Append("Logistics uppdated successfully for computer with serial number " + equipSerialNo + "!<bR>");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        message.Append(ex.ToString());
                        transaction.Rollback();
                    }
                }
            }
            transaction.Commit();
            dbConn.Close();
            return message.ToString();
        }

    }
}
