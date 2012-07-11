using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Monitor
    {
        private int id;
        private string size;
        private string brand;
        private string resolution;
        private string connectors;
        private string model;
        private string displayText;

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

        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
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

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }

        public string Resolution
        {
            get
            {
                return resolution;
            }
            set
            {
                resolution = value;
            }
        }

        public string Connectors
        {
            get
            {
                return connectors;
            }
            set
            {
                connectors = value;
            }
        }

        public string DisplayText
        {
            get
            {
                return displayText;
            }
            set
            {
                displayText = value;
            }
        }

        public string toString()
        {
            return brand + "  " + size + " " + model;
        }
    }
}
