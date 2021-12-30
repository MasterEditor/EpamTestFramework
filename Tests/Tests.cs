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
using Serilog;
using FrameworkCore.Services;
using FrameworkCore.Models;
using FrameworkCore.Utils;

namespace FrameworkCore.Tests
{
    [TestFixture]
    public class Tests : CommonConditions
    {

        [Test, Order(1)]
        public void LogInTest()
        {
            var loginPage = new LoginPage()
                .OpenPage();

            var driver = Driver.GetDriver();
            var startUrl = driver.Url;

            loginPage.Login(UserCreator.CreateWithEmptyUsername());
            Assert.AreEqual(startUrl, driver.Url);

            loginPage.Login(UserCreator.CreateFromConfig());
            Assert.That(loginPage.AvatarBar, Is.Not.Null);
        }

        [Test, Order(2)]
        public void ChangeAssetTest()
        {
            var tradePage = new TradePage()
                .OpenPage();

            tradePage.SelectEURAsset();
            StringAssert.AreEqualIgnoringCase("EUR/USD (OTC)", tradePage.CurrentAsset.Text);

            tradePage.SelectBitcoinAsset();
            StringAssert.AreEqualIgnoringCase("BITCOIN", tradePage.CurrentAsset.Text);

        }

        [Test, Order(3)]
        public void PlaceBetTest()
        {
            var tradePage = new TradePage();
            //tradePage.SelectBitcoinAsset();
            tradePage.SelectDemoAccount();

            var validBet = BetCreator.CreateCorrectBet();
            tradePage.PlaceBet(validBet);

            var invalidBet = BetCreator.CreateIncorrectBet();
            tradePage.PlaceBet(invalidBet);

            var openBets = tradePage.GetOpenBets();

            CollectionAssert.Contains(openBets, validBet);
            CollectionAssert.DoesNotContain(openBets, invalidBet);
        }

        [Test, Order(4)]
        public void ChangeTimeZoneTest()
        {
            var tradePage = new TradePage();

            var timeZone = TimeZoneCreator.CreateFirst();
            tradePage.ChangeTimeZone(timeZone);
            string currentTimeZone = tradePage.GetCurrentTimeZone();

            StringAssert.AreEqualIgnoringCase(timeZone.FullValue, currentTimeZone);

            timeZone = TimeZoneCreator.CreateSecond();
            tradePage.ChangeTimeZone(timeZone);
            currentTimeZone = tradePage.GetCurrentTimeZone();

            StringAssert.AreEqualIgnoringCase(timeZone.FullValue, currentTimeZone);
        }

        [Test, Order(5)]
        public void ChangeNicknameTest()
        {
            var nickname = StringHelper.RandomString(10);

            new PersonalDataPage()
                .OpenPage()
                .ChangeNickname(nickname);

            var confirmedNickname = new ProfilePage()
                .OpenPage()
                .GetNickname();

            StringAssert.AreEqualIgnoringCase(nickname, confirmedNickname);
        }
    }
}
