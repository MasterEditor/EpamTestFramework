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
using Serilog;
using System.IO;

namespace FrameworkCore.Tests
{
    [TestFixture]
    public class CommonConditions
    {
        [OneTimeSetUp]
        public void Startup()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Directory.GetCurrentDirectory() + Configuration.Instance["LogFile"]).CreateLogger();
        }

        [OneTimeTearDown]
        public void Close()
        {
            Driver.CloseDriver();
        }
    }
}
