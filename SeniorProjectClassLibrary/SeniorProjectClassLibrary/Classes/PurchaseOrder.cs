﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SeniorProject
{
    public class PurchaseOrder
    {
        private int? id;
        private ArrayList computers;
        private ArrayList equipment;
        private string purchaseDate;
        private string poNumber;
        private string requisitionNo;
        private string title;
        private string deliveryDate;

        public PurchaseOrder()
        {
            computers = new ArrayList();
            equipment = new ArrayList();
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

        public ArrayList Computers
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

        public ArrayList Equipment 
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

        public string savePO(string connString)
        {
            return PODA.savePO(this, connString);
        }

    }
}
