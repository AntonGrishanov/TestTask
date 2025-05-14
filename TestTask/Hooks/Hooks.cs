using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BoDi;
using TestTask.Drivers;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _container;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var driver = DriverFactory.CreateDriver();
        driver.Navigate().GoToUrl("https://demo.1crmcloud.com");
        driver.Manage().Window.Maximize();
        _container.RegisterInstanceAs(driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        var driver = _container.Resolve<IWebDriver>();
        driver.Quit();
    }
}