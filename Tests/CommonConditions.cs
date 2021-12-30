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
using NUnit.Framework.Interfaces;
using FrameworkCore.Utils;

namespace FrameworkCore.Tests
{
    [TestFixture]
    public class CommonConditions
    {
        [OneTimeSetUp]
        public void Startup()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Configuration.Instance["LogFile"]).CreateLogger();

            Log.Debug("Initialized");
        }

        [TearDown]
        public void TearDown()
        {
            var context = TestContext.CurrentContext;
            Log.Information($"Test '{context.Test.Name}' finished: {context.Result.Outcome.ToString()} ({context.Result.Message})");
            bool havePassed = context.Result.Outcome.Status == TestStatus.Passed;
            if (havePassed) return;

            ScreenshotHelper.TakeScreenshot();
        }

        [OneTimeTearDown]
        public void Close()
        {
            Log.Debug("Close driver");
            Log.CloseAndFlush();
            Driver.CloseDriver();
        }
    }
}
