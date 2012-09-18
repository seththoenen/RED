using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SeniorProject
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
            groups = new ArrayList();
            po = new PurchaseOrder();
            licenses = new ArrayList();
            warranties = new ArrayList();
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
    }
}
