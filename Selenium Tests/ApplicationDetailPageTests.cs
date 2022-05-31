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
    internal class ApplicationDetailPageTests
    {
        IWebDriver driver;
        ApplicationDetailPage applicationDetailPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            applicationDetailPage = new ApplicationDetailPage(driver);
            applicationDetailPage.Open().ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsOverviewButton().ClickDetailsOnApplication();
        }

        [Test]
        [Description("State Transition TC13")]
        public void ReturnButtonOnApplicationDetailsPageShouldOpenApplicationsOverviewPage()
        {
            applicationDetailPage.ClickReturnButton();

            Assert.AreEqual(ApplicationsOverviewPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC21")]
        public void ClickingSignOutOnApplicationDetailPageShouldRedirectToSignInPage()
        {
            applicationDetailPage.Logout();

            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
