using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestTask.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly Actions actions;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        protected IWebElement FindElement(By by, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                IWebElement element = wait.Until(driver => driver.FindElement(by));

                if (!element.Displayed || !element.Enabled)
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
        protected void JsClickElement(string url, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains(url));
            var element = FindElement(locator);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        protected string EnterDate(string inputCssSelector, DateTime date)
        {
            //dropdown.Click();

            var dateInput = FindElement(By.CssSelector(inputCssSelector));
            string formattedDate = date.ToString("yyyy-MM-dd");

            dateInput.Clear();
            dateInput.SendKeys(formattedDate);

            var confirmButton = FindElement(By.CssSelector("div.active-icon.uii-accept.uii-lg.uii"));
            confirmButton.Click();

            return formattedDate;
        }
    }
}