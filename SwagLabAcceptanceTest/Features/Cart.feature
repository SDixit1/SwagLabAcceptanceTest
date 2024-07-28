Feature: Verifying CartPage functionality

Background:
	Given I am on the SauceDemo login page
	And I enter valid 'standard_user' and 'secret_sauce'
	And I click the login button
	And I land on inventory Page

Scenario: 01 Add items to shopping cart
	And I add the following items to the shopping cart
		| itemName              |
		| Sauce Labs Backpack   |
		| Sauce Labs Bike Light |
	And the shopping cart badge should show "2"
	When I click on cart link
	Then the following items should be in the cart
		| itemName              |
		| Sauce Labs Backpack   |
		| Sauce Labs Bike Light |

Scenario: 02 Remove items to shopping cart
	And I add the following items to the shopping cart
		| itemName              |
		| Sauce Labs Backpack   |
		| Sauce Labs Bike Light |
	And I click on cart link
	When I  remove <ItemName> from the cart
	Then cart is has "1"  item
Examples:
	| ItemName            |
	| Sauce Labs Backpack |

Scenario: 03 Verify Back and Forth Scenario
	And I add the following items to the shopping cart
		| itemName                |
		| Sauce Labs Backpack     |
		| Sauce Labs Bike Light   |
		| Sauce Labs Bolt T-Shirt |
		| Sauce Labs Onesie       |
	And I click on cart link
	When I click on Continue Shipping button
	Then I land on inventory Page
	When I click on cart link
	Then I land on cart Page
	When I click on checkout button
	Then I land on checkout-step-one Page





