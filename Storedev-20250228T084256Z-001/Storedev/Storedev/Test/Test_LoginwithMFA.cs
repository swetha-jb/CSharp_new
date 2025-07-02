using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Storedev.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Test
{
    public class Test_LoginwithMFA    
    {
        private const string BaseUrl = "https://accounts-qa.netgear.com/login?redirectUrl=https:%2F%2Fstoredev.netgear.com%2Fon%2Fdemandware.store%2FSites-netgear-us-Site%2Fen_US%2FSingleSignOn-Reentry";
        private static IWebDriver driver;
        private Login_withMFA Login_withMFA1;
        private string randomEmail;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Login_withMFA1 = new Login_withMFA(driver);
            randomEmail = GenerateRandomEmail();
        }
        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
        [Test]
        public void LoginWithMFA()
        {
            Login_withMFA1.SetEmail("store126@yopmail.com");
            Login_withMFA1.SetPassword("Pass@123");
            Login_withMFA1.submit();
            Login_withMFA1.otp("store126@yopmail.com");
            Login_withMFA1.continue_button();
            Login_withMFA1.do_nottrust();
        }
        public static string GenerateRandomEmail()
        {
            string domain = "yopmail.com";
            Random random = new Random();
            int randomNumber = random.Next(0, 999);
            string localPart = "storedev" + randomNumber.ToString();
            string email = localPart + "@" + domain;
            return email;
        }
    }
}




