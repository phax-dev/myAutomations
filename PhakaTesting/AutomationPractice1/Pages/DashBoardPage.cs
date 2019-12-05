using System;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationPractice1.Pages
{
    public class DashBoardPage
    {
        private IWebDriver _driver;
        // private WebDriverWait _wait;
        //  private DefaultWait<IWebDriver> _fluentWait;

        //INITIALISING PAGE OBJECTS
        public DashBoardPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement txtWelcomeMsg => _driver.FindElement(By.XPath("//p[@class='info-account']"));
        public IWebElement txtSignOut => _driver.FindElement(By.XPath("//a[@class='logout']"));
        public IWebElement txtUser => _driver.FindElement(By.XPath("//a[@class='account']"));
        public IWebElement User => _driver.FindElement(By.XPath("//span[contains(text(),'James Paddy')]"));
        public IWebElement Women => _driver.FindElement(By.CssSelector("a[title='Women']"));
        public IWebElement Blouse => _driver.FindElement(By.CssSelector("a[title='Blouse'] > img[alt='Blouse']"));
        public IWebElement Add => _driver.FindElement(By.CssSelector("p#add_to_cart  span"));
        public IWebElement Item => _driver.FindElement(By.XPath("//a[@class='product-name'][contains(text(),'Blouse')]"));
        public IWebElement Switch => _driver.FindElement(By.XPath("//span[contains(text(),'Proceed to checkout')]"));
        public IWebElement getText => _driver.FindElement(By.XPath("//td[@class='cart_description']//a[contains(text(),'Blouse')]"));
        public IWebElement Proceed => _driver.FindElement(By.XPath("//span[contains(text(), 'Proceed to checkout')]"));


        //Actions
        public string VerifyWelcomeMessage()
        {
            return txtWelcomeMsg.Text;
        }

        public string VerifyUserName()
        {
            string user = User.Text;
            Console.WriteLine(user);
            return user;
        }

        //public String VerifyUserName(String uName)
        //{
        //    return _driver.FindElement(By.XPath("//span[contains(text(),'" + uName + "')]")).Text;
        //}

        public void ClickWomen()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            Women.Click();
        }

        public void ClickBlouse()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            Blouse.Click();
        }

        public void SelectBlouse()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            Blouse.Click();
        }

        public String ClickAdd() //::IMPLICIT WAIT
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            return Add.Text;
        }

        public void switchFrame()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//div[@class='layer_cart_cart col-xs-12 col-md-6']")));
            Switch.Click();
        }

        public void ClickProceed()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            Proceed.Click();
        }

        public void ClickCart()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            Switch.Click();
        }

        public string GetText()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            return getText.Text;
        }

        public string VerifySignout()
        {
            Thread.Sleep(1500); //::IMPLICIT WAIT
            return txtSignOut.Text;
        }
    }
}
