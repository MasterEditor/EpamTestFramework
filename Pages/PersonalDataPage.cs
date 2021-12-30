﻿using System;
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
            NicknameField.Clear();
            NicknameField.SendKeys(nickname);
            ConfirmButton.Click();
            return this;
        }



    }
}