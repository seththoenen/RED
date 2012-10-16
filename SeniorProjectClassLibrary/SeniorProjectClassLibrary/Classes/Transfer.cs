using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Transfer
    {
        private int id;
        private string name;
        private string date;
        private string where;
        private string notes;
        private ArrayList inventory;

        public Transfer()
        {
            inventory = new ArrayList();
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

        public string Where
        {
            get
            {
                return where;
            }
            set
            {
                where = value;
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

        public ArrayList Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public static string saveTransfer(Transfer transfer)
        {
            return TransferDA.saveTransfer(transfer);
        }

    }
}
