using AutomationPractice1.Utils.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationPractice1.Utils.Hooks
{
    [Binding]
   internal static class TestRunHooks
    {
        [AfterTestRun]
        internal static void AfterTestRun()
        {
            // :: CONTEXT INJECTION
            // :: IF TAG CONTAINS DEBUG.......STOP WEBDRIVER
            
            
            //    DriverController.Instance.StopWebDriver();
            


        }
    }
}
