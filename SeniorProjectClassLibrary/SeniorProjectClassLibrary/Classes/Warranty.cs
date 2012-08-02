using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Warranty
    {
        private int id;
        private string company;
        private string startDate;
        private string endDate;
        private string warrantyType;
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

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
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

        public string WarrantyType
        {
            get
            {
                return warrantyType;
            }
            set
            {
                warrantyType = value;
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

        public static string addWarranty(int invID, Warranty warranty)
        {
            return WarrantyDA.addWarranty(invID, warranty);
        }

        public static string deleteWarrantyComputer(ArrayList serialNos)
        {
            return WarrantyDA.deleteWarrantyComputer(serialNos);
        }

        public static string deleteWarrantyEquipment(ArrayList serialNos)
        {
            return WarrantyDA.deleteWarrantyEquipment(serialNos);
        }

        public static string addWarrantysComputer(ArrayList serialNos, Warranty warranty)
        {
            return WarrantyDA.addWarrantysComputer(serialNos, warranty);
        }

        public static string addWarrantysEquipment(ArrayList serialNos, Warranty warranty)
        {
            return WarrantyDA.addWarrantysEquipment(serialNos, warranty);
        }

    }
}
