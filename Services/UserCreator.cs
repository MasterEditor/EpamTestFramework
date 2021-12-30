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
    public static class UserCreator
    {
        private static IConfigurationSection _userConfigSection = Configuration.Instance.Root.GetSection("UserCredentials");

        public static User CreateFromConfig()
        {
            return new User
            {
                Login = _userConfigSection["Username"],
                Password = _userConfigSection["Password"]
            };
        }

        public static User CreateWithEmptyUsername()
        {
            var userSection = Configuration.Instance.Root.GetSection("UserCredentials");
            return new User
            {
                Login = "",
                Password = _userConfigSection["Password"]
            };
        }

        public static User CreateWithEmptyPassword()
        {
            var userSection = Configuration.Instance.Root.GetSection("UserCredentials");
            return new User
            {
                Login = _userConfigSection["Username"],
                Password = ""
            };
        }
    }
}
