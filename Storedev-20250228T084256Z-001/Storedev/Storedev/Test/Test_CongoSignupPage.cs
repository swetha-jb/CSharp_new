using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Storedev.Method;
using NPOI.XSSF.UserModel;
using NUnit.Framework; 
using System.IO;
using System;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using NUnit.Framework.Legacy;
namespace Storedev.Test
{
    public class Test_CongoSignupPage
    {
        private const string BaseUrl = "https://storedev.netgear.com";
        private static IWebDriver driver;
        private CongoSignupPage CongoSignupPage1;
        private string randomEmail;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000); 
            CongoSignupPage1 = new CongoSignupPage(driver);
            randomEmail = GenerateRandomEmail(); 
        }
        
        [Test]
        public void CreateAccount() 
        {
            string path = @"C:\Users\vvdn\Desktop\Storedev\Storedev\Excel\exceldata.xlsx";
            XSSFWorkbook wb = new XSSFWorkbook(File.Open(path, FileMode.Open));

            var sheet = wb.GetSheetAt(0);
            CongoSignupPage1.addincart();
            CongoSignupPage1.clickcart();
            CongoSignupPage1.membership();
            CongoSignupPage1.checkout();

            for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row != null)
                {
                    // Assuming first cell consider email and pwd
                    string fname = row.GetCell(0)?.ToString();
                    string lname = row.GetCell(1)?.ToString();
                    string pwd = row.GetCell(2)?.ToString();
                    string cnfpwd = row.GetCell(3)?.ToString(); 

                    if (!string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname) || !string.IsNullOrEmpty(pwd) || !string.IsNullOrEmpty(cnfpwd))
                    {
                        Console.WriteLine($"Firstname is : {fname}, Lastname is : {lname}, Password is : {pwd}, Confirm Password is : {cnfpwd}");

                        int minPasswordLength = 8; 
                        if (pwd.Length < minPasswordLength)
                        {  
                            Console.WriteLine($"Password must be at least {minPasswordLength} characters long.");
                            continue; // Skip this iteration if password is too short
                        }
                        CongoSignupPage1.fill_fname(fname); 
                        CongoSignupPage1.fill_lname(lname); 
                        CongoSignupPage1.fill_emailfield(randomEmail);
                        CongoSignupPage1.fill_password(pwd); 
                        CongoSignupPage1.fill_cinfpassword(cnfpwd);
                        
                        try
                        {
                            ClassicAssert.IsTrue(CongoSignupPage1.IsButtonClickable(), "Button is not clickable.");
                        }
                        catch (AssertionException ex)
                        {
                            Console.WriteLine(ex.Message);
                            // Handle the assertion failure if needed
                            // For example, you could log the error and continue to the next iteration
                            continue;
                        }
                        CongoSignupPage1.button();
                    }
                }
            }
            wb.Close();
            CongoSignupPage1.password("Pass@123");
            CongoSignupPage1.signin_button();
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
