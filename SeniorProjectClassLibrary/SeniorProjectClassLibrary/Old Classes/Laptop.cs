using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Laptop : Computer
    {
        private string size;
    
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
    }
}
