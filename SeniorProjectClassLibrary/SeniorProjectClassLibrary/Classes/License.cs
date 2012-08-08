using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class License
    {
        private int id;
        private string software;
        private string operatingSystem;
        private string key;
        private int numOfCopies;
        private string expirationDate;
        private string notes;
        private string name;
        private string type;

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

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Software
        {
            get
            {
                return software;
            }
            set
            {
                software = value;
            }
        }

        public string OS
        {
            get
            {
                return operatingSystem;
            }
            set
            {
                operatingSystem = value;
            }
        }

        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        public int NumOfCopies
        {
            get
            {
                return numOfCopies;
            }
            set
            {
                numOfCopies = value;
            }
        }

        public string ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value;
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

        public static string saveLicense(License license)
        {
            return LicenseDA.saveLicense(license);
        }

        public static License getLicense(int licenseID)
        {
            return LicenseDA.getLicense(licenseID);
        }

        public static string addLicense(int licenseID, int invID)
        {
            return LicenseDA.addLicense(licenseID, invID);
        }

        public static string removeLicense(int licenseID, int invID)
        {
            return LicenseDA.removeLicense(licenseID, invID);
        }

        public static string removeAllLicensesComputer(List<int> ids)
        {
            return LicenseDA.removeAllLicensesComputer(ids);
        }

        public static string removeAllLicensesEquipment(List<int> ids)
        {
            return LicenseDA.removeAllLicensesEquipment(ids);
        }

        public static string removeSelectLicenseComputer(List<int> ids, int licenseID)
        {
            return LicenseDA.removeSelectLicenseComputer(ids, licenseID);
        }

        public static string removeSelectLicenseEquipment(List<int> ids, int licenseID)
        {
            return LicenseDA.removeSelectLicenseEquipment(ids, licenseID);
        }

        public static string addLicensesComputer(List<int> ids, int licenseID)
        {
            return LicenseDA.addLicensesComputer(ids, licenseID);
        }

        public static string addLicensesEquipment(List<int> ids, int licenseID)
        {
            return LicenseDA.addLicensesEquipment(ids, licenseID);
        }

        public static string updateLicense(License license)
        {
            return LicenseDA.updateLicense(license);
        }

    }
}
