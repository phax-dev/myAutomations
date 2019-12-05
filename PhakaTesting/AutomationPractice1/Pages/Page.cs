using AutomationPractice1.Utils.Selenium;


namespace AutomationPractice1.Pages
{
    public abstract class Page
    { 
    
        protected T InstanceOf<T>() where T : BasePage, new()
        {
            var pageClass = new T { Driver = Driver.Browser() };
            return pageClass;
        }
    }
}
