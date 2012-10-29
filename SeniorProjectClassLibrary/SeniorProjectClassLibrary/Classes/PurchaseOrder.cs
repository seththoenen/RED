using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class PurchaseOrder
    {
        private int? id;
        private List<Computer> computers;
        private List<Equipment> equipment;
        private string purchaseDate;
        private string poNumber;
        private string requisitionNo;
        private string title;
        private string deliveryDate;

        public PurchaseOrder()
        {
            computers = new List<Computer>();
            equipment = new List<Equipment>();
        }

        public int? ID
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

        public string PONumber
        {
            get
            {
                return poNumber;
            }
            set
            {
                poNumber = value;
            }
        }

        public string RequisitionNumber
        {
            get
            {
                return requisitionNo;
            }
            set
            {
                requisitionNo = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string DeliveryDate
        {
            get
            {
                return deliveryDate;
            }
            set
            {
                deliveryDate = value;
            }
        }

        public static string savePO(PurchaseOrder po)
        {
            return PODA.savePO(po);
        }

        public static string updatePO(PurchaseOrder newPO, int oldPOid)
        {
            return PODA.updatePO(newPO, oldPOid);
        }

        public static PurchaseOrder getPO(string POID)
        {
            return PODA.getPO(POID);
        }

        public static string saveFile(int LicID, string fileName, string description, string fullPath)
        {
            return PODA.saveFile(LicID, fileName, description, fullPath);
        }

        public static void deleteFile(int fileID)
        {
            PODA.deleteFile(fileID);
        }

    }
}
