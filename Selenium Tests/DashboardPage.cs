using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void ClickHomeButton()
        {
            driver.FindElement(homeButton).Click();
        }

        public Settings OpenSettings()
        {
            driver.FindElement(settingsButton).Click();
            Thread.Sleep(100);
            return new Settings(driver);
        }

        public void Logout()
        {
            Thread.Sleep(100);
            driver.FindElement(logoutButton).Click();
        }
    }
}
