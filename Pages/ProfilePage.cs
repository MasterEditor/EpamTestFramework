using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameworkCore.Models;
using OpenQA.Selenium;


namespace FrameworkCore.Pages
{
    internal class ProfilePage : BasePage
    {
        public IWebElement Nickname => Driver.FindElement(By.XPath("//p[@data-test-profile-view-nickname]"));

        public ProfilePage OpenPage()
        {
            Driver.Navigate().GoToUrl("https://binarium.link/main/profile");
            return this;
        }

        public string GetNickname()
        {
            return Nickname.Text;
        }


    }
}
