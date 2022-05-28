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

            Homepage landing = new Homepage(driver);
            landing.Open();
            
            SignInPage signInPage = landing.ClickLoginButton();
            dashboardPageStudents = signInPage.LoginStudentWithValidCredentials();
        }

        [Test]
        public void DashboardLoads()
        {
            Assert.True(driver.FindElement(By.TagName("Body")).Enabled);
        }

        [Test]
        public void DashboardTitleShouldBeDashboard()
        {
            Assert.True(driver.FindElement(By.TagName("Body")).Enabled);
        }

        [Test]
        public void StudentDashboardContainsLogoutButton()
        {
            Assert.True(driver.FindElement(By.Id("pxlLogo")).Enabled);
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
        public void BedrijvenButtonOpensCompanyOverviewPage()
        {
            dashboardPageStudents.ClickCompanyOverviewButton();
            Assert.AreEqual("http://localhost:8080/general/companyOverview.html", driver.Url);
        }

        [Test]
        public void SollicitatiesButtonOpensApplicationsPage()
        {
            dashboardPageStudents.ClickApplicationsButton();
            Assert.AreEqual("http://localhost:8080/student/studentApplicationOverview.html", driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
