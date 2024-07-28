Feature: Login:I want to login So that I can access the inventory page

Scenario Outline: Successful Login with valid credentials
	Given I am on the SauceDemo login page
	When I enter valid <UserName> and <Password>
	And I click the login button
	Then I should see the inventory page
Examples:
	| UserName                | Password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |
	| error_user              | secret_sauce |
	| visual_user             | secret_sauce |
