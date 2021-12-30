using FrameworkCore.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Pages
{
    internal class LoginPage : BasePage
    {
        public IWebElement EmailInput => Driver.FindElement(By.XPath("//input[@formcontrolname=\"email\"]"));
        public IWebElement PasswordInput => Driver.FindElement(By.XPath("//input[@type=\"password\"]"));
        public IWebElement SubmitButton => Driver.FindElement(By.CssSelector(".c-button.ng-star-inserted"));
        public IWebElement LoginOptionButton => Driver.FindElement(By.CssSelector(".c-buttons > button:first-child"));
        public IWebElement AvatarBar => Driver.FindElement(By.ClassName("avatar__bar"));

        public LoginPage OpenPage()
        {
            Driver.Navigate().GoToUrl("https://binarium.world/");
            return this;
        }

        public void Login(User user)
        {
            LoginOptionButton.Click();

            EmailInput.Clear();
            PasswordInput.Clear();

            EmailInput.SendKeys(user.Login);
            PasswordInput.SendKeys(user.Password);

            SubmitButton.Click();

            //Wait.Until(_driver => _driver.FindElement(By.ClassName("wallet-menu-total__amount")));
        }

    }
}
