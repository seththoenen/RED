using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
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

        public static ArrayList getMonitors()
        {
            return MonitorDA.getMonitors();
        }

        public static Monitor getMonitor(int monID)
        {
            return MonitorDA.getMonitor(monID);
        }

        public static string saveMonitor(Monitor mon)
        {
            return MonitorDA.saveMonitor(mon);
        }

        public static string updateMonitor(Monitor mon)
        {
            return MonitorDA.updateMonitor(mon);
        }

        public static string deleteMonitor(int monID, int compID)
        {
            return MonitorDA.deleteMonitor(monID, compID);
        }

        public static string addMonitor(int monID, int compID)
        {
            return MonitorDA.addMonitor(monID, compID);
        }

        public static string deleteMonitors(ArrayList serialNos)
        {
            return MonitorDA.deleteMonitors(serialNos);
        }

        public static string removeSelectMonitor(ArrayList serialNos, int monID)
        {
            return MonitorDA.removeSelectMonitor(serialNos, monID);
        }

        public static string addMonitorsComputer(ArrayList serialNos, int monID)
        {
            return MonitorDA.addMonitorsComputer(serialNos, monID);
        }

    }
}
