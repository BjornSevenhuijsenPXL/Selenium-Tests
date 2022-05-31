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
        [Description("State Transition TC03")]
        public void StudentCanLoginWithValidCredentials()
        {
            signInPage.LoginStudentWithValidCredentials();
            Thread.Sleep(100);
            Assert.AreEqual(DashboardPageStudents.CurrentURL, driver.Url);
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
        //Yep
        [Test]
        public void InvalidEmailShowsError()
        {
            signInPage.Login("q@q.q", "temp");

            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.Id("ErrorBox")).Enabled);
        }
        //yep
        [Test]
        public void InvalidEmailErrorShouldIncludeEmailOrPasswordIsInvalid()
        {
            signInPage.Login("q@q.q", "temp");

            Thread.Sleep(100);
            StringAssert.Contains("email or password is invalid", driver.FindElement(By.Id("ErrorBox")).Text.ToLower());
        }
        //Yep
        [Test]
        public void InvalidPasswordShowsError()
        {
            signInPage.Login("stefaan@email.be", "q");

            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.Id("ErrorBox")).Enabled);
        }
        //yep
        [Test]
        public void InvalidPasswordErrorShouldIncludeEmailOrPasswordIsInvalid()
        {
            signInPage.Login("stefaan@email.be", "q");

            Thread.Sleep(100);
            StringAssert.Contains("email or password is invalid", driver.FindElement(By.Id("ErrorBox")).Text.ToLower());
        }
        //yep
        [Test]
        public void EmptyCredentialsShowsError()
        {
            signInPage.Login("", "");

            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.Id("ErrorBox")).Enabled);
        }
        //YEP
        [Test]
        public void CanNotLoginAfter3InlavidLoginAttempts()
        {
            for (int i = 0; i < 3; i++)
            {
                signInPage.Login("Q", "Q");
                Thread.Sleep(100);
            }
            signInPage.LoginStudentWithValidCredentials();
            Thread.Sleep(100);
            Assert.AreNotEqual(DashboardPageStudents.CurrentURL, driver.Url);
        }
        //YEP
        [Test]
        public void ErrorBoxShouldShowThatAccountIsLockedAfter3InvalidLoginAttempts()
        {
            for (int i = 0; i < 3; i++)
            {
                signInPage.Login("Q", "Q");
                Thread.Sleep(100);
            }
            StringAssert.Contains("3 invalid attempts",driver.FindElement(By.Id("ErrorBox")).Text.ToLower());
        }

        [Test]
        public void LoginPageTitleShouldBeLogin()
        {
            Assert.AreEqual(SignInPage.Title, driver.Title);
        }

        [Test]
        public void LoginPageUrlShouldBeLocalhost8080Login()
        {
            Assert.AreEqual(SignInPage.ExpectedURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC04")]
        public void ReturnButtonOnLoginPageShouldOpenHomepage()
        {
            signInPage.ClickReturnButton();
            Thread.Sleep(100);
            Assert.AreEqual(Homepage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
