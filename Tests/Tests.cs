using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FrameworkCore.Shared;
using System.Threading;
using System.IO;
using FrameworkCore.Pages;

namespace FrameworkCore.Tests
{
    [TestFixture]
    public class Tests : CommonConditions
    {
        [Test]
        public void Test()
        {
            var loginPage = new LoginPage()
                .OpenPage();

            loginPage.Login();

            Assert.That(loginPage.AvatarBar, Is.Not.Null);
        }
    }
}
