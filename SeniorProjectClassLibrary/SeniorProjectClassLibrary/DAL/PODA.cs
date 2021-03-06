﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SeniorProjectClassLibrary.Classes;
using System.IO;

namespace SeniorProjectClassLibrary.DAL
{
    public class PODA
    {
        public static string savePO(PurchaseOrder PO)
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

            if (PODA.poExist(dbCmd, PO.PONumber) == false)
            {

                try
                {
                    String sqlCommand = "INSERT INTO PO (POno, DeliveryDate, RequisitionNo, PurchaseDate, Title) " +
                        "VALUES (@POno, @DeliveryDate, @RequisitionNo, @PurchaseDate, @Title)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("POno", PO.PONumber);
                    dbCmd.Parameters.AddWithValue("DeliveryDate", PO.DeliveryDate);
                    dbCmd.Parameters.AddWithValue("RequisitionNo", PO.RequisitionNumber);
                    dbCmd.Parameters.AddWithValue("PurchaseDate", PO.PurchaseDate);
                    dbCmd.Parameters.AddWithValue("Title", PO.Title);

                    dbCmd.ExecuteNonQuery();
                    transaction.Commit();
                    dbCmd.Parameters.Clear();
                    dbConn.Close();
                    message.Append("Purchase Order created successfully<bR>");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    message.Append(ex.ToString());
                }
                return message.ToString();
            }
            else
            { 
                message.Append("That PO number already exists, choose another.<bR>");
                return message.ToString();
            }
        }

        public static string updatePO(PurchaseOrder newPO, int oldPOid) 
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

            PurchaseOrder oldPO = PODA.getPO(dbCmd, oldPOid);

            if (newPO.PONumber == oldPO.PONumber || PODA.poExist(dbCmd, newPO.PONumber) == false)
            {
                try
                {
                    String sqlCommand = "UPDATE PO SET " +
                        "POno = @PONO, " +
                        "DeliveryDate = @DeliveryDate, " +
                        "RequisitionNo = @RequisitionNo, " +
                        "PurchaseDate = @PurchaseDate, " +
                        "Title = @Title " +
                        "WHERE POno = @OldPONO";


                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("PONO", newPO.PONumber);
                    dbCmd.Parameters.AddWithValue("DeliveryDate", newPO.DeliveryDate);
                    dbCmd.Parameters.AddWithValue("RequisitionNo", newPO.RequisitionNumber);
                    dbCmd.Parameters.AddWithValue("PurchaseDate", newPO.PurchaseDate);
                    dbCmd.Parameters.AddWithValue("Title", newPO.Title);
                    dbCmd.Parameters.AddWithValue("OldPONO", oldPO.PONumber);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                    transaction.Commit();
                    dbConn.Close();
                    message.Append("Purchase Order created successfully<bR>");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    message.Append(ex.ToString());
                    transaction.Rollback();
                }
                return message.ToString();
            }
            else
            {
                message.Append("That PO number already exists, choose another.<bR>");
                return message.ToString();
            }
        }

        public static PurchaseOrder getPODetails(SqlCommand cmd, int invID) 
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT PO.POID, POno, DeliveryDate, RequisitionNo, PurchaseDate, Title FROM PO, POInventory WHERE PO.POID = POInventory.POID and POInventory.InvID = @InvID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("InvID", invID);

            dbReader = cmd.ExecuteReader();
            PurchaseOrder PO = new PurchaseOrder();

            while (dbReader.Read())
            {
                PO.ID = Convert.ToInt32(dbReader["POID"]);
                PO.PONumber = dbReader["POno"].ToString();
                PO.DeliveryDate = dbReader["DeliveryDate"].ToString();
                PO.RequisitionNumber = dbReader["RequisitionNo"].ToString();
                PO.PurchaseDate = dbReader["PurchaseDate"].ToString();
                PO.Title = dbReader["Title"].ToString();
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return PO;
        }

        public static PurchaseOrder getPO(string POID) 
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
                string sql = "SELECT POID, POno, DeliveryDate, REquisitionNo, PurchaseDate, Title FROM PO WHERE POID = @POID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("POID", POID);

                dbReader = dbCmd.ExecuteReader();
                PurchaseOrder PO = new PurchaseOrder();

                while (dbReader.Read())
                {
                    PO.ID = Convert.ToInt32(dbReader["POID"]);
                    PO.PONumber = dbReader["POno"].ToString();
                    PO.DeliveryDate = dbReader["DeliveryDate"].ToString();
                    PO.RequisitionNumber = dbReader["RequisitionNo"].ToString();
                    PO.PurchaseDate = dbReader["PurchaseDate"].ToString();
                    PO.Title = dbReader["Title"].ToString();
                }
                dbReader.Close();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();

                return PO;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }

        }

        public static PurchaseOrder getPO(SqlCommand cmd, int POID) 
        {
            SqlDataReader dbReader;
            
            string sql = "SELECT POID, POno, DeliveryDate, RequisitionNo, PurchaseDate, Title FROM PO WHERE POID = @POID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("POID", POID);

            dbReader = cmd.ExecuteReader();
            PurchaseOrder PO = new PurchaseOrder();

            while (dbReader.Read())
            {
                PO.ID = Convert.ToInt32(dbReader["POID"]);
                PO.PONumber = dbReader["POno"].ToString();
                PO.DeliveryDate = dbReader["DeliveryDate"].ToString();
                PO.RequisitionNumber = dbReader["RequisitionNo"].ToString();
                PO.PurchaseDate = dbReader["PurchaseDate"].ToString();
                PO.Title = dbReader["Title"].ToString();
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return PO;
        }

        public static int getPOID(SqlCommand cmd, string PONo) 
        {
            SqlDataReader dbReader;

            string sql = "SELECT POID FROM PO WHERE POno = @POno";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("POno", PONo);

            dbReader = cmd.ExecuteReader();
            PurchaseOrder PO = new PurchaseOrder();

            int POID = 0;
            while (dbReader.Read())
            {
                POID = Convert.ToInt32(dbReader["POID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return POID;
        }

        public static Boolean poExist(SqlCommand cmd, string poNum) 
        {

            SqlDataReader dbReader;

            string sql;

            sql = "SELECT POID FROM PO WHERE poNO = @PONum";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("PONum", poNum);

            dbReader = cmd.ExecuteReader();

            int poID = 0;

            while (dbReader.Read())
            {
                poID = Convert.ToInt32(dbReader["POID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            if (poID > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static void deleteLink(SqlCommand cmd, int InvID) 
        {
            String sqlCommand = "DELETE from POInventory WHERE InvID = @InvID";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("InvID", InvID);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
        }

        public static void addLink(SqlCommand cmd, int invID, int? poID) 
        {
            StringBuilder message = new StringBuilder();

            string sqlCommand = "INSERT INTO POInventory (POID, InvID) " +
                "VALUES (@POID, @InvID2)";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("@POID", poID);
            cmd.Parameters.AddWithValue("@InvID2", invID);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

        }

        public static string saveFile(int LicID, string fileName, string description, string fullPath)
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
                if (File.Exists(fullPath) == true)
                {
                    message.Append("This license already has that file.");
                }
                else
                {
                    string sqlCommand = "INSERT INTO POFiles (POID, description, filename) " +
                        "VALUES (@LicID, @description, @filename)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("LicID", LicID);
                    dbCmd.Parameters.AddWithValue("filename", fileName);
                    dbCmd.Parameters.AddWithValue("description", description);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();

                    transaction.Commit();
                    dbConn.Close();
                    message.Append("File added successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
                File.Delete(fullPath);
            }
            return message.ToString();

        }

        public static void deleteFile(int fileID)
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
                string sqlCommand = "DELETE FROM POFiles WHERE FileID= @FileID";

                dbCmd.CommandText = sqlCommand;

                dbCmd.Parameters.AddWithValue("FileID", fileID);

                dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();

                transaction.Commit();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
            }

        }
    }
}
