using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProjectClassLibrary.DAL
{
    public class GroupDA
    {
        public static string saveGroup(Group group)
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

            if (GroupDA.groupExist(group.Name) == false)
            {

                try
                {
                    string sqlCommand = "INSERT INTO Groups (Name, Notes, Type) " +
                        "VALUES (@GroupName, @Notes, @Type)";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("GroupName", group.Name);
                    dbCmd.Parameters.AddWithValue("Notes", group.Notes);
                    dbCmd.Parameters.AddWithValue("Type", group.Type);

                    dbCmd.ExecuteNonQuery();
                    transaction.Commit();
                    dbConn.Close();
                    message.Append("Group created successfully<bR>");

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
                message.Append("That group name already exists, choose another.<bR>");
                return message.ToString();
            }
        }

        public static string updateGroup(Group newGroup, int oldGroupID)
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

            Group oldGroup = new Group();
            oldGroup = GroupDA.getGroup(dbCmd, oldGroupID);

            if (newGroup.Name == oldGroup.Name  || GroupDA.groupExist(dbCmd, newGroup.Name) == false)
            {

                try
                {
                    string sqlCommand = "UPDATE Groups SET " +
                        "Name = @Name, " +
                        "Notes = @Notes " +
                        "WHERE Name = @OldName";

                    dbCmd.CommandText = sqlCommand;

                    dbCmd.Parameters.AddWithValue("Name", newGroup.Name);
                    dbCmd.Parameters.AddWithValue("Notes", newGroup.Notes);
                    dbCmd.Parameters.AddWithValue("OldName", oldGroup.Name);

                    dbCmd.ExecuteNonQuery();
                    transaction.Commit();
                    dbConn.Close();
                    message.Append("Group updated successfully<bR>");

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
                message.Append("That group name already exists, choose another.<bR>");
                return message.ToString();
            }
        }

        public static bool groupExist(string GroupName) 
        {
            SqlConnection dbConn;
            string sConnection;
            SqlCommand dbCmd;
            SqlTransaction transaction;
            StringBuilder message = new StringBuilder();
            SqlDataReader dbReader;

            sConnection = GlobalVars.ConnectionString;
            dbConn = new SqlConnection(sConnection);
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            transaction = dbConn.BeginTransaction("Transaction");
            dbCmd.Transaction = transaction;

            string sql = "SELECT * FROM Groups WHERE Name = @Name";

            dbCmd.CommandText = sql;

            dbCmd.Parameters.AddWithValue("Name", GroupName);

            dbReader = dbCmd.ExecuteReader();

            ArrayList groupList = new ArrayList();

            while (dbReader.Read())
            {
                Group group = new Group();
                group.ID = Convert.ToInt32(dbReader["GroupID"]);
                group.Notes = dbReader["Notes"].ToString();
                groupList.Add(group);
            }

            if (groupList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool groupExist(SqlCommand cmd, string groupName) 
        {
            SqlDataReader dbReader;
            
            string sql = "SELECT * FROM Groups WHERE Name = @GroupName";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("GroupName", groupName);

            dbReader = cmd.ExecuteReader();

            ArrayList groupList = new ArrayList();

            while (dbReader.Read())
            {
                Group group = new Group();
                group.ID = Convert.ToInt32(dbReader["GroupID"]);
                group.Notes = dbReader["Notes"].ToString();
                groupList.Add(group);
            }
            dbReader.Close();

            if (groupList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Group getGroup(int GroupID) 
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
                string sql = "SELECT * from Groups where GroupID = @GroupID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("GroupID", GroupID);

                dbReader = dbCmd.ExecuteReader();
                Group group = new Group();

                while (dbReader.Read())
                {
                    group.ID = Convert.ToInt32(dbReader["GroupID"]);
                    group.Name = dbReader["Name"].ToString();
                    group.Notes = dbReader["Notes"].ToString();
                }
                dbReader.Close();

                //sql = "SELECT Inventory.InviD FROM , GroupComputer WHERE GroupComputer.CompID = Desktop.id AND GroupComputer.GroupID = " + GroupID;

                //dbCmd = new SqlCommand();
                //dbCmd.CommandText = sql;
                //dbCmd.Connection = dbConn;

                //dbReader = dbCmd.ExecuteReader();
                //group.Computers = new ArrayList();

                //while (dbReader.Read())
                //{
                //    Computer comp = new Computer();
                //    comp = DesktopDA.getDesktop(dbReader["id"].ToString(), connectionString);
                //    group.Computers.Add(comp);
                //}

                transaction.Commit();
                return group;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }

        }

        public static Group getGroup(SqlCommand cmd, int groupID) 
        {
            SqlDataReader dbReader;
            
            string sql = "SELECT * FROM Groups WHERE GroupID = @GroupID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("GroupID", groupID);

            dbReader = cmd.ExecuteReader();
            Group group = new Group();

            while (dbReader.Read())
            {
                group.ID = Convert.ToInt32(dbReader["GroupID"]);
                group.Name = dbReader["Name"].ToString();
                group.Notes = dbReader["Notes"].ToString();
            }
            dbReader.Close();

            return group;
        }

        public static Group getGroupComputers(string groupName)
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
                int groupID = GroupDA.getGroupID(dbCmd, groupName);
                
                string sql = "SELECT SerialNo FROM Inventory, GroupInventory WHERE GroupInventory.InvID = Inventory.InvID AND GroupInventory.GroupID = @GroupID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("GroupID", groupID);

                dbReader = dbCmd.ExecuteReader();

                Group group = new Group();
                while (dbReader.Read())
                {
                    Computer comp = new Computer();
                    comp.SerialNo = dbReader["SerialNo"].ToString();
                    group.Computers.Add(comp);
                }
                dbReader.Close();

                transaction.Commit();
                dbConn.Close();
                return group;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
        }

        public static Group getGroupEquipment(string groupName)
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
                int groupID = GroupDA.getGroupID(dbCmd, groupName);

                string sql = "SELECT SerialNo FROM Inventory, GroupInventory WHERE GroupInventory.InvID = Inventory.InvID AND GroupInventory.GroupID = @GroupID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("GroupID", groupID);

                dbReader = dbCmd.ExecuteReader();

                Group group = new Group();
                while (dbReader.Read())
                {
                    Equipment equip = new Equipment();
                    equip.SerialNo = dbReader["SerialNo"].ToString();
                    group.Equipment.Add(equip);
                }
                dbReader.Close();

                transaction.Commit();
                dbConn.Close();
                return group;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
        }

        public static ArrayList getGroups(SqlCommand cmd, int invID) 
        {
            SqlDataReader dbReader;
            string sql;

            sql = "SELECT Name, Notes FROM GroupInventory, Groups WHERE GroupInventory.GroupID = Groups.GroupID AND InvID = @InvID";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("InvID", invID);

            dbReader = cmd.ExecuteReader();
            ArrayList groupList = new ArrayList();

            while (dbReader.Read())
            {
                Group group = new Group();
                group.Name = dbReader["Name"].ToString();
                group.Notes = dbReader["Notes"].ToString();
                groupList.Add(group);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return groupList;
        }

        public static ArrayList getAllComputerGroups() 
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

            string sql = "SELECT * FROM Groups WHERE Type = 'Computer'";

            dbCmd.CommandText = sql;

            dbReader = dbCmd.ExecuteReader();
            ArrayList groupList = new ArrayList();

            while (dbReader.Read())
            {
                Group group = new Group();
                group.ID = Convert.ToInt16(dbReader["GroupID"]);
                group.Name = dbReader["Name"].ToString();
                group.Notes = dbReader["Notes"].ToString();
                groupList.Add(group);
            }

            return groupList;
        }

        public static ArrayList getAllEquipmentGroups() 
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

            string sql = "SELECT * FROM Groups WHERE Type = 'Equipment'";

            dbCmd.CommandText = sql;

            dbReader = dbCmd.ExecuteReader();
            ArrayList groupList = new ArrayList();

            while (dbReader.Read())
            {
                Group group = new Group();
                group.ID = Convert.ToInt16(dbReader["GroupID"]);
                group.Name = dbReader["Name"].ToString();
                group.Notes = dbReader["Notes"].ToString();
                groupList.Add(group);
            }

            return groupList;
        }

        public static ArrayList getAllGroups() 
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

            string sql = "SELECT * FROM Groups";

            dbCmd.CommandText = sql;

            dbReader = dbCmd.ExecuteReader();
            ArrayList groupList = new ArrayList();

            while (dbReader.Read())
            {
                Group group = new Group();
                group.ID = Convert.ToInt16(dbReader["GroupID"]);
                group.Name = dbReader["Name"].ToString();
                group.Notes = dbReader["Notes"].ToString();
                groupList.Add(group);
            }

            return groupList;
        }

        public static void updateGroups(SqlCommand cmd, ArrayList groupList, int invID) 
        {
            GroupDA.removeLinks(cmd, invID);

            for (int i = 0; i < groupList.Count; i++)
            {
                int groupID = GroupDA.getGroupID(cmd, groupList[i].ToString());
                GroupDA.addLink(cmd, groupID, invID);
            }

        }

        public static string updateGroups(ArrayList groupList, int invID) 
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

            try
            {
                GroupDA.removeLinks(dbCmd, invID);

                for (int i = 0; i < groupList.Count; i++)
                {
                    int groupID = GroupDA.getGroupID(dbCmd, groupList[i].ToString());
                    GroupDA.addLink(dbCmd, groupID, invID);
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

        public static void removeLinks(SqlCommand cmd, int invID) 
        {

            string sqlCommand = "DELETE FROM GroupInventory WHERE InvID = @InvID4";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("@InvID4", invID);
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        public static void addLink(SqlCommand cmd, int groupID, int invID) 
        {

            string sqlCommand = "INSERT INTO GroupInventory (GroupID, InvID) " 
            + "VALUES (@GroupID , @InvID)";

            cmd.CommandText = sqlCommand;

            cmd.Parameters.AddWithValue("@GroupID", groupID);
            cmd.Parameters.AddWithValue("@InvID", invID);
            

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        public static int getGroupID(SqlCommand cmd, string groupName) 
        {

            SqlDataReader dbReader;
            string sql;

            sql = "SELECT GroupId FROM Groups WHERE Name = @GroupName";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@GroupName", groupName);
            

            dbReader = cmd.ExecuteReader();

            int groupID = 0;

            while (dbReader.Read())
            {
                groupID = Convert.ToInt32(dbReader["GroupID"]);
            }
            dbReader.Close();
            cmd.Parameters.Clear();

            return groupID;
        }

        public static int getGroupID(string groupName) 
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
                string sql = "SELECT GroupID FROM Groups WHERE Name = @Name";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("Name", groupName);

                dbReader = dbCmd.ExecuteReader();
                int groupID = 0;

                while (dbReader.Read())
                {
                    groupID = Convert.ToInt32(dbReader["GroupID"]);
                }
                dbReader.Close();

                transaction.Commit();
                dbConn.Close();
                return groupID;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return 0;
            }
        }

        public static bool invInGroup(string serialNo, int groupId)
        {
            bool isInGroup = false;
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
                int invId = ComputerDA.getInvID(dbCmd, serialNo);
                
                string sql = "SELECT InvID FROM GroupInventory WHERE  GroupID = @GroupID";

                dbCmd.CommandText = sql;

                dbCmd.Parameters.AddWithValue("GroupID", groupId);

                dbReader = dbCmd.ExecuteReader();

                while (dbReader.Read())
                {
                    if (Convert.ToInt32(dbReader["InvID"]) == invId)
                    {
                        isInGroup = true;
                    }
                }
                dbReader.Close();

                transaction.Commit();
                dbConn.Close();
                
                return isInGroup;
            }

            catch (Exception ex)
            {
                ex.ToString();
                transaction.Rollback();
                return true;
            }
            
        }

        public static string addInvToGroup(ArrayList serialNos, int groupID)
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

            try
            {
                for (int i = 0; i < serialNos.Count; i++)
                {
                    int invID = ComputerDA.getInvID(dbCmd, (string)serialNos[i]);
                    GroupDA.addLink(dbCmd, groupID, invID);
                }
                transaction.Commit();
                message.Append("Inventory added successfully!<bR>");
                return message.ToString();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                message.Append(ex.ToString());
                return message.ToString();
            }
        }
    }
}
