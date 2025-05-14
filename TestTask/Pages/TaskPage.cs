using OpenQA.Selenium;

namespace TestTask.Pages
{
    public class TaskPage : BasePage
    {
        private IWebElement TaskName => FindElement(By.Id("_form_header"));
        private IWebElement ProjectName => FindElement(By.CssSelector("#DetailForm_parent_info a.tabDetailViewDFLink"));
        private IWebElement Status => FindElement(By.CssSelector("div.form-value .badge"));
        private IWebElement StartDate => FindElement(By.CssSelector("div.cell-date_start nobr.text-number"));
        private IWebElement DueDate => FindElement(By.CssSelector("div.cell-date_due nobr.text-number"));

        public string GetTaskName() => TaskName.Text;
        public string GetProjectName() => ProjectName.Text;
        public string GetStatus() => Status.Text.ToLower();
        public string GetStartDate() => StartDate.Text;
        public string GetDueDate() => DueDate.Text;

        public TaskPage(IWebDriver driver) : base(driver) { }
    }
}