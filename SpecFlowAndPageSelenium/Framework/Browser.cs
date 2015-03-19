using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Framework
{
    public static class Browser
    {
        public static readonly IWebDriver webDriver = new ChromeDriver();

        public static IWebDriver Driver
        {
            get
            {
                return webDriver;
            }
        }

        public static void GoTo(string url)
        {
            webDriver.Url = url;
        }

        public static void Close()
        {
            webDriver.Close();
        }
    }
}