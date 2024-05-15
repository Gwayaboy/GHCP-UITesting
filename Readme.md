# GitHub Copilot prompt crafting for UI Automation with SpecFlow ,Selenium and Playwright

## Description

GHCP Pratical demo in UI Test Automation

 1) **Task 1**:
 
        Starting from a scaffolded SpecFlow NUnit Project with a Feature file about a fictif e-commerce website at https://cloudtesting.contosotraders.com/ and the following [ShoppingCart.feature](SpecFlowProject.Tests\Features\ShoppingCart.feature) Feature file:
        
            ```gherkin
            Feature: Shopping Cart
                As a technology enthusiast
                I want to manage product items in my shopping cart
                So that I can place an order
            ```
            Add the following scenarios:

            1) 
                ```gherkin
                Scenario: Adding the first Xbox controller to an empty cart
                ``` 
                - prompt:
                
                    Add the scenario "Adding the first Xbox controller to an empty cart" the url to list all xbox controller is at  https://cloudtesting.contosotraders.com/list/controllers" to an empty cart from https://cloudtesting.contosotraders.com/list/controllers

            2) 
                ```gherkin
                Scenario: Viewing a cart a non-empty cart 5 existing product items
                ``` 
                - prompt:
                    
                    add a scenario for "Viewing a cart a non-empty cart" the cart willhave the first 5 products from the Product  API at https://contoso-traders-productsctprd.eastus.cloudapp.azure.com/v1/Products

                - can refine code asking to use the https://cloudtesting.contosotraders.com/product/detail/{productId} to navigate a specific product then add the product to shopping cart through the Web page.

                - Final scenario could look like below:
                    ```gherkin
                    Scenario: Viewing a non-empty cart
                    Given the shopping cart has the first 5 products
                    When I view my cart
                    Then the cart should display all 5 products each with Quantity of 1
                    ``` 

            3)  ```gherkin
                Scenario: Increase and decrease quantity of the last product item
                ``` 
                - simply start by asking GHCP to add the scenario and work your way towards a potential outcome as follow:
                    ```gherkin
                    Scenario: Updating the quantity of an existing item in the shopping cart
                    Given the shopping cart has the first 5 controllers
                    When I increment the quantity of the "Xbox Wireless Controller Black" by 1
                    Then the "Xbox Wireless Controller Black" quantity should be 2
                    And the subtotal should be 2x its unit price
                    ```

            4)  ```gherkin
                Scenario: Remove the first product item
                ``` 


        - Task 2: use GHCP to scaffold Specflow step definitions for the first 2 scenarios in Selenium and implement the navigation & interaction logic with elements on the page


        # Steps

        - Task 2
            
            1. Use GHCP Chat inline to ask 
            
                Add the scenario Adding the "Xbox Wireless Controller Black" Xbox controller to an empty cart". The url to list all xbox controller is at  https://cloudtesting.contosotraders.com/list/controllers

            2. Generate Steps Definition and add steps scaffold in Steps folder beside Feature file either use SpecFlow extension or inline GHCP Chat from feature file

            3. Nagivate to the Xbox controller list page at https://cloudtesting.contosotraders.com/list/controllers

            4. In the When step method Use the following prompts to find product and add to the cart 
                - Wait for max 30 seconds to find the product div element with a title equal to productName by css selector and click it
                - wait for max 30 seconds to find by css selector for the add button element with the class name CartButton using the button tag name and click it. 

            5. In the Then step method use the following prompts:
            -  Go to cart page https://cloudtesting.contosotraders.com/cart and wait 30 seconds max to find by Xpath the product div element has text equal to productName 
            -  Assert that the element found matches the product name

            6. Run the Scenario to verify it works
            7. Select the Step file and ask copilot to 
                - refactor this using page objects


2) **Task 2**

     use GHCP to generate scaffolds steps in Selenium

    
