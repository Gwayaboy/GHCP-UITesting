package steps;

import com.microsoft.playwright.*;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;
import io.cucumber.java.Before;
import io.cucumber.java.After;
import io.cucumber.java.DataTableType;

import pages.ProductListPage;
import pages.ProductViewModel;
import pages.ShoppingCartPage;

import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

public class ShoppingCartSteps {
    private static Playwright playwright;
    private static Browser browser;
    private static BrowserContext context;
    private static Page page;
    private static ProductListPage productListPage;
    private static ShoppingCartPage shoppingCartPage;
    private static List<ProductViewModel> expectedProducts;

    @Before
    public static void setup() {
        playwright = Playwright.create();
        browser = playwright.chromium().launch(new BrowserType.LaunchOptions().setHeadless(false));
        context = browser.newContext();
        page = context.newPage();
        productListPage = new ProductListPage(page);
    }

    @After
    public static void teardown() {
        page.close();
        context.close();
        browser.close();
        playwright.close();
    }

    @Given("the shopping cart has 5 products")
    public void shoppingCartHasFirst5Products(List<ProductViewModel> products) {

        for (ProductViewModel product : products) {
            productListPage
                    .select(product)
                    .addToCart();
        }
    }

    @When("I view the shopping cart")
    public void ViewShoppingCart() {
        shoppingCartPage = productListPage.ViewShoppingCart();

    }

    @Then("the shopping cart should contain the following products")
    public void shoppingCartShouldContainProducts(List<ProductViewModel> products) {
        List<ProductViewModel> actualProducts = shoppingCartPage.getItemsInCart();
        assertEquals(expectedProducts, actualProducts);
    }

    @DataTableType
    public ProductViewModel productViewModelEntry(Map<String, String> entry) {
        return new ProductViewModel(Integer.parseInt(entry.get("ID")), entry.get("Product Name"));
    }

}
