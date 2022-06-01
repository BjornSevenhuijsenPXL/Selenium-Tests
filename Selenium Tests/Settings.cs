using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class Settings : DashboardPage
    {
        private By changePasswordButton = By.Id("changePasswordButton");
        
        public Settings(IWebDriver driver) : base(driver)
        {
        }

        public ChangePasswordPage ClickChangePassword()
        {
            driver.FindElement(changePasswordButton).Click();
            return new ChangePasswordPage(driver);
        }
    }
}
