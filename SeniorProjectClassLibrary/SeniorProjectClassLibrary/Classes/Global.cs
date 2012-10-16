using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
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
