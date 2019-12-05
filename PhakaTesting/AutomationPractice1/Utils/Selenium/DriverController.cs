using System;
using System.Diagnostics;
using AutomationPractice1.Utils.Drivers;
using OpenQA.Selenium;


namespace AutomationPractice1.Utils.Selenium
{
    internal  class DriverController
    {
        internal static DriverController Instance = new DriverController();
        internal IWebDriver WebDriver { get; set; }

        internal void StartChrome()
        {
            if (WebDriver!= null)return;
            WebDriver = ChromeWebDriver.LoadChromeDriver();        
        }

        internal void StopWebDriver()
        {
            if (WebDriver == null) return;
            try
            {
                WebDriver.Quit();
                WebDriver.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e, ":: WebDriver Stop Error");
            }
            WebDriver = null;
            Console.WriteLine(":: WebDriver Stopped");

        }


    }
}
