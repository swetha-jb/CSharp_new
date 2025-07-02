using Storedev.Xpath;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Storedev.Method
{
    public class Login_withMFA
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;


        public Login_withMFA(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;

        }
        public void SetEmail(string email)
        {
            driver.FindElement(Locators.EmailInput).Clear();
            Thread.Sleep(500);
            driver.FindElement(Locators.EmailInput).SendKeys(email);
            Thread.Sleep(1000);
        }
        public void SetPassword(string password)
        {
            driver.FindElement(Locators.PasswordInput).Clear();
            Thread.Sleep(500);
            driver.FindElement(Locators.PasswordInput).SendKeys(password);
            Thread.Sleep(500);
        }
        public void submit()
        {
            driver.FindElement(Locators.submitt_button_1).Click();
            Thread.Sleep(3000);
            js.ExecuteScript("window.scrollBy(0, 450);");
            Thread.Sleep(3000);
        }
        public void otp(string email)
        {

            js.ExecuteScript("window.scrollBy(0,500);");
            Thread.Sleep(1000);
            string otp = email_otpvarification(driver, email);
            Console.WriteLine("OTP received: " + otp);
            Thread.Sleep(2000);
            driver.FindElement(Locators.click_on_mfabox).Click();
            Thread.Sleep(1000);
            driver.FindElement(Locators.click_on_mfabox).SendKeys(otp);
            Thread.Sleep(1000);
        }

        
        public void continue_button()
        {
            driver.FindElement(Locators.continue_button).Click();
            Thread.Sleep(3000);
        }
        public void do_nottrust()
        {
            driver.FindElement(Locators.donot_trust).Click();
            Thread.Sleep(11000);
        }

        
        public static string email_otpvarification(IWebDriver driver, string email)
        {
            driver.Navigate().GoToUrl("https://yopmail.com/en/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='login']")).SendKeys(email);
            driver.FindElement(By.XPath("//button[@onclick='{if(chkl())go()}']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("ifmail");
            string otp = driver.FindElement(By.XPath("(//td[@align='center'])[2]")).Text;
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            return otp;
        }
    }
}







        


