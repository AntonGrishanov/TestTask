using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TestTask.Helpers;

namespace TestTask.Pages
{
    public class ProjectManagementPage : BasePage
    {
        private IWebElement ProjectManagementTab => WaitAndFind(By.Id("grouptab-3"));
        private IWebElement GoToModuleButton => WaitAndFind(By.CssSelector("a[href=\"index.php?module=ProjectTask&action=index\"].tool-icon"));
        private IWebElement SearchInput => WaitAndFind(By.Id("filter_text"));
        private IWebElement СreateButton => WaitAndFind(By.Name("SubPanel_create"));

        public ProjectManagementPage(IWebDriver driver) : base(driver) { }

        public void OpenProjectManagementTab()
        {
            ProjectManagementTab.Click();
        }

        public void OpenProjectTasksPage()
        {
            GoToModuleButton.Click();
        }

        public void ClickCreateTask()
        {
            waiter.JsClickElement("module=ProjectTask&action=index", By.Name("SubPanel_create"));
        }

        public void SearchForATask(string taskName)
        {
            ProjectManagementTab.Click();
            GoToModuleButton.Click();
            SearchInput.SendKeys(taskName);
            actions.SendKeys(Keys.Enter).Perform();
        }

        public void OpenFoundTask()
        {
            waiter.JsClickElement("module=ProjectTask&action=index&layout=Browse&list_limit", By.CssSelector("a.listViewNameLink"));
        }
    }
}
