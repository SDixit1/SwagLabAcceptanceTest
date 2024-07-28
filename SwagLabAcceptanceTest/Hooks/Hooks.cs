using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BoDi;
using System.Globalization;

namespace SwagLabAcceptanceTest.Hooks
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            _driver = new ChromeDriver(chromeOptions);
            _driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(_driver);
        }

        [AfterStep]
        public void MakeScreenshotAfterStep()
        {
            var random = new Random();
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var textInfo = new CultureInfo("en-GB", false).TextInfo;
            var scenarioName = textInfo.ToTitleCase(
                                    _scenarioContext.ScenarioInfo.Title.Replace(")", ""))
                                     .Replace(" ", "").Replace("\"", "");
            var datetimeStamp = DateTime.Now.ToString($"dd.MM.yyy_HH.mm.ss");
            var tempFileNameTimeStamp = $"{scenarioName}" + $"_{datetimeStamp}" + "_" + random.Next() + ".png";
            screenshot.SaveAsFile(tempFileNameTimeStamp);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
               _driver.Quit(); _driver.Dispose();
            }
        }
    }
}
