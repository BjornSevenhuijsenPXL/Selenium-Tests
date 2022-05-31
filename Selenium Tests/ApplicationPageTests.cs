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
    internal class ApplicationPageTests
    {
        IWebDriver driver;
        ApplicationPage applicationPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            applicationPage = new ApplicationPage(driver);
            applicationPage.Open().ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().ClickApplyButton();
        }

        //database moet leeg gemaakt worden als er geen tijdsloten over zijn
        [Test]
        [Description("State Transition TC10")]
        public void AValidInternshipApplicationShouldRedirectUserToCompanyDetailPage()
        {
            applicationPage.FillInApplicationWithValidData();
            Thread.Sleep(200);
            Assert.AreEqual(CompanyDetailPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC11")]
        public void ReturnButtonOnApplicationPageShouldOpenCompanyDetailPage()
        {
            applicationPage.ClickReturnButton();

            Assert.AreEqual(CompanyDetailPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC19")]
        public void ClickingSignOutOnApplicationPageShouldRedirectToSignInPage()
        {
            applicationPage.Logout();
            Thread.Sleep(100);
            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
