using Framework;
using TechTalk.SpecFlow;

namespace AcceptanceTest
{
    [Binding]
    class SpecFlowHooks
    {
        [AfterScenario]
        public static void Close()
        {
            //Browser.Close();
        }
    }
}
