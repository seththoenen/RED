﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Group
    {

        private int id;
        private string name;
        private string notes;
        private string type;
        private List<Computer> computers;
        private List<Equipment> equipment;

        public Group()
        {
            computers = new List<Computer>();
            equipment = new List<Equipment>();
        }

        public int ID
        {
            get 
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public List<Computer> Computers
        {
            get
            {
                return computers;
            }
            set
            {
                computers = value;
            }
        }

        public List<Equipment> Equipment
        {
            get
            {
                return equipment;
            }
            set
            {
                equipment = value;
            }
        }

        public static List<Group> getAllComputerGroups()
        {
            return GroupDA.getAllComputerGroups();
        }

        public static string saveGroup(Group group)
        {
            return GroupDA.saveGroup(group);
        }

        public static string updateGroup(Group newGroup, int oldGroupID)
        {
            return GroupDA.updateGroup(newGroup, oldGroupID);
        }

        public static bool groupExist(string GroupName)
        {
            return GroupDA.groupExist(GroupName);
        }

        public static Group getGroup(int GroupID)
        {
            return GroupDA.getGroup(GroupID);
        }

        public static Group getGroupComputers(string groupName)
        {
            return GroupDA.getGroupComputers(groupName);
        }

        public static Group getGroupEquipment(string groupName)
        {
            return GroupDA.getGroupEquipment(groupName);
        }

        public static List<Group> getAllEquipmentGroups()
        {
            return GroupDA.getAllEquipmentGroups();
        }

        public static List<Group> getAllGroups()
        {
            return GroupDA.getAllGroups();
        }

        public static string updateGroups(List<string> groupList, int invID)
        {
            return GroupDA.updateGroups(groupList, invID);
        }

        public static int getGroupID(string groupName)
        {
            return GroupDA.getGroupID(groupName);
        }

        public static bool invInGroup(string serialNo, int groupId)
        {
            return GroupDA.invInGroup(serialNo, groupId);
        }

        public static string addInvToGroup(List<string> serialNos, int groupID)
        {
            return GroupDA.addInvToGroup(serialNos, groupID);
        }

    }
}
