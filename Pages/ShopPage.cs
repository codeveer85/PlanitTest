using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PlanitTest.Helpers;

namespace PlanitTest.Pages

{
    public class ShopPage: BasePage
    {
        
        public ShopPage(IWebDriver driver) : base(driver)
        {
           
        }

        private IWebElement FunnyCowBuyButton => Driver.FindElement(By.CssSelector("#product-6 a"));
        private IWebElement FluffyBunnyBuyButton => Driver.FindElement(By.CssSelector("#product-4 a"));

        public IWebElement CartLink => Driver.FindElement(By.Id("nav-cart"));

      

        public CartPage GoToCartPage()
        {
            CartLink.Click();
            return new CartPage(Driver);
        }


        // Receives the product and quantity and add it to cart
        internal void AddProductToCart(Product product, int quantity)
        {
            var js = (IJavaScriptExecutor)Driver;
            switch (product)
            {
                case Product.FluffyBunny:
                    for (int i = quantity; i > 0; i--)
                        js.ExecuteScript("arguments[0].click();", FluffyBunnyBuyButton);
                    break;
                case Product.FunnyCow:
                    for (int i = quantity; i > 0; i--)
                        js.ExecuteScript("arguments[0].click();", FunnyCowBuyButton);
                    break;
                //default:
                    
                //    break;
            }
        }


        public bool compareDictionaries(Dictionary<Product, int> dictionary1, Dictionary<Product, int> dictionary2)
        {
            bool Isidentical = false;
            return Isidentical = dictionary1.Count == dictionary2.Count && dictionary1.Keys.SequenceEqual(dictionary2.Keys) && dictionary1.Values.SequenceEqual(dictionary2.Values);
        }

    }
}