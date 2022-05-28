using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class DashboardPage : SignInPage
    {
        private By homeButton = By.Id("pxlLogo");
        private By settingsButton = By.Id("settingIcon");
        private By logoutButton = By.Id("logoutIcon");

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToDashboard()
        {
            driver.FindElement(homeButton).Click();
        }

        public void OpenSettings()
        {
            driver.FindElement(settingsButton).Click();
        }

        public void Logout()
        {
            driver.FindElement(logoutButton).Click();
        }
    }
}
