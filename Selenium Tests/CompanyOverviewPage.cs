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
        public static string URL = "http://localhost:8080/general/companyOverview.html";
        public By firstCompany = By.Id("1");

        public CompanyOverviewPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public CompanyDetailPage ClickFirstCompany()
        {
            Thread.Sleep(500);
            driver.FindElement(firstCompany).Click();
            return new CompanyDetailPage(driver);
        }
    }
}
