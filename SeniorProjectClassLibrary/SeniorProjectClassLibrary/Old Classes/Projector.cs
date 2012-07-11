using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeniorProject
{
    public class Projector : Equipment
    {
        private string resolution;
        private string connectors;
    
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
    }
}
