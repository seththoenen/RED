using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
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

        public static string massUpdateLogisticsComputer(List<int> ids, Logistics logs) 
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
            dbCmd.Connection = dbConn;

            for (int i = 0; i < ids.Count; i++)
            { 
                int invID = ids[i];

                Computer comp = new Computer();
                comp = ComputerDA.getComputer(dbCmd, invID);

                LogisticsDA.removeLogistics(dbCmd, invID);

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

                    dbCmd.Parameters.AddWithValue("InvID", invID);
                    dbCmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
                    dbCmd.Parameters.AddWithValue("Status", "Active");

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                        
                    message.Append("Logistics uppdated successfully for computer with serial number " + comp.SerialNo + "!<bR>");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    message.Append(ex.ToString());
                    transaction.Rollback();
                }
            }
            transaction.Commit();
            dbConn.Close();
            return message.ToString();
        }

        public static string massUpdateLogisticsEquipment(List<int> ids, Logistics logs) 
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
            dbCmd.Connection = dbConn;

            for (int i = 0; i < ids.Count; i++)
            {
                int invID = ids[i];
                Equipment equip = new Equipment();
                equip = EquipmentDA.getEquipment(dbCmd, invID);

                LogisticsDA.removeLogistics(dbCmd, invID);

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

                    dbCmd.Parameters.AddWithValue("InvID", invID);
                    dbCmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
                    dbCmd.Parameters.AddWithValue("Status", "Active");

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    message.Append("Logistics uppdated successfully for computer with serial number " + equip.SerialNo + "!<bR>");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    message.Append(ex.ToString());
                    transaction.Rollback();
                }
            }
            transaction.Commit();
            dbConn.Close();
            return message.ToString();
        }

    }
}
