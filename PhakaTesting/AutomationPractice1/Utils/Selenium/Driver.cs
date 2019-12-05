using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice1.Utils.Selenium
{
    [Binding]
    internal class Driver
    {
        internal static IWebDriver Browser()
        {
            return DriverController.Instance.WebDriver;
        }
    }
}
