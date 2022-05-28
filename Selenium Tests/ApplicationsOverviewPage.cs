using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class ApplicationsOverviewPage : DashboardPageStudents
    {
        public static string URL = "http://localhost:8080/student/studentApplicationOverview.html";
        public By detailButton = By.XPath("/html/body/main/div[2]/button");


        public ApplicationsOverviewPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public ApplicationDetailPage ClickDetailsOnApplication()
        {
            Thread.Sleep(500);
            driver.FindElement(detailButton).Click();
            return new ApplicationDetailPage(driver);
        }
    }
}
