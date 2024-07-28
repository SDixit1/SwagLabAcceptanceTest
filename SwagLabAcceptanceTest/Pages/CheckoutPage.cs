using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabAcceptanceTest.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        public By FirstName { get { return By.Id("first-name"); } }
        public By LastName { get { return By.Id("last-name"); } }
        public By PostCode { get { return By.Id("postal-code"); } }
        public By ContinueButton { get { return By.Id("continue"); } }
        public By FinishButton { get { return By.Id("finish"); } }
        public By PaymentInfoLabel { get { return By.XPath("//div[@data-test='payment-info-label']"); } }
        public By PaymentInfoValue { get { return By.XPath("//div[@data-test='payment-info-value']"); } }
        public By ShippingInfolabel { get { return By.XPath("//div[@data-test='shipping-info-label']"); } }
        public By ShippingInfoValue { get { return By.XPath("//div[@data-test='shipping-info-value']"); } }
        public By TotalProceInfolabel { get { return By.XPath("//div[@data-test='total-info-label']"); } }
        public By TotalPriceLabel { get { return By.XPath("//div[@data-test='total-info-label']"); } }
        public By TotalPriceValue { get { return By.XPath("//div[@data-test='subtotal-label']"); } }
        public By TotalValue { get { return By.XPath("//div[@data-test='tax-label']"); } }
        public By CompleteOrderHeader { get { return By.ClassName("complete-header"); } }
        public By CompleteOrderContent { get { return By.ClassName("complete-text"); } }
        public By BackHomeButton { get { return By.XPath("//button[@data-test='back-to-products']"); } }

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void EnterPersonalDerails()
        {
            _driver.FindElement(FirstName).SendKeys("Test");
            _driver.FindElement(LastName).SendKeys("Code");
            _driver.FindElement(PostCode).SendKeys("UKCode");
        }

        public void ClickContinueButton()
        {
            _driver.FindElement(ContinueButton).Click();
        }
        public void ClickFinishButton()
        {
            _driver.FindElement(FinishButton).Click();
        }
        public void VerifyPriceAndShippingDetails()
        {
            Assert.That(_driver.FindElement(PaymentInfoLabel).Displayed);
            Assert.That(_driver.FindElement(PaymentInfoValue).Displayed);
            Assert.That(_driver.FindElement(ShippingInfolabel).Displayed);
            Assert.That(_driver.FindElement(ShippingInfoValue).Displayed);
            Assert.That(_driver.FindElement(TotalProceInfolabel).Displayed);
            Assert.That(_driver.FindElement(TotalPriceLabel).Displayed);
            Assert.That(_driver.FindElement(TotalPriceValue).Displayed);
            Assert.That(_driver.FindElement(TotalValue).Displayed);
        }
        public void VerifyOrderConfirmation()
        {
            Assert.That(_driver.FindElement(CompleteOrderHeader).Displayed);
            Assert.That(_driver.FindElement(CompleteOrderContent).Displayed);
        }
        public void ClickBackHomeButton()
        {
            _driver.FindElement(BackHomeButton).Click();
        }
    }
}
