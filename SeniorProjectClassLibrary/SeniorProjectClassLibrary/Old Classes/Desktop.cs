using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Desktop : Computer
    {
        private string size;
        private Monitor monitor;
    
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


        public Monitor Monitor 
        {
            get
            {
                return monitor;
            }
            set
            {
                monitor = value;
            }
        }
    }
}
