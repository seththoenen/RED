using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Settings
    {
        public static string saveSetting(string value, string type)
        {
            return SettingsDA.saveSetting(value, type);
        }

        public static string deleteSetting(int id)
        {
            return SettingsDA.deleteSetting(id);
        }

        public static bool authenticatePassword(string password)
        {
            return SettingsDA.authenticatePassword(password);
        }

    }
}
