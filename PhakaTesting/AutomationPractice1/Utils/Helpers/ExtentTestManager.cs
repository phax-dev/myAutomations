using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice1.Utils.Helpers
{

    public class ExtentTestManager
    {
        #region Fields and properties


        [ThreadStatic] private static ExtentTest _parentTest;

        [ThreadStatic] private static ExtentTest _childTest;

        [ThreadStatic] private static ExtentTest _grandChildTest;

        private static List<string> _featureContextList = new List<string>();

        private static readonly object _locker = new object();

        private static readonly Lazy<ExtentReports> Lazy = new Lazy<ExtentReports>(() => new ExtentReports());
        public static ExtentReports ReportInstance { get { return Lazy.Value; } }
        #endregion


        public static void InitializeTestSuiteReporting(string reportingLocation, string reportTitle, bool cleanUpOldReports = true)
        {
            try
            {
                if (cleanUpOldReports)
                {
                    CleanUpFolders(Directory.GetParent(reportingLocation).FullName, 3);
                }

                if (!Directory.Exists(reportingLocation))
                {
                    Directory.CreateDirectory(reportingLocation);
                }


                var htmlReporter = new ExtentHtmlReporter(reportingLocation + "\\");

                htmlReporter.Config.DocumentTitle = reportTitle;
                htmlReporter.Config.JS = _jsToAddLogo;
                ReportInstance.AttachReporter(htmlReporter);
            }
            catch (Exception) { }
        }


        public static void CleanUpFolders(string path, int numberOfDays)
        {
            foreach (string dir in Directory.GetDirectories(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);

                if (directoryInfo.CreationTime < DateTime.Now.AddDays(-numberOfDays))
                    Directory.Delete(dir, true);
            }
        }

        public static void InitializeScenario(FeatureContext currentFeatureContest, ScenarioContext scenarioContext)
        {
            lock (_locker)
            {
                if (_featureContextList.All(_ => _ != currentFeatureContest.FeatureInfo.Title))
                {
                    _featureContextList.Add(currentFeatureContest.FeatureInfo.Title);
                    CreateParentTest(currentFeatureContest.FeatureInfo.Title);
                }
                CreateTest($"SCENARIO : {scenarioContext.ScenarioInfo.Title}");
            }

        }


        public static void ReportStep(IWebDriver driver, ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var formattedStep = $"{stepType.ToUpper()} {string.Empty} : {scenarioContext.StepContext.StepInfo.Text}";

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    CreateNode<Given>(formattedStep);
                }
                else if (stepType == "When")
                    CreateNode<When>(formattedStep);
                else if (stepType == "Then")
                    CreateNode<Then>(formattedStep);
            }
            else if (scenarioContext.TestError != null)
            {
                var screenShotDriver = driver as ITakesScreenshot;
                var base64Screenshot = screenShotDriver?.GetScreenshot()?.AsBase64EncodedString;

                if (stepType == "Given")
                    CreateNode<Given>(formattedStep).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot, "Screenshot.png").Build());
                else if (stepType == "When")
                    CreateNode<When>(formattedStep).Fail(scenarioContext.TestError.Message
                        , MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot, "Screenshot.png").Build());

                else if (stepType == "Then")
                    CreateNode<Then>(formattedStep).Fail(scenarioContext.TestError.Message
                        , MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot, "Screenshot.png").Build());
            }
        }


        public static void FinalizeScenario()
        {
            if (_grandChildTest == null)
            {
                _childTest.CreateNode<Given>("<<<<<<<<<<<<< ERROR STARTING TESTS >>>>>>>>>>>>>>").Warning("No Steps Executed. Check there are no issues in your hooks. There seems to be problem with execution even before the tests started.");
            }
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateParentTest(string testName, string description = null)
        {
            _parentTest = ReportInstance.CreateTest<Feature>(testName, description);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateTest(string testName, string description = null)
        {
            _childTest = _parentTest.CreateNode<Scenario>(testName, description);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static ExtentTest CreateNode<T>(string testName, string description = null)
            where T : IGherkinFormatterModel
        {
            _grandChildTest = _childTest?.CreateNode<T>(testName, description);
            return _grandChildTest;
        }


        #region Logo and Javascript to Dislay Logo

        private static readonly string _base64EncodedLogo =
            "";


        private static readonly string _jsToAddLogo =

            $"   function removeElement(elementLocator)                                         " +
            "   {                                                                              " +
            "      var element = document.querySelector(elementLocator);                       " +
            "      element.parentNode.removeChild(element);                                    " +
            "  }                                                                               " +
            "                                                                                  " +
            "  function addElement(parentLocator, elementTag, elementId, html)                 " +
            "  {                                                                               " +
            "      var p = document.querySelector(parentLocator);                              " +
            "      var newElement = document.createElement(elementTag);                        " +
            "      newElement.setAttribute('id', elementId);                                   " +
            "      newElement.innerHTML = html;                                                " +
            "      p.appendChild(newElement);                                                  " +
            "  }                                                                               " +
            "                                                                                  " +
            "  removeElement('.badge-primary:nth-child(1)');                                   " +
            $"  addElement('.m-r-10:nth-child(1) a', 'div', 'logo', \"<img src='data:png;base64,{_base64EncodedLogo} '>\");   " +
            "                                                                                  ";


        #endregion

    }



}
