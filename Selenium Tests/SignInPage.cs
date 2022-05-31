using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class SignInPage : Homepage
    {
        public static string CurrentURL = "http://localhost:8080/login/login.html";
        public static string ExpectedURL = "http://localhost:8080/login.html";
        public static string Title = "Login";
        private By email = By.Id("inputEmail");
        private By password = By.Id("inputPassword");
        private By retunButton = By.XPath("//*[@id=\"leftContainer\"]/div/img");

        public SignInPage(IWebDriver driver) : base(driver)
        { 
        }

        public DashboardPage Login(string email, string password)
        {
            driver.FindElement(this.email).Clear();
            driver.FindElement(this.password).Clear();
            driver.FindElement(this.email).SendKeys(email);
            driver.FindElement(this.password).SendKeys(password);
            driver.FindElement(By.Id("buttonLogin")).Click();
            return new DashboardPage(driver);
        }

        public DashboardPageStudents LoginStudentWithValidCredentials()
        {
            driver.FindElement(email).Clear();
            driver.FindElement(password).Clear();
            driver.FindElement(email).SendKeys("stefaan@email.be");
            driver.FindElement(password).SendKeys("temp");
            driver.FindElement(By.Id("buttonLogin")).Click();
            Thread.Sleep(200);
            return new DashboardPageStudents(driver);
        }

        public void ClickReturnButton()
        {
            Thread.Sleep(100);
            driver.FindElement(retunButton).Click();
        }
    }
}
