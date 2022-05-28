using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class ApplicationPage : CompanyDetailPage
    {
        public static string URL = "http://localhost:8080/student/applicationForm.html";
        private By assignmentDropBox = By.Id("assignmentSelect");
        private By motivationTextBox = By.Id("studentMotivation");
        private By timeSlotDropBox = By.Id("timeSlotSelect");
        private By cvUploadInput = By.Id("cvInput");
        private By submitButton = By.Id("sendButton");

        public ApplicationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void FillInApplicationWithValidData()
        {
            driver.FindElement(motivationTextBox).SendKeys("Test");
            driver.FindElement(cvUploadInput).SendKeys(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Files\download.pdf");
            Thread.Sleep(500);
            driver.FindElement(submitButton).Click(); 
        }
    }
}
