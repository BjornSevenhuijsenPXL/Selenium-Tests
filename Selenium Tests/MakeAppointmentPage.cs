using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class MakeAppointmentPage : ApplicationDetailPage
    {
        public static string ExpectedURL = "http://localhost:8080/MakeAppointment.html";
        private By sendInAppointmentButton = By.Id("sendInAppointmentButton");

        public MakeAppointmentPage(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitAppointment()
        {
            driver.FindElement(sendInAppointmentButton).Click();
        }
    }
}
