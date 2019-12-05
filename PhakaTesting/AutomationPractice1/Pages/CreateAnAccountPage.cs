using System;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationPractice1.Pages
{
    public class CreateAnAccountPage
    {
        private IWebDriver _driver;
        // private WebDriverWait _driverwait;

        //initializing the page Objects
        public CreateAnAccountPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        //Create an account objects
        public IWebElement txtCreateAnAccount => _driver.FindElement(By.XPath("//h1[@class='page-heading']"));
        public IWebElement radioTitle => _driver.FindElement(By.Name("id_gender"));
        public IWebElement txtFirst => _driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        public IWebElement txtLast => _driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
        public IWebElement txtEmail => _driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement txtPassword => _driver.FindElement(By.XPath("//input[@id='passwd']"));
        public IWebElement txtFirstName => _driver.FindElement(By.XPath("//input[@id='firstname']"));
        public IWebElement txtLastName => _driver.FindElement(By.XPath("//input[@id='lastname']"));
        public IWebElement txtAddress => _driver.FindElement(By.XPath("//input[@id='address1']"));
        public IWebElement txtCity => _driver.FindElement(By.XPath("//input[@id='city']"));
        public IWebElement txtState => _driver.FindElement(By.XPath("//select[@id='id_state']"));
        public IWebElement txtZipcode => _driver.FindElement(By.XPath("//input[@id='postcode']"));
        public IWebElement selCountry => _driver.FindElement(By.Id("id_country"));
        public IWebElement txtMobile => _driver.FindElement(By.Name("phone_mobile"));
        public IWebElement txtAlias => _driver.FindElement(By.Id("alias"));

        public IWebElement btnRegister => _driver.FindElement(By.XPath("//span[contains(text(),'Register')]"));

        //Actions
        //Actions
        public String VerifyCreateAnAccountPage()
        {
            return txtCreateAnAccount.Text;
        }

        public void SelectTitle()
        {
            radioTitle.Click();
        }

        public void EnterFirst(string first)
        {
            txtFirst.SendKeys(first);
        }

        public void EnterLast(string last)
        {
            txtLast.SendKeys(last);
        }

        public void EnterEmail(string email)
        {
            txtEmail.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            txtPassword.SendKeys(password);
        }

        public void EnterFirstName(string first)
        {
            txtFirstName.SendKeys(first);
        }

        public void EnterLastName(string last)
        {
            txtLastName.SendKeys(last);
        }

        public void EnterAddress(string address)
        {
            txtAddress.SendKeys(address);
        }

        public void EnterCity(string city)
        {
            txtCity.SendKeys(city);
        }

        public void EnterState(string state)
        {
            txtState.SendKeys(state);
        }

        public void EnterZipCode(int city)
        {
            txtZipcode.SendKeys(city.ToString());
        }

        public void SelectCountry(string country)
        {
            txtZipcode.SendKeys(country);
        }

        public void EnterMobile(int mobile)
        {
            txtMobile.SendKeys(mobile.ToString());
        }

        public void EnterAlias(string alias)
        {
            txtAlias.SendKeys(alias);
        }

        public DashBoardPage ClickRegister()
        {
            btnRegister.Click();
            return new DashBoardPage(_driver);
        }
    }
}
