using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PlanitTest.Helpers;
using System;

namespace PlanitTest.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [TestInitialize]

        public void SetUp()
        {
            int implicitWaitSec = Constants.IMPLICIT_WAIT_DEFAULT;
            var factory = new WebDriverFactory();
            Driver = factory.GetBrowser(BrowserType.Chrome);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitSec); //sets global implicit wait
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}