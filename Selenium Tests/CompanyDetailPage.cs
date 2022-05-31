using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class CompanyDetailPage : CompanyOverviewPage
    {
        public static string CurrentURL = "http://localhost:8080/company/promotionPage.html";
        public static string ExpectedURL = "http://localhost:8080/PromotionPage.html";
        public By applyButton = By.Id("applyButton");

        public CompanyDetailPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public ApplicationPage ClickApplyButton()
        {
            driver.FindElement(applyButton).Click();
            return new ApplicationPage(driver);
        }
    }
}
