using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SeniorProjectClassLibrary.DAL;


namespace SeniorProjectClassLibrary.Classes
{
    public class Computer : Inventory
    {
        private int compID;
        private string cpu;
        private string videoCard;
        private string hardDrive;
        private string memory;
        private string opticalDrive;
        private string removableMedia;
        private int? usbPorts;
        private string otherConnectivity;
        private string size;
        private ArrayList monitors;
        private string type;

        public Computer()
        {
            monitors = new ArrayList();
            po = new PurchaseOrder();
            groups = new ArrayList();
            logistics = new ArrayList();
            currentLocation = new Logistics();
            licenses = new ArrayList();
            warranties = new ArrayList();
        }

        public int CompID
        {
            get
            {
                return compID;
            }
            set
            {
                compID = value;
            }
        }
        
        public string CPU
        {
            get
            {
                return cpu;
            }
            set
            {
                cpu = value;
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


        public string VideoCard
        {
            get
            {
                return videoCard;
            }
            set
            {
                videoCard = value;
            }
        }

        public string HardDrive
        {
            get
            {
                return hardDrive;
            }
            set
            {
                hardDrive = value;
            }
        }

        public string Memory
        {
            get
            {
                return memory;
            }
            set
            {
                memory = value;
            }
        }

        public string OpticalDrive
        {
            get
            {
                return opticalDrive;
            }
            set
            {
                opticalDrive = value;
            }
        }

        public string RemovableMedia
        {
            get
            {
                return removableMedia;
            }
            set
            {
                removableMedia = value;
            }
        }

        public int? USBports
        {
            get
            {
                return usbPorts;
            }
            set
            {
                usbPorts = value;
            }
        }

        public string OtherConnectivity
        {
            get
            {
                return otherConnectivity;
            }
            set
            {
                otherConnectivity = value;
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


        public ArrayList Monitors
        {
            get
            {
                return monitors;
            }
            set
            {
                monitors = value;
            }
        }

        public static string saveComputers(ArrayList computers)
        {
            return ComputerDA.saveComputers(computers);
        }

        public static Boolean computerExist(string serialNo)
        {
            return ComputerDA.computerExist(serialNo);
        }

        public static Computer getComputer(string invID)
        {
            return ComputerDA.getComputer(invID);
        }

        public static string updateComputers(ArrayList computers)
        {
            return ComputerDA.updateComputers(computers);
        }

        public static bool computerTransferred(string serialNo)
        {
            return ComputerDA.computerTransferred(serialNo);
        }

        public static string updateComputer(Computer oComp, Computer comp)
        {
            return ComputerDA.updateComputer(oComp, comp);
        }

        public static int? computerExistReturnID(string serialNo)
        {
            return ComputerDA.computerExistReturnID(serialNo);
        }
    }
}
