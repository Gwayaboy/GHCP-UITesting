Feature: Shopping Cart
    As a technology enthusiast
    I want to manage product items in my shopping cart
    So that I can place an order

    # Scenario: Adding the first Xbox controller to an empty cart
    #     Given I navigate to the Xbox controller list page
    #     When I add the first Xbox controller to the cart
    #     Then the cart should contain the Xbox controller

    Scenario: Viewing a non-empty cart with 5 existing product items
        Given the shopping cart has 5 products
        | ID | Product Name |
        | 1  | Xbox Wireless Controller Lunar Shift Special Edition |
        | 2  | Xbox Wireless Controller Mineral Camo Special Edition |
        | 3  | Xbox Elite Wireless Controller Series 2 Core (White) |
        | 4  | Xbox Wireless Controller 20th Anniversary Special Edition |
        | 5  | Xbox Elite Wireless Controller Series 2 Halo Infinite Limited Edition |
        When I view the shopping cart
        Then the cart should display all 5 products each with Quantity of 1

    # Scenario: Increase and decrease quantity of the last product item
    #     Given the shopping cart has the first 5 controllers
    #     When I increment the quantity of the "Xbox Wireless Controller Black" by 1
    #     Then the "Xbox Wireless Controller Black" quantity should be 2
    #     And the subtotal should be 2x its unit price

    # Scenario: Remove the first product item
    #     Given the shopping cart has the first 5 products
    #     When I remove the first product item
    #     Then the cart should not contain the first product item