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
    public class Test_Congo_onetime_otp
    {
        private const string BaseUrl = "https://accounts-qa.netgear.com/signup/congo?redirectUrl=https:%2F%2Fstoredev.netgear.com%2Fon%2Fdemandware.store%2FSites-netgear-us-Site%2Fen_US%2FSingleSignOn-Reentry";
        private IWebDriver driver;
        private Congo_onetime_otp Congo_onetime_otp1;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Congo_onetime_otp1 = new Congo_onetime_otp(driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void onetime_otp()
        {
            Congo_onetime_otp1.click_on_onetimeotp();
            Congo_onetime_otp1.fill_one_time_email("storedev881@yopmail.com");
            Congo_onetime_otp1.click_on_one_timebutton();
            Congo_onetime_otp1.otp("storedev881@yopmail.com");
            Congo_onetime_otp1.click_on_ligin_button();
        }
    }
}
