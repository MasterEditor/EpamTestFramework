using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrameworkCore.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.Pages
{
    internal class PersonalDataPage : BasePage
    {
        public IWebElement NicknameField => Driver.FindElement(By.XPath("//input[@data-test-profile-personal-nickname]"));
        public IWebElement ConfirmButton => Driver.FindElement(By.XPath("//button[@data-test-profile-personal-btn]"));

        public PersonalDataPage OpenPage()
        {
            Driver.Navigate().GoToUrl("https://binarium.link/main/profile/personal");
            return this;
        }

        public PersonalDataPage ChangeNickname(string nickname)
        {
            ScrollPage();

            NicknameField.Clear();
            NicknameField.SendKeys(nickname);
            ConfirmButton.Click();
            return this;
        }

        private void ScrollPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("javascript:window.scrollBy(250,350)");
        }



    }
}
