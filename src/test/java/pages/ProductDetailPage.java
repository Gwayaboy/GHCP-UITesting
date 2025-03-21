package pages;

import com.microsoft.playwright.Page;

public class ProductDetailPage {

    private Page page;

    public ProductDetailPage(Page page) {
        this.page = page;
    }

    public ProductDetailPage addToCart() {
        page.click("css=button.CartButton");
        return this;
    }
}