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
    public class Test_mfaenable
    {
        private const string BaseUrl = "https://storedev.netgear.com";
        private static IWebDriver driver;
        private Mfaenable Mfaenable1;
        private string randomEmail;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Mfaenable1 = new Mfaenable(driver);
            randomEmail = GenerateRandomEmail();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
        [Test]
        public void MFAenable()
        {
            Mfaenable1.click_on_the_iocn();
            Mfaenable1.click_on_the_account_create_button();
            Mfaenable1.SetEmail(randomEmail);
            Mfaenable1.SetFirstName("gautam");
            Mfaenable1.SetLastName("goswmai");
            Mfaenable1.SetPassword("Pass@123");
            Mfaenable1.AgreeToTerms();
            Mfaenable1.SubmitForm();
            Mfaenable1.pwdInput("Pass@123");
            Mfaenable1.again_submit();
            
            Mfaenable1.icon();
            Mfaenable1.manage_profile();
            Mfaenable1.cancel_submit();
            Mfaenable1.login_setting();
            Mfaenable1.two_step_verification();
            Mfaenable1.toggle_button((IJavaScriptExecutor)driver);
            Mfaenable1.continue_button();
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
