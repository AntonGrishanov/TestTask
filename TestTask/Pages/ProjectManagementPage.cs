﻿using OpenQA.Selenium;

namespace TestTask.Pages
{
    public class ProjectManagementPage : BasePage
    {
        private IWebElement ProjectManagementTab => FindElement(By.Id("grouptab-3"));
        private IWebElement GoToModuleButton => FindElement(By.CssSelector("a[href=\"index.php?module=ProjectTask&action=index\"].tool-icon"));
        private IWebElement SearchInput => FindElement(By.Id("filter_text"));
        private IWebElement СreateButton => FindElement(By.Name("SubPanel_create"));

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
            JsClickElement("module=ProjectTask&action=index", By.Name("SubPanel_create"));
        }

        public void SearchForATask(string taskName)
        {
            SearchInput.SendKeys(taskName);
            actions.SendKeys(Keys.Enter).Perform();
        }

        public void OpenFoundTask()
        {
            JsClickElement("module=ProjectTask&action=index&layout=Browse&list_limit", By.CssSelector("a.listViewNameLink"));
        }
    }
}
