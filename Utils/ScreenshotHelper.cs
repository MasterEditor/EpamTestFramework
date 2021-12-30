using FrameworkCore.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Utils
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot()
        {
            string screenshotName = $"{DateTime.Now.ToString("dd-MM-yy HH.mm")} - {TestContext.CurrentContext.Test.MethodName}.png";
            string screenshotPath = Configuration.Instance["ScreenshotPath"];

            if (!Directory.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }

           ((ITakesScreenshot)Driver.GetDriver())
              .GetScreenshot().
              SaveAsFile(screenshotPath + screenshotName, ScreenshotImageFormat.Png);
        }
    }
}
