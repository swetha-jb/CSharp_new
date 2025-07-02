using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Storedev.Xpath;
using System;
using System.Threading;
namespace Storedev.Method
{
    public class Changemail : BasePage
    {
        public Changemail(IWebDriver driver) : base(driver)
        {
        }
        public void click_on_changeemail()
        {
            driver.FindElement(Locators.click_on_changeemail).Click();
        }
        public void new_email(string new_email)
        { 
            string updated_email = new_email;
            Console.WriteLine($"ChangeEmail is: {updated_email}");
            driver.FindElement(Locators.fill_new_email).SendKeys(new_email);
        }
        public void cnf_new_email(string new_cnf_email)
        {
            driver.FindElement(Locators.fill_cnf_new_email).SendKeys(new_cnf_email);
        }
        public void current_pass(string current_password, IJavaScriptExecutor js)
        {
            driver.FindElement(Locators.fill_current_pass).SendKeys(current_password);
            js.ExecuteScript("window.scrollBy(0, 150);");
            Thread.Sleep(100);
        }
        public void submitt()
        {
            driver.FindElement(Locators.submit).Click();
            Thread.Sleep(1000);           
        }
        public void EnterOTP(string new_email, IJavaScriptExecutor js) 
        {
            string originalWindowHandle = driver.CurrentWindowHandle;
            string otp = RetrieveOTP(new_email, js);
            driver.SwitchTo().Window(originalWindowHandle);
            driver.FindElement(Locators.fill_verification_code).SendKeys(otp);
            js.ExecuteScript("window.scrollBy(0,100);");
            Thread.Sleep(100);
            driver.FindElement(Locators.submit).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.ElementExists(Locators.changemailpop_message));
            string expectedText = driver.FindElement(Locators.changemailpop_message).Text;
            Console.WriteLine("Expected text: " + expectedText);
            Assert.That(expectedText, Is.EqualTo("Email Successfully Reset"), "mail Successfully not Reset");
        }
        public string RetrieveOTP(string new_email, IJavaScriptExecutor js)
        {
            js.ExecuteScript("window.open('https://yopmail.com/en/');");
            string otp = "";

            foreach (string windowHandle in driver.WindowHandles)
            {
                // Switch to the new window
                if (windowHandle != driver.CurrentWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    driver.Manage().Window.Maximize();
                    otp = email_otpvarification(new_email);
                    Console.WriteLine("OTP received is: " + otp);
                    driver.Close();
                    break;
                }
            }
            return otp; 
        }        
        private string email_otpvarification(string new_email)
        {
            driver.Navigate().GoToUrl("https://yopmail.com/en/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//input[@id='login']")).SendKeys(new_email);
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//button[@onclick='{if(chkl())go()}']")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().Frame("ifmail");
            string otp = driver.FindElement(By.XPath("//tr/td[text()='Verification Code: ']/b")).Text;          
            return otp;
        }
    }     
}