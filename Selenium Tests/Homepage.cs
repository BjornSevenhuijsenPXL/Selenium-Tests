using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class Homepage
    {
        public static string URL = "http://localhost:8080/general/landingpage.html";
        protected IWebDriver driver;
        public By buttonLogin = By.XPath("/html/body/div[2]/a[2]/button");
        public By buttonRegisterAsCompany = By.XPath("//*[@id=\"body\"]/div[2]/a[1]/button");

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Url = "http://localhost:8080/general/landingpage.html";
        }

        public SignInPage ClickLoginButton()
        {
            driver.FindElement(buttonLogin).Click();
            return new SignInPage(driver);
        }
    }
}
