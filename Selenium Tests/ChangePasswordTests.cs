using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    internal class ChangePasswordTests
    {
        IWebDriver driver;
        ChangePasswordPage changePasswordPage;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"X:\PXL Jaar 2\S2\DevOps Management\Selenium Tests\Selenium Tests\Drivers\");
            changePasswordPage = new ChangePasswordPage(driver);
            
        }

        [Test]
        [Description("EP & BVA TC01")]
        public void LengthEqualTo8AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("P@ssw0rd");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "P@ssw0rd").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC02")]
        public void LengthGreaterThan8AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("Passw0rd!123");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "Passw0rd!123").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC03")]
        public void LengthEqualTo128AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("H8q,<Z!(X=,cR[>bzw3C/9s-,mkgx2`~k=q;D<:8KSEW7YE$wsFC$B<M%y~n,5't_n[j}?V^Fs34+zEQk(9{?JAV%mc*%+h4[yXFv8cVWU+?<srL>c$4Zu{*%k2.KA7=");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));

            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "H8q,<Z!(X=,cR[>bzw3C/9s-,mkgx2`~k=q;D<:8KSEW7YE$wsFC$B<M%y~n,5't_n[j}?V^Fs34+zEQk(9{?JAV%mc*%+h4[yXFv8cVWU+?<srL>c$4Zu{*%k2.KA7=").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            } 
        }

        [Test]
        [Description("EP & BVA TC04")]
        public void LengthEqualTo127AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("H8q,<Z!(X=,cR[>bzw3C/9s-,mkgx2`~k=q;D<:8KSEW7YE$wsFC$B<M%y~n,5't_n[j}?V^Fs34+zEQk(9{?JAV%mc*%+h4[yXFv8cVWU+?<srL>c$4Zu{*%k2.KA7");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "H8q,<Z!(X=,cR[>bzw3C/9s-,mkgx2`~k=q;D<:8KSEW7YE$wsFC$B<M%y~n,5't_n[j}?V^Fs34+zEQk(9{?JAV%mc*%+h4[yXFv8cVWU+?<srL>c$4Zu{*%k2.KA7").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC05")]
        public void SpecialCharacterEqualTo1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("Passw0rd!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "Passw0rd!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC06")]
        public void SpecialCharacterGreaterThan1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("P@ssw0rd!!!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "P@ssw0rd!!!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC07")]
        public void UpperCaseCharacterEqualTo1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("Passw0rd!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "Passw0rd!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC08")]
        public void UpperCaseCharacterGreaterThan1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("PASSw0rd!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "PASSw0rd!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC09")]
        public void LowerCaseCharacterEqualTo1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("PaSSW0RD!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "PaSSW0RD!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC10")]
        public void LowerCaseCharacterGreaterThan1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("PassW0RD!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "PassW0RD!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC11")]
        public void NumberEqualTo1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("Passw0rd!");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "Passw0rd!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC12")]
        public void NumberGreaterThan1AndOtherRequirementsValidShouldPass()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("P@ssw0rd");
                Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "P@ssw0rd").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC13")]
        public void LengthLessThan1AndOtherRequirementsValidShouldFail()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("P@sw0rd");
                Assert.DoesNotThrow(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "P@sw0rd").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC14")]
        public void LengthGreaterThan129AndOtherRequirementsValidShouldFail()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("H8q,<Z!(X=,cR[>bzw3C/9s-,mkgx2`~k=q;D<:8KSEW7YE$wsFC$B<M%y~n,5't_n[j}?V^Fs34+zEQk(9{?JAV%mc*%+h4[yXFv8cVWU+?<srL>c$4Zu{*%k2.KA7=a");
                Assert.DoesNotThrow(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "H8q,<Z!(X=,cR[>bzw3C/9s-,mkgx2`~k=q;D<:8KSEW7YE$wsFC$B<M%y~n,5't_n[j}?V^Fs34+zEQk(9{?JAV%mc*%+h4[yXFv8cVWU+?<srL>c$4Zu{*%k2.KA7=a").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC15")]
        public void NoSpecialCharacterAndOtherRequirementsValidShouldFail()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("Passw0rd");
                Assert.DoesNotThrow(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "Passw0rd").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC16")]
        public void NoUpperCaseAndOtherRequirementsValidShouldFail()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("passw0rd!");
                Assert.DoesNotThrow(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "passw0rd!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC17")]
        public void NoLowerCaseAndOtherRequirementsValidShouldFail()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("PASSW0RD!");
                Assert.DoesNotThrow(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "PASSW0RD!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [Test]
        [Description("EP & BVA TC18")]
        public void NoNumberAndOtherRequirementsValidShouldFail()
        {
            try
            {
                changePasswordPage.GoToChangePasswordAndChangeTo("Password!");
                Assert.DoesNotThrow(() => driver.FindElement(By.Id("ErrorBox")));
            }
            finally
            {
                //Wachtwoord terug naar default zetten
                changePasswordPage.Open().ClickLoginButton().Login("stefaan@email.be", "Password!").OpenSettings().ClickChangePassword().CreateNewPassword("temp");
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
