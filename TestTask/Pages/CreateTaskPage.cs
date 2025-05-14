using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestTask.Models;

namespace TestTask.Pages
{
    public class CreateTaskPage : BasePage
    {
        private IWebElement NameInput => FindElement(By.Id("DetailFormname-input"));
        private IWebElement ProjectInput => FindElement(By.Id("DetailFormparent-input"));
        private IWebElement StatusInput => FindElement(By.Id("DetailFormstatus-input-label"));
        private IWebElement StartDateInput => FindElement(By.Id("DetailFormdate_start-input"));
        private IWebElement DueDateInput => FindElement(By.Id("DetailFormdate_due-input"));
        private IWebElement SaveButton => FindElement(By.Id("DetailForm_save"));
        private IWebElement ReturnButton => FindElement(By.Id("DetailForm_return_list"));
        public TaskDataModel TaskData { get; private set; } = new TaskDataModel();
        public CreateTaskPage(IWebDriver driver) : base(driver) { }

        public void EnterTaskName(string taskName) => NameInput.SendKeys(taskName);
        public void AssignStatus()
        {
            TaskData.Status = StatusInput.Text.Trim().ToLower();
        }
        public void ClickPojects() => ProjectInput.Click();
        public void ClickStartDate() => StartDateInput.Click();
        public void ClickDueDate() => DueDateInput.Click();

        public void ClickSave() => SaveButton.Click();

        public void ClickReturn() => ReturnButton.Click();
    }
}