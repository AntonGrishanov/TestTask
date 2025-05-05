using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestTask.Configuration;

namespace TestTask.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            if (TestConfiguration.Browser.ToLower() == "chrome")
            {
                var options = new ChromeOptions();
                // options.AddArgument("--headless");
                return new ChromeDriver(options);
            }

            throw new NotSupportedException($"Browser {TestConfiguration.Browser} not supported");
        }
    }
}