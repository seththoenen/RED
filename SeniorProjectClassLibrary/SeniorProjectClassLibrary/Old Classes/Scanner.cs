using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Scanner : Equipment
    {
        private string bedSize;
        private string speed;
        private string connectivity;
    
        public string BedSize
        {
            get
            {
                return bedSize;
            }
            set
            {
                bedSize = value;
            }
        }

        public string Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public string Connectivity
        {
            get
            {
                return connectivity;
            }
            set
            {
                connectivity = value;
            }
        }
    }
}
