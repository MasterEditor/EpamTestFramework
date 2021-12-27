using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using FrameworkCore.Shared;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.Pages
{
    internal class BasePage
    {
        protected IWebDriver Driver
        {
            get { return Shared.Driver.GetDriver(); }
        }

        private WebDriverWait _wait;
        protected WebDriverWait Wait
        {
            get { return _wait ?? (_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15))); }
        }

    }
}
