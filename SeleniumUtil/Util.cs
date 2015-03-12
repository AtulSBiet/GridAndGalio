using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUtil
{
    class Util
    {
        internal static void ImplicitWaitInSeconds(OpenQA.Selenium.IWebDriver driver, int waitSeconds)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(waitSeconds));

        }
    }
}
