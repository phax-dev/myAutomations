using AutomationPractice1.Utils.Selenium;
using BoDi;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace AutomationPractice1.Utils.Hooks
{
    [Binding]
    internal static class ScenarioHooks    
    {
        [BeforeScenario]
        internal static void StartWebDriver()
        {
            //:: IF TAG CONTAINS "Chrome"
            // :: CALL STARTCHROME

            //:: IF TAG CONTAINS "Fifefox"
            // :: STARTFIREFOX





            {
                DriverController.Instance.StartChrome();
            }

        }
        [AfterScenario]
        internal static void StopWebDriver()
        {
            //:: IF NOT ScenarioInfo.Tags.Contains("Debug")

            //STOP DRIVER
        }


    }
}
