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
    internal class CompanyOverviewTests
    {
        IWebDriver driver;
        CompanyOverviewPage companyOverviewPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            companyOverviewPage = new CompanyOverviewPage(driver);
            companyOverviewPage.Open().ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton();
        }

        [Test]
        [Description("State Transition TC07")]
        public void ClickingACompanyShouldOpenCompanyDetailPage()
        {
            companyOverviewPage.ClickFirstCompany();

            Assert.AreEqual(CompanyDetailPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC17")]
        public void ClickingSignOutOnCompanyOverviewPageShouldRedirectToSignInPage()
        {
            companyOverviewPage.Logout();

            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("TC14")]
        public void ReturnButtonOnCompanyOverviewPageShouldOpenDashboard()
        {
            companyOverviewPage.ClickReturnButton();

            Assert.AreEqual(DashboardPageStudents.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
