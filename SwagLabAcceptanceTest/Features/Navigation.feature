Feature: Verify Menu and Footer Navigation links 

Background:
	Given I am on the SauceDemo login page
	And I enter valid 'standard_user' and 'secret_sauce'
	And I click the login button
	And I land on inventory Page

Scenario: 01 Validate the footer navigation links
	Then I click on the <link> and navigate to the <url>
Examples:
	| link     | url                                          |
	| Twitter  | https://x.com/saucelabs                      |
	| Facebook | https://www.facebook.com/saucelabs           |
	| LinkedIn | https://www.linkedin.com/company/sauce-labs/ |

Scenario: 02 Validate the menu navigation links
	When I Click on the  Menu option
	Then I Select on the menu <link> and navigate to the <url>
Examples:
	| link      | url                                      |
	| All Items | https://www.saucedemo.com/inventory.html |
	| About     | https://saucelabs.com/                   |
	| Logout    | https://www.saucedemo.com/               |

