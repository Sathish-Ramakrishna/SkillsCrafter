using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.AppData
{
    public class AppSettings
    {
        #region Gets the Database Provider name specified in the App.config --> appSettings tag
        public static string DatabaseProvider
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseProvider"].ToString();
            }
        } 
        #endregion
    }
}
