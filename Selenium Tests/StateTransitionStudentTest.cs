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
    internal class StateTransitionStudentTest
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
        [Description("TC01")]
        public void URLShouldOpenHomepage()
        {
            driver.Url = "http://localhost:8080/";
            Assert.AreEqual(Homepage.URL, driver.Title);
        }

        [Test]
        [Description("TC02")]
        public void LoginButtonOnHomepageShouldOpenLoginPage()
        {
            landingPage.ClickLoginButton();
            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [Test]
        [Description("TC03")]
        public void LoginWithValidCredentialsShouldOpenDashboard()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials();

            Assert.AreEqual(DashboardPageStudents.URL, driver.Url);
        }

        [Test]
        [Description("TC04")]
        public void ReturnButtonOnLoginPageShouldOpenHomepage()
        {
            landingPage.ClickLoginButton().ClickReturnButton();

            Assert.AreEqual(Homepage.URL, driver.Url);
        }

        [Test]
        [Description("TC05")]
        public void CompanyButtonShouldOpenCompanyOverview()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton();

            Assert.AreEqual(CompanyOverviewPage.URL, driver.Url);
        }

        [Test]
        [Description("TC06")]
        public void InternshipApplicationsButtonShouldOpenApplicationsOverview()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsButton();

            Assert.AreEqual("http://localhost:8080/student/studentApplicationOverview.html", driver.Url);
        }

        [Test]
        [Description("TC07")]
        public void ClickingACompanyShouldOpenCompanyDetailPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany();

            Assert.AreEqual(CompanyDetailPage.URL, driver.Url);
        }

        [Test]
        [Description("TC08")]
        public void StudentShouldBeAbleToOpenTheApplicationPageOnTheCompanyDetailPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().ClickApplyButton();

            Assert.AreEqual(ApplicationPage.URL, driver.Url);
        }

        [Test]
        [Description("TC09")]
        public void ReturnButtonOnCompanyDetailPageShouldOpenCompanyOverviewPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().ClickReturnButton();

            Assert.AreEqual(CompanyOverviewPage.URL, driver.Url);
        }

        //database moet leeg gemaakt worden als er geen tijdsloten over zijn
        [Test]
        [Description("TC10")]
        public void AValidInternshipApplicationShouldRedirectUserToCompanyDetailPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().ClickApplyButton().FillInApplicationWithValidData();
            Thread.Sleep(100);
            Assert.AreEqual(CompanyDetailPage.URL, driver.Url);
        }

        [Test]
        [Description("TC11")]
        public void ReturnButtonOnApplicationPageShouldOpenCompanyDetailPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().ClickApplyButton().ClickReturnButton();

            Assert.AreEqual(CompanyDetailPage.URL, driver.Url);
        }

        [Test]
        [Description("TC12")]
        public void StudentShouldBeAbleToOpenInternshipApplicationDetailsPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsButton().ClickDetailsOnApplication();

            Assert.AreEqual(ApplicationDetailPage.URL, driver.Url);
        }

        [Test]
        [Description("TC13")]
        public void ReturnButtonOnApplicationDetailsPageShouldOpenApplicationsOverviewPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsButton().ClickDetailsOnApplication().ClickReturnButton();

            Assert.AreEqual(ApplicationsOverviewPage.URL, driver.Url);
        }

        [Test]
        [Description("TC14")]
        public void CompanyOverviewReturnButtonShouldOpenDashboard()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickReturnButton();

            Assert.AreEqual(DashboardPageStudents.URL, driver.Url);
        }

        [Test]
        [Description("TC15")]
        public void ApplicationsOverviewReturnButtonShouldOpenDashboard()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsButton().ClickReturnButton();

            Assert.AreEqual(DashboardPageStudents.URL, driver.Url);
        }

        [Test]
        [Description("TC016")]
        public void LogoutButtonShouldReturnUserToSignInPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().Logout();

            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [Test]
        [Description("TC17")]
        public void ClickingSignOutOnCompanyOverviewPageShouldRedirectToSignInPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().Logout();

            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [Test]
        [Description("TC18")]
        public void ClickingSignOutOnCompanyDetailPageShouldRedirectToSignInPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().Logout();

            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [Test]
        [Description("TC19")]
        public void ClickingSignOutOnApplicationPageShouldRedirectToSignInPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickCompanyOverviewButton().ClickFirstCompany().ClickApplyButton().Logout();
            Thread.Sleep(100);
            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [Test]
        [Description("TC20")]
        public void ClickingSignOutOnApplicationsOverviewPageShouldRedirectToSignInPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsButton().Logout();

            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [Test]
        [Description("TC21")]
        public void ClickingSignOutOnApplicationDetailPageShouldRedirectToSignInPage()
        {
            landingPage.ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsButton().ClickDetailsOnApplication().Logout();

            Assert.AreEqual(SignInPage.URL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
