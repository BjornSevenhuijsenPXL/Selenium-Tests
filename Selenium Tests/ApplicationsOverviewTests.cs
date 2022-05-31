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
    internal class ApplicationsOverviewTests
    {
        IWebDriver driver;
        ApplicationsOverviewPage applicationsOverviewPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            applicationsOverviewPage = new ApplicationsOverviewPage(driver);
            applicationsOverviewPage.Open().ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsOverviewButton();
        }

        [Test]
        [Description("State Transition TC12")]
        public void StudentShouldBeAbleToOpenApplicationDetailsPage()
        {
            applicationsOverviewPage.ClickDetailsOnApplication();

            Assert.AreEqual(ApplicationDetailPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC15")]
        public void ReturnButtonOnApplicationsOverviewPageShouldOpenDashboard()
        {
            applicationsOverviewPage.ClickReturnButton();

            Assert.AreEqual(DashboardPageStudents.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC20")]
        public void ClickingSignOutOnApplicationsOverviewPageShouldRedirectToSignInPage()
        {
            applicationsOverviewPage.Logout();

            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
