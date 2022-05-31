using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class ApplicationDetailPage : ApplicationsOverviewPage
    {
        public static string CurrentURL = "http://localhost:8080/student/studentApplicationDetails.html";
        public static string ExpectedURL = "http://localhost:8080/ApplicationDetails.html";
        private By makeAppointmentButton = By.Id("makeAppointmentButton");

        public ApplicationDetailPage(IWebDriver driver) : base(driver)
        {
        }

        public MakeAppointmentPage ClickMakeAppointment()
        {
            driver.FindElement(makeAppointmentButton).Click();
            return new MakeAppointmentPage(driver);
        }
    }
}
