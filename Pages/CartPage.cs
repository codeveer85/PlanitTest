using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PlanitTest.Helpers;

namespace PlanitTest.Pages

{
    public class CartPage : BasePage
    {

        public CartPage(IWebDriver driver) : base(driver)
        {

        }
        private IEnumerable <IWebElement> ItemsInCart => Driver.FindElements(By.CssSelector("[name= 'quantity']"));

        private IEnumerable<IWebElement> ItemsName => Driver.FindElements(By.CssSelector(".cart-item td:nth-child(1)"));

        public Dictionary<Product, int> ItemsPresentInCart()
        {
            var ItemsAdded = new Dictionary<Product, int>();
            int count =ItemsInCart.Count();
            for (int i = 0; count > 0; count--, i++)
            {
                ItemsAdded[ProductName(ItemsName.ElementAt(i).Text)] = Convert.ToInt32(ItemsInCart.ElementAt(i).GetAttribute("value"));
            }
            return ItemsAdded;
        }

        public Product ProductName(String product)
        {

            Product productname = Product.TeddyBear;
            switch (product)
            {
                case "Fluffy Bunny":
                    productname = Product.FluffyBunny;
                    break;
                case "Funny Cow":
                    productname = Product.FunnyCow;
                    break;

            }
            return productname;

        }
    }
}