using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
{
    public class InventoryDA
    {
        public static List<int> instantSearch(string serialNo)
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
            List<int> results = new List<int>();
            try
            {
                if (ComputerDA.computerExist(dbCmd, serialNo) == true)
                {
                    results.Add(ComputerDA.getInvID(dbCmd, serialNo));
                    results.Add(1);
                    return results;
                }
                else if (EquipmentDA.equipmentExist(dbCmd, serialNo) == true)
                {
                    results.Add(EquipmentDA.getInvID(dbCmd, serialNo));
                    results.Add(2);
                    return results;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }

                        
        }

        public static List<string> getInvStatus(string serialNo)
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
            List<string> results = new List<string>();
            try
            {
                if (ComputerDA.computerExist(dbCmd, serialNo) == true)
                {
                    results.Add("Computer");
                    if (ComputerDA.computerTransferred(serialNo) == false)
                    {
                        results.Add("Active");
                        results.Add(ComputerDA.getInvID(dbCmd, serialNo).ToString());
                    }
                    else
                    {
                        results.Add("Transferred");
                    }

                    return results;
                }
                else if (EquipmentDA.equipmentExist(dbCmd, serialNo) == true)
                {
                    results.Add("Equipment");
                    if (ComputerDA.computerTransferred(serialNo) == false)
                    {
                        results.Add("Active");
                        results.Add(EquipmentDA.getInvID(dbCmd, serialNo).ToString());
                    }
                    else
                    {
                        results.Add("Transferred");
                    }
                    return results;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

    }
}
