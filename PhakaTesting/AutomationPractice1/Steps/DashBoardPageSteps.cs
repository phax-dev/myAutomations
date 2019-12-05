using AutomationPractice1.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

using TechTalk.SpecFlow;
using static AutomationPractice1.Utils.Selenium.Settings;

namespace InsightsAutoTest.StepDefinitions
{
    [Binding]
    public class DashBoardPageTestSteps
    {
        SigninPage pageSignin;
        DashBoardPage pageDash;
        private readonly IWebDriver _driver;

        public DashBoardPageTestSteps(SigninPage signin, DashBoardPage dash, IWebDriver driver)
        {
            pageSignin = signin;
            pageDash = dash;
            _driver = driver;
        }

        [When(@"I enter valid ""(.*)"" and ""(.*)""")]
        public void WhenIEnterValidAnd(string email, string Password)
        {
            var _userA = UserA;
            var _passwordA = PasswordA;
            //pageLogin.Login(email, Password);
            //-var configReader = new ConfigReader();
            //-pageSignin.Signin(configReader.GetStringSetting("UserA"), configReader.GetStringSetting("PasswordA"));
            pageSignin.Signin(_userA, PasswordA);
        }

        [Then(@"I should navigate to a dashboard page")]
        public void ThenIShouldNavigateToADashboardPage()
        {
            pageDash = pageSignin.ClickSignin();
        }

        [Then(@"I should (.*) displayed")]
        public void ThenIShouldSeeDisplayed(string UserName)
        {
            string user = pageDash.VerifyUserName();

            Assert.That(user.Contains(UserName));
        }
    }
}
