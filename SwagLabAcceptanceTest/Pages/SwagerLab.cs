using OpenQA.Selenium;
using SwagLabAcceptanceTest.Pages;

namespace SwagLabAcceptanceTest.Pages
{
    public class SwagerLab
    {
        public IWebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public InventoryPage InventoryPage { get; set; }
        public  CartPage CartPage { get; set; }
        public CheckoutPage CheckoutPage { get; set; }
        public NavigationPage NavigationPage { get; set; }
        public SwagerLab(IWebDriver driver)
        {
            Driver = driver;
            LoginPage = new LoginPage(driver);
            InventoryPage = new InventoryPage(driver);
            CartPage = new CartPage(driver);
            CheckoutPage = new CheckoutPage(driver);
            NavigationPage  = new NavigationPage(driver);
        }
    }
}
