using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace SwagLabAcceptanceTest.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void SwitchTabs()
        {
            ReadOnlyCollection<String> windows = _driver.WindowHandles;
            if (_driver.WindowHandles.Count > 1)
                _driver.SwitchTo().Window(windows[_driver.WindowHandles.Count - 1]);
            else
                _driver.SwitchTo().Window(windows[0]);
        }

        public void AddItemToCart(string addItem)
        {
            _driver.FindElement(By.XPath($"//div[@class='inventory_item' and .//img[@alt='" + addItem + "']]//button[contains(@class, 'btn_inventory')]")).Click();
        }
        public void RemoveItemFromCart(string removeItem)
        {
            _driver.FindElement(By.XPath($"//div[@class='inventory_item' and .//img[@alt='{removeItem}']]//button[contains(@class, 'btn_inventory') and contains(text(), 'Remove')]")).Click();
        }

    }
}

