using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Storedev.Method;
using Storedev.Xpath;
using NUnit.Framework;

namespace Storedev.Test
{
    public class Purchase_test
    {
        private const string BaseUrl = "https://storedev.netgear.com/";
        private static IWebDriver driver;
        private Purchase Purchase1;
        private string randomEmail;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Purchase1 = new Purchase(driver);
            randomEmail = GenerateRandomEmail();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
           // driver.Quit();
        }

       

        [Test]
        [Category("CreateAc")]
        public void createAccount_with_validcred()
        {
            Purchase1.SetEmail(randomEmail);
            Purchase1.SetFirstName("gautam");
            Purchase1.SetLastName("goswami");
            Purchase1.SetPassword("Pass@123");
            Purchase1.AgreeToTerms();
            Purchase1.SubmitForm();
            Purchase1.pwdInput("Pass@123");
            Purchase1.again_submit();
            Purchase1.fill_email(randomEmail);
            Purchase1.fill_pwd("Pass@123");
            Purchase1.submit();
            Purchase1.addincart();
            Purchase1.clickcart();
            Purchase1.membership();
            Purchase1.checkout();
            Purchase1.fill_fname("gautam");
            Purchase1.fill_lname("goswami");
            Purchase1.fill_staddress("newyork");
            Purchase1.fill_city("newyork");
            Purchase1.fill_state("New York");
            Purchase1.fill_zip("10001");
            Purchase1.phoneNumber("0987654321");
            Purchase1.button();
            Purchase1.user_org_address_button();
            Purchase1.Cardnumber(4242424242424242);
            Purchase1.Expiration_Date("726");
            Purchase1.CVV_Code("123");
            Purchase1.review_order();
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
