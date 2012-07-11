using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Computers : Equipment
    {
        private string cpu;
        private string videoCard;
        private string hardDrive;
        private string memory;
        private string opticalDrive;
        private string removableMedia;
        private string usbPorts;
        private string otherConnectivity;
        private string name;
    
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

        public string USBports
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
    }
}
