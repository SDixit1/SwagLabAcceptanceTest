Feature: verify Checkout page functionality

Scenario: 01 Verify order submittion
	Given I am on the SauceDemo login page
	And I enter valid 'standard_user' and 'secret_sauce'
	And I click the login button
	And I land on inventory Page
	And I add the following items to the shopping cart
		| itemName                |
		| Sauce Labs Backpack     |
		| Sauce Labs Bike Light   |
		| Sauce Labs Bolt T-Shirt |
		| Sauce Labs Onesie       |
	And I click on cart link
	And I land on cart Page
	And I procced to checkout
	And I enter my information
	And I review my order
		| itemName                |
		| Sauce Labs Backpack     |
		| Sauce Labs Bike Light   |
		| Sauce Labs Bolt T-Shirt |
		| Sauce Labs Onesie       |
	And I verify price and shipping Information
	When I finish the checkout
	Then I should see the checkout-complete page
	And I verify order confimation message
	When I click on backhome button
	Then I land on inventory Page


