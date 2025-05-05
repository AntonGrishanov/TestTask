using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestTask.Helpers;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace TestTask.Pages
{
    public class CreateTaskPage : BasePage
    {
        private IWebElement NameInput => WaitAndFind(By.Id("DetailFormname-input"));
        private IWebElement ProjectInput => WaitAndFind(By.Id("DetailFormparent-input"));
        private IWebElement StatusInput => WaitAndFind(By.Id("DetailFormstatus-input-label"));
        private IWebElement StartDateInput => WaitAndFind(By.Id("DetailFormdate_start-input"));
        private IWebElement DueDateInput => WaitAndFind(By.Id("DetailFormdate_due-input"));
        private IWebElement SaveButton => WaitAndFind(By.Id("DetailForm_save"));
        private IWebElement ReturnButton => WaitAndFind(By.Id("DetailForm_return_list"));
        public string TaskName { get; private set; }
        public string ProjectName { get; private set; }
        public string Status { get; private set; }
        public string StartDate { get; private set; }
        public string DueDate { get; private set; }

        public CreateTaskPage(IWebDriver driver) : base(driver) { }

        public void EnterTaskName()
        {
            TaskName = "AutoTask_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            NameInput.SendKeys(TaskName);
        }

        public void GetStatus()
        {
            Status = StatusInput.Text.Trim().ToLower();
        }
        public void SelectProject()
        {
            ProjectInput.Click();
            WaitAndFind(By.CssSelector("div.active-icon.uii-extern.uii-lg.uii")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Находит первую ссылку на проект в таблице
            var projectLink = wait.Until(d =>
            {
                var link = d.FindElement(By.CssSelector("tr.listViewRow a.listViewNameLink"));
                return (link.Displayed && link.Enabled) ? link : null;
            });
            ProjectName = projectLink.Text;
            projectLink.Click();
        }
        public string EnterDate(IWebElement dropdown, string inputCssSelector, DateTime date)
        {
            dropdown.Click();

            var dateInput = WaitAndFind(By.CssSelector(inputCssSelector));
            string formattedDate = date.ToString("yyyy-MM-dd");

            dateInput.Clear();
            dateInput.SendKeys(formattedDate);

            var confirmButton = WaitAndFind(By.CssSelector("div.active-icon.uii-accept.uii-lg.uii"));
            confirmButton.Click();

            return formattedDate;
        }
        public void EnterStartDate()
        {
            StartDate = EnterDate(StartDateInput, "#DetailFormdate_start-calendar-text input.input-text", DateTime.Today);
        }
        public void EnterDueDate()
        {
            DueDate = EnterDate(DueDateInput, "#DetailFormdate_due-calendar-text input.input-text", DateTime.Today.AddMonths(1));
        }

        public void ClickSave()
        {
            SaveButton.Click();
        }

        public void ClickReturn()
        {
            ReturnButton.Click();
        }
    }
}