using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Storedev.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storedev.Resources;

namespace Storedev.Test
{
    public class Test_Changepass
    {
        private static IWebDriver driver;
        private Changepass Changepass1;
        private Utility Utility1;
        private string randomEmail;


        [SetUp]
        public void Setup1()
        {
            Utility1 = new Utility();
            string browserType = Utility.ReadConfigValue("web.browser");
            Utility1.Driver_call(browserType);
            driver = Utility1.GetDriver();
            string baseUrl = Utility1.GetBaseUrl();
            driver.Navigate().GoToUrl(baseUrl);
            Changepass1 = new Changepass(driver);
            randomEmail = GenerateRandomEmail();
        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }

        [Test]
        public void changepassword()
        {
            Changepass1.click_on_the_iocn();
            Changepass1.click_on_the_account_create_button();
            Changepass1.SetEmail(randomEmail);
            Changepass1.SetFirstName("gautam");
            Changepass1.SetLastName("goswmai");
            Changepass1.SetPassword("Pass@123");
            Changepass1.AgreeToTerms();
            string actualResult = Changepass1.SubmitForm();
            string expectedResult = "Your account has been created. Please log in to continue";
            Changepass1.assertText(expectedResult, actualResult);
            Changepass1.pwdInput("Pass@123");
            Changepass1.again_submit();         
            Changepass1.icon();
            Changepass1.manage_profile();
            Changepass1.cancel_submit();
            Changepass1.login_setting();
            Changepass1.Changepassword();
            Changepass1.old_pass("Pass@123");
            Changepass1.pass("Password@123");
            Changepass1.cnf_pass("Password@123", (IJavaScriptExecutor)driver);
            Changepass1.submitt();
        }

        public static string GenerateRandomEmail()
        {
            string domain = "yopmail.com";
            string name = "storedev";
            string currentDate = DateTime.Now.ToString("ddMMyy");
            Random random = new Random();
            int randomNumber = random.Next(0, 999);
            string localPart = name + currentDate + randomNumber.ToString();
            string email = localPart + "@" + domain;
            return email;
        }
    }
}

