using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Copier : Equipment
    {
        private Boolean color;
        private bool staple;
    
        public Boolean Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public Boolean Staple
        {
            get
            {
                return staple;
            }
            set
            {
                staple = value;
            }
        }
    }
}
