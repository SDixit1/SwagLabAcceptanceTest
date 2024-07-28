using FluentAssertions.Equivalency.Tracing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagLabAcceptanceTest.Pages;


namespace SwagLabAcceptanceTest.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly SwagerLab _swagerLab;
        public LoginStepDefinitions(SwagerLab sawgerLab)
        {
            _swagerLab = sawgerLab;
        }

        [Given(@"I am on the SauceDemo login page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            _swagerLab.LoginPage.Login();
        }

        [Given(@"I enter valid '(.*)' and '(.*)'")]
        [When(@"I enter valid (.*) and (.*)")]

        public void WhenIEnterValidUsernameAndPassword(String userName, String passWord)
        {
            _swagerLab.LoginPage.EnterCredentials(userName, passWord);
        }

        [Given(@"I click the login button")]
        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _swagerLab.LoginPage.ClickLogin();
        }

        [Given(@"I land on (.*) Page")]
        [Then(@"I land on (.*) Page")]
        [Then(@"I should see the (.*) page")]
        public void ThenIShouldSeeThePage(String expectedUrl)
        {
            Assert.That(_swagerLab.Driver.Url, Does.Contain(expectedUrl));
        }
    }
}
