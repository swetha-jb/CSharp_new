using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Storedev.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Resources
{
    public class Utility
    {
        protected IWebDriver driver;
        public void Driver_call(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                case "firefox":
                    string geckoDriverPath = @"C:\Drivers";
                    driver = new FirefoxDriver(geckoDriverPath);
                    break;
                case "edge":
                   // string edgeDriverPath = @"C:\Drivers";
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser: " + browserType);
            }
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }


        public IWebDriver GetDriver()
        {
            return driver;
        }
        public static string ReadConfigValue(string key)
        {
            string configFile = "config.properties";
            string value = "";
            try
            {
                using (StreamReader sr = new StreamReader(configFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith(key))
                        {
                            value = line.Substring(line.IndexOf('=') + 1).Trim();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading config file: " + ex.Message);
            }
            return value;
        }
        public string GetBaseUrl()
        {
            return ReadConfigValue("web.url");
        }
    }

    
}