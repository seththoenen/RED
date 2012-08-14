using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static string deleteWarrantyComputer(List<int> ids)
        {
            return WarrantyDA.deleteWarrantyComputer(ids);
        }

        public static string deleteWarrantyEquipment(List<int> ids)
        {
            return WarrantyDA.deleteWarrantyEquipment(ids);
        }

        public static string addWarrantysComputer(List<int> ids, Warranty warranty)
        {
            return WarrantyDA.addWarrantysComputer(ids, warranty);
        }

        public static string addWarrantysEquipment(List<int> ids, Warranty warranty)
        {
            return WarrantyDA.addWarrantysEquipment(ids, warranty);
        }

    }
}
