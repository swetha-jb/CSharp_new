using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Threading;
using Storedev.Method;

namespace Storedev.Test
{
    public class Test_Congo_Forgotpwd
    {
        private const string BaseUrl = "https://accounts-qa.netgear.com/signup/congo?redirectUrl=https:%2F%2Fstoredev.netgear.com%2Fon%2Fdemandware.store%2FSites-netgear-us-Site%2Fen_US%2FSingleSignOn-Reentry";
        private IWebDriver driver;
        private Congo_Forgotpwd Congo_Forgotpwd1;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Congo_Forgotpwd1 = new Congo_Forgotpwd(driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_clickon_forgotpwd()
        {
            Congo_Forgotpwd1.forgotpass();
            Congo_Forgotpwd1.email_fill("storedev881@yopmail.com");
            Congo_Forgotpwd1.clckbutton();
            Congo_Forgotpwd1.otp("storedev881@yopmail.com");
            Congo_Forgotpwd1.new_pass("Password@123");
            Congo_Forgotpwd1.cnf_pass("Password@123");
            Congo_Forgotpwd1.clckbutton1();
        }
    }
}






        


    




