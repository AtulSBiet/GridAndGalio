using OpenQA.Selenium.Support.PageObjects;

namespace Framework
{
    public static class GooglePages
    {
        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                PageFactory.InitElements(Browser.Driver, homePage);
                return homePage;
            }
        }
    }
}
