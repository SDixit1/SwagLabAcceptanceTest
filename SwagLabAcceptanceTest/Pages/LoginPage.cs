using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabAcceptanceTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public By UserName { get { return By.XPath("//input[@id='user-name']"); } }
        public By Password { get { return By.XPath("//input[@id='password']"); } }
        public By LoginButton { get { return By.XPath("//input[@id='login-button']"); } }

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Login()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        public void EnterCredentials(string userName, string password)
        {
            _driver.FindElement(UserName).SendKeys(userName);
            _driver.FindElement(Password).SendKeys(password);
        }

        public void ClickLogin()
        {
            _driver.FindElement(LoginButton).Click();
        }
    }
}
