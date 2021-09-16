using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace SeleniumNunit
{
    public class Hooks 
    {
        public IWebDriver _driver;
        
        public void Setup(string browser)
        {
            if (browser.ToLower().Equals("chrome"))
            {
                _driver = new ChromeDriver();
            }

            else if (browser.ToLower().Equals("firefox"))
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AcceptInsecureCertificates = true;
                _driver = new FirefoxDriver(options);
            }

            else if (browser.ToLower().Equals("edge"))
            {
                _driver = new EdgeDriver();
            }

            _driver.Navigate().GoToUrl("https://www.gmail.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }


        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }


        public static IEnumerable<string> RunBrowser()
        {
            string[] browsers = { "chrome","firefox"};

            foreach (string b in browsers)
            {
                yield return b;
            }
        }
    }
}