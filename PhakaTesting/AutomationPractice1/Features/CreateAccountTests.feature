Feature: CreateAccountTests
	In order to Successfully login 
	As a customer 
	I want to enter valid credentials
	
Background:
	Given I am on automationpractice landing page
	And I navigate to the sign up page

Scenario: Validate Mandatory fields in sign up page

	Then I should see an email field
	And Create an account button

Scenario Outline: Validate Mandatory fields with invalid

	When I enter an invalid "<email>"
	And Click the create an account button
	Then I should an "invalid email address" error message

	Examples:
	| email		|
	| UserB		|

Scenario Outline: Validate Mandatory fields with existing email 

	When I enter an existing "<email>"
	And Click the create an account button
	Then I should an "An account using this email address has already been registered. Please enter a valid password or request a new one." error message

	Examples:
	| email		|
	| UserA		|

Scenario Outline: Validate Mandatory fields with valid email

	When I enter a valid "<email>"
	And Click the create an account button
	Then I should navigate to a registration form page

	Examples:
	| email		|
	| UserC		|

