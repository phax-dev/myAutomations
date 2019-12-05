
using AutomationPractice1.Pages;
using AutomationPractice1.Utils.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice1.Steps
{
    [Binding]
    public sealed class BaseScenarioSteps:BaseSteps
    {
        [Then(@"I see the page url contains ""(.*)""")]
        public void ThenISeeThePageUrlContains(string p0)
        {
           
        }


        [Then(@"I see the page title contains ""(.*)""")]
        public void ThenISeeThePageTitleContains(string expectedTitle)
        {
            InstanceOf<BasePage>().ValidatePageTitle(expectedTitle);
        }

        [Given(@"I navigate to the Homepage")]
        public void GivenINavigateToTheHomepage()
        {
            InstanceOf<BasePage>().NavigateMainEnterPoint();
        }


    }
}
