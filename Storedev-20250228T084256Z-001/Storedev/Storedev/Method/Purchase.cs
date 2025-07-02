using Storedev.Xpath;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Storedev.Method
{
    public class Purchase
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;


        public Purchase(IWebDriver driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }

        public void SetEmail(string email)
        {
            string storedEmail = email;
            Console.WriteLine($"Email: {storedEmail}");
            driver.FindElement(Locators.EmailInput).Clear();
            driver.FindElement(Locators.EmailInput).SendKeys(email);
            Thread.Sleep(4000);
            driver.FindElement(Locators.ConfirmEmailInput).Clear();
            driver.FindElement(Locators.ConfirmEmailInput).SendKeys(email);
        }

        public void SetFirstName(string firstName)
        {
            driver.FindElement(Locators.FirstNameInput).Clear();
            driver.FindElement(Locators.FirstNameInput).SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            driver.FindElement(Locators.LastNameInput).Clear();
            driver.FindElement(Locators.LastNameInput).SendKeys(lastName);
            js.ExecuteScript("window.scrollBy(0, 300);");
        }

        public void SetPassword(string password)
        {
            driver.FindElement(Locators.PasswordInput).Clear();
            driver.FindElement(Locators.PasswordInput).SendKeys(password);
            driver.FindElement(Locators.ConfirmPasswordInput).Clear();
            driver.FindElement(Locators.ConfirmPasswordInput).SendKeys(password);
            Thread.Sleep(500);
        }

        public void AgreeToTerms()
        {
            driver.FindElement(Locators.TermsCheckbox).Click();
            Thread.Sleep(500);
        }

        public void SubmitForm()
        {
            driver.FindElement(Locators.submitt_button).Click();
            Thread.Sleep(10000);
            js.ExecuteScript("window.scrollBy(0, -200);");
        }

        public void pwdInput(string password)
        {
            driver.FindElement(Locators.PasswordInput).SendKeys(password);
            js.ExecuteScript("window.scrollBy(0, document.body.scrollHeight);");
            Thread.Sleep(500);
        }

        public void again_submit()
        {
            driver.FindElement(Locators.submitt_button_1).Click();
            Thread.Sleep(15000);
        }

        public void fill_email(string email)
        {
            driver.FindElement(Locators.EmailInput).SendKeys(email);
        }

        public void fill_pwd(string password)
        {
            driver.FindElement(Locators.PasswordInput).SendKeys(password);
        }

        public void submit()
        {
            driver.FindElement(Locators.submitt_button_1).Click();
            js.ExecuteScript("window.scrollBy(0, 450);");
        }


        public void addincart()
        {
            driver.FindElement(Locators.Addtocart).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void clickcart()
        {
            driver.FindElement(Locators.click_oncart).Click();
            Thread.Sleep(9000);
            js.ExecuteScript("window.scrollBy(0, 400);");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }
        public void membership()
        {
            driver.FindElement(Locators.membership).Click();
            Thread.Sleep(9000);
        }
        public void checkout()
        {
            driver.FindElement(Locators.checkout).Click();
        }
        public void fill_fname(string fname)
        {
            driver.FindElement(Locators.fill_fname).SendKeys(fname);
        }
        public void fill_lname(string lname)
        {
            driver.FindElement(Locators.fill_lname).SendKeys(lname);
        }
        public void fill_staddress(string address)
        {
            driver.FindElement(Locators.Street_address).SendKeys(address);
            js.ExecuteScript("window.scrollBy(0, 400);");
            Thread.Sleep(500);
        }
        public void fill_city(string city)
        {
            driver.FindElement(Locators.city).SendKeys(city);
            Thread.Sleep(1500);
        }
        public void fill_state(string state)
        {
            IWebElement dropdown = driver.FindElement(Locators.state);
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText(state);
            Thread.Sleep(1000);
        }
        public void fill_zip(string code)
        {
            driver.FindElement(Locators.Zip_code).SendKeys(code);
            Thread.Sleep(500);
        }
        public void phoneNumber(string phone)
        {

            driver.FindElement(Locators.phone_no).SendKeys(phone);
            js.ExecuteScript("window.scrollBy(0, 600);");
            Thread.Sleep(100);
        }
        public void button()
        {
            driver.FindElement(Locators.payment_submitt_button).Click();
            Thread.Sleep(5000);
        }
        public void user_org_address_button()
        {
            driver.FindElement(Locators.org_address_button).Click();
            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0, 450);");
            Thread.Sleep(2000);
        }
        public void Cardnumber(long cardnumber)
        {
            string cardNumberString = cardnumber.ToString(); // Convert integer to string
            driver.FindElement(Locators.fill_cardno).SendKeys(cardNumberString);
            Thread.Sleep(1000);
        }
        public void Expiration_Date(string date)
        {
            driver.FindElement(Locators.fll_card_exp_date).SendKeys(date);
            Thread.Sleep(1000);
        }
        public void CVV_Code(string code)
        {
            driver.FindElement(Locators.fill_cvv).SendKeys(code);
            Thread.Sleep(1000);
        }
        public void review_order()
        {
            driver.FindElement(Locators.clck_submit_paymentbutton).Click();
            Thread.Sleep(1000);
        }
       
       
    }
}
            
        
       

    

       
           


        
    
