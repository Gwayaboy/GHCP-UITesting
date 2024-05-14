# GitHub Copilot prompt crafting for UI Automation with SpecFlow ,Selenium and Playwright

## Description

GHCP Pratical demo in UI Test Automation

 1) Starting from a scaffolded SpecFlow NUnit Project with a Feature file about a fictif e-commerce website at https://cloudtesting.contosotraders.com/ and the following [ShoppingCart.feature](SpecFlowProject.Tests\Features\ShoppingCart.feature) Feature file:
 
    ```gherkin
    Feature: Shopping Cart
        As a technology enthusiast
        I want to manage product items in my shopping cart
        So that I can place an order
    ```
    Add the following scenarios:

    - 
        ```gherkin
        Scenario: Adding the first Xbox controller to an empty cart
        ``` 
        - prompt:
        
            Add the scenario "Adding the first Xbox controller to an empty cart" the url to list all xbox controller is at  https://cloudtesting.contosotraders.com/list/controllers" to an empty cart from https://cloudtesting.contosotraders.com/list/controllers

    - 
        ```gherkin
        Scenario: Viewing a cart a non-empty cart 5 existing product items
        ``` 
        - prompt:
            
            add a scenario for "Viewing a cart a non-empty cart" the cart willhave the first 5 products from the Product  API at https://contoso-traders-productsctprd.eastus.cloudapp.azure.com/v1/Products

    -  ```gherkin
        Scenario: Increase and decrease quantity of the last product item
        ``` 
        - prompt:

            add a scenario for "Increase "

    -  ```gherkin
        Scenario: Remove the first product item
        ``` 


- Task 2: use GHCP to scaffold Specflow step definitions for the first 2 scenarios in Selenium and implement the navigation & interaction logic with elements on the page



- Task 3: use GHCP to generate scaffolds steps in Selenium


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


- Task 2: use GHCP to generate scaffolds steps in Selenium

    
