using System;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.API.Helpers
{
    public class WebConfigHelper
    {
        public static string GetConnectionString()
        {
            return WebConfigurationManager.ConnectionStrings[Environment.MachineName].ConnectionString;
        }
    }
}
