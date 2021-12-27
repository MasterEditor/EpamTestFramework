using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkCore.Shared
{
    public static class Driver
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver is null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                ChromeOptions options = new ChromeOptions();
                options.AddArgument(@"user-data-dir=C:\Users\ILLUSION\AppData\Local\Google\Chrome\User Data");
                _driver = new ChromeDriver(options);
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Quit();
            _driver = null;
        }

    }
}
