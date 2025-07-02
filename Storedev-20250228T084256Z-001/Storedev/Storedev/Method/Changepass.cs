using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Storedev.Xpath;
using System.Threading;

namespace Storedev.Method
{
    public class Changepass : BasePage
    {
        public Changepass(IWebDriver driver) : base(driver)
        {

        }
        public void Changepassword()
        {
            driver.FindElement(Locators.click_on_changepass).Click();
            Thread.Sleep(2000);
        }
        public void old_pass(string password)
        {
            string Password = password;
            Console.WriteLine($"oldpassword is: {Password}");
            driver.FindElement(Locators.fill_old_pass).SendKeys(password);
        }
        public void pass(string new_password)
        {
            string Password = new_password;
            Console.WriteLine($"newpassword is: {Password}");
            driver.FindElement(Locators.fill_pass).SendKeys(new_password);
        }

        public void cnf_pass(string new_password, IJavaScriptExecutor js)
        {
            driver.FindElement(Locators.fill_cnfpass).SendKeys(new_password);
            js.ExecuteScript("window.scrollBy(0, 150);");
            Thread.Sleep(500);
        }

        public void submitt()
        {
            driver.FindElement(Locators.submit).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.ElementExists(Locators.changepassword_popupmessage));
            string expectedText = driver.FindElement(Locators.changepassword_popupmessage).Text;
            Console.WriteLine("Expected text: " + expectedText);
            Assert.That(expectedText, Is.EqualTo("Password Successfully Reset"), "password Successfully not Reset");
        }
    }
}
