using System.Text.RegularExpressions;
using System.Threading;
using Framework;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AcceptanceTest
{
    [Binding]
    public class NumberOfHitsSteps
    {
        [Given(@"I go to the startpage")]
        public void GivenIGoToTheStartpage()
        {
            GooglePages.HomePage.GoTo();
        }

        [Then(@"I search for '(.*)'")]
        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string p0)
        {
            GooglePages.HomePage.SearchBox = p0;
            GooglePages.HomePage.Search();
            Thread.Sleep(3000);
        }
        
        [Then(@"I should be presented with the number of hits")]
        public void ThenIShouldBePresentedWithTheNumberOfHits()
        {
            Assert.IsTrue(int.Parse(Regex.Match(GooglePages.HomePage.ResultStats, @"([0-9]+)").Groups[0].Value) > 0);
        }


    }
}
