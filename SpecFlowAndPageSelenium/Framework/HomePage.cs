using OpenQA.Selenium;

namespace Framework
{
    public class HomePage
    {
        private const string SearchBoxId = "lst-ib";
        private const string url = "http://google.com";

        public string SearchBox
        {
            get
            {
                return Browser.Driver.FindElement(By.Id(SearchBoxId)).Text;
            }
            set
            {
                Browser.Driver.FindElement(By.Id(SearchBoxId)).SendKeys(value);
            }
        }

        public string ResultStats
        {
            get
            {
                return Browser.Driver.FindElement(By.Id("resultStats")).Text;
            }
        }

        public void GoTo()
        {
            Browser.GoTo(url);
        }

        public void Search()
        {
            Browser.Driver.FindElement(By.Id("lst-ib")).Click();
        }
    }
}