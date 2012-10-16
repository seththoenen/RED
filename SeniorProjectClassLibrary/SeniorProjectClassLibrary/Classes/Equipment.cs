using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Equipment : Inventory
    {
        private int equipID;
        private string equipmentType;
        private string other;
        private string networkCapable;
        private string connectivity;

        public Equipment()
        {
            currentLocation = new Logistics();
            groups = new List<Group>();
            po = new PurchaseOrder();
            licenses = new List<License>();
            warranties = new List<Warranty>();
        }
        
        public int EquipID
        {
            get
            {
                return equipID;
            }
            set
            {
                equipID = value;
            }
        }

        public string EquipmentType
        {
            get
            {
                return equipmentType;
            }
            set
            {
                equipmentType = value;
            }
        }

        public string Other
        {
            get
            {
                return other;
            }
            set
            {
                other = value;
            }
        }

        public string NetworkCapable
        {
            get
            {
                return networkCapable;
            }
            set
            {
                networkCapable = value;
            }
        }

        public string Connectivity
        {
            get
            {
                return connectivity;
            }
            set
            {
                connectivity = value;
            }
        }

        public static string saveEquipment(List<Equipment> equipment)
        {
            return EquipmentDA.saveEquipment(equipment);
        }

        public static Equipment getEquipment(int invID)
        {
            return EquipmentDA.getEquipment(invID);
        }

        public static Boolean equipmentExist(string serialNo)
        {
            return EquipmentDA.equipmentExist(serialNo);
        }

        public static string updateEquipment(Equipment oEquip, Equipment equip)
        {
            return EquipmentDA.updateEquipment(oEquip, equip);
        }

        public static string updateEquipment(List<Equipment> equipment)
        {
            return EquipmentDA.updateEquipment(equipment);
        }

        public static int? equipmentExistReturnID(string serialNo)
        {
            return EquipmentDA.equipmentExistReturnID(serialNo);
        }

    }
}
