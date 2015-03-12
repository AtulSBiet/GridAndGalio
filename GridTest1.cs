//using System;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading;
//using MbUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Remote;


//namespace SmapleProject
//{
//    [Parallelizable]
//    [TestFixture]
//    public class GridTest1
//    {
//        private IWebDriver driver;
//        private StringBuilder verificationErrors;
//        private string baseURL;


//        [SetUp]
//        public void SetupTest()
//        {
//            DesiredCapabilities capabilities = new DesiredCapabilities();
//            capabilities = DesiredCapabilities.InternetExplorer();
//            capabilities.SetCapability(CapabilityType.BrowserName, "iexplore");
//            capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
//            capabilities.SetCapability(CapabilityType.Version, "11.0");


//            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
//            //driver = new InternetExplorerDriver();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
//            baseURL = "https://www.google.co.in/";
//            verificationErrors = new StringBuilder();
//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            //driver.Quit();
//        }

//        [Test]
//        public void GoogleTest()
//        {
//            driver.Navigate().GoToUrl(baseURL + "/");
//            driver.FindElement(By.Id("lst-ib")).Clear();
//            driver.FindElement(By.Id("lst-ib")).SendKeys("Testing");
//            driver.FindElement(By.Name("btnG")).Click();
//        }
//    }
//}