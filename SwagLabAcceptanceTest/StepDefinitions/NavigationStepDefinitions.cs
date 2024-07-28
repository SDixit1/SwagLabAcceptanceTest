using OpenQA.Selenium;
using SwagLabAcceptanceTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabAcceptanceTest.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        private readonly SwagerLab _swagerLab;

        private readonly IWebDriver _driver;
        public NavigationStepDefinitions(SwagerLab sawgerLab, IWebDriver driver)
        {
            _swagerLab = sawgerLab;
            _driver = driver;
        }

        [When(@"I select (.*) from the filter dropdown")]
        public void WhenISelectNameAToZFromTheFilterDropdown(string filterOption)
        {
            _swagerLab.NavigationPage.FilterItems(filterOption);
        }

        [Then(@"the items should be sorted by (.*) in (.*) order")]
        public void ThenTheItemsShouldBeSortedByNameInAscendingOrder(string filterby, string order)
        {
            _swagerLab.NavigationPage.SortItems(filterby, order);
        }

        [Then(@"I click on the (.*) and navigate to the (.*)")]
        public void ThenIClickOnTheTwitterAndNavigateToTheHttpsX_ComSaucelabs(string linkText, string expectedUrl)
        {
            _swagerLab.NavigationPage.ClickOnFooterLink(linkText);
            _swagerLab.NavigationPage.ValidateChangeInURL(expectedUrl);
            _swagerLab.NavigationPage.CloseTab();
        }

        [When(@"I Click on the  Menu option")]
        public void WhenIClickOnTheMenuOption()
        {
            _swagerLab.NavigationPage.SelectMenu();
        }

        [Then(@"I Select on the menu (.*) and navigate to the (.*)")]
        public void ThenISelectOnTheMenuAllItemsAndNavigateToTheHttpsWww_Saucedemo_ComInventory_Html(string menuoption, string navUrl)
        {
            _swagerLab.NavigationPage.SelectMenuOption(menuoption, navUrl);
        }

    }
}
