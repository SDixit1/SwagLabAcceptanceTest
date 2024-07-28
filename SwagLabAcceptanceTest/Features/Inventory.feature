Feature: Verifying Inventorypage functionality

Background:
	Given I am on the SauceDemo login page
	And I enter valid 'standard_user' and 'secret_sauce'
	And I click the login button
	And I land on inventory Page

Scenario: 01 Verify basket item count is updated when item is added and removed
	When I add the <ItemName> to the basket
	Then the item count should be increase in the basket
	When I remove the "<ItemName>" from the tile
	Then the cart should be empty
Examples:
	| ItemName                 |
	| Sauce Labs Fleece Jacket |

Scenario: 02 Verify basket item count is updated when Multiple items are  added and removed
	When I add the following items to the shopping cart
		| itemName              |
		| Sauce Labs Backpack   |
		| Sauce Labs Bike Light |
	Then the shopping cart badge should show "2"
	When I remove the following items from the tile
		| itemName              |
		| Sauce Labs Backpack   |
		| Sauce Labs Bike Light |
	Then the cart should be empty
 
Scenario Outline: 03 Filter Items based on filter selection
	When I select <FilterType> from the filter dropdown
	Then the items should be sorted by <FilterType> in <Order> order
Examples:
	| FilterType          | Order     |
	| Name (A to Z)       | ascending |
	| Name (Z to A)       | decending |
	| Price (low to high) | ascending |
	| Price (high to low) | decending |