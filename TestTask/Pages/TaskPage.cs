using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TestTask.Helpers;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestTask.Pages
{
    public class TaskPage : BasePage
    {
        public TaskPage(IWebDriver driver) : base(driver) { }
        public string GetTaskName() => WaitAndFind(By.Id("_form_header")).Text;
        public string GetProjectName() => WaitAndFind(By.CssSelector("#DetailForm_parent_info a.tabDetailViewDFLink")).Text;
        public string GetStatus() => WaitAndFind(By.CssSelector("div.form-value .badge")).Text.ToLower();
        public string GetStartDate() => WaitAndFind(By.CssSelector("div.cell-date_start nobr.text-number")).Text;
        public string GetDueDate() => WaitAndFind(By.CssSelector("div.cell-date_due nobr.text-number")).Text;
    }
}