using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace POSSIBLE.ProfiledContentRepository
{
    public static class ConfigManager
    {
        public static bool EnableProfiledRepository
        {
            get
            {
                string sett = ConfigurationManager.AppSettings.Get("EnableProfiledRepository");
                if (sett != null && sett.ToLower() == "true")
                {
                    return true;
                }
                return false;
            }
            
        }
    }
}
