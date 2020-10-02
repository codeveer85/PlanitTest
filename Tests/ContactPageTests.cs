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
    [TestClass, TestCategory(TestCategory.ContactPage)]
    public class ContactPageTests : BaseTest
    {
        [TestMethod, Description("Validate the error messages of ContactPage"), TestProperty("Author", "NikhilKumar"), TestCategory(TestCategory.Regression)]

        public void TestCase1()

        {
            try
            {
                //arrange
                var foreName = "Batista";
                var email = "batista@wwe.com";
                var message = "I am Batista-The Animal";
                var homePage = new HomePage(Driver);

                //act
                homePage.GoTo();
                ContactPage contactPage = homePage.GoToContactPage();
                contactPage.ClickSubmitButton();

                //Asserts on empty mandatory fields
                Assert.AreEqual("Forename is required", contactPage.GetForeNameErrorMsg(), $"Displayed Forename error message  is different and looks like : {contactPage.GetForeNameErrorMsg()}");
                Assert.AreEqual("Email is required", contactPage.GetEmailErrorMsg(), $"Displayed Email error message  is different and looks like : {contactPage.GetEmailErrorMsg()}");
                Assert.AreEqual("Message is required", contactPage.GetMessageErrorMsg(), $"Displayed Error message on message field is different and looks like : {contactPage.GetMessageErrorMsg()}");
                // Populate Mandatory Fields
                contactPage.InputMandatoryConatctDetails(foreName, email, message);
                // Asserts on error message fields not visible
                Assert.AreEqual(string.Empty, contactPage.GetForeNameErrorMsg(), $"Error messge for ForeName field is visible");
                Assert.AreEqual(string.Empty, contactPage.GetEmailErrorMsg(), $"Error messge for Email field is visible");
                Assert.AreEqual(string.Empty, contactPage.GetMessageErrorMsg(), $"Error messge for Message field is visible");
            }

            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod, Description("Validate the Successful submission Message on Contact Page"), TestProperty("Author", "NikhilKumar"), TestCategory(TestCategory.Regression)]

        public void TestCase2()

        {
            try
            {
                //arrange
                var foreName = "Batista";
                var email = "batista@wwe.com";
                var message = "I am Batista-The Animal";
                //act
                var homePage = new HomePage(Driver);
                homePage.GoTo();
                ContactPage contactPage = homePage.GoToContactPage();

                // Populate Mandatory Fields
                contactPage.InputMandatoryConatctDetails(foreName, email, message);
                contactPage.ClickSubmitButton();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("alert-success")));

                //assert on validating successful messgae
                Assert.AreEqual($"Thanks {foreName}, we appreciate your feedback.", contactPage.GetSuccessMessage(), $"Displayed succesful message recieved is different and looks like : {contactPage.GetSuccessMessage()}");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }



        [TestMethod, Description("Validate the Error Messages on submitting Invalid Data"), TestProperty("Author", "NikhilKumar"), TestCategory(TestCategory.SIT)]

        public void TestCase3()

        {
            try
            {
                var invalidEmail = "Email";
                var invalidPhone = "Phone";
                var homePage = new HomePage(Driver);
                homePage.GoTo();
                ContactPage contactPage = homePage.GoToContactPage();
                //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                //wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".btn-contact.btn.btn-primary")));
                contactPage.EnterEmail(invalidEmail);
                contactPage.EnterTelephone(invalidPhone);

                Assert.AreEqual("Please enter a valid email", contactPage.GetEmailErrorMsg(), $"Displayed Email error message  is different and looks like : {contactPage.GetEmailErrorMsg()}");
                Assert.AreEqual("Please enter a valid telephone number", contactPage.GetTelephoneErrorMsg(), $"Displayed telephone error message  is different and looks like : {contactPage.GetTelephoneErrorMsg()}");
            }

            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
