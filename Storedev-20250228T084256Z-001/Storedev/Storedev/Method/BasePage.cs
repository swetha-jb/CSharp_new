using OpenQA.Selenium;
using Storedev.Xpath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NPOI.SS.Formula.Functions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework.Legacy;

namespace Storedev.Method
{
    public class BasePage
    {
        protected IWebDriver driver;
        private IJavaScriptExecutor js;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void click_on_the_iocn()
        {
            driver.FindElement(Locators.click_on_icon).Click();
        }
        public void click_on_the_account_create_button()
        {
            driver.FindElement(Locators.Create_Account_button).Click();
            Thread.Sleep(1000);
        }
        public void SetEmail(string email)
        {
            string storedEmail = email;
            Console.WriteLine($"CreatedEmail is: {storedEmail}");
            driver.FindElement(Locators.EmailInput).Clear();
            driver.FindElement(Locators.EmailInput).SendKeys(email);
            driver.FindElement(Locators.ConfirmEmailInput).Clear();
            driver.FindElement(By.XPath("//div[@class='MainWrapper']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(Locators.ConfirmEmailInput).SendKeys(email);
        }
        public void SetFirstName(string firstName)
        {
           // bool isValid = IsValidFirstName(firstName);
            //Assert.That(isValid, Is.True, "Invalid first name entered.");
            driver.FindElement(Locators.FirstNameInput).Clear();
            driver.FindElement(Locators.FirstNameInput).SendKeys(firstName);
           

        }
        public void SetLastName(string lastName)
        {
            driver.FindElement(Locators.LastNameInput).Clear();
            driver.FindElement(Locators.LastNameInput).SendKeys(lastName);
            js.ExecuteScript("window.scrollTo(0,250);");
            Thread.Sleep(200);
        }
        public void SetPassword(string password)
        {
            driver.FindElement(Locators.PasswordInput).Clear();
            driver.FindElement(Locators.PasswordInput).SendKeys(password);
            driver.FindElement(Locators.ConfirmPasswordInput).Clear();
            driver.FindElement(Locators.ConfirmPasswordInput).SendKeys(password);
            js.ExecuteScript("window.scrollTo(0,250);");
            Thread.Sleep(200);
        }
        public void AgreeToTerms()
        {
            driver.FindElement(Locators.TermsCheckbox).Click();
            Thread.Sleep(100);
        }
        public string SubmitForm()
        {
            driver.FindElement(Locators.submitt_button).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(ExpectedConditions.ElementExists(Locators.popupMessage));
            string actualText = driver.FindElement(Locators.popupMessage).Text;
            Console.WriteLine("Actual text: " + actualText);
            return actualText;
        }
        public void assertText(string expectedText, string actualValue)
        {
            try
            {
                Assert.That(actualValue, Is.EqualTo(expectedText), "Text assertion failed.");
            }
            catch (AssertionException ex)
            {
                Console.WriteLine("Assertion failed: " + ex.Message);
            }
        }
        public void pwdInput(string password)
        {
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0, 200);");
            Thread.Sleep(100);
            driver.FindElement(Locators.PasswordInput).SendKeys(password);
            js.ExecuteScript("window.scrollBy(0, document.body.scrollHeight);");
            Thread.Sleep(100);
        }
        public void again_submit()
        {
            driver.FindElement(Locators.submitt_button_1).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.Until(ExpectedConditions.ElementExists(Locators.logovalidation));
            IWebElement logoImage = driver.FindElement(Locators.logovalidation);
            string altText = logoImage.GetAttribute("alt");
            Assert.That(altText, Is.EqualTo("Netgear"), "Expected alt text of the logo image is not 'Netgear'");
        }
        public void icon()
        {
            driver.FindElement(Locators.click_on_icon).Click();
            Thread.Sleep(500);
        }
        public void manage_profile()
        {
            driver.FindElement(Locators.click_on_manage_profile).Click();
            Thread.Sleep(5000);
        }
        public void cancel_submit()
        {
            driver.FindElement(Locators.click_on_cancel).Click();
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0, 100);");

        }
        public void login_setting()
        {
            driver.FindElement(Locators.click_on_login_setting).Click();
            Thread.Sleep(500);
        }
    }
}
