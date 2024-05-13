Feature: Shopping Cart
	As a computer enthusiast
	I want to add or update product items my shopping cart
	So that I can place an order

Scenario: Adding the "Xbox Wireless Controller Black" Xbox controller to an empty cart
	Given I am on the Xbox controller list page
	When I add the "Xbox Wireless Controller Black" to my cart
	Then the cart should contain the "Xbox Wireless Controller Black"

#add a scenario for viewing a cart that already has the first 5 products from the Product at API https://contoso-traders-productsctprd.eastus.cloudapp.azure.com/v1/Products



   



