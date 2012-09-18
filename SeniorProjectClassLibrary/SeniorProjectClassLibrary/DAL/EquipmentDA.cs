using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SeniorProject
{
    public class EquipmentDA
    {
        public static string saveEquipment(ArrayList equipment, string connectionString)
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
                for (int i = 0; i < equipment.Count; i++)
                {
                    Equipment equip = (Equipment)equipment[i];

                    //Insert Into Inventory Table
                    string sqlCommand = "INSERT INTO Inventory (SMSUTag, SerialNo, Manufacturer, Model, PurchasePrice, Notes, Status, PhysicalAddress) " +
                        "VALUES (@SMSUTag, @SerialNo, @Manufacturer, @Model, @PurchasePrice, @Notes, @Status, @PhysicalAddress)";

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.Parameters.AddWithValue("SMSUtag", equip.SMSUtag);
                    dbCmd.Parameters.AddWithValue("SerialNo", equip.SerialNo);
                    dbCmd.Parameters.AddWithValue("Manufacturer", equip.Manufacturer);
                    dbCmd.Parameters.AddWithValue("Model", equip.Model);
                    dbCmd.Parameters.AddWithValue("PurchasePrice", equip.PurchasePrice);
                    dbCmd.Parameters.AddWithValue("Notes", equip.Notes);
                    dbCmd.Parameters.AddWithValue("Status", equip.Status);
                    dbCmd.Parameters.AddWithValue("PhysicalAddress", equip.PhysicalAddress);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    //Get InvID
                    equip.InvID = ComputerDA.getInvID(dbCmd, equip.SerialNo);

                    //Insert Into Computer Table
                    sqlCommand = "INSERT INTO Equipment (InvID, EquipmentType, Connectivity, NetworkCapable, Other) " +
                        "VALUES (@InvID, @EquipmentType, @Connectivity, @NetworkCapable, @Other)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", equip.InvID);
                    dbCmd.Parameters.AddWithValue("EquipmentType", equip.EquipmentType);
                    dbCmd.Parameters.AddWithValue("Connectivity", equip.Connectivity);
                    dbCmd.Parameters.AddWithValue("NetworkCapable", equip.NetworkCapable);
                    dbCmd.Parameters.AddWithValue("Other", equip.Other);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    sqlCommand = "INSERT INTO Logistics (InvID, Building, Room, PrimaryUser, Name, StartDate, Status) " +
                        "VALUES (@InvID5, @Building, @Room, @PrimaryUser, @Name, @StartDate, @Status)";

                    dbCmd.CommandText = sqlCommand;
                        
                    dbCmd.Parameters.AddWithValue("InvID5", equip.InvID);
                    dbCmd.Parameters.AddWithValue("Building", equip.CurrentLocation.Building);
                    dbCmd.Parameters.AddWithValue("Room", equip.CurrentLocation.Room);
                    dbCmd.Parameters.AddWithValue("PrimaryUser", equip.CurrentLocation.PrimaryUser);
                    dbCmd.Parameters.AddWithValue("Name", equip.CurrentLocation.Name);
                    dbCmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
                    dbCmd.Parameters.AddWithValue("Status", "Active");
                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    PODA.addLink(dbCmd, equip.InvID, equip.PO.ID);

                    for (int j = 0; j < equip.Groups.Count; j++)
                    { 
                        Group grp = new Group();
                        grp = (Group)equip.Groups[j];
                        GroupDA.addLink(dbCmd, grp.ID, equip.InvID);
                    }

                    for (int j = 0; j < equip.Licenses.Count; j++)
                    {
                        License li = new License();
                        li = (License)equip.Licenses[j];
                        LicenseDA.addLicense(dbCmd, li.ID, equip.InvID);
                    }

                    for (int j = 0; j < equip.Warranties.Count; j++)
                    {
                        WarrantyDA.addWarranty(dbCmd, equip.InvID, (Warranty)equip.Warranties[j]);
                    }
                }
                transaction.Commit();
                dbConn.Close();

                message.Append("Operation successfull!<bR>");
                return message.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append("Database Error: " + ex.ToString() + "<bR>");
                transaction.Rollback();
                return message.ToString();
            }
        }

        public static Equipment getEquipment(int invID, string connectionString)
        {
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;
            SqlDataReader dbReader;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;
            dbCmd.Connection = dbConn;

            try
            {
                string sql = "SELECT * FROM Inventory, Equipment, Logistics WHERE Inventory.InvID = Equipment.InvID AND "
                + "Inventory.InvID = Logistics.InvID AND Inventory.InvID = @InvID AND Logistics.Status = @Status";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("InvID", invID);
                dbCmd.Parameters.AddWithValue("Status", "Active");



                dbReader = dbCmd.ExecuteReader();
                Equipment equip = new Equipment();

                while (dbReader.Read())
                {
                    equip.InvID = Convert.ToInt32(invID);
                    equip.SMSUtag = dbReader["SMSUtag"].ToString();
                    equip.SerialNo = dbReader["SerialNo"].ToString();
                    equip.Manufacturer = dbReader["Manufacturer"].ToString();
                    equip.Model = dbReader["Model"].ToString();
                    equip.PurchasePrice = Convert.ToDouble(dbReader["PurchasePrice"]);
                    equip.Notes = dbReader["Notes"].ToString();
                    equip.PhysicalAddress = dbReader["PhysicalAddress"].ToString();

                    equip.EquipmentType = dbReader["EquipmentType"].ToString();
                    equip.Connectivity = dbReader["Connectivity"].ToString();
                    equip.NetworkCapable = dbReader["NetworkCapable"].ToString();
                    equip.Other = dbReader["Other"].ToString();

                    equip.Status = dbReader["Status"].ToString();
                    equip.CurrentLocation.Building = dbReader["Building"].ToString();
                    equip.CurrentLocation.Room = dbReader["Room"].ToString();
                    equip.CurrentLocation.PrimaryUser = dbReader["PrimaryUser"].ToString();
                    equip.CurrentLocation.Name = dbReader["Name"].ToString();

                }
                dbReader.Close();
                dbCmd.Parameters.Clear();

                equip.PO = PODA.getPODetails(dbCmd, equip.InvID);
                equip.Groups = GroupDA.getGroups(dbCmd, equip.InvID);

                dbReader.Close();

                transaction.Commit();
                dbConn.Close();

                return equip;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
        }

        public static Equipment getEquipment(SqlCommand cmd, string serialNo)
        {

            SqlDataReader dbReader;

            string sql = "SELECT * FROM Inventory, Equipment, Logistics WHERE Inventory.InvID = Equipment.InvID AND "
            + "Inventory.InvID = Logistics.InvID AND Inventory.SerialNo = @SerialNo AND Logistics.Status = @Status";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("SerialNo", serialNo);
            cmd.Parameters.AddWithValue("Status", "Active");



            dbReader = cmd.ExecuteReader();
            Equipment equip = new Equipment();

            while (dbReader.Read())
            {
                equip.InvID = Convert.ToInt32(dbReader["InvID"]);
                equip.SMSUtag = dbReader["SMSUtag"].ToString();
                equip.SerialNo = dbReader["SerialNo"].ToString();
                equip.Manufacturer = dbReader["Manufacturer"].ToString();
                equip.Model = dbReader["Model"].ToString();
                equip.PurchasePrice = Convert.ToDouble(dbReader["PurchasePrice"]);
                equip.Notes = dbReader["Notes"].ToString();

                equip.EquipmentType = dbReader["EquipmentType"].ToString();
                equip.Connectivity = dbReader["Connectivity"].ToString();
                equip.NetworkCapable = dbReader["NetworkCapable"].ToString();
                equip.Other = dbReader["Other"].ToString();

                equip.Status = dbReader["Status"].ToString();
                equip.CurrentLocation.Building = dbReader["Building"].ToString();
                equip.CurrentLocation.Room = dbReader["Room"].ToString();
                equip.CurrentLocation.PrimaryUser = dbReader["PrimaryUser"].ToString();
                equip.CurrentLocation.Name = dbReader["Name"].ToString();

            }
            dbReader.Close();
            cmd.Parameters.Clear();

            equip.PO = PODA.getPODetails(cmd, equip.InvID);
            equip.Groups = GroupDA.getGroups(cmd, equip.InvID);

            dbReader.Close();

            return equip;

        }

        public static bool equipmentExist(SqlCommand cmd, string serialNo)
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT Equipment.InvID FROM Inventory, Equipment WHERE Inventory.InvID = Equipment.InvID AND SerialNO = @SerialNo";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@SerialNo", serialNo);

            dbReader = cmd.ExecuteReader();
            int invId = 0;

            while (dbReader.Read())
            {
                invId = Convert.ToInt32(dbReader["InvID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            if (invId > 0)
                return true;
            else
                return false;
        }

        public static Boolean equipmentExist(string serialNo, string connectionString)
        {
            SqlConnection dbConn;
            SqlCommand dbCmd;
            SqlDataReader dbReader;
            string sConnection;
            string sql;

            sConnection = connectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();

            sql = "SELECT * FROM Inventory, Equipment Where Inventory.InvID = Equipment.InvID AND SerialNo = @SerialNo";

            dbCmd = new SqlCommand();
            dbCmd.CommandText = sql;
            dbCmd.Parameters.AddWithValue("@SerialNo", serialNo);
            dbCmd.Connection = dbConn;

            dbReader = dbCmd.ExecuteReader();
            ArrayList equipment = new ArrayList();

            while (dbReader.Read())
            {
                Equipment equip = new Equipment();
                equip.SerialNo = dbReader["SerialNo"].ToString();
                equipment.Add(equip);
            }

            if (equipment.Count > 0)
                return true;
            else
                return false;
        }

        public static int getInvID(SqlCommand cmd, string equipSerialNo)
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT InvID FROM Inventory WHERE SerialNo = @SerialNo";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@SerialNo", equipSerialNo);


            dbReader = cmd.ExecuteReader();
            int invId = 0;

            while (dbReader.Read())
            {
                invId = Convert.ToInt32(dbReader["InvID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return invId;
        }

        public static string updateEquipment(Equipment oEquip, Equipment equip, string connectionString)
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

            if (oEquip.SerialNo.ToUpper() != equip.SerialNo.ToUpper() && EquipmentDA.equipmentExist(dbCmd, equip.SerialNo))
            {
                message.Append("That serial number is already in use. Please try again.<bR>");
            }
            else
            {
                try
                {

                    String sqlCommand = "UPDATE Inventory SET SMSUTag = @SMSUTag, SerialNo = @SerialNo, Manufacturer = @Manufacturer, Model = @Model, PurchasePrice = @PurchasePrice, " +
                        "Notes = @Notes, Status = @Status, PhysicalAddress = @PhysicalAddress WHERE InvID = @InvID";


                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("SMSUTag", equip.SMSUtag);
                    dbCmd.Parameters.AddWithValue("SerialNo", equip.SerialNo);
                    dbCmd.Parameters.AddWithValue("Manufacturer", equip.Manufacturer);
                    dbCmd.Parameters.AddWithValue("Model", equip.Model);
                    dbCmd.Parameters.AddWithValue("PurchasePrice", equip.PurchasePrice);
                    dbCmd.Parameters.AddWithValue("Notes", equip.Notes);
                    dbCmd.Parameters.AddWithValue("PhysicalAddress", equip.PhysicalAddress);

                    if (oEquip.Status != "Transferred")
                    {
                        dbCmd.Parameters.AddWithValue("Status", equip.Status);
                    }
                    else
                    {
                        dbCmd.Parameters.AddWithValue("Status", oEquip.Status);
                    }

                    dbCmd.Parameters.AddWithValue("InvID", equip.InvID);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    sqlCommand = "UPDATE Equipment SET EquipmentType = @EquipmentType, Connectivity = @Connectivity, NetworkCapable = @NetworkCapable, Other = @Other WHERE " +
                        "InvID = @InvID";

                    dbCmd.Parameters.AddWithValue("InvID", equip.InvID);
                    dbCmd.Parameters.AddWithValue("EquipmentType", equip.EquipmentType);
                    dbCmd.Parameters.AddWithValue("Connectivity", equip.Connectivity);
                    dbCmd.Parameters.AddWithValue("NetworkCapable", equip.NetworkCapable);
                    dbCmd.Parameters.AddWithValue("Other", equip.Other);

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    if (equip.CurrentLocation.Name == oEquip.CurrentLocation.Name && equip.CurrentLocation.Building == oEquip.CurrentLocation.Building
                        && equip.CurrentLocation.Room == oEquip.CurrentLocation.Room && equip.CurrentLocation.PrimaryUser == oEquip.CurrentLocation.PrimaryUser)
                    {
                        //do nothing
                    }
                    else
                    {
                        LogisticsDA.removeLogistics(dbCmd, equip.InvID);
                        LogisticsDA.addLogistics(dbCmd, equip);
                    }

                    if (oEquip.PO.ID != equip.PO.ID)
                    {
                        PODA.deleteLink(dbCmd, equip.InvID);
                        PODA.addLink(dbCmd, equip.InvID, equip.PO.ID);
                    }

                    transaction.Commit();
                    dbConn.Close();
                    message.Append("Update Successful!<bR>");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    message.Append(ex.ToString());
                    transaction.Rollback();
                }
            }

            return message.ToString();
        }

        public static string updateEquipment(ArrayList equipment, string connectionString)
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

            try
            {
                for (int i = 0; i < equipment.Count; i++)
                {
                    Equipment equip = new Equipment();
                    equip = (Equipment)equipment[i];


                    if (EquipmentDA.equipmentExist(dbCmd, equip.SerialNo) == true)
                    {
                        Equipment oEquip = EquipmentDA.getEquipment(dbCmd, equip.SerialNo);

                        StringBuilder sqlCommand = new StringBuilder();
                        sqlCommand.Append("UPDATE Inventory SET ");
                        if (equip.SMSUtag != "")
                        {
                            sqlCommand.Append("SMSUtag = @SMSUtag,");
                            dbCmd.Parameters.AddWithValue("SMSUtag", equip.SMSUtag);
                        }
                        if (equip.Manufacturer != "")
                        {
                            sqlCommand.Append("Manufacturer = @Manufacturer,");
                            dbCmd.Parameters.AddWithValue("Manufacturer", equip.Manufacturer);
                        }
                        if (equip.Model != "")
                        {
                            sqlCommand.Append("Model = @Model,");
                            dbCmd.Parameters.AddWithValue("Model", equip.Model);
                        }

                        double? price = equip.PurchasePrice;
                        if (price.HasValue)
                        {
                            sqlCommand.Append("PurchasePrice = @PurchasePrice,");
                            dbCmd.Parameters.AddWithValue("PurchasePrice", equip.PurchasePrice);
                        }
                        if (equip.Notes != "")
                        {
                            sqlCommand.Append("Notes = @Notes,");
                            dbCmd.Parameters.AddWithValue("Notes", equip.Notes);
                        }
                        if (equip.PhysicalAddress!= "")
                        {
                            sqlCommand.Append("PhysicalAddress = @PhysicalAddress,");
                            dbCmd.Parameters.AddWithValue("PhysicalAddress", equip.PhysicalAddress);
                        }
                        if (equip.Status != "")
                        {
                            if (oEquip.Status != "Transferred")
                            {
                                sqlCommand.Append("Status = @Status,");
                                dbCmd.Parameters.AddWithValue("Status", equip.Status);
                            }
                        }

                        sqlCommand.Remove((sqlCommand.Length - 1), 1);
                        sqlCommand.Append(" WHERE InvID = @InvID");
                        dbCmd.Parameters.AddWithValue("InvID", oEquip.InvID);

                        dbCmd.CommandText = sqlCommand.ToString();

                        if (dbCmd.CommandText != "UPDATE Inventory SET WHERE InvID = @InvID")
                        {
                            dbCmd.ExecuteNonQuery();
                        }

                        dbCmd.Parameters.Clear();


                        sqlCommand = new StringBuilder();
                        sqlCommand.Append("UPDATE Equipment SET ");
                        if (equip.EquipmentType != "")
                        {
                            sqlCommand.Append("EquipmentType = @EquipmentType,");
                            dbCmd.Parameters.AddWithValue("EquipmentType", equip.EquipmentType);
                        }
                        if (equip.Connectivity != "")
                        {
                            sqlCommand.Append("Connectivity = @Connectivity,");
                            dbCmd.Parameters.AddWithValue("Connectivity", equip.Connectivity);
                        }
                        if (equip.NetworkCapable != "")
                        {
                            sqlCommand.Append("NetworkCapable = @NetworkCapable,");
                            dbCmd.Parameters.AddWithValue("NetworkCapable", equip.NetworkCapable);
                        }
                        if (equip.Other != "")
                        {
                            sqlCommand.Append("Other = @Other,");
                            dbCmd.Parameters.AddWithValue("Other", equip.Other);
                        }

                        sqlCommand.Remove((sqlCommand.Length - 1), 1);
                        sqlCommand.Append(" WHERE InvID = @InvID");
                        dbCmd.Parameters.AddWithValue("InvID", oEquip.InvID);

                        dbCmd.CommandText = sqlCommand.ToString();

                        if (dbCmd.CommandText != "UPDATE Equipment SET WHERE InvID = @InvID")
                        {
                            dbCmd.ExecuteNonQuery();
                        }

                        dbCmd.Parameters.Clear();

                        if (equip.PO.ID != null)
                        {
                            PODA.deleteLink(dbCmd, oEquip.InvID);
                            PODA.addLink(dbCmd, oEquip.InvID, equip.PO.ID);
                        }

                        message.Append("Equipment with Service Tag " + equip.SerialNo + " updated successfully!<bR>");
                    }
                    else
                    {
                        message.Append("Equipment with Service Tag " + equip.SerialNo + " does not exist.<bR>");
                    }
                }
                transaction.Commit();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Clear();
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }
            return message.ToString();
        }
    }
}
