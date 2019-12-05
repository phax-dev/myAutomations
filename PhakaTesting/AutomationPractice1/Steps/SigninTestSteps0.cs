using NUnit.Framework;
using OpenQA.Selenium;
using System;
using static AutomationPractice1.Utils.Selenium.Settings;
using TechTalk.SpecFlow;
using AutomationPractice1.Pages;

namespace AutomationPractice1.Steps
{
    [Binding]
    public class SigninTestSteps0
    {
        SigninPage pageSignin;
        DashBoardPage pageDash;
        CreateAnAccountPage pageAccount;
        private readonly IWebDriver _driver;

        public SigninTestSteps0(SigninPage signin, DashBoardPage dash, CreateAnAccountPage account, IWebDriver driver)
        {
            pageSignin = signin;
            pageDash = dash;
            pageAccount = account;
            _driver = driver;
        }

        [Given(@"I am on automationpractice landing page")]
        public void GivenIAmOnAutomationpracticeLandingPage()
        {
            var _baseurl = BaseUrl;
            _driver.Navigate().GoToUrl(_baseurl);
        }

        [Given(@"I navigate to the sign up page")]
        public void GivenINavigateToTheSignUpPage()
        {
            pageSignin.NavigateToSigninPage();
            string verify = pageSignin.VerifyCreateAnAccount();
            Assert.That(verify.Contains("Create an account"), "String not found in entire page content.");
        }

        [Then(@"I should see an email field")]
        public void ThenIShouldSeeAnEmailField()
        {
            var emailField = pageSignin.VerifyEmailField();
            Assert.IsTrue(emailField);
        }

        [Then(@"Create an account button")]
        public void ThenCreateAnAccountButton()
        {
            var accountBtn = pageSignin.CreateAccountBtn();
            Assert.IsTrue(accountBtn);
        }

        [When(@"I enter an invalid ""(.*)""")]
        public void WhenIEnterAnInvalid(string UserB)
        {
            var _userB = UserB;
            pageSignin.Register(UserB);
        }

        [When(@"Click the create an account button")]
        public void WhenClickTheCreateAnAccountButton()
        {
            pageSignin.ClickCreateAccount();
        }

        [Then(@"I should an ""(.*)"" error message")]
        public void ThenIShouldAnErrorMessage(string Expected)
        {
            string error = pageSignin.VerifyErrorMessagePopUp();
            Assert.That(error.Contains(Expected));
        }

        [When(@"I enter an existing ""(.*)""")]
        public void WhenIEnterAnExisting(string UserA)
        {
            //-var configReader = new ConfigReader();
            var _userA = UserA;
            pageSignin.Register(_userA);
        }

        [When(@"I enter a valid ""(.*)""")]
        public void WhenIEnterAValid(string UserC)
        {
            //- var configReader = new ConfigReader();
            var _userC = UserC;
            pageSignin.Register(_userC);
        }

        [Then(@"I should navigate to a registration form page")]
        public void ThenIShouldNavigateToARegistrationFormPage()
        {
            pageAccount = pageSignin.ClickCreateAccount();
            string validate = pageAccount.VerifyCreateAnAccountPage();
            //Assert.That(validate.Contains("Create an account"), "String not found in entire page content.");
        }

        [When(@"I select an item to add to cart")]
        public void WhenISelectAnItemToAddToCart()
        {
            pageDash.ClickWomen();
            pageDash.ClickBlouse();
            pageDash.SelectBlouse();
            pageDash.ClickAdd();
            pageDash.switchFrame();
            pageDash.ClickProceed();
            pageDash.ClickCart();
            pageDash.GetText();
            Console.WriteLine(pageDash.GetText());
        }

        [Then(@"I should see the same item in the cart")]
        public void ThenIShouldSeeTheSameItemInTheCart()
        {

        }

    }

}
