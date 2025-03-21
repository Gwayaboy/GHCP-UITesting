package pages;

import com.microsoft.playwright.Page;

public class ProductListPage {
    private Page page;

    public ProductListPage(Page page) {
        this.page = page;
        page.navigate("https://contoso-traders-ui2ct2025.azureedge.net/list/all-products");
    }

    public ProductDetailPage select(ProductViewModel product) {
        page.navigate("https://contoso-traders-ui2ct2025.azureedge.net/product/detail/" + product.getId());
        return new ProductDetailPage(page);
    }

    public ShoppingCartPage ViewShoppingCart() {
        page.click("css=button[aria-label='cart']");
        return new ShoppingCartPage(page);
    }
}
