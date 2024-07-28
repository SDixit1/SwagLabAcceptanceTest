using NUnit.Framework;
using SwagLabAcceptanceTest.Pages;

namespace SwagLabAcceptanceTest.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        private readonly SwagerLab _swagerLab;
        public CartStepDefinitions(SwagerLab sawgerLab)
        {
            _swagerLab = sawgerLab;
        }      

        [Given(@"the shopping cart badge should show ""([^""]*)""")]
        [Then(@"the shopping cart badge should show ""([^""]*)""")]
        public void ThenTheShoppingCartBadgeShouldShow(int totalItems)
        {
            int itemCount = _swagerLab.CartPage.ItemInTheBasket();
            Assert.That(itemCount, Is.EqualTo(totalItems));
        }

        [Given(@"I click on cart link")]
        [When(@"I click on cart link")]
        public void WhenIClickOnCartLink()
        {
            _swagerLab.CartPage.ClickOnCartLink();     
        }

        [Then(@"the following items should be in the cart")]
        public void ThenTheFollowingItemShouldBeInTheCart(Table table)
        {
            _swagerLab.CartPage.VerifyCart( table);
        }

        [When(@"I  remove (.*)from the cart")]
        public void WhenIRemoveStaSauceLabsBackpackFromTheCart(String removeItem)
        {
            _swagerLab.CartPage.RemoveItemFromShoppingCart(removeItem);
        }

        [Then(@"cart is has ""([^""]*)""  item")]
        public void ThenCartIsHasItem(string items)
        {
            _swagerLab.CartPage.CartIsUpdated(items);
        }

        [When(@"I click on Continue Shipping button")]
        public void WhenIClickOnContinueShippingButton()
        {
            _swagerLab.CartPage.ClickOnContinueShoppingButton();
        }

        [When(@"I click on checkout button")]
        [Given(@"I procced to checkout")]
        public void WhenIClickOnCheckoutButton()
        {
            _swagerLab.CartPage.ClickOnCheckoutButton();
        }
    }
}

