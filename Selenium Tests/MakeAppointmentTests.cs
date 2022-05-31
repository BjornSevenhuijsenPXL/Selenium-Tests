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
    internal class MakeAppointmentTests
    {
        IWebDriver driver;
        MakeAppointmentPage makeAppointmentPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");

            makeAppointmentPage = new MakeAppointmentPage(driver);
            makeAppointmentPage.Open().ClickLoginButton().LoginStudentWithValidCredentials().ClickApplicationsOverviewButton().ClickDetailsOnApplication().ClickMakeAppointment();
        }

        [Test]
        [Description("State Transition TC23")]
        public void SuccesfullySubmittingAppointmentShouldRedirectToDetailPage()
        {
            makeAppointmentPage.SubmitAppointment();

            Assert.AreEqual(ApplicationDetailPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC24")]
        public void StudentShouldBeAbleToReturnToApplicationDetailPage()
        {
            makeAppointmentPage.ClickReturnButton();

            Assert.AreEqual(ApplicationDetailPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC25")]
        public void ClickingSignOutOnTheMakeAppointmentPageShouldRedirectToLoginPage()
        {
            makeAppointmentPage.Logout();

            Assert.AreEqual(SignInPage.CurrentURL, driver.Url);
        }

        [Test]
        [Description("State Transition TC29")]
        public void ClickingHomeButtonOpensTheDashboard()
        {
            makeAppointmentPage.ClickHomeButton();

            Assert.AreEqual(DashboardPageStudents.CurrentURL, driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
