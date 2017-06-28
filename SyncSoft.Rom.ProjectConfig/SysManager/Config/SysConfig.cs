using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoft.Rom.ProjectConfig.SysManager.Config
{
   public class SysConfig
    {
        public static string GetScriptParameter()
        {
            return ConfigurationManager.AppSettings["scriptVersion"]; 
        }


        public static string GetDataBaseQz()
        {
            return "OMS.";
        }
    }
}
