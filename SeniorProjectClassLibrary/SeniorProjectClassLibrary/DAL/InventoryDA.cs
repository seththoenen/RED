using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SeniorProject
{
    public class InventoryDA
    {
        public static List<int> instantSearch(string serialNo, string connectionString)
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
    }
}
