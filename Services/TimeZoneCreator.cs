using FrameworkCore.Models;
using FrameworkCore.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Services
{
    public static class TimeZoneCreator
    {
        private static IConfigurationSection _timeZonesConfigSection = Configuration.Instance.Root.GetSection("TimeZones");

        public static Models.TimeZone CreateFirst()
        {
            return new Models.TimeZone
            {
                ShortValue = _timeZonesConfigSection["First"],
                FullValue = $"(UTC {_timeZonesConfigSection["First"]})"
            };
        }

        public static Models.TimeZone CreateSecond()
        {
            return new Models.TimeZone
            {
                ShortValue = _timeZonesConfigSection["Second"],
                FullValue = $"(UTC {_timeZonesConfigSection["Second"]})"
            };
        }
    }
}
