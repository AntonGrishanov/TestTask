using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace TestTask.Helpers
{
    public class Waiter
    {
        private readonly IWebDriver _driver;

        public Waiter(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement FindElement(By by, TimeSpan? timeout = null)
        {
            timeout ??= TimeSpan.FromSeconds(10);
            var wait = new WebDriverWait(_driver, timeout.Value);
            try
            {
                IWebElement element = wait.Until(driver => driver.FindElement(by));

                if(!element.Displayed || !element.Enabled)
                {
                    throw new ElementNotInteractableException($"Element {by} not available for interaction.");
                }

                return element;
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"Element {by} not found or not visible.");
            }
        }

        public void JsClickElement(string url, By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains(url));
            var element = FindElement(locator);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}