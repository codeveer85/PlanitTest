using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PlanitTest.Pages
{
    public class ContactPage : BasePage
    {
        public ContactPage(IWebDriver driver) : base(driver) { }
        private IWebElement ForeName => Driver.FindElement(By.Id("forename"));
        private IWebElement EMail => Driver.FindElement(By.Id("email"));
        private IWebElement TelePhone => Driver.FindElement(By.Id("telephone"));
        private IWebElement Message => Driver.FindElement(By.Id("message"));
        private IWebElement SubmitButton => Driver.FindElement(By.CssSelector(".btn-contact.btn.btn-primary"));
        private IEnumerable<IWebElement> ForeNameError => Driver.FindElements(By.Id("forename-err"));

        private IEnumerable<IWebElement> EmailError => Driver.FindElements(By.Id("email-err"));
        private IEnumerable<IWebElement> TelePhoneError => Driver.FindElements(By.Id("telephone-err"));
        private IEnumerable<IWebElement> MessageError => Driver.FindElements(By.Id("message-err"));


        public void EnterForeName(string forename)
        {
            ForeName.SendKeys(forename);
        }
        public void EnterEmail(string email)
        {
            EMail.SendKeys(email);
        }
        public void EnterMessage(string message)
        {
            Message.SendKeys(message);
        }
        public void EnterTelephone(string telephone)
        {
            TelePhone.SendKeys(telephone);
        }

        internal string GetForeNameErrorMsg()
        {
            if (ForeNameError.Count() > 0)
                return ForeNameError.ElementAt(0).Text;
            else
                return
                    string.Empty;
        }

        internal string GetEmailErrorMsg()
        {
            if (EmailError.Count() > 0)
                return EmailError.ElementAt(0).Text;
            else
                return
                    "";
        }

        internal string GetMessageErrorMsg()
        {
            if (MessageError.Count() > 0)
                return MessageError.ElementAt(0).Text;
            else
                return
                    "";
        }
        internal string GetTelephoneErrorMsg()
        {
            if (TelePhoneError.Count() > 0)
                return TelePhoneError.ElementAt(0).Text;
            else
                return
                    "";
        }



        public void ClickSubmitButton()
        {
            RawClick(SubmitButton);
        }



       
        public void RawClick(IWebElement elem)
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView()", elem);
            js.ExecuteScript("arguments[0].click();", elem);
        }
        public void InputMandatoryConatctDetails(string foreName, string email, string message)
        {
            EnterForeName(foreName);
            EnterEmail(email);
            EnterMessage(message);
        }
        public string GetSuccessMessage()
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[ui-if='contactValidSubmit'] div"))).Text;
        }

        
    }
}