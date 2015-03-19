//using System;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

//namespace Learning
//{
//    [TestFixture]
//    public class IDEExported
//    {
//        private IWebDriver driver;
//        private StringBuilder verificationErrors;
//        private string baseURL;
//        private bool acceptNextAlert = true;
        
//        [SetUp]
//        public void SetupTest()
//        {
//            driver = new FirefoxDriver();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
//            baseURL = "https://www.google.co.in/";
//            verificationErrors = new StringBuilder();
//        }
        
//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                driver.Quit();
//            }
//            catch (Exception)
//            {
//                // Ignore errors if unable to close the browser
//            }
//            Assert.AreEqual("", verificationErrors.ToString());
//        }
        
//        [Test]
//        public void TheLearningTest()
//        {
//            driver.Navigate().GoToUrl(baseURL + "/");
//            driver.FindElement(By.Id("lst-ib")).Clear();
//            driver.FindElement(By.Id("lst-ib")).SendKeys("atul kumar singh");
//            driver.FindElement(By.LinkText("Atul Kumar Singh Profiles | Facebook")).Click();
//        }
//        private bool IsElementPresent(By by)
//        {
//            try
//            {
//                driver.FindElement(by);
//                return true;
//            }
//            catch (NoSuchElementException)
//            {
//                return false;
//            }
//        }
        
//        private bool IsAlertPresent()
//        {
//            try
//            {
//                driver.SwitchTo().Alert();
//                return true;
//            }
//            catch (NoAlertPresentException)
//            {
//                return false;
//            }
//        }
        
//        private string CloseAlertAndGetItsText() {
//            try {
//                IAlert alert = driver.SwitchTo().Alert();
//                string alertText = alert.Text;
//                if (acceptNextAlert) {
//                    alert.Accept();
//                } else {
//                    alert.Dismiss();
//                }
//                return alertText;
//            } finally {
//                acceptNextAlert = true;
//            }
//        }
//    }
//}
