using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class ChangePasswordPage : Settings
    {
        public static string CurrentURL = "http://localhost:8080/general/changePassword.html";
        private By submitNewPasswordButton = By.Id("buttonChangePassword");
        private By newPassword = By.Id("inputPassword");
        private By confirmNewPassword = By.Id("inputRepeatPassword");
        
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
        }

        public void CreateNewPassword(String newPassword)
        {
            driver.FindElement(this.newPassword).SendKeys(newPassword);
            driver.FindElement(confirmNewPassword).SendKeys(newPassword);
            driver.FindElement(submitNewPasswordButton).Click();
        }

        public void GoToChangePasswordAndChangeTo(String newPassword)
        {
            this.Open().ClickLoginButton().LoginStudentWithValidCredentials().OpenSettings().ClickChangePassword().CreateNewPassword(newPassword);
            Thread.Sleep(100);
        }

        public void ResetToDefaultPassword(String usedPassword)
        {
            this.Open().ClickLoginButton().Login("stefaan@email.be", usedPassword).OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            Thread.Sleep(100);
        }

        public void ClickSubmitNewPassword()
        {
            driver.FindElement(submitNewPasswordButton).Click();
        }
    }
}
