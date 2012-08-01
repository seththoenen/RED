using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SeniorProject
{
    public class LicenseDA
    {
        public static string saveLicense(License license) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            if (LicenseDA.licenseExist(dbCmd, license) == false)
            {

                try
                {
                    string sqlCommand = "INSERT INTO Licenses (Software, OS, LicenseKey, NumOfCopies, ExpirationDate, Notes, Type) " +
                        "VALUES (@Software, @OS, @LicenseKey, @NumOfCopies, @ExpirationDate, @Notes, @Type)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("Software", license.Software);
                    dbCmd.Parameters.AddWithValue("OS", license.OS);
                    dbCmd.Parameters.AddWithValue("LicenseKey", license.Key);
                    dbCmd.Parameters.AddWithValue("NumOfCopies", license.NumOfCopies);
                    dbCmd.Parameters.AddWithValue("ExpirationDate", license.ExpirationDate);
                    dbCmd.Parameters.AddWithValue("Notes", license.Notes);
                    dbCmd.Parameters.AddWithValue("Type", license.Type);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    transaction.Commit();
                    dbConn.Close();
                    message.Append("License created successfully!<bR>");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    message.Append(ex.ToString() + "<bR>");
                    transaction.Rollback();
                }
                return message.ToString();
            }
            else
            {
                message.Append("That license name already exists, choose another.<bR>");
                return message.ToString();
            }
        }

        public static License getLicense(SqlCommand cmd, int licenseID) 
        {
            SqlDataReader dbReader;

            string sql = "SELECT * FROM Licenses WHERE LicID = @LicID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("LicID", licenseID);

            dbReader = cmd.ExecuteReader();
            License license = new License();

            while (dbReader.Read())
            {
                license.ID = licenseID;
                license.Software = dbReader["Software"].ToString();
                license.OS = dbReader["OS"].ToString();
                license.Key = dbReader["LicenseKey"].ToString();
                license.NumOfCopies = Convert.ToInt16(dbReader["NumOfCopies"]);
                license.ExpirationDate = dbReader["ExpirationDate"].ToString();
                license.Notes = dbReader["Notes"].ToString();
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return license;
        }

        public static License getLicense(int licenseID)
        {
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
            dbCmd.Connection = dbConn;

            License lic = new License();
            lic = LicenseDA.getLicense(dbCmd, licenseID);

            return lic;
        }
        
        public static bool licenseExist(SqlCommand cmd, License license) 
        {
            SqlDataReader dbReader;

            string sql = "SELECT * FROM Licenses WHERE Software = @Software AND LicenseKey = @Key";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("Software", license.Software);
            cmd.Parameters.AddWithValue("Key", license.Key);

            dbReader = cmd.ExecuteReader();

            ArrayList licenseList = new ArrayList();

            while (dbReader.Read())
            {
                licenseList.Add(dbReader["LicID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            if (licenseList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string addLicense(int licenseID, int invID) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                License license = new License();
                license = LicenseDA.getLicense(dbCmd, licenseID);

                if (LicenseDA.licenseExist(dbCmd, license, invID) == true)
                {
                    message.Append("That computer already has that license");
                }
                else
                {
                    string sqlCommand = "INSERT INTO LicenseInventory (LicID, InvID) VALUES (@LicID, @InvID)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("LicID", license.ID);
                    dbCmd.Parameters.AddWithValue("InvID", invID);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    message.Append("License added successfully<bR>");
                }

                transaction.Commit();
                dbConn.Close();
                return message.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
                return message.ToString();
            }
        }

        public static void addLicense(SqlCommand cmd, int licenseID, int invID) 
        {
            string sqlCommand = "INSERT INTO LicenseInventory (LicID, InvID) VALUES (@LicID, @InvID)";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("LicID", licenseID);
            cmd.Parameters.AddWithValue("InvID", invID);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void removeLicenses(SqlCommand cmd, int invId) 
        {
            string sqlCommand = "DELETE FROM LicenseInventory WHERE InvID = @InvID";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("InvID", invId);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static bool licenseExist(SqlCommand cmd, License license, int InvID) 
        {
            SqlDataReader dbReader;

            string sql = "SELECT * FROM Licenses, LicenseInventory WHERE Licenses.LicID = LicenseInventory.LicID AND Software = @Software AND LicenseKey = @Key AND InvID = @InvID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("Software", license.Software);
            cmd.Parameters.AddWithValue("Key", license.Key);
            cmd.Parameters.AddWithValue("InvID", InvID);

            dbReader = cmd.ExecuteReader();

            ArrayList licenseList = new ArrayList();

            while (dbReader.Read())
            {
                licenseList.Add(dbReader["LicID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            if (licenseList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string removeLicense(int licenseID, int invID) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                string sqlCommand = "DELETE FROM LicenseInventory WHERE LicID = @LicID AND InvID = @InvID";

                dbCmd.CommandText = sqlCommand;

                dbCmd.Parameters.AddWithValue("LicID", licenseID);
                dbCmd.Parameters.AddWithValue("InvID", invID);

                dbCmd.ExecuteNonQuery();

                transaction.Commit();
                dbConn.Close();
                message.Append("License removed successfully<bR>");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string removeAllLicensesComputer(ArrayList serialNos) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];
                    int invId = ComputerDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "DELETE FROM LicenseInventory WHERE InvID = @InvID";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", invId);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }

                message.Append("Licenses removed successfully");
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

        public static string removeAllLicensesEquipment(ArrayList serialNos) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];

                    int invId = EquipmentDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "DELETE FROM LicenseInventory WHERE InvID = @InvID";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", invId);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }

                message.Append("Licenses removed successfully");
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

        public static string removeSelectLicenseComputer(ArrayList serialNos, int licenseID) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];
                    int invID = ComputerDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "DELETE FROM LicenseInventory WHERE InvID = @InvID AND LicID = @LicID";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", invID);
                    dbCmd.Parameters.AddWithValue("LicID", licenseID);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }

                transaction.Commit();
                dbConn.Close();
                message.Append("License removed successfully<bR>");
                return message.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
                return message.ToString();
            }
        }

        public static string removeSelectLicenseEquipment(ArrayList serialNos, int licenseID) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];
                    
                    int invID = EquipmentDA.getInvID(dbCmd, serialNo);

                    string sqlCommand = "DELETE FROM LicenseInventory WHERE InvID = @InvID AND LicID = @LicID";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("InvID", invID);
                    dbCmd.Parameters.AddWithValue("LicID", licenseID);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }

                transaction.Commit();
                dbConn.Close();
                message.Append("License removed successfully<bR>");
                return message.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
                return message.ToString();
            }
        }

        public static string addLicensesComputer(ArrayList serialNos, int licenseID) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();
            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];

                    int invID = ComputerDA.getInvID(dbCmd, serialNo);
                    License lic = new License();
                    lic = LicenseDA.getLicense(dbCmd, licenseID);
                    if (LicenseDA.licenseExist(dbCmd, lic, invID) == true)
                    {
                        message.Append("Computer with Serial Number " + serialNos[i] + " already has that license<bR>");
                    }
                    else
                    {
                        string sqlCommand = "INSERT INTO LicenseInventory (LicID, InvID) VALUES (@LicID, @InvID)";

                        dbCmd.CommandText = sqlCommand;

                        dbCmd.Parameters.AddWithValue("LicID", licenseID);
                        dbCmd.Parameters.AddWithValue("InvID", invID);

                        dbCmd.ExecuteNonQuery();
                        dbCmd.Parameters.Clear();
                    }
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("License added successfully<bR>");
                return message.ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
                return message.ToString();
            }
        }

        public static string addLicensesEquipment(ArrayList serialNos, int licenseID) 
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();
            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    string serialNo = (String)serialNos[i];
                    
                    int invID = EquipmentDA.getInvID(dbCmd, serialNo);
                    License lic = new License();
                    lic = LicenseDA.getLicense(dbCmd, licenseID);
                    if (LicenseDA.licenseExist(dbCmd, lic, invID) == true)
                    {
                        message.Append("Equipment with Serial Number " + serialNos[i] + " already has that license<bR>");
                    }
                    else
                    {
                        string sqlCommand = "INSERT INTO LicenseInventory (LicID, InvID) VALUES (@LicID, @InvID)";

                        dbCmd.CommandText = sqlCommand;

                        dbCmd.Parameters.AddWithValue("LicID", licenseID);
                        dbCmd.Parameters.AddWithValue("InvID", invID);

                        dbCmd.ExecuteNonQuery();
                        dbCmd.Parameters.Clear();
                    }
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("License added successfully<bR>");
                return message.ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
                return message.ToString();
            }
        }

        public static string updateLicense(License license)
        {
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
            dbCmd.Connection = dbConn;
            StringBuilder message = new StringBuilder();

            try
            {
                string sqlCommand = "UPDATE Licenses SET Software = @Software, OS = @OS, LicenseKey = @LicenseKey, NumOfCopies = @NumOfCopies, " +
                        "ExpirationDate = @ExpirationDate, Notes = @Notes WHERE LicID = @LicID";

                dbCmd.CommandText = sqlCommand;

                dbCmd.Parameters.AddWithValue("LicID", license.ID);
                dbCmd.Parameters.AddWithValue("Software", license.Software);
                dbCmd.Parameters.AddWithValue("OS", license.OS);
                dbCmd.Parameters.AddWithValue("LicenseKey", license.Key);
                dbCmd.Parameters.AddWithValue("NumOfCopies", license.NumOfCopies);
                dbCmd.Parameters.AddWithValue("ExpirationDate", license.ExpirationDate);
                dbCmd.Parameters.AddWithValue("Notes", license.Notes);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();
                message.Append("License updated successfully!<bR>");

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
