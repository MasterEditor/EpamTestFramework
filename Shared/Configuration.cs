using FrameworkCore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Shared
{
    public class Configuration
    {
        private static Configuration _instance;
        public static Configuration Instance
        {
            get { return _instance ?? (_instance = new Configuration()); }
        }

        private Configuration()
        {
            Root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("configuration.json", false)
                .Build();
        }

        public readonly IConfigurationRoot Root;

        public string this[string name]
        {
            get { return Root[name]; }
        }

    }
}
