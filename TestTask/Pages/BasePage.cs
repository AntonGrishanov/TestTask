using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TestTask.Helpers;

namespace TestTask.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly Waiter waiter;
        protected readonly Actions actions;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            waiter = new Waiter(driver);
            actions = new Actions(driver);
        }

        protected IWebElement WaitAndFind(By by)
        {
            return waiter.FindElement(by);
        }
    }
}