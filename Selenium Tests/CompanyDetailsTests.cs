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
    internal class CompanyDetailsTests
    {
        IWebDriver driver;
        CompanyDetailPage companyDetailPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            companyDetailPage = new CompanyDetailPage(driver);
            companyDetailPage.Open().ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany();
        }

        [Test]
        [Description("State Transition TC08")]
        public void StudentShouldBeAbleToOpenTheApplicationForumOnTheCompanyDetailPage()
        {
            companyDetailPage.ClickApplyButton();

            Assert.AreEqual(ApplicationPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC09")]
        public void ReturnButtonOnCompanyDetailPageShouldOpenCompanyOverviewPage()
        {
            companyDetailPage.ClickReturnButton();

            Assert.AreEqual(CompanyOverviewPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC18")]
        public void ClickingSignOutOnCompanyDetailPageShouldRedirectToSignInPage()
        {
            companyDetailPage.Logout();

            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
