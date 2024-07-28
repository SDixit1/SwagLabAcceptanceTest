using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace SwagLabAcceptanceTest.Pages
{
    public class NavigationPage
    {
        public By ProductFilter { get { return By.ClassName("product_sort_container"); } }
        public By PriceFilter { get { return By.ClassName("inventory_item_price"); } }
        public By NameFilter { get { return By.ClassName("inventory_item_name"); } }
        public By menuOption { get { return By.XPath("//button[contains(@id, 'menu-btn')]"); } }


        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public NavigationPage(IWebDriver driver)
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

        public void FilterItems(string filterOption)
        {
            var filterDropdown = _wait.Until(d => d.FindElement(ProductFilter));
            var selectElement = new SelectElement(filterDropdown);
            selectElement.SelectByText(filterOption);
        }
        public void SortItems(string filterby, string order)
        {
            if (filterby.Contains("Name"))
            {
                var itemNames = _wait.Until(d => d.FindElements(NameFilter));
                var sortedItemNames = new List<string>(itemNames.Select(item => item.Text));
                var expectedSortedItemNames = new List<string>(sortedItemNames);
                expectedSortedItemNames.Sort();
                if (order.Contains("decending"))
                {
                    expectedSortedItemNames.Reverse();
                }
                Assert.That(sortedItemNames, Is.EqualTo(expectedSortedItemNames));
            }
            if (filterby.Contains("Price"))
            {
                var itemPrices = _wait.Until(d => d.FindElements(By.ClassName("inventory_item_price")));
                var actualItemPrices = itemPrices.Select(item => decimal.Parse(item.Text.Replace("$", ""))).ToList();

                var expectedSortedItemPrices = new List<decimal>(actualItemPrices);
                expectedSortedItemPrices.Sort();
                if (order.Contains("decending"))
                {
                    expectedSortedItemPrices.Reverse();
                }
                Assert.That(actualItemPrices, Is.EqualTo(expectedSortedItemPrices));
            }
        }

        public void ClickOnFooterLink(string link)
        {
            IWebElement linkElement = _driver.FindElement(By.XPath("//li[contains(@class, 'social')]/a[text()='" + link + "']"));
            linkElement.Click();
        }

        public void ValidateChangeInURL(string changeUrl)
        {
            SwitchTabs();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Assert.That(_driver.Url.ToString(), Is.EqualTo(changeUrl));
            _driver.Navigate().Back();
        }

        public void CloseTab()
        {
            ReadOnlyCollection<String> windows = _driver.WindowHandles;
            if (_driver.WindowHandles.Count > 1)
            {
                for (int i = 0; i < _driver.WindowHandles.Count; i++)
                {
                    if (windows[i].Equals(_driver.CurrentWindowHandle.ToString()))
                    {
                        _driver.Close();
                        SwitchTabs();
                    }
                }
            }
        }

        public void SelectMenu()
        {
            _driver.FindElement(menuOption).Click();

        }
        public void SelectMenuOption(string option, string navUrl)
        {
            _driver.FindElement(By.XPath("//nav[contains(@class, 'bm-item-list')]/a[text()='" + option + "']")).Click();
            Assert.That(_driver.Url, Does.Contain(navUrl));


        }
    }


}
