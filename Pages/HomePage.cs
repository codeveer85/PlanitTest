using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PlanitTest.Pages
{
    internal class HomePage: BasePage
    {
        public HomePage(IWebDriver driver):base(driver)
        {
        }

        private IWebElement ShopMenu => Driver.FindElement(By.Id("nav-shop"));

        private IWebElement ContactMenu => Driver.FindElement(By.Id("nav-contact"));


        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }

        public ContactPage GoToContactPage()
        {
            ContactMenu.Click();
            
            return new ContactPage(Driver);
        }

        public ShopPage GoToShopPage()
        {
            ShopMenu.Click();
            return new ShopPage(Driver);
        }
    }
}