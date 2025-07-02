using OpenQA.Selenium;
using Storedev.Xpath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Method
{
    public class CongoSignupPage
    {
        protected IWebDriver driver;
        private IJavaScriptExecutor js;


        public CongoSignupPage(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }
        public void addincart()
        {
            driver.FindElement(Congo_Locators.Addtocart).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }
        public void clickcart()
        {
            driver.FindElement(Congo_Locators.click_oncart).Click();
            Thread.Sleep(7000);
            js.ExecuteScript("window.scrollBy(0, 400);");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }
        public void membership()
        {
            driver.FindElement(Congo_Locators.membership).Click();
            Thread.Sleep(9000);
        }
        public void checkout()
        {
            driver.FindElement(Congo_Locators.checkout).Click();
        }
        public void fill_fname(string fname)
        {
            driver.FindElement(Congo_Locators.fill_firstname).Clear();
            Thread.Sleep(100);
            driver.FindElement(Congo_Locators.fill_firstname).SendKeys(fname);
        }
        public void fill_lname(string lname)
        {
            driver.FindElement(Congo_Locators.fill_lastname).Clear();
            Thread.Sleep(100);
            driver.FindElement(Congo_Locators.fill_lastname).SendKeys(lname);
        }
        public void fill_emailfield(string email)
        {
            string storedEmail = email;
            Console.WriteLine($"storedEmail is: {storedEmail}");
            driver.FindElement(Congo_Locators.fill_emailfield).Clear();
            Thread.Sleep(100);
            driver.FindElement(Congo_Locators.fill_emailfield).SendKeys(email);
            js.ExecuteScript("window.scrollBy(0, 400);");
            Thread.Sleep(500);
        }
        public void fill_password(string pwd)
        {
            driver.FindElement(Congo_Locators.fill_password).Clear();
            Thread.Sleep(100);
            driver.FindElement(Congo_Locators.fill_password).SendKeys(pwd);
            Thread.Sleep(500);
        }
        public void fill_cinfpassword(string cnfpwd)
        {
            driver.FindElement(Congo_Locators.fill_cinfirmpwd).Clear();
            Thread.Sleep(100);
            driver.FindElement(Congo_Locators.fill_cinfirmpwd).SendKeys(cnfpwd);
            Thread.Sleep(500);
            js.ExecuteScript("window.scrollBy(0, -200);");
            Thread.Sleep(500);
        }
        public void button()
        {
            driver.FindElement(Congo_Locators.click_onbutton).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0, -200);");
            Thread.Sleep(6000);
        }
        public bool IsButtonClickable()
        {
            try
            {
                
                IWebElement button = driver.FindElement(Congo_Locators.click_onbutton);                
                return button.Enabled;
            }
            catch (NoSuchElementException)
            {                
                return false;
            }
        }
        public void password(string password)
        {
            driver.FindElement(Congo_Locators.fillpwd).SendKeys(password);
            Thread.Sleep(300);
            js.ExecuteScript("window.scrollBy(0, 100);");
            Thread.Sleep(500);
        }
        public void signin_button()
        {
            driver.FindElement(Congo_Locators.click_signinbutton).Click();
        }
    }
}
