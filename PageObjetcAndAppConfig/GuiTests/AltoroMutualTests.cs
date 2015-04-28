using System;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using Tests.PageObjects;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Structura.GuiTests
{
    [TestFixture]
    public class AltoroMutualTests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Create();
            _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
            _verificationErrors.ToString().Should().BeEmpty("No verification errors are expected.");
        }

        [Test]
        public void Sample()
        {
            //_driver.Navigate().GoToUrl("http://newtours.demoaut.com/");
            ////width attribute is unique for table
            //string test = _driver.FindElement(By.XPath("//table[@width=\"270\"]/tbody/tr[4]/td")).Text;

            //_driver.Navigate().GoToUrl("http://guru99.com/");
            //IReadOnlyCollection<IWebElement> dateBox = _driver.FindElements(By.XPath("//h2[contains(text(),'A few of our most popular courses')]/parent::div//div[//a[text()='SELENIUM']]/following-sibling::div[@class='rt-grid-2 rt-omega']"));
            //IReadOnlyCollection<IWebElement> dateBox1 = _driver.FindElements(By.XPath("//div[.//a[text()='SELENIUM']]/ancestor::div[@class='rt-grid-2 rt-omega']/following-sibling::div"));
            ////Print all the which are sibling of the the element named as 'SELENIUM' in 'Popular course'

            //foreach (IWebElement webElement in dateBox1)
            //{

            //    Console.WriteLine(webElement.Text);
            //}

            //_driver.Navigate().GoToUrl("https://paashq.shephertz.com/#");
            File.OpenRead("");
            _driver.Url = "https://paashq.shephertz.com/#";
            //_driver.FindElement(By.LinkText("Log in with GitHub")).Click();
            Actions oAct = new Actions(_driver);
            oAct.SendKeys(Keys.Alt + Keys.F4).Build().Perform();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.Id("a")));
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(waitDriver => waitDriver.FindElement(By.Id("a")));
            WebDriverWait waitDriver = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement element = waitDriver.Until(drv => drv.FindElement(By.Id("a")));
            //Excel Op, PDF, Screnshots, Video, FlashPlayer
            Console.ReadLine();
        }

        [Test]
        public void LoginWithValidCredentialsShouldSucceed()
        {
            // Arrange
            // Act
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);

            // Assert
            new MainPage(_driver).GetAccountButton.Displayed.Should().BeTrue();
        }

        [Test]
        public void LoginWithInvalidCredentialsShouldFail()
        {
            // Arrange
            // Act
            new LoginPage(_driver).LoginAsNobody(_baseUrl);

            // Assert
            Action a = () =>
            {
                var displayed = new MainPage(_driver).GetAccountButton.Displayed; // throws exception if not found
            };
            a.ShouldThrow<NoSuchElementException>().WithMessage("Could not find element by: By.Id: btnGetAccount");
        }
        
        [Test]
        public void TransferAmountShouldBeAccepted()
        {
            // Arrange
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);
            var transferFundsPage = new TransferFundsPage(_driver);
            new MainPage(_driver).NavigateToTransferFunds();

            // Act
            transferFundsPage.Transfer99Dollar();

            // Assert

            // Need to wait until the results are displayed on the web page
            Thread.Sleep(1000);
            
            transferFundsPage.TranferMoneyMessage.Text.StartsWith(
                "$99 was successfully transferred from Account 20 into Account 21"
                , true, CultureInfo.InvariantCulture).Should().BeTrue();
        }
    }
}


