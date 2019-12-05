Feature: SigninTests
	In order to Successfully login 
	As a customer 
	I want to enter valid credentials

Scenario Outline: Sucessfully login in

	Given I am on automationpractice landing page
	And I navigate to the sign up page
	When I enter valid "<email>" and "<password>"
	And Click the create an account button
	Then I should navigate to a dashboard page
	And I should "James Paddy" displayed

	Examples:
	| email | password  |
	| UserA | password1 |

Scenario: Add item to cart

	Given I am on automationpractice landing page
	And I navigate to the sign up page
	When I enter valid "<email>" and "<password>"
	And Click the create an account button
	And I select an item to add to cart
	Then I should see the same item in the cart
