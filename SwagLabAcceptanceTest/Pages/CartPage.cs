using NUnit.Framework;
using OpenQA.Selenium;

namespace SwagLabAcceptanceTest.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        public By BasketItem { get { return By.ClassName("shopping_cart_badge"); } }
        public By CartLink { get { return By.ClassName("shopping_cart_link"); } }
        public By CartItemName { get { return By.ClassName("inventory_item_name"); } }
        public By ContinueShoppingButton { get { return By.XPath("//button[@id='continue-shopping']"); } }
        public By CheckoutButton { get { return By.XPath("//button[@id='checkout']"); } }
        public By RemoveItem { get { return By.XPath("//*[@id='remove-sauce-labs-backpack']"); } }

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public int ItemInTheBasket()
        {
            var cartBadges = _driver.FindElements(BasketItem);
            if (cartBadges.Count == 0)
            {
                return 0;
            }
            return int.Parse(cartBadges[0].Text);
        }

        public void ClickOnCartLink()
        {
            _driver.FindElement(CartLink).Click();
        }

        public void VerifyCart(Table table)
        {
            IList<IWebElement> cartItems = _driver.FindElements(CartItemName);

            foreach (var row in table.Rows)
            {
                string itemName = row["itemName"];
                Assert.That(cartItems.Any(item => item.Text.Equals(itemName)), Is.True);
            }
        }
        public void RemoveItemFromShoppingCart(string item)
        {
            _driver.FindElement(RemoveItem).Click();
        }
        public void CartIsUpdated(string items)
        {
            string badgeText = _driver.FindElement(BasketItem).Text;
            Assert.That(badgeText, Is.EqualTo(items));

        }
        public void ClickOnContinueShoppingButton()
        {
            _driver.FindElement(ContinueShoppingButton).Click();
        }
        public void ClickOnCheckoutButton()
        {
            _driver.FindElement(CheckoutButton).Click();
        }

        public int EmptyCart()
        {
            var cartBadges = _driver.FindElements(BasketItem);
            if (cartBadges.Count == 0)
            {
                return 0;
            }
            return int.Parse(cartBadges[0].Text);
        }
    }
}
