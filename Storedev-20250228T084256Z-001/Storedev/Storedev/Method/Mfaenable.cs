using OpenQA.Selenium;
using Storedev.Xpath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Method
{
    public class Mfaenable : BasePage
    {
        public Mfaenable(IWebDriver driver) : base(driver)
        {
        }
        public void two_step_verification()
        {
            driver.FindElement(Locators.click_on_two_step_verification).Click();
            Thread.Sleep(4000);
        }
        public void toggle_button(IJavaScriptExecutor js)
        {
            driver.FindElement(Locators.click_on_toggle_button).Click();
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0, 100);");
            Thread.Sleep(1000);
        }
        public void continue_button()
        {
            driver.FindElement(Locators.click_on_continue_button).Click();
        }
    }
}
