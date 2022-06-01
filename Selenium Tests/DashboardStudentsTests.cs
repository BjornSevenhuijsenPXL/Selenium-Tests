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
    class DashboardStudentsTests
    {
        IWebDriver driver;
        DashboardPageStudents dashboardPageStudents;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");
            
            dashboardPageStudents = new DashboardPageStudents(driver);
            dashboardPageStudents.Open().ClickLoginButton().LoginStudentWithValidCredentials();
        }

        [Test]
        public void DashboardLoads()
        {
            Assert.True(driver.FindElement(By.TagName("Body")).Enabled);
        }

        [Test]
        public void DashboardTitleShouldBeDashboard()
        {
            Assert.AreEqual(DashboardPageStudents.Title, driver.Title);
        }

        [Test]
        public void StudentDashboardContainsLogoutButton()
        {
            Assert.True(driver.FindElement(By.Id("logoutIcon")).Enabled);
        }

        [Test]
        public void StudentDashboardContainsSettingsButton()
        {
            Assert.True(driver.FindElement(By.Id("settingIcon")).Enabled);
        }

        [Test]
        public void StudentDashboardContainsAHomeButton()
        {
            Assert.True(driver.FindElement(By.Id("pxlLogo")).Enabled);
        }

        [Test]
        [Description("State Transition TC05")]
        public void CompanyButtonShouldOpenCompanyOverviewPage()
        {
            dashboardPageStudents.ClickCompanyOverviewButton();

            Assert.AreEqual(CompanyOverviewPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC06")]
        public void InternshipApplicationsButtonShouldOpenApplicationsOverview()
        {
            dashboardPageStudents.ClickApplicationsOverviewButton();

            Assert.AreEqual(ApplicationsOverviewPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC016")]
        public void ClickingSignOutOnDashbpardShouldRedirectUserToSignInPage()
        {
            dashboardPageStudents.Logout();

            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
