using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class HomepageTests
    {
        IWebDriver driver;
        Homepage homepage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            homepage = new Homepage(driver);
            homepage.Open();
        }

        [Test]
        public void LandingPageLoads()
        {
            Assert.True(driver.FindElement(By.TagName("Body")).Enabled);
        }

        [Test]
        public void LoginButtonOpensLoginPage()
        { 
            homepage.ClickLoginButton();

            Thread.Sleep(100);
            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [Test]
        public void LoginButtonContentContainsLogin()
        {
            StringAssert.Contains("Login", driver.FindElement(homepage.buttonLogin).Text);
        }

        [Test]
        public void HomepageTitleShouldBeHomepage()
        {
            Assert.AreEqual(Homepage.Title, driver.Title);
        }

        [Test]
        public void HomepageUrlShouldBeLocalhost8080()
        {
            Assert.AreEqual(Homepage.ExpectedURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC01")]
        public void URLShouldOpenHomepage()
        {
            driver.Url = "http://localhost:8080/";

            Assert.AreEqual(Homepage.Title, driver.Title);
        }

        [Test]
        [Description("State Transition TC02")]
        public void LoginButtonOnHomepageShouldOpenLoginPage()
        {
            homepage.ClickLoginButton();
            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
