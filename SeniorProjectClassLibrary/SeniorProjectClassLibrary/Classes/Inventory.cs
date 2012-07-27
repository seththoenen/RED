using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SeniorProject
{
    public class Inventory
    {
        protected int invID;
        protected string smsuTag;
        protected string serialNo;
        protected string manufacturer;
        protected string model;
        protected double? purchasePrice;
        protected string warrantyExpires;
        protected string notes;
        protected PurchaseOrder po;
        protected string status;
        protected ArrayList groups;
        protected ArrayList logistics;
        protected Logistics currentLocation;
        protected ArrayList licenses;
        protected ArrayList warranties;
        protected string physicalAddress;

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

        public ArrayList Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
            }
        }

        public ArrayList Warranties
        {
            get
            {
                return warranties;
            }
            set
            {
                warranties = value;
            }
        }

        public ArrayList Logistics
        {
            get
            {
                return logistics;
            }
            set
            {
                logistics = value;
            }
        }

        public ArrayList Licenses
        {
            get
            {
                return licenses;
            }
            set
            {
                licenses = value;
            }
        }

        public Logistics CurrentLocation
        {
            get
            {
                return currentLocation;
            }
            set
            {
                currentLocation = value;
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

        public PurchaseOrder PO
        {
            get
            {
                return po;
            }
            set
            {
                po = value;
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

        public double? PurchasePrice
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

        public string PhysicalAddress
        {
            get
            {
                return physicalAddress;
            }
            set
            {
                physicalAddress = value;
            }
        }
    }
}
