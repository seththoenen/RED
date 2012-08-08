using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
{
    public class MonitorDA
    {
        public static ArrayList getMonitors()
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
            dbCmd.Connection = dbConn; ;

            string sql = "SELECT * FROM Monitor";

            dbCmd.CommandText = sql;

            dbReader = dbCmd.ExecuteReader();

            ArrayList monitorList = new ArrayList();

            while (dbReader.Read())
            {
                Monitor mon = new Monitor();
                mon.ID = Convert.ToInt32(dbReader["MonID"]);
                mon.Size = dbReader["Size"].ToString();
                mon.Brand = dbReader["Brand"].ToString();
                mon.Resolution = dbReader["Resolution"].ToString();
                mon.Connectors = dbReader["Connectors"].ToString();
                mon.Model = dbReader["Model"].ToString();
                monitorList.Add(mon);
            }

            return monitorList;
        }

        public static ArrayList getMonitor(SqlCommand cmd, int compID)
        {
            SqlDataReader dbReader;
            string sql = "SELECT * FROM MonitorComputer, Monitor WHERE MonitorComputer.MonID = Monitor.MonID AND MonitorComputer.CompID = @CompID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("CompID", compID);

            dbReader = cmd.ExecuteReader();

            ArrayList monitors = new ArrayList();
            while (dbReader.Read())
            {
                Monitor mon = new Monitor();
                mon.ID = Convert.ToInt32(dbReader["MonID"]);
                mon.Size = dbReader["Size"].ToString();
                mon.Brand = dbReader["Brand"].ToString();
                mon.Resolution = dbReader["Resolution"].ToString();
                mon.Connectors = dbReader["Connectors"].ToString();
                mon.Model = dbReader["Model"].ToString();
                mon.DisplayText = dbReader["Display"].ToString();
                monitors.Add(mon);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return monitors;
        }

        public static Monitor getMonitor(int monID)
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
                string sql = "SELECT * FROM Monitor WHERE MonID = @MonID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("MonID", monID);

                dbReader = dbCmd.ExecuteReader();

                Monitor mon = new Monitor();

                while (dbReader.Read())
                {
                    mon.ID = Convert.ToInt32(dbReader["MonID"]);
                    mon.Size = dbReader["Size"].ToString();
                    mon.Brand = dbReader["Brand"].ToString();
                    mon.Resolution = dbReader["Resolution"].ToString();
                    mon.Connectors = dbReader["Connectors"].ToString();
                    mon.Model = dbReader["Model"].ToString();
                    mon.DisplayText = dbReader["Display"].ToString();
                }
                dbReader.Close();
                transaction.Commit();
                dbConn.Close();

                return mon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }

        }

        public static string saveMonitor(Monitor mon)
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
                String sqlCommand = "INSERT INTO Monitor (Size, Brand, Resolution, Connectors, Model, Display) " +
                    "VALUES (@Size, @Brand, @Resolution, @Connectors, @Model, @Display)";

                dbCmd.CommandText = sqlCommand;

                dbCmd.Parameters.AddWithValue("Size", mon.Size);
                dbCmd.Parameters.AddWithValue("Brand", mon.Brand);
                dbCmd.Parameters.AddWithValue("Resolution", mon.Resolution);
                dbCmd.Parameters.AddWithValue("Connectors", mon.Connectors);
                dbCmd.Parameters.AddWithValue("Model", mon.Model);
                dbCmd.Parameters.AddWithValue("Display", mon.DisplayText);

                dbCmd.ExecuteNonQuery();
                transaction.Commit();
                dbCmd.Parameters.Clear();
                dbConn.Close();
                message.Append("Monitor added successfully<bR>");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString());
                transaction.Rollback();
            }
            return message.ToString();
        }

        public static string updateMonitor(Monitor mon)
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
                string sql = "UPDATE Monitor SET Size = @Size, Brand = @Brand, Resolution = @Resolution, Connectors = @Connectors, Model = @Model, " +
                    " Display = @Display WHERE MonID= @MonID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("Size", mon.Size);
                dbCmd.Parameters.AddWithValue("Brand", mon.Brand);
                dbCmd.Parameters.AddWithValue("Resolution", mon.Resolution);
                dbCmd.Parameters.AddWithValue("Connectors", mon.Connectors);
                dbCmd.Parameters.AddWithValue("Model", mon.Model);
                dbCmd.Parameters.AddWithValue("Display", mon.DisplayText);
                dbCmd.Parameters.AddWithValue("MonID", mon.ID);

                dbCmd.ExecuteNonQuery();

                transaction.Commit();
                dbConn.Close();

                message.Append("Monitor updated successfully!");
                return message.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                message.Append(ex.ToString());
                return message.ToString();
            }
        }

        public static string deleteMonitor(int monID, int compID)
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
            StringBuilder message = new StringBuilder();

            try
            {
                string sql = "SELECT id FROM MonitorComputer WHERE MonID = @MonID AND CompID = @CompID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("MonID", monID);
                dbCmd.Parameters.AddWithValue("CompID", compID);

                dbReader = dbCmd.ExecuteReader();
                int id= 0;
                while (dbReader.Read())
                {
                    id = Convert.ToInt32(dbReader["id"]);
                }
                dbReader.Close();

                sql = "DELETE FROM MonitorComputer WHERE id = @id";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("id", id);

                dbCmd.ExecuteNonQuery();

                transaction.Commit();
                dbConn.Close();
                message.Append("Monitor removed successfully<bR>");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string addMonitor(int monID, int compID)
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
                string sql = "INSERT INTO MonitorComputer (MonID, CompID) VALUES (@MonID, @CompID)";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("MonID", monID);
                dbCmd.Parameters.AddWithValue("CompID", compID);

                dbCmd.ExecuteNonQuery();

                transaction.Commit();
                dbConn.Close();
                message.Append("Monitor added successfully<bR>");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static string deleteMonitors(List<int> ids)
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
                for (int i=0; i<ids.Count; i++)
                {
                    int invId = ids[i];
                    int compId = ComputerDA.getCompID(dbCmd, invId);

                    string sql = "DELETE FROM MonitorComputer WHERE CompID = @CompID";

                    dbCmd.CommandText = sql;

                    dbCmd.Parameters.AddWithValue("CompID", compId);

                    dbCmd.ExecuteNonQuery();                        
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Monitors removed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Append(ex.ToString() + "<bR>");
                transaction.Rollback();
            }

            return message.ToString();
        }

        public static void deleteMonitors(SqlCommand cmd, int invId)
        {

            int compId = 0;
            compId = ComputerDA.getCompID(cmd, invId);

            string sql = "DELETE FROM MonitorComputer WHERE CompID = @CompID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("CompID", compId);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        
        public static string removeSelectMonitor(List<int> ids, int monID)
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
                for (int i = 0; i < ids.Count; i++)
                {
                    int invID = ids[i];
                    int compID = ComputerDA.getCompID(dbCmd, invID);

                    string sqlCommand = "DELETE FROM MonitorComputer WHERE CompID = @CompID AND MonID = @MonID";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("CompID", compID);
                    dbCmd.Parameters.AddWithValue("MonID", monID);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }

                transaction.Commit();
                dbConn.Close();
                message.Append("Monitor removed successfully<bR>");
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

        public static string addMonitorsComputer(List<int> ids, int monID)
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
                for (int i = 0; i < ids.Count; i++)
                {
                    int invID = ids[i];
                    int compID = ComputerDA.getCompID(dbCmd, invID);

                    string sqlCommand = "INSERT INTO MonitorComputer (CompID, MonID) VALUES (@CompID, @MonID)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("CompID", compID);
                    dbCmd.Parameters.AddWithValue("MonID", monID);

                    dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
                }
                transaction.Commit();
                dbConn.Close();
                message.Append("Monitor added successfully<bR>");
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
    }
}
