using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic; // Add this line for the 'Product' class
using System.Linq; // Add this line for the 'Take' method
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic; // Add this line for the 'Product' class
using System.Linq; // Add this line for the 'Take' method
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Binding]
public class ShoppingCartSteps 
{
      private readonly IWebDriver _driver;
    private readonly HttpClient _httpClient;
    private IEnumerable<Product> _products;

    public ShoppingCartSteps(IWebDriver driver, HttpClient httpClient)
    {
        _driver = driver;
        _httpClient = httpClient;
    }
    
    [Given(@"the shopping cart has the first (\d+) products")]
    public async Task GivenTheShoppingCartHasTheFirstProducts(int numberOfProducts)
    {
        // Implement code to add the first 'numberOfProducts' Products to the shopping cart from  https://contoso-traders-productsctprd.eastus.cloudapp.azure.com/v1/Products
        // I want to post directly to the API to add the Products to the shopping cart

        // Set up HTTP client
        _httpClient.BaseAddress = new Uri("https://contoso-traders-productsctprd.eastus.cloudapp.azure.com/v1/Products");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Get first 'numberOfProducts' Products
        HttpResponseMessage response = await _httpClient.GetAsync("https://contoso-traders-productsctprd.eastus.cloudapp.azure.com/v1/Products");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonString);
            _products = jsonObject["products"].Select(p => new Product((int)p["id"], (string)p["name"], (decimal)p["price"])).ToArray();            
           
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            
             //write a for loop to add the first 'numberOfProducts' Products to the shopping cart
            foreach (var product in _products.Take(numberOfProducts))
            {
                // Navigate to product detail page
                _driver.Navigate().GoToUrl($"https://cloudtesting.contosotraders.com/product/detail/{product.Id}");

                // Click on Add to Bag button
                var addToBagButton = wait.Until(driver => driver.FindElement(By.CssSelector("button.CartButton")));

                // Click on Add to Bag button
                addToBagButton.Click();

                // Wait for the cart to update
            }
        }
    }

    [When(@"I view my cart")]
    public void WhenIViewMyCart()
    {
        // Navigate to cart page
        _driver.Navigate().GoToUrl("https://cloudtesting.contosotraders.com/cart");
    }

    [Then(@"the cart should display all (\d+) products each with Quantity of (\d+)")]
    public void ThenTheCartShouldDisplayProducts(int expectedNumberOfProducts)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
    
        var cartItems = wait.Until(driver => driver.FindElements(By.CssSelector("div.allProductlist")));
    
        Assert.Equals(expectedNumberOfProducts, cartItems.Count);
    
        foreach (var cartItem in cartItems)
        {
            var productName = cartItem.FindElement(By.CssSelector("div.Productname")).Text;
            var productPriceText = cartItem.FindElement(By.CssSelector("div.Productprice")).Text;
            var productPrice = decimal.Parse(productPriceText.Replace("Price / Unit : ", "").Replace("$", ""));

            // Assuming the product id is the last part of the image src URL
            var productImageSrc = cartItem.FindElement(By.CssSelector("img.imagesection")).GetAttribute("src");
            var productId = int.Parse(productImageSrc.Split('/').Last().Replace("PID", "").Replace("-1.jpg", ""));

            // Extract the product quantity
            var productQuantityText = cartItem.FindElement(By.CssSelector("input.quantity-display")).GetAttribute("value");
            var productQuantity = int.Parse(productQuantityText);

            // Now you can compare these values with the ones in _products
            var product = _products.SingleOrDefault(p => p.Id == productId);
            Assert.IsFalse(product == null, $"Product with id {productId} not found in the list of products");
            Assert.Equals(product.Name, productName);
            Assert.Equals(product.Price, productPrice);
            Assert.Equals(productQuantity, 1);

        }
    }
}

public class Product 
{
    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
