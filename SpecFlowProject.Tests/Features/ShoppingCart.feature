Feature: Shopping Cart
	As a computer enthusiast
	I want to add or update product items my shopping cart
	So that I can place an order

Scenario: Adding the "Xbox Wireless Controller Black" Xbox controller to an empty cart
	Given I am on the Xbox controller list page
	When I add the "Xbox Wireless Controller Black" to my cart
	Then the cart should contain the "Xbox Wireless Controller Black"

Scenario: Viewing a non-empty cart
	Given the shopping cart has the first 5 controllers
	When I view my cart
	Then the cart should display 5 controllers

Scenario: Updating the quantity of an item in the cart
	Given the shopping cart has the first 5 controllers
	And the "Xbox Wireless Controller Black" quantity is 1
	When I increase the quantity of the "Xbox Wireless Controller Black" 
	Then the cart the "Xbox Wireless Controller Black" should be 2 
	And the subtotal for the "Xbox Wireless Controller Black" should be 2x its unit price


	






