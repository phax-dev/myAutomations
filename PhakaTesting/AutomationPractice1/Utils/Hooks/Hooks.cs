using System;
using System.IO;
using System.Reflection;
using AutomationPractice1.Utils.Helpers;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;
using static AutomationPractice1.Utils.Selenium.Settings;

namespace AutomationPractice1.Utils.Hooks
{
    [Binding]
    public class Hooks
    {

        private static IWebDriver _driver;
        //private static WebDriverWait _driverWait;
        
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public static object browser { get; private set; }

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this._objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        private static IWebDriver IeDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            IWebDriver driver = new InternetExplorerDriver(options);
            return driver;
        }

        private static IWebDriver FirefoxDriver()
        {
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            IWebDriver driver = new FirefoxDriver("Automation");
            return driver;
        }

        private static IWebDriver ChromeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(chromeOptions);
            return driver;
        }

        public static void StartBrowser(string browser, int defaultTimeOut = 15)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    _driver = ChromeDriver();
                    break;
                case "ie":
                case "internet explorer":
                    _driver = IeDriver();
                    break;
                case "firefox":
                    _driver = FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException("You need to set a valid browser type.");
            }

            var _wait = int.Parse(Wait);
            var _pageLoadtimeOut = int.Parse(PageLoadtimeOut);

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_wait);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_pageLoadtimeOut);
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        [BeforeScenario]
        public void StartBrowser()
        {
            try
            {
                ExtentTestManager.InitializeScenario(_featureContext, _scenarioContext);
                StartBrowser(Browser);
                _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            }
            catch
            {
                ExtentTestManager.FinalizeScenario();
            }

        }

        [AfterScenario]
        public void RunStepsAfterScenario()
        {
            AttachScreenShot();
            _driver?.Quit();
        }

        [BeforeTestRun]
        public static void RunBeforeAll()
        {
            var prefix = "RUN" + DateTime.Now.ToString("ddMMMyyyyhhmm").ToUpper();
            var saveDirectoryRoot = $"{TestSettings.ReportFolder}\\TestResults\\{prefix}";
            ExtentTestManager.InitializeTestSuiteReporting(saveDirectoryRoot, "INSIGHT AUTOMATION");
        }

        private void AttachScreenShot()
        {
            if (_scenarioContext.TestError != null)
            {
                var screenShotPath = AppDomain.CurrentDomain.BaseDirectory + "\\TestResults\\ScreenShots";
                Directory.CreateDirectory(screenShotPath);

                if (_driver != null)
                {
                    var guid = Guid.NewGuid();
                    var screenshotTaker = _driver as ITakesScreenshot;
                    screenshotTaker?.GetScreenshot().SaveAsFile(Path.Combine(screenShotPath, guid + ".jpg"), ScreenshotImageFormat.Jpeg);
                    TestContext.AddTestAttachment(Path.Combine(screenShotPath, guid + ".jpg"));
                }
            }

        }

        [AfterStep]
        public void RunAfterStep()
        {
            ExtentTestManager.ReportStep(_driver, _scenarioContext);
        }

        [AfterTestRun]
        public static void RunAfterExecution()
        {
            var _baseurl = BaseUrl;
            var _browser = browser;
            ExtentTestManager.ReportInstance.AddSystemInfo("User", Environment.UserName);
            ExtentTestManager.ReportInstance.AddSystemInfo("OS", Environment.OSVersion.ToString());
            ExtentTestManager.ReportInstance.AddSystemInfo("Url", _baseurl);
            ExtentTestManager.ReportInstance.AddSystemInfo("Browser", _browser.ToString());
            ExtentTestManager.ReportInstance.Flush();
        }
    }

    public class TestSettings
    {
        public static string ReportFolder => Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
    }
}


