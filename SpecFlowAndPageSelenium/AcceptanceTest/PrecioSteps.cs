using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTest
{
    [Binding]
    public class PrecioSteps
    {
        Calculator _calculator;
        int _result;

        [BeforeScenario()]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int enteredValue)
        {
            _calculator.Number(enteredValue);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedValue)
        {
            Assert.AreEqual(_result, expectedValue);
        }
    }
}
