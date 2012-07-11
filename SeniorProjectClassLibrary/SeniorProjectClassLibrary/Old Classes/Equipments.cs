using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Equipments
    {
        private int id;
        private string smsuTag;
        private string serialNo;
        private string manufacturer;
        private string model;
        private string building;
        private string roomNo;
        private string primaryUser;
        private string purchasePrice;
        private string purchaseDate;
        private string warrantyExpires;
        private string poNum;
        private string notes;

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

        public string SMSUtag
        {
            get
            {
                return smsuTag;
            }
            set
            {
                smsuTag = value;
            }
        }

        public string SerialNo
        {
            get
            {
                return serialNo;
            }
            set
            {
                serialNo = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
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

        public string RoomNo
        {
            get
            {
                return roomNo;
            }
            set
            {
                roomNo = value;
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

        public string PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
            }
        }

        public string PurchaseDate
        {
            get
            {
                return purchaseDate;
            }
            set
            {
                purchaseDate = value;
            }
        }

        public string WarrantyExpires
        {
            get
            {
                return warrantyExpires;
            }
            set
            {
                warrantyExpires = value;
            }
        }

        public string PONum
        {
            get
            {
                return poNum;
            }
            set
            {
                poNum = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes; ;
            }
            set
            {
                notes = value;
            }
        }
    }
}
