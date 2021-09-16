using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNunit
{
    [TestFixture]

    public class Tests: Hooks
    {
        [Test]
        [TestCaseSource(typeof(Hooks), "RunBrowser")]
        public void Test1(string browser)
        {
            Setup(browser);
            _driver.FindElement(By.XPath("//*[@id='identifierId']")).SendKeys("vnextautomation");
            _driver.FindElement(By.XPath("//*[@id='identifierNext']/div/button/span"));
        }
    }
}
