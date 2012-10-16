using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
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
        protected List<Group> groups;
        protected List<Logistics> logistics;
        protected Logistics currentLocation;
        protected List<License> licenses;
        protected List<Warranty> warranties;
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

        public List<Group> Groups
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

        public List <Warranty> Warranties
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

        public List<Logistics> Logistics
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

        public List<License> Licenses
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

        public static List<int> instantSearch(string serialNo)
        {
            return InventoryDA.instantSearch(serialNo);
        }

        public static List<string> getInvStatus(string serialNo)
        {
            return InventoryDA.getInvStatus(serialNo);
        }
    }
}
