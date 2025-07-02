using OpenQA.Selenium;
using Storedev.Xpath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Method
{
    public class Congo_onetime_otp
    {
        protected IWebDriver driver;
        private IJavaScriptExecutor js;

        public Congo_onetime_otp(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void click_on_onetimeotp()
        {
            driver.FindElement(Congo_Locators.click_on_onetimepass).Click();
            js.ExecuteScript("window.scrollBy(0,1000);");
            Thread.Sleep(1000);
        }
        public void fill_one_time_email(string email)
        {
            driver.FindElement(Congo_Locators.onetime_email).SendKeys(email);
            Thread.Sleep(35000);
        }
        public void click_on_one_timebutton()
        {
            driver.FindElement(Congo_Locators.click_ontimebutton).Click();
            Thread.Sleep(2000);
        }
        public void otp(string email)
        {
            string otp = one_timeotp(driver, email);
            Console.WriteLine("OTP received: " + otp);
            Thread.Sleep(2000);
            driver.FindElement(Locators.fill_otp).SendKeys(otp);
            Thread.Sleep(1000);
        }
        public void click_on_ligin_button()
        {
            driver.FindElement(Congo_Locators.click_onlogin);
        }
        public static string one_timeotp(IWebDriver driver, string email)
        {
            driver.Navigate().GoToUrl("https://yopmail.com/en/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='login']")).SendKeys(email);
            driver.FindElement(By.XPath("//button[@onclick='{if(chkl())go()}']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("ifmail");
            IWebElement otpElement = driver.FindElement(By.XPath("//p[contains(text(),'One-time Password')]"));
            string otp = otpElement.Text.Substring(19, 6);
            Console.WriteLine("OTP received: " + otp);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            return otp;
        }
    }
}
