using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
{
    public class ComputerDA
    {
        public static string saveComputers(List<Computer> computers)
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
                for (int i = 0; i < computers.Count; i++)
                {
                    Computer comp = (Computer)computers[i];

                    //Insert Into Inventory Table
                    string sqlCommand = "INSERT INTO Inventory (SMSUTag, SerialNo, Manufacturer, Model, PurchasePrice, Notes, Status, PhysicalAddress) " +
                        "VALUES (@SMSUTag, @SerialNo, @Manufacturer, @Model, @PurchasePrice, @Notes, @Status, @PhysicalAddress)";

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.Parameters.AddWithValue("SMSUtag", comp.SMSUtag);
                    dbCmd.Parameters.AddWithValue("SerialNo", comp.SerialNo);
                    dbCmd.Parameters.AddWithValue("Manufacturer", comp.Manufacturer);
                    dbCmd.Parameters.AddWithValue("Model", comp.Model);
                    dbCmd.Parameters.AddWithValue("PurchasePrice", comp.PurchasePrice);
                    dbCmd.Parameters.AddWithValue("Notes", comp.Notes);
                    dbCmd.Parameters.AddWithValue("Status", comp.Status);
                    dbCmd.Parameters.AddWithValue("PhysicalAddress", comp.PhysicalAddress);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    //Get InvID
                    comp.InvID = ComputerDA.getInvID(dbCmd, comp.SerialNo);

                    //Insert Into Computer Table
                    sqlCommand = "INSERT INTO Computer (InvID, CPU, VideoCard, HardDrive, Memory, OpticalDrive, RemovableMedia, USBPorts, OtherConnectivity, FormFactor, Type) " +
                        "VALUES (@InvID, @CPU, @VideoCard, @HardDrive, @Memory, @OpticalDrive, @RemovableMedia, @USBPorts, @OtherConnectivity, @FormFactor, @Type)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", comp.InvID);
                    dbCmd.Parameters.AddWithValue("CPU", comp.CPU);
                    dbCmd.Parameters.AddWithValue("VideoCard", comp.VideoCard);
                    dbCmd.Parameters.AddWithValue("HardDrive", comp.HardDrive);
                    dbCmd.Parameters.AddWithValue("Memory", comp.Memory);
                    dbCmd.Parameters.AddWithValue("OpticalDrive", comp.OpticalDrive);
                    dbCmd.Parameters.AddWithValue("RemovableMedia", comp.RemovableMedia);
                    dbCmd.Parameters.AddWithValue("USBPorts", comp.USBports);
                    dbCmd.Parameters.AddWithValue("OtherConnectivity", comp.OtherConnectivity);
                    dbCmd.Parameters.AddWithValue("FormFactor", comp.Size);
                    dbCmd.Parameters.AddWithValue("Type", comp.Type);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    comp.CompID = ComputerDA.getCompID(dbCmd, comp.InvID);

                    sqlCommand = "INSERT INTO Logistics (InvID, Building, Room, PrimaryUser, Name, StartDate, Status) " +
                        "VALUES (@InvID5, @Building, @Room, @PrimaryUser, @Name, @StartDate, @Status)";

                    dbCmd.CommandText = sqlCommand;
                        
                    dbCmd.Parameters.AddWithValue("InvID5", comp.InvID);
                    dbCmd.Parameters.AddWithValue("Building", comp.CurrentLocation.Building);
                    dbCmd.Parameters.AddWithValue("Room", comp.CurrentLocation.Room);
                    dbCmd.Parameters.AddWithValue("PrimaryUser", comp.CurrentLocation.PrimaryUser);
                    dbCmd.Parameters.AddWithValue("Name", comp.CurrentLocation.Name);
                    dbCmd.Parameters.AddWithValue("StartDate", DateTime.Now.ToShortDateString());
                    dbCmd.Parameters.AddWithValue("Status", "Active");
                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    for (int j = 0; j < comp.Monitors.Count; j++)
                    {
                        sqlCommand = "INSERT INTO MonitorComputer (MonID, CompID) VALUES (@MonID, @CompID)";
                        dbCmd.CommandText = sqlCommand;

                        Monitor mon = new Monitor();
                        mon = (Monitor)comp.Monitors[j];

                        dbCmd.Parameters.AddWithValue("MonID", mon.ID);
                        dbCmd.Parameters.AddWithValue("CompID", comp.CompID);

                        dbCmd.ExecuteNonQuery();
                        dbCmd.Parameters.Clear();
                            
                    }

                    PODA.addLink(dbCmd, comp.InvID, comp.PO.ID);
                    GroupDA.updateGroups(dbCmd, comp.Groups, comp.InvID);

                    for (int j = 0; j < comp.Licenses.Count; j++)
                    { 
                        License li = new License();
                        li = (License)comp.Licenses[j];
                        LicenseDA.addLicense(dbCmd, li.ID, comp.InvID);
                    }

                    for (int j = 0; j < comp.Warranties.Count; j++)
                    {
                        WarrantyDA.addWarranty(dbCmd, comp.InvID, (Warranty)comp.Warranties[j]);
                    }
                }
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

        public static int getInvID(SqlCommand cmd, string compSerialNo)
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT InvID FROM Inventory WHERE SerialNo = @SerialNo";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@SerialNo", compSerialNo);
            

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

        public static int getCompID(SqlCommand cmd, int invID)
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT CompID FROM Computer WHERE InvID = @InvID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@InvID", invID);

            dbReader = cmd.ExecuteReader();
            int compID = 0;

            while (dbReader.Read())
            {
                compID = Convert.ToInt32(dbReader["CompID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return compID;
        }

        public static Boolean computerExist(string serialNo)
        {
            SqlConnection dbConn;
            SqlCommand dbCmd;
            SqlDataReader dbReader;
            string sConnection;
            string sql;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();

            sql = "SELECT SerialNo FROM Inventory, Computer Where Inventory.InvID = Computer.InvID AND SerialNo = @SerialNo";

            dbCmd = new SqlCommand();
            dbCmd.CommandText = sql;
            dbCmd.Parameters.AddWithValue("@SerialNo", serialNo);
            dbCmd.Connection = dbConn;

            dbReader = dbCmd.ExecuteReader();
            List<Computer> desktops = new List<Computer>();

            while (dbReader.Read())
            {
                Computer comp = new Computer();
                comp.SerialNo = dbReader["SerialNo"].ToString();
                desktops.Add(comp);
            }
            dbReader.Close();
            dbCmd.Parameters.Clear();

            if (desktops.Count > 0)
                return true;
            else
                return false;
        }

        public static bool computerExist(SqlCommand cmd, string serialNo)
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT Computer.InvID FROM Inventory, Computer WHERE Inventory.InvID = Computer.InvID AND SerialNO = @SerialNo";

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

        public static bool computerTransferred(SqlCommand cmd, string serialNo)
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT Status FROM Inventory WHERE SerialNO = @SerialNo";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@SerialNo", serialNo);

            dbReader = cmd.ExecuteReader();
            string status = "";

            while (dbReader.Read())
            {
                status = dbReader["Status"].ToString();
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            if (status != "Transferred")
                return false;
            else
                return true;
        }

<<<<<<< HEAD
        public static Computer getComputer(int invID, string connectionString)
=======
        public static Computer getComputer(string invID)
>>>>>>> parent of 2a12043... Replaced Array Lists with Lists
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
            dbCmd.Connection = dbConn;

            try
            {
                string sql = "SELECT CompID, SMSUTag, SerialNo, Manufacturer, Model, PurchasePrice, Notes, PhysicalAddress, CPU, VideoCard, HardDrive, Memory, OpticalDrive, RemovableMedia, USBports,"+
                    " OtherConnectivity, FormFactor, Type, Inventory.Status, Building, Room, PrimaryUser, Name FROM Inventory, Computer, Logistics WHERE Inventory.InvID = Computer.InvID AND "
                + "Inventory.InvID = Logistics.InvID AND Inventory.InvID = @InvID AND Logistics.Status = @Status";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("InvID", invID);
                dbCmd.Parameters.AddWithValue("Status", "Active");

                

                dbReader = dbCmd.ExecuteReader();
                Computer comp = new Computer();

                while (dbReader.Read())
                {
                    comp.InvID = Convert.ToInt32(invID);
                    comp.CompID = Convert.ToInt32(dbReader["CompID"]);
                    comp.SMSUtag = dbReader["SMSUtag"].ToString();
                    comp.SerialNo = dbReader["SerialNo"].ToString();
                    comp.Manufacturer = dbReader["Manufacturer"].ToString();
                    comp.Model = dbReader["Model"].ToString();
                    comp.PurchasePrice = Convert.ToDouble(dbReader["PurchasePrice"]);
                    comp.Notes = dbReader["Notes"].ToString();
                    comp.PhysicalAddress = dbReader["PhysicalAddress"].ToString();
                    comp.CPU = dbReader["CPU"].ToString();
                    comp.VideoCard = dbReader["VideoCard"].ToString();
                    comp.HardDrive = dbReader["HardDrive"].ToString();
                    comp.Memory = dbReader["Memory"].ToString();
                    comp.OpticalDrive = dbReader["OpticalDrive"].ToString();
                    comp.RemovableMedia = dbReader["RemovableMedia"].ToString();
                    comp.USBports = Convert.ToInt32(dbReader["USBports"]);
                    comp.OtherConnectivity = dbReader["OtherConnectivity"].ToString();
                    comp.Size = dbReader["FormFactor"].ToString();
                    comp.Type = dbReader["Type"].ToString();
                    comp.Status = dbReader["Status"].ToString();
                    comp.CurrentLocation.Building = dbReader["Building"].ToString();
                    comp.CurrentLocation.Room = dbReader["Room"].ToString();
                    comp.CurrentLocation.PrimaryUser = dbReader["PrimaryUser"].ToString();
                    comp.CurrentLocation.Name = dbReader["Name"].ToString();

                }
                dbReader.Close();
                dbCmd.Parameters.Clear();
                

                comp.Monitors = MonitorDA.getMonitor(dbCmd,comp.CompID);
                comp.PO = PODA.getPODetails(dbCmd, comp.InvID);
                comp.Groups = GroupDA.getGroups(dbCmd, comp.InvID);

                dbReader.Close();

                transaction.Commit();
                dbConn.Close();
                
                return comp;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
            
        }

        public static Computer getComputer(SqlCommand cmd, string serialNo)
        {
            SqlDataReader dbReader;

            string sql = "SELECT Inventory.InvID, CompID, SMSUTag, SerialNo, Manufacturer, Model, PurchasePrice, Notes, CPU, VideoCard, HardDrive, "+
                "Memory, OpticalDrive, RemovableMedia, USBPorts, OtherConnectivity, FormFactor, Type, Inventory.Status, Building, Room, PrimaryUser, Name "+
                "FROM Inventory, Computer, Logistics WHERE Inventory.InvID = Computer.InvID AND "
            + "Inventory.InvID = Logistics.InvID AND Inventory.SerialNo = @SerialNo AND Logistics.Status = @Status";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("SerialNo", serialNo);
            cmd.Parameters.AddWithValue("Status", "Active");



            dbReader = cmd.ExecuteReader();
            Computer comp = new Computer();

            while (dbReader.Read())
            {
                comp.InvID = Convert.ToInt32(dbReader["InvID"]);
                comp.CompID = Convert.ToInt32(dbReader["CompID"]);
                comp.SMSUtag = dbReader["SMSUtag"].ToString();
                comp.SerialNo = dbReader["SerialNo"].ToString();
                comp.Manufacturer = dbReader["Manufacturer"].ToString();
                comp.Model = dbReader["Model"].ToString();
                comp.PurchasePrice = Convert.ToDouble(dbReader["PurchasePrice"]);
                comp.Notes = dbReader["Notes"].ToString();
                comp.CPU = dbReader["CPU"].ToString();
                comp.VideoCard = dbReader["VideoCard"].ToString();
                comp.HardDrive = dbReader["HardDrive"].ToString();
                comp.Memory = dbReader["Memory"].ToString();
                comp.OpticalDrive = dbReader["OpticalDrive"].ToString();
                comp.RemovableMedia = dbReader["RemovableMedia"].ToString();
                comp.USBports = Convert.ToInt32(dbReader["USBports"]);
                comp.OtherConnectivity = dbReader["OtherConnectivity"].ToString();
                comp.Size = dbReader["FormFactor"].ToString();
                comp.Type = dbReader["Type"].ToString();
                comp.Status = dbReader["Status"].ToString();
                comp.CurrentLocation.Building = dbReader["Building"].ToString();
                comp.CurrentLocation.Room = dbReader["Room"].ToString();
                comp.CurrentLocation.PrimaryUser = dbReader["PrimaryUser"].ToString();
                comp.CurrentLocation.Name = dbReader["Name"].ToString();

            }
            dbReader.Close();
            cmd.Parameters.Clear();


            comp.Monitors = MonitorDA.getMonitor(cmd, comp.CompID);
            comp.PO = PODA.getPODetails(cmd, comp.InvID);
            comp.Groups = GroupDA.getGroups(cmd, comp.InvID);

            return comp;

        }

        public static Computer getComputer(SqlCommand cmd, int invID)
        {
            SqlDataReader dbReader;

            string sql = "SELECT SerialNo, CompID, SMSUTag, Manufacturer, Model, PurchasePrice, Notes, CPU, VideoCard, "+
                "HardDrive, Memory, OpticalDrive, RemovableMedia, USBPorts, OtherConnectivity, FormFactor, Type, Inventory.Status, Building, Room, PrimaryUser, Name "+
                "FROM Inventory, Computer, Logistics WHERE Inventory.InvID = Computer.InvID AND "
            + "Inventory.InvID = Logistics.InvID AND Inventory.InvID = @InvID AND Logistics.Status = @Status";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("InvID", invID);
            cmd.Parameters.AddWithValue("Status", "Active");

            dbReader = cmd.ExecuteReader();
            Computer comp = new Computer();

            while (dbReader.Read())
            {
                comp.CompID = Convert.ToInt32(dbReader["CompID"]);
                comp.SMSUtag = dbReader["SMSUtag"].ToString();
                comp.SerialNo = dbReader["SerialNo"].ToString();
                comp.Manufacturer = dbReader["Manufacturer"].ToString();
                comp.Model = dbReader["Model"].ToString();
                comp.PurchasePrice = Convert.ToDouble(dbReader["PurchasePrice"]);
                comp.Notes = dbReader["Notes"].ToString();
                comp.CPU = dbReader["CPU"].ToString();
                comp.VideoCard = dbReader["VideoCard"].ToString();
                comp.HardDrive = dbReader["HardDrive"].ToString();
                comp.Memory = dbReader["Memory"].ToString();
                comp.OpticalDrive = dbReader["OpticalDrive"].ToString();
                comp.RemovableMedia = dbReader["RemovableMedia"].ToString();
                comp.USBports = Convert.ToInt32(dbReader["USBports"]);
                comp.OtherConnectivity = dbReader["OtherConnectivity"].ToString();
                comp.Size = dbReader["FormFactor"].ToString();
                comp.Type = dbReader["Type"].ToString();
                comp.Status = dbReader["Status"].ToString();
                comp.CurrentLocation.Building = dbReader["Building"].ToString();
                comp.CurrentLocation.Room = dbReader["Room"].ToString();
                comp.CurrentLocation.PrimaryUser = dbReader["PrimaryUser"].ToString();
                comp.CurrentLocation.Name = dbReader["Name"].ToString();

            }
            dbReader.Close();
            cmd.Parameters.Clear();


            comp.Monitors = MonitorDA.getMonitor(cmd, comp.CompID);
            comp.PO = PODA.getPODetails(cmd, comp.InvID);
            comp.Groups = GroupDA.getGroups(cmd, comp.InvID);

            return comp;

        }

        public static string updateComputer(Computer oComp, Computer comp)
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

            if (comp.SerialNo.ToUpper() != oComp.SerialNo.ToUpper() && computerExist(comp.SerialNo))
            {
                message.Append("That Service tag is already in use. Please try again.<bR>");
            }
            else
            {
                try
                {
                    
                    String sqlCommand = "UPDATE Inventory SET SMSUTag = @SMSUTag, SerialNo = @SerialNo, Manufacturer = @Manufacturer, Model = @Model, PurchasePrice = @PurchasePrice, " +
                        "Notes = @Notes, Status = @Status, PhysicalAddress = @PhysicalAddress WHERE InvID = @InvID";


                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("SMSUTag", comp.SMSUtag);
                    dbCmd.Parameters.AddWithValue("SerialNo", comp.SerialNo);
                    dbCmd.Parameters.AddWithValue("Manufacturer", comp.Manufacturer);
                    dbCmd.Parameters.AddWithValue("Model", comp.Model);
                    dbCmd.Parameters.AddWithValue("PurchasePrice", comp.PurchasePrice);
                    dbCmd.Parameters.AddWithValue("Notes", comp.Notes);
                    dbCmd.Parameters.AddWithValue("Status", comp.Status);
                    dbCmd.Parameters.AddWithValue("InvID", comp.InvID);
                    dbCmd.Parameters.AddWithValue("PhysicalAddress", comp.PhysicalAddress);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    sqlCommand = "UPDATE Computer SET CPU = @CPU, VideoCard = @VideoCard, HardDrive = @HardDrive, Memory = @Memory, OpticalDrive = @OpticalDrive, " +
                        "RemovableMedia = @RemovableMedia, USBPorts = @USBPorts, OtherConnectivity = @OtherConnectivity, FormFactor = @FormFactor, Type = @Type WHERE " +
                        "InvID = @InvID";

                    dbCmd.Parameters.AddWithValue("InvID", comp.InvID);
                    dbCmd.Parameters.AddWithValue("CPU", comp.CPU);
                    dbCmd.Parameters.AddWithValue("VideoCard", comp.VideoCard);
                    dbCmd.Parameters.AddWithValue("HardDrive", comp.HardDrive);
                    dbCmd.Parameters.AddWithValue("Memory", comp.Memory);
                    dbCmd.Parameters.AddWithValue("OpticalDrive", comp.OpticalDrive);
                    dbCmd.Parameters.AddWithValue("RemovableMedia", comp.RemovableMedia);
                    dbCmd.Parameters.AddWithValue("USBPorts", comp.USBports);
                    dbCmd.Parameters.AddWithValue("OtherConnectivity", comp.OtherConnectivity);
                    dbCmd.Parameters.AddWithValue("FormFactor", comp.Size);
                    dbCmd.Parameters.AddWithValue("Type", comp.Type);

                    dbCmd.CommandText = sqlCommand;
                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    if (comp.CurrentLocation.Name == oComp.CurrentLocation.Name && comp.CurrentLocation.Building == oComp.CurrentLocation.Building
                        && comp.CurrentLocation.Room == oComp.CurrentLocation.Room && comp.CurrentLocation.PrimaryUser == oComp.CurrentLocation.PrimaryUser)
                    {
                        //do nothing
                    }
                    else
                    {
                        LogisticsDA.removeLogistics(dbCmd, comp.InvID);
                        LogisticsDA.addLogistics(dbCmd, comp);
                    }

                    if (oComp.PO.ID != comp.PO.ID)
                    {
                        PODA.deleteLink(dbCmd, comp.InvID);
                        PODA.addLink(dbCmd, comp.InvID, comp.PO.ID);
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

        public static void transferComputer(SqlCommand cmd, int invID)
        {
            string sqlCommand = "UPDATE Inventory SET Status = @TransferStatus WHERE InvID = @InventoryID";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("TransferStatus", "Transferred");
            cmd.Parameters.AddWithValue("InventoryID", invID);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static string updateComputers(List<Computer> computers)
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

            try
            {
                for (int i = 0; i < computers.Count; i++)
                {
                    Computer comp = new Computer();
                    comp = (Computer)computers[i];              

                    Computer oComp = ComputerDA.getComputer(dbCmd, comp.SerialNo);
                        
                    StringBuilder sqlCommand = new StringBuilder();
                    sqlCommand.Append("UPDATE Inventory SET ");
                    if (comp.SMSUtag != "")
                    {
                        sqlCommand.Append("SMSUtag = @SMSUtag,");
                        dbCmd.Parameters.AddWithValue("SMSUtag", comp.SMSUtag);
                    }
                    if (comp.Manufacturer != "")
                    {
                        sqlCommand.Append("Manufacturer = @Manufacturer,");
                        dbCmd.Parameters.AddWithValue("Manufacturer", comp.Manufacturer);
                    }
                    if (comp.Model != "")
                    {
                        sqlCommand.Append("Model = @Model,");
                        dbCmd.Parameters.AddWithValue("Model", comp.Model);
                    }

                    double? price = comp.PurchasePrice;
                    if (price.HasValue)
                    {
                        sqlCommand.Append("PurchasePrice = @PurchasePrice,");
                        dbCmd.Parameters.AddWithValue("PurchasePrice", comp.PurchasePrice);
                    }
                    if (comp.Notes != "")
                    {
                        sqlCommand.Append("Notes = @Notes,");
                        dbCmd.Parameters.AddWithValue("Notes", comp.Notes);
                    }
                    if (comp.PhysicalAddress != "")
                    {
                        sqlCommand.Append("PhysicalAddress = @PhysicalAddress,");
                        dbCmd.Parameters.AddWithValue("PhysicalAddress", comp.PhysicalAddress);
                    }
                    if (comp.Status != "")
                    {
                        if (oComp.Status != "Transferred")
                        {
                            sqlCommand.Append("Status = @Status,");
                            dbCmd.Parameters.AddWithValue("Status", comp.Status);
                        }
                    }

                    sqlCommand.Remove((sqlCommand.Length - 1), 1);
                    sqlCommand.Append(" WHERE InvID = @InvID");
                    dbCmd.Parameters.AddWithValue("InvID", oComp.InvID);

                    dbCmd.CommandText = sqlCommand.ToString();

                    if (dbCmd.CommandText != "UPDATE Inventory SET WHERE InvID = @InvID")
                    {
                        dbCmd.ExecuteNonQuery();
                    }

                    dbCmd.Parameters.Clear();


                    sqlCommand = new StringBuilder();
                    sqlCommand.Append("UPDATE Computer SET ");
                    if (comp.CPU != "")
                    {
                        sqlCommand.Append("CPU = @CPU,");
                        dbCmd.Parameters.AddWithValue("CPU", comp.CPU);
                    }
                    if (comp.VideoCard != "")
                    {
                        sqlCommand.Append("VideoCard = @VideoCard,");
                        dbCmd.Parameters.AddWithValue("VideoCard", comp.VideoCard);
                    }
                    if (comp.HardDrive != "")
                    {
                        sqlCommand.Append("HardDrive = @HardDrive,");
                        dbCmd.Parameters.AddWithValue("HardDrive", comp.HardDrive);
                    }
                    if (comp.Memory != "")
                    {
                        sqlCommand.Append("Memory = @Memory,");
                        dbCmd.Parameters.AddWithValue("Memory", comp.Memory);
                    }
                    if (comp.OpticalDrive != "")
                    {
                        sqlCommand.Append("OpticalDrive = @OpticalDrive,");
                        dbCmd.Parameters.AddWithValue("OpticalDrive", comp.OpticalDrive);
                    }
                    if (comp.RemovableMedia != "")
                    {
                        sqlCommand.Append("RemovableMedia = @RemovableMedia,");
                        dbCmd.Parameters.AddWithValue("RemovableMedia", comp.RemovableMedia);
                    }

                    int? ports = comp.USBports;
                    if (ports.HasValue)
                    {
                        sqlCommand.Append("USBports = @USBports,");
                        dbCmd.Parameters.AddWithValue("USBports", comp.USBports);
                    }
                    if (comp.OtherConnectivity != "")
                    {
                        sqlCommand.Append("OtherConnectivity = @OtherConnectivity,");
                        dbCmd.Parameters.AddWithValue("OtherConnectivity", comp.OtherConnectivity);
                    }
                    if (comp.Size != "")
                    {
                        sqlCommand.Append("FormFactor = @FormFactor,");
                        dbCmd.Parameters.AddWithValue("FormFactor", comp.Size);
                    }
                    if (comp.Type != "")
                    {
                        sqlCommand.Append("Type = @Type,");
                        dbCmd.Parameters.AddWithValue("Type", comp.Type);
                    }

                    sqlCommand.Remove((sqlCommand.Length - 1), 1);
                    sqlCommand.Append(" WHERE InvID = @InvID");
                    dbCmd.Parameters.AddWithValue("InvID", oComp.InvID);

                    dbCmd.CommandText = sqlCommand.ToString();

                    if (dbCmd.CommandText != "UPDATE Computer SET WHERE InvID = @InvID")
                    {
                        dbCmd.ExecuteNonQuery();
                        dbCmd.Parameters.Clear();
                    }

                    dbCmd.Parameters.Clear();

                    if (comp.PO.ID != null)
                    {
                        PODA.deleteLink(dbCmd, oComp.InvID);
                        PODA.addLink(dbCmd, oComp.InvID, comp.PO.ID);
                    }

                    message.Append("Computer with Service Tag " + comp.SerialNo + " updated successfully!<bR>");
                }
                transaction.Commit();
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

        public static bool computerTransferred(string serialNo)
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

            return ComputerDA.computerTransferred(dbCmd, serialNo);

        }

        public static int? computerExistReturnID(string serialNo)
        {
            StringBuilder message = new StringBuilder();
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlDataReader dbReader;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();

            try
            {
                string sql = "SELECT SerialNo FROM Inventory, Computer Where Inventory.InvID = Computer.InvID AND SerialNo = @SerialNo";

                dbCmd = new SqlCommand();
                dbCmd.CommandText = sql;
                dbCmd.Parameters.AddWithValue("@SerialNo", serialNo);
                dbCmd.Connection = dbConn;

                dbReader = dbCmd.ExecuteReader();
                List<Computer> desktops = new List<Computer>();

                while (dbReader.Read())
                {
                    Computer comp = new Computer();
                    comp.SerialNo = dbReader["SerialNo"].ToString();
                    desktops.Add(comp);
                }
                dbReader.Close();
                dbCmd.Parameters.Clear();

                if (desktops.Count > 0)
                    return ComputerDA.getInvID(dbCmd, serialNo);
                else
                    return null;
            }

            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }

        }
    }
}
