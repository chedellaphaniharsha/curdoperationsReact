using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperationsReact.Utilitiy
{
    public class LoadConnectionString
    {
        public string LoadString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json").Build();
            string constr = configuration.GetConnectionString("constr");
            return constr;
        }
    }
}
