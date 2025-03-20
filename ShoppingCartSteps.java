import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;

public class ShoppingCartSteps {

    @Given("I navigate to the Xbox controller list page")
    public void navigateToXboxControllerListPage() {
        // Implement navigation logic here
    }

    @When("I add the first Xbox controller to the cart")
    public void addFirstXboxControllerToCart() {
        // Implement add to cart logic here
    }

    @Then("the cart should contain the Xbox controller")
    public void verifyCartContainsXboxController() {
        // Implement verification logic here
    }

    @Given("the shopping cart has the first 5 products")
    public void shoppingCartHasFirst5Products() {
        // Implement logic to ensure cart has first 5 products
    }

    @When("I view my cart")
    public void viewMyCart() {
        // Implement view cart logic here
    }

    @Then("the cart should display all 5 products each with Quantity of 1")
    public void verifyCartDisplays5Products() {
        // Implement verification logic here
    }

    @When("I increment the quantity of the {string} by 1")
    public void incrementProductQuantity(String productName) {
        // Implement increment quantity logic here
    }

    @Then("the {string} quantity should be 2")
    public void verifyProductQuantity(String productName) {
        // Implement verification logic here
    }

    @Then("the subtotal should be 2x its unit price")
    public void verifySubtotal() {
        // Implement subtotal verification logic here
    }

    @When("I remove the first product item")
    public void removeFirstProductItem() {
        // Implement remove product logic here
    }

    @Then("the cart should not contain the first product item")
    public void verifyCartDoesNotContainFirstProduct() {
        // Implement verification logic here
    }
}
