Feature: Shopping Cart
	As a computer enthusiast
	I want to add or update product items my shopping cart
	So that I can place an order

Scenario: Adding the "Xbox Wireless Controller Black" Xbox controller to an empty cart
	Given I am on the Xbox controller list page
	When I add the "Xbox Wireless Controller Black" to my cart
	Then the cart should contain the "Xbox Wireless Controller Black"

Scenario: Adding the "Xbox Wireless Controller Black" Xbox controller to a non-empty cart
	Given the shopping cart has the first 5 controllers
	When I add the "Xbox Wireless Controller Black" to my cart
	Then the cart should display 6 controllers

Scenario: Viewing a non-empty cart
	Given the shopping cart has the first 5 products
	When I view my cart
	Then the cart should display all 5 products each with Quantity of 1
	
#add a scenario to Increase the quantity of an existing item in the shopping cart
Scenario: Updating the quantity of an existing item in the shopping cart
	Given the shopping cart has the first 5 controllers
	When I increment the quantity of the "Xbox Wireless Controller Black" by 1
	Then the "Xbox Wireless Controller Black" quantity should be 2
	And the subtotal should be 2x its unit price







