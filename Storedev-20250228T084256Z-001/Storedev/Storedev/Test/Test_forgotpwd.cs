using OpenQA.Selenium;
using Storedev.Method;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;


namespace Storedev.Test
{
    public class TestForgotPwd
    {
        private const string BaseUrl = "https://accounts-qa.netgear.com/login?redirectUrl=https:%2F%2Fstoredev.netgear.com%2Fon%2Fdemandware.store%2FSites-netgear-us-Site%2Fen_US%2FSingleSignOn-Reentry";
        private IWebDriver driver;
        private Forgotpwd Forgotpwd1;
        private string randomEmail;

        [SetUp]
        public void Setup()
        {
            string geckoDriverPath = @"C:\Drivers";
            //var service = FirefoxDriverService.CreateDefaultService(geckoDriverPath);
            IWebDriver driver = new FirefoxDriver(geckoDriverPath);
            // IWebDriver driver = new EdgeDriver();
            //driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Forgotpwd1 = new Forgotpwd(driver);
            randomEmail = GenerateRandomEmail();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ChangePasswordTest()
        {
            Forgotpwd1.forgotpass();
            Forgotpwd1.email_fill("gautam780@yopmail.com");
            Forgotpwd1.clckbutton();
            Forgotpwd1.otp("gautam780@yopmail.com");
            Forgotpwd1.new_pass("Password@123");
            Forgotpwd1.cnf_pass("Password@123");
            Forgotpwd1.clckbutton1();
        }

        private string GenerateRandomEmail()
        {
            // Implement your random email generation logic here
            return "example@example.com"; // Placeholder example
        }
    }
}
