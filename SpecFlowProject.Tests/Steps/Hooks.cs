using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BoDi; // Add this line for the 'Task' class

[Binding]
public class Hooks
{
    private readonly IObjectContainer _container;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void Initialize()
    {
        _container.RegisterInstanceAs<IWebDriver>(new ChromeDriver());
        _container.RegisterInstanceAs<HttpClient>(new HttpClient());
    }
}
