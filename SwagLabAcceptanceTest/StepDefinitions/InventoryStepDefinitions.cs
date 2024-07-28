using NUnit.Framework;
using SwagLabAcceptanceTest.Pages;
using System;
using OpenQA.Selenium;
namespace SwagLabAcceptanceTest.StepDefinitions
{
    [Binding]
    public class InventoryStepDefinitions
    {
        private readonly SwagerLab _swagerLab;
        private int basketItemCount;
        private readonly IWebDriver _driver;

        public InventoryStepDefinitions(SwagerLab sawgerLab, IWebDriver driver)
        {
            _swagerLab = sawgerLab;
            _driver = driver;
        }

        [When(@"I add the (.*) to the basket")]
        public void WhenIAddTheToTheBasket(string selectedItem)
        {
            _swagerLab.InventoryPage.AddItemToCart(selectedItem);
        }

        [Given(@"I add the following items to the shopping cart")]
        [When(@"I add the following items to the shopping cart")]
        public void WhenIAddTheFollowingItemsToTheShoppingCart(Table table)
        {
            foreach (var row in table.Rows)
            {
                var itemName = row["itemName"];
                _swagerLab.InventoryPage.AddItemToCart(itemName);
            }
        }

        [Then(@"the item count should be increase in the basket")]
        public void ThenTheShouldNotBeInTheBasket()
        {
            int itemCount= _swagerLab.CartPage.ItemInTheBasket();
            Assert.That(basketItemCount + 1, Is.EqualTo(itemCount));
        }

        [When(@"I remove the ""(.*)"" from the tile")]
        public void WhenIRemoveTheFromTheTile(string item)
        {
            _swagerLab.InventoryPage.RemoveItemFromCart(item);
        }

        [When(@"I remove the following items from the tile")]
        public void WhenIRemoveTheFollowingItemsFromTheTile(Table table)
        {
            foreach (var row in table.Rows)
            {
                var itemName = row["itemName"];
                _swagerLab.InventoryPage.RemoveItemFromCart(itemName);
            }
        }

        [Then(@"the cart should be empty")]
        public void ThenTheCartShouldBeEmpty()
        {
            int itemCount = _swagerLab.CartPage.ItemInTheBasket();
            Assert.That(itemCount , Is.EqualTo(0));
        }

    }
}
