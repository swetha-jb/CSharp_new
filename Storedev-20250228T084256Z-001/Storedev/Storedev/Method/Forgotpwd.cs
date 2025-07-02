using OpenQA.Selenium;
using Storedev.Xpath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Method
{
    public class Forgotpwd
    {
        protected IWebDriver driver;
        private IJavaScriptExecutor js;
        public Forgotpwd(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void forgotpass()
        {
            driver.FindElement(Locators.forgot_password).Click();
            Thread.Sleep(2000);

        }
        public void email_fill(string email)
        {
            driver.FindElement(Locators.fill_email).SendKeys(email);
            js.ExecuteScript("window.scrollBy(0, 150);");
            Thread.Sleep(30000);
        }
        public void clckbutton()
        {
            driver.FindElement(Locators.click_on_button).Click();
            Thread.Sleep(2000);
        }
        public void otp(string email)
        { 
            js.ExecuteScript("window.scrollBy(0, 150);");
            Thread.Sleep(500);
            string verificationCode = method_forgotpass(driver,email);
            Console.WriteLine("OTP received: " + verificationCode);
            js.ExecuteScript("window.scrollBy(0,2000);");
            Thread.Sleep(2000);
            driver.FindElement(Locators.Eneter_verificationcode).SendKeys(verificationCode);
            Thread.Sleep(500);
        }
        public void new_pass(string pass)
        {
            driver.FindElement(Locators.Eneter_Newpassword).SendKeys(pass);
            Thread.Sleep(500);
        }
        public void cnf_pass(string pass)
        {
            driver.FindElement(Locators.Eneter_cnfpassword).SendKeys(pass);
            Thread.Sleep(500);
        }
        public void clckbutton1()
        {
            driver.FindElement(Locators.click_on_submittbutton).Click();
            Thread.Sleep(2000);
        }
        public static string method_forgotpass(IWebDriver driver, string email)
        {
            driver.Navigate().GoToUrl("https://yopmail.com/en/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='login']")).SendKeys(email);
            driver.FindElement(By.XPath("//button[@onclick='{if(chkl())go()}']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Frame("ifmail");
            string otp = driver.FindElement(By.XPath("//tr/td[text()='Verification Code: ']/b")).Text;
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            return otp;
        }
    }
}
