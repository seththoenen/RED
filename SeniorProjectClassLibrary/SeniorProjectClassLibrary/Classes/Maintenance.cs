using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Maintenance
    {
        private int id;
        private int invID;
        private string description;
        private string date;

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

        public int InvID
        {
            get
            {
                return invID;
            }
            set
            {
                invID = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public static string addMaintenance(Maintenance maint)
        {
            return MaintenanceDA.addMaintenance(maint);
        }

        public static string addMassMaintenanceComputer(ArrayList serialNos, Maintenance maint)
        {
            return MaintenanceDA.addMassMaintenanceComputer(serialNos, maint);
        }

        public static string addMassMaintenanceEquipment(ArrayList serialNos, Maintenance maint)
        {
            return MaintenanceDA.addMassMaintenanceEquipment(serialNos, maint);
        }

    }
}
