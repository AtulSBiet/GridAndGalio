using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using Selenium;
using OpenQA.Selenium.Support.Events;
using System.Drawing.Imaging;
using System.IO;
using SeleniumUtil;
using OpenQA.Selenium.IE;
using System.Linq;


namespace SmapleProject
{
    #region Grid Parallelism Attributes
    [Header("browser", "version", "platform")] // name of the parameters in the rows
    [Row("firefox", "36.0", "WINDOWS")] // run all tests in the fixture against firefox 36 for windows 7
    //[Row("internet explorer", "11.0", "WINDOWS")] // run all tests in the fixture against iexplore 11 for windows 7
    [Row("chrome", "41.0", "WINDOWS")]
    //[Row("chrome", "41.0", "WINDOWS")]
    #endregion
    [Parallelizable]
    [Category("First")]
    [TestFixture]
    public class GridTest2
    {
        #region Fields
        //private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        #endregion

        [SetUp]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            baseURL = "http://google.co.in";
            verificationErrors = new StringBuilder();
        }

        private IWebDriver _Setup(string browser, string version, string platform)
        {
            /****Grid****/
            IWebDriver driver = StartGridDriver(browser, version, platform);
            /****DriverEventMgmt****/
            //IWebDriver driver = StartEventFiringDriver();
            return driver;
        }

        private IWebDriver StartEventFiringDriver()
        {
            EventFiringWebDriver firingDriver = new EventFiringWebDriver(new ChromeDriver());
            IWebDriver driver = firingDriver;
            firingDriver.ExceptionThrown += (sender, e) => firingDriver_TakeScreenshotOnException(sender, e, driver);

            Util.ImplicitWaitInSeconds(driver,5);
            return driver;
        }

        private static RemoteWebDriver StartGridDriver(string browser, string version, string platform)
        {
            RemoteWebDriver remoteDriver =  new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), SetDriverCapability(browser, version, platform));
            Util.ImplicitWaitInSeconds(remoteDriver, 5);
            return remoteDriver;
        }

        private static DesiredCapabilities SetDriverCapability(string browser, string version, string platform)
        {
            DesiredCapabilities desiredCapabilites = new DesiredCapabilities();
            desiredCapabilites.SetCapability(CapabilityType.BrowserName, browser);
            //desiredCapabilites.SetCapability(CapabilityType.Version, version);
            desiredCapabilites.SetCapability(CapabilityType.Platform, platform);
            //desiredCapabilites.SetCapability(CapabilityType.AcceptSslCertificates,true);
            return desiredCapabilites;
        }

        private void firingDriver_TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e, IWebDriver driver)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Automation\Selenium\C#\GridAndGalio\Screenshots\Exception-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg", ImageFormat.Jpeg);
        }

        //[TearDown]
        //public void TeardownTest()
        //{
        //    driver.Quit();
        //}


        [Test, Parallelizable]
        public void GoogleTest(string browser, string version, string platform)
        {
            IWebDriver driver = _Setup(browser, version, platform);
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("Testing");

            //string test = driver.FindElement(By.Id("lst-ib")).GetAttribute("value");
            //string test2 = driver.FindElement(By.Id("lst-ib")).GetAttribute("class");
            //driver.FindElement(By.Name("btnG")).Click();
            //driver.SwitchTo().W
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //DriverWithFirefoxprofile();
            //IWebElement e1 = driver.FindElement(By.Id("blst-ib"),10);
            //driver.FindElement(By.XPath("//img[contains(@src,’Profile’)]"));
            //Actions action = new Actions(driver);
            //SelectElement selector = new SelectElement(e1);
            //driver.FindElements(By.LinkText("Services")).Where(r => r.Displayed).ToArray(); ;
            //IWebElement e2 = driver.FindElement(By.Name("destination"));
            //action.ContextClick(e1).Perform();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            CleanUp(driver);
        }

        private void DriverWithFirefoxprofile()
        {
            string pathToCurrentUserProfiles = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Mozilla\Firefox\Profiles"; // Path to profile
            string[] pathsToProfiles = Directory.GetDirectories(pathToCurrentUserProfiles, "*.TestQAr", SearchOption.TopDirectoryOnly);
            if (pathsToProfiles.Length != 0)
            {
                FirefoxProfile profile = new FirefoxProfile (pathsToProfiles[0]);
                profile.SetPreference("browser.tabs.loadInBackground", false); // set preferences you need
                IWebDriver driver = new FirefoxDriver(new FirefoxBinary(), profile);
            }
            else
            {
                IWebDriver driver = new FirefoxDriver();
            }
        }

        private void CleanUp(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
