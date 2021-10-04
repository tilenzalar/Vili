using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappServerApp.BusinessLogic
{
    public class AppSettingsReader
    {
        private readonly IConfiguration _configuration;

        public AppSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAPIConnectionString()
        {
            return _configuration["API:ConnectionString"];
        }
    }
}
