package steps;

import com.microsoft.playwright.*;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.AfterAll;
import java.util.logging.Logger;
import java.util.logging.Level;
import static org.junit.jupiter.api.Assertions.assertTrue;

public class ShoppingCartSteps {
    private static final Logger logger = Logger.getLogger(ShoppingCartSteps.class.getName());
    private static Playwright playwright;
    private static Browser browser;
    private static BrowserContext context;
    private static Page page;

    @BeforeAll
    public static void setup() {
        try {
            logger.info("Setting up Playwright");
            playwright = Playwright.create();
            browser = playwright.chromium().launch(new BrowserType.LaunchOptions().setHeadless(false));
            context = browser.newContext();
            page = context.newPage();
            logger.info("Playwright setup complete");
        } catch (Exception e) {
            logger.log(Level.SEVERE, "Error during Playwright setup", e);
        }
    }

    @AfterAll
    public static void teardown() {
        try {
            logger.info("Tearing down Playwright");
            page.close();
            context.close();
            browser.close();
            playwright.close();
            logger.info("Playwright teardown complete");
        } catch (Exception e) {
            logger.log(Level.SEVERE, "Error during Playwright teardown", e);
        }
    }

    @Given("I navigate to the Xbox controller list page")
    public void navigateToXboxControllerListPage() {
        try {
            logger.info("Navigating to Xbox controller list page");
            page.navigate("https://contoso-traders-ui2ct2025.azureedge.net/list/all-products");
        } catch (Exception e) {
            logger.log(Level.SEVERE, "Error navigating to Xbox controller list page", e);
        }
    }

    @When("I add the first Xbox controller to the cart")
    public void addFirstXboxControllerToCart() {
        try {
            logger.info("Adding first Xbox controller to the cart");
            page.click("css=div[title='Xbox Wireless Controller']");
            page.click("css=button.CartButton");
        } catch (Exception e) {
            logger.log(Level.SEVERE, "Error adding first Xbox controller to the cart", e);
        }
    }

    @Then("the cart should contain the Xbox controller")
    public void verifyCartContainsXboxController() {
        try {
            logger.info("Verifying cart contains Xbox controller");
            page.navigate("https://cloudtesting.contosotraders.com/cart");
            boolean isVisible = page.isVisible("text='Xbox Wireless Controller'");
            assertTrue(isVisible, "Xbox Wireless Controller is not visible in the cart");
        } catch (Exception e) {
            logger.log(Level.SEVERE, "Error verifying cart contains Xbox controller", e);
        }
    }
}
