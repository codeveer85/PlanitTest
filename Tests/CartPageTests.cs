using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlanitTest.Helpers;
using PlanitTest.Pages;

namespace PlanitTest.Tests
{
    [TestClass, TestCategory(TestCategory.CartPage)]
    public class CartPageTests: BaseTest
    {
        [TestMethod, Description("Validate the cart for selected items"), TestProperty("Author", "NikhilKumar"), TestCategory(TestCategory.UAT)]

        public void TestCase4()
        {
            try
            {
                //arrange
                var ItemsTobeAdded = new Dictionary<Product, int>();          
                ItemsTobeAdded[Product.FunnyCow] = 2;
                ItemsTobeAdded[Product.FluffyBunny] = 1;

                var homePage = new HomePage(Driver);
                homePage.GoTo();
                ShopPage shopPage = homePage.GoToShopPage();
               

                //act
                foreach (var keyValuePair in ItemsTobeAdded)
                {
                    shopPage.AddProductToCart(keyValuePair.Key, keyValuePair.Value);
                }

                CartPage cartPage = shopPage.GoToCartPage();

                //assert

                Assert.IsTrue(shopPage.compareDictionaries(ItemsTobeAdded, cartPage.ItemsPresentInCart()), "Items in the cart are not same as the items added");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
