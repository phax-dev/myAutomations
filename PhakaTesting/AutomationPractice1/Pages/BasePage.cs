using OpenQA.Selenium;
using static AutomationPractice1.Utils.Selenium.Driver;
using static AutomationPractice1.Utils.Selenium.Settings;

using System;
using NUnit.Framework;


namespace AutomationPractice1.Pages
{
    public class BasePage : Page

    {
        public IWebDriver Driver { get; internal set; }

        public void ValidatePageTitle(string expectedTitle)
        {
            var titleToValidate = Driver.Title.Contains(expectedTitle);
            string title = Driver.Title;
            Assert.IsTrue(titleToValidate, "My Store");
            Console.WriteLine(":: The Title of the page is " + title);


        }

        public void NavigateMainEnterPoint()
        {
            var baseurl = BaseUrl;
            Browser().Navigate().GoToUrl(baseurl);
            Browser().Manage().Window.Maximize();
           // Console.WriteLine(WelcomeMessage);
        }
    }
}
