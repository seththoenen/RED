using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Logistics
    {

        private int id;
        private int compID;
        private string building;
        private string room;
        private string primaryUser;
        private string name;
        private string startDate;
        private string endDate;
        private string status;

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

        public int ComputerID
        {
            get
            {
                return compID;
            }
            set
            {
                compID = value;
            }
        }

        public string Building
        {
            get
            {
                return building;
            }
            set
            {
                building = value;
            }
        }

        public string Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
            }
        }

        public string PrimaryUser
        {
            get
            {
                return primaryUser;
            }
            set
            {
                primaryUser = value;
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

        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public static string massUpdateLogisticsComputer(List<int> ids, Logistics logs)
        {
            return LogisticsDA.massUpdateLogisticsComputer(ids, logs);
        }

        public static string massUpdateLogisticsEquipment(List<int> ids, Logistics logs)
        {
            return LogisticsDA.massUpdateLogisticsEquipment(ids, logs);
        }

    }
}
