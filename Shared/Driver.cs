using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
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
                var browser = Configuration.Instance["Browser"];

                switch (browser)
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        _driver = new EdgeDriver();
                        break;
                    case "Firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        _driver = new FirefoxDriver();
                        break;
                    case "IE":
                        new DriverManager().SetUpDriver(new InternetExplorerConfig());
                        _driver = new InternetExplorerDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        _driver = new ChromeDriver();
                        break;
                }
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
