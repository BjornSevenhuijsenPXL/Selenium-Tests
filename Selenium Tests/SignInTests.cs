using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class SignInTests
    {
        
        IWebDriver driver;
        SignInPage signInPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            signInPage = new SignInPage(driver);
            signInPage.Open();
            signInPage.ClickLoginButton();
        }

        [Test]
        public void SignInPageLoads()
        {
            Assert.True(driver.FindElement(By.TagName("Body")).Enabled);
        }

        [Test]
        public void StudentCanLoginWithValidCredentials()
        {
            signInPage.Login("stefaan@email.be", "temp");

            Thread.Sleep(100);
            Assert.AreEqual("http://localhost:8080/student/studentDashboard.html", driver.Url);
        }

        [Test]
        public void CoördinatorCanLoginWithValidCredentials()
        {
            signInPage.Login("admin@admin.com", "pxl");

            Thread.Sleep(100);
            Assert.AreEqual("http://localhost:8080/coordinator/coordinatorDashboard.html", driver.Url);
        }

        [Test]
        public void CompanyCanLoginWithValidCredentials()
        {
            signInPage.Login("cegeka@gmail.com", "pxl");

            Thread.Sleep(100);
            Assert.AreEqual("http://localhost:8080/company/companyDashboard.html", driver.Url);
        }

        [Test]
        public void InvalidEmailThrowsError()
        {
            signInPage.Login("q@q.q", "temp");

            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.Id("ErrorBox")).Enabled);
        }

        [Test]
        public void InvalidPasswordThrowsError()
        {
            signInPage.Login("stefaan@email.be", "q");

            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.Id("ErrorBox")).Enabled);
        }

        [Test]
        public void EmptyCredentialsThrowsError()
        {
            signInPage.Login("", "");

            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.Id("ErrorBox")).Enabled);
        }

        [Test]
        public void CanNotImmediatlyLoginAfter3Attempts()
        {
            for (int i = 0; i < 3; i++)
            {
                signInPage.Login("Q", "Q");
                Thread.Sleep(100);
            }
            signInPage.LoginStudentWithValidCredentials();
            Thread.Sleep(100);
            Assert.AreNotEqual("http://localhost:8080/student/studentDashboard.html", driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
