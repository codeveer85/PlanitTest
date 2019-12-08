using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanitTest.Helpers;
using System;
using System.IO;
using System.Reflection;

namespace PlanitTest
{
    public class WebDriverFactory
    {
        
        public IWebDriver GetBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();

                case BrowserType.IExplorer:
                    return GetIEDriver();

                case BrowserType.FireFox:
                    return GetFireFoxDriver();


                default:
                    throw new ArgumentOutOfRangeException("We Does not need this Browser");
            }
        }

        private IWebDriver GetFireFoxDriver()
        {
            throw new NotImplementedException();
        }

        private IWebDriver GetIEDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }


    }
}
    
