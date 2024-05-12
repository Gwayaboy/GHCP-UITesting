using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; 

[Binding]
public class ShoppingCartSteps
{
    private IWebDriver driver;

    [BeforeScenario]
    public void Setup()
    {
        // Set up Chrome driver
        driver = new ChromeDriver();
    }

    [AfterScenario]
    public void TearDown()
    {
        // Quit Chrome driver
        driver.Quit();
    }

    [Given(@"I am on the Xbox controller list page")]
    public void GivenIAmOnTheXboxControllerListPage()
    {
        
    }

    [When(@"I add the ""(.*)"" to my cart")]
    public void WhenIAddTheToMyCart(string productName)
    {
        
    }

    [Then(@"the cart should contain the ""(.*)""")]
    public void ThenTheCartShouldContainThe(string productName)
    {
        
               
    }
}