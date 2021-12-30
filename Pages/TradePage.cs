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
    internal class TradePage : BasePage 
    {
        public IReadOnlyCollection<IWebElement> OpenBets => Driver.FindElements(By.CssSelector("div.open-option"));
        public IWebElement BetInput => Driver.FindElement(By.XPath("(//textarea[@a-test=\"chartBetValue\"])[2]"));
        public IWebElement BetTime => Driver.FindElement(By.XPath("(//span[@a-test=\"currentExpiration\"])[2]"));
        public IWebElement PlaceBetButton => Driver.FindElement(By.XPath("(//div[@class=\"chart-buy__button --call\"])[2]"));
        public IWebElement UpdateBetTimeButton => Driver.FindElement(By.XPath("(//div[@class=\"spinners__button --inc\"])[3]"));
        public IWebElement HistoryButton => Driver.FindElement(By.XPath("//div[@a-test=\"tradingHistoryMenuBtn\"]"));
        public IWebElement EURAssetSelector => Driver.FindElement(By.CssSelector(".chart-tabs > .chart-tabs__item:nth-child(1)"));
        public IWebElement BitcoinAssetSelector => Driver.FindElement(By.CssSelector(".chart-tabs > .chart-tabs__item:nth-child(2)"));
        public IWebElement WalletMenu => Driver.FindElement(By.ClassName("wallet-menu-total__view"));
        public IWebElement DemoAccountSelector => Driver.FindElement(By.CssSelector(".wallet-account.--demo"));
        public IWebElement CurrentAsset => Driver.FindElement(By.XPath("//div[@class=\"chart-tab --active --closable\"]/div[1]/div[1]/div[1]"));
        public IWebElement OpenSettingsButton => Driver.FindElement(By.ClassName("settings-button"));
        public IWebElement CloseSettingsButton => Driver.FindElement(By.XPath("//div[@a-test=\"settings-close\"]"));
        public IWebElement TimeZoneDropdown => Driver.FindElement(By.XPath("//div[@a-test=\"settings-timezone\"]"));
        public IWebElement CurrentTimeZone => Driver.FindElement(By.XPath("(//div[@class=\"server-time__offset\"])[2]"));

        public TradePage OpenPage()
        {
            Driver.Navigate().GoToUrl("https://binarium.world/terminal");
            return this;
        }

        public TradePage SelectBitcoinAsset()
        {
            BitcoinAssetSelector.Click();
            return this;
        }

        public TradePage SelectEURAsset()
        {
            EURAssetSelector.Click();
            return this;
        }

        public TradePage SelectDemoAccount()
        {
            WalletMenu.Click();
            DemoAccountSelector.Click();
            return this;
        }

        public TradePage SetBetValue(int betValue)
        {
            BetInput.Clear();
            BetInput.SendKeys(Keys.Backspace);
            BetInput.SendKeys(Convert.ToString(betValue));
            return this;
        }

        public TradePage PlaceBet(Bet bet)
        {
            SetBetValue(bet.Value);
            bet.Time = BetTime.Text;
            PlaceBetButton.Click();
            UpdateBetTimeButton.Click();
            return this;
        }

        public List<Bet> GetOpenBets()
        {
            SwitchHistory();

            List<Bet> bets = new List<Bet>();

            foreach(var openBetElement in OpenBets)
            {
                var stringValue = openBetElement.FindElement(By.CssSelector("div.open-option__bet > bdi")).Text;
                var value = int.Parse(stringValue, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
                bets.Add(new Bet(value));
            }

            SwitchHistory();

            return bets;

        }

        public TradePage SwitchHistory()
        {
            HistoryButton.Click();
            return this;
        }

        public TradePage ChangeTimeZone(Models.TimeZone timeZone)
        {
            OpenSettingsButton.Click();
            TimeZoneDropdown.Click();

            var timeZoneSelector = Driver.FindElement(By.XPath($"//div[@class=\"t-select-list__option\"]/span[text()=\" {timeZone.ShortValue} \"]"));
            timeZoneSelector.Click();

            CloseSettingsButton.Click();

            return this;
        }

        public string GetCurrentTimeZone()
        {
            return CurrentTimeZone.Text;
        }
    }
}
