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

[Binding]
public class ShoppingCartSteps 
{
      private readonly IWebDriver _driver;
    private readonly HttpClient _httpClient;

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
            dynamic products = JsonConvert.DeserializeObject(jsonString);

            if (products != null)
            {
                //write a for loop to add the first 'numberOfProducts' Products to the shopping cart
                for (int i = 0; i < numberOfProducts; i++)
                {
                    var product = products[i];
                    // Navigate to product detail page
                    _driver.Navigate().GoToUrl($"https://cloudtesting.contosotraders.com/product/detail/{product.Id}");

                    // Click on Add to Bag button
                    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                    var addToBagButton = wait.Until(driver => driver.FindElement(By.CssSelector("button.CartButton")));

                    // Click on Add to Bag button
                    addToBagButton.Click();

                    // Wait for the cart to update
                }
            }

        }
    }

    [When(@"I view my cart")]
    public void WhenIViewMyCart()
    {
        // Navigate to cart page
        _driver.Navigate().GoToUrl("https://cloudtesting.contosotraders.com/cart");
    }

    [Then(@"the cart should display the (\d+) products")]
    public void ThenTheCartShouldDisplayProducts(int expectedNumberOfProducts)
    {
        // Implement code to check that the shopping cart displays the expected number of products
    }
}
