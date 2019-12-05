using System;
using System.Threading;
using AutomationPractice1.Pages;
using OpenQA.Selenium;

namespace AutomationPractice1.Pages
{
    public class SigninPage
    {
        private IWebDriver _driver;
        //  private WebDriverWait _wait;

        //initializing the page Objects
        public SigninPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        //login objects
        public IWebElement txtEmail => _driver.FindElement(By.CssSelector("input#email"));
        public IWebElement txtPassword => _driver.FindElement(By.CssSelector("input#passwd"));
        public IWebElement btnLogin => _driver.FindElement(By.Name("SubmitLogin"));
        public IWebElement btnHome => _driver.FindElement(By.CssSelector("a[title='Return to Home']"));
        public IWebElement imgLogo => _driver.FindElement(By.CssSelector("img[alt='My Store']"));


        // regsiter objects
        public IWebElement inputEmail => _driver.FindElement(By.CssSelector("input#email_create"));
        public IWebElement btnCreateAccount => _driver.FindElement(By.CssSelector("button#SubmitCreate > span"));
        public IWebElement errorField => _driver.FindElement(By.CssSelector("div#create_account_error  li"));

        //Actions
        public void NavigateToSigninPage()
        {
            _driver.FindElement(By.XPath("//a[@class='login']")).Click();
        }

        public Boolean VerifyHomeLogo()
        {
            return imgLogo.Displayed;
        }

        public Boolean VerifySignInBtn()
        {
            return btnLogin.Displayed;
        }

        public Boolean VerifyEmailField()
        {
            return inputEmail.Displayed;
        }

        public Boolean CreateAccountBtn()
        {
            return btnCreateAccount.Displayed;
        }

        public void Signin(string email, string password)
        {
            //username
            txtEmail.SendKeys(email);
            //password
            txtPassword.SendKeys(password);
        }

        public DashBoardPage ClickSignin()
        {
            btnLogin.Click();
            return new DashBoardPage(_driver);
        }

        public void Register(string email)
        {
            //username
            inputEmail.SendKeys(email);
        }

        public CreateAnAccountPage ClickCreateAccount()
        {
            btnCreateAccount.Click();
            return new CreateAnAccountPage(_driver);
        }

        public string VerifyCreateAnAccount()
        {
            return btnCreateAccount.Text;
        }

        public void CreateAnAccount()
        {
            btnCreateAccount.Click();
        }

        public String VerifyErrorMessagePopUp()
        {
            return errorField.Text;
        }
    }
}
