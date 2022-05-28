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
        Homepage landingPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            landingPage = new Homepage(driver);
            landingPage.Open();
        }

        [Test]
        public void LandingPageLoads()
        {
            Assert.True(driver.FindElement(By.TagName("Body")).Enabled);
        }

        [Test]
        public void LoginButtonOpensLoginPage()
        { 
            landingPage.ClickLoginButton();

            Thread.Sleep(100);
            Assert.AreEqual("http://localhost:8080/login/login.html", driver.Url);
        }

        [Test]
        public void LoginButtonContentIsLogin()
        {            
            Assert.AreEqual("Login", driver.FindElement(landingPage.buttonLogin).Text);
        }

        [Test]
        public void CompanyRegisterButtonContentIsRegisterCompany()
        {
            Assert.AreEqual("Registreer (bedrijf)", driver.FindElement(landingPage.buttonRegisterAsCompany).Text);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
