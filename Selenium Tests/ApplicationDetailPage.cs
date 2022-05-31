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

        public ApplicationDetailPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
