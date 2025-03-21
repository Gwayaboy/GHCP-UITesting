package pages;

import java.util.List;
import java.util.ArrayList;

import com.microsoft.playwright.Locator;
import com.microsoft.playwright.Page;

public class ShoppingCartPage {

    private Page page;
    // private static final String SHOPPING_CART_URL =
    // "https://contoso-traders-ui2ct2025.azureedge.net/cart";
    private static final String SHOPPING_CART_ITEM_SELECTOR = "div.allProductlist > div.product";
    private static final String SHOPPING_CART_ITEM_NAME_SELECTOR = "div.Productname";

    public ShoppingCartPage(Page page) {
        this.page = page;
    }

    public void removeItemFromCart(String itemName) {
        page.click("text=" + itemName);
        page.click("css=button[aria-label='remove']");
    }

    public boolean isItemInCart(String itemName) {
        return page.isVisible("text=" + itemName);
    }

    public void proceedToCheckout() {
        page.click("css=button[aria-label='checkout']");
    }

    public List<ProductViewModel> getItemsInCart() {
        Locator itemsLocator = page.locator(SHOPPING_CART_ITEM_SELECTOR);
        int itemCount = itemsLocator.count();
        List<ProductViewModel> items = new ArrayList<>();
        for (int i = 0; i < itemCount; i++) {
            Locator item = itemsLocator.nth(i);
            items.add(new ProductViewModel(
                    Integer.parseInt(item.locator(SHOPPING_CART_ITEM_NAME_SELECTOR).textContent()),
                    item.locator("div.Producttype").textContent()));
        }
        return items;
    }
}
