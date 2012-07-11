using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
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
    }
}
