using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Storedev.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Storedev.Test
{
    public class Test_Changemail
    {
        private const string BaseUrl_CreateAcc = "https://storedev.netgear.com";
        private static IWebDriver driver;
        private Changemail Changemail1; 
        private string randomEmail, randomEmail1;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl_CreateAcc);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Changemail1 = new Changemail(driver);
            randomEmail = GenerateRandomEmail(true);
            randomEmail1 = GenerateRandomEmail(false);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void CreateAccount()
        {
            Changemail1.click_on_the_iocn();
            Changemail1.click_on_the_account_create_button();
            Changemail1.SetEmail(randomEmail);
            Changemail1.SetFirstName("gautam");
            Changemail1.SetLastName("goswmai");
            Changemail1.SetPassword("Pass@123");
            Changemail1.AgreeToTerms();
            Changemail1.SubmitForm();
            Changemail1.pwdInput("Pass@123");
            Changemail1.again_submit();
            Changemail1.icon();
            Changemail1.manage_profile();
            Changemail1.cancel_submit();
            Changemail1.login_setting();
            Changemail1.click_on_changeemail();
            Changemail1.new_email(randomEmail1);
            Changemail1.cnf_new_email(randomEmail1);
            Changemail1.current_pass("Pass@123",(IJavaScriptExecutor)driver);
            Changemail1.submitt();
            Changemail1.EnterOTP(randomEmail1,(IJavaScriptExecutor)driver);
        }
        public static string GenerateRandomEmail(bool isNetgear)
        {
            string domain = "yopmail.com";
            Random random = new Random();
            int randomNumber = random.Next(0, 999);
            string localPart = isNetgear ? "Netgear_" : "store_dev";
            string email = localPart + randomNumber.ToString() + "@" + domain;
            return email;
        }
    }
}
