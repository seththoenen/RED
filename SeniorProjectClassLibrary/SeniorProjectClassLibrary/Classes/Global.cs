using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SeniorProject
{
    public class GlobalVars
    {
        static string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

        public static string ConnectionString
        {
            get
            {
                return connString;
            }
        }
    }
}
