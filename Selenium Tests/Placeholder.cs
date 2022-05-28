using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class Placeholder
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");
        }

        [Test]
        public void Test()
        {
            driver.Url = "http://www.google.co.in";
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
