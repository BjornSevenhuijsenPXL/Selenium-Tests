using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class CompanyOverviewPage : DashboardPageStudents
    {
        public static string CurrentURL = "http://localhost:8080/general/companyOverview.html";
        public static string ExpectedURL = "http://localhost:8080/CompanyOverview.html";
        public By firstCompany = By.Id("1");

        public CompanyOverviewPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public CompanyDetailPage ClickFirstCompany()
        {
            Thread.Sleep(1000);
            driver.FindElement(firstCompany).Click();
            return new CompanyDetailPage(driver);
        }
    }
}
