using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class DashboardPageStudents : DashboardPage
    {
        public static string URL = "http://localhost:8080/student/studentDashboard.html";
        private By bedrijvenButton = By.XPath("/html/body/div/div/a[1]/button");
        private By sollicitatiesButton = By.XPath("/html/body/div/div/a[2]/button");
        
        public DashboardPageStudents(IWebDriver driver) : base(driver) 
        {
        }

        public CompanyOverviewPage ClickCompanyOverviewButton()
        {
            driver.FindElement(bedrijvenButton).Click();
            return new CompanyOverviewPage(driver);
        }

        public ApplicationsOverviewPage ClickApplicationsButton()
        {
            driver.FindElement(sollicitatiesButton).Click();
            return new ApplicationsOverviewPage(driver);
        }
    }
}
