using SwagLabAcceptanceTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabAcceptanceTest.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinition
    {
        private readonly SwagerLab _swagerLab;

        public CheckoutStepDefinition(SwagerLab sawgerLab)
        {
            _swagerLab = sawgerLab;
        }

        [Given(@"I enter my information")]
        public void WhenIEnterMyInformation()
        {
            _swagerLab.CheckoutPage.EnterPersonalDerails();
            _swagerLab.CheckoutPage.ClickContinueButton();
        }

        [Given(@"I review my order")]
        public void WhenIReviewMyOrder(Table table)
        {
            _swagerLab.CartPage.VerifyCart(table);
        }

        [When(@"I finish the checkout")]
        public void WhenIFinishTheCheckout()
        {
            _swagerLab.CheckoutPage.ClickFinishButton();
        }

        [Given(@"I verify price and shipping Information")]
        public void GivenIVerifyPriceAndShippingInformation()
        {
            _swagerLab.CheckoutPage.VerifyPriceAndShippingDetails();
        }

        [Then(@"I verify order confimation message")]
        public void ThenIVerifyOrderConfimationMessage()
        {
            _swagerLab.CheckoutPage.VerifyOrderConfirmation();
        }

        [When(@"I click on backhome button")]
        public void WhenIClickOnBackhomeButton()
        {
            _swagerLab.CheckoutPage.ClickBackHomeButton();
        }
    }
}
