using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestTask.Configuration;
using TestTask.Models;
using TestTask.Pages;

namespace TestTask.StepDefinitions
{
    [Binding]
    public class CreateTask : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProjectManagementPage _projectPage;
        private readonly CreateTaskPage _createTaskPage;
        private readonly TaskPage _taskPage;

        TaskDataModel taskData = new TaskDataModel
        {
            TaskName = "AutoTask_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
        };

        public CreateTask(IWebDriver driver, LoginPage loginPage, ProjectManagementPage projectManagementPage, CreateTaskPage createTaskPage, TaskPage taskPage) : base(driver)
        {
            _driver = driver;
            _loginPage = loginPage;
            _projectPage = projectManagementPage;
            _createTaskPage = createTaskPage;
            _taskPage = taskPage;
        }

        [Given(@"I am logged into the system")]
        public void GivenIAmLoggedIn()
        {
            _loginPage.EnterUserName(TestConfiguration.Username);
            _loginPage.EnterPassword(TestConfiguration.Password);
            _loginPage.ClickLogin();
        }
        [Given(@"I've opened the Project Management tab")]
        public void IOpenedTheProjectManagementTab()
        {
            _projectPage.OpenProjectManagementTab();
        }
        [Given(@"I've opened My Opened Project tasks module")]
        public void IOpenedMyOpenedProjectTasksModule()
        {
            _projectPage.OpenProjectTasksPage();
        }
        [When(@"I click the Create button")]
        public void IClickTheCreateButton()
        {
            _projectPage.ClickCreateTask();
        }
        [When(@"I enter task name")]
        public void IEnterTaskName()
        {
            _createTaskPage.EnterTaskName(taskData.TaskName);
        }
        [When(@"I select start and due dates")]
        public void ISelectStartAndDueDates()
        {
            _createTaskPage.ClickStartDate();
            taskData.StartDate = EnterDate("#DetailFormdate_start-calendar-text input.input-text", DateTime.Today);
            _createTaskPage.ClickDueDate();
            taskData.DueDate = EnterDate("#DetailFormdate_due-calendar-text input.input-text", DateTime.Today.AddMonths(1));
        }
        [When(@"I select a project")]
        public void ISelectAProject()
        {
            _createTaskPage.ClickPojects();

            var iconProj = FindElement(By.CssSelector("div.active-icon.uii-extern.uii-lg.uii"));
            iconProj.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var projectLink = wait.Until(d =>
            {
                var link = d.FindElement(By.CssSelector("tr.listViewRow a.listViewNameLink"));
                return (link.Displayed && link.Enabled) ? link : null;
            });
            taskData.ProjectName = projectLink.Text;
            projectLink.Click();
        }
        [When(@"I leave the default status")]
        public void ILeaveTheDefaultStatus()
        {
            _createTaskPage.AssignStatus();
        }
        [When(@"I save the task")]
        public void ISaveTheTask()
        {
            _createTaskPage.ClickSave();
        }
        [When(@"I click Return to list button")]
        public void IClickReturnToList()
        {
            _createTaskPage.ClickReturn();
        }
        [When(@"I search for a task using search")]
        public void WhenISearchForATaskUsingSearch()
        {
            _projectPage.SearchForATask(taskData.TaskName);
            _projectPage.OpenFoundTask();
        }
        [Then(@"The task should be visible with correct name")]
        public void TaskShouldBeVisibleWithCorrectName()
        {
            Assert.That(_taskPage.GetTaskName(), Is.EqualTo(taskData.TaskName), "Task name mismatch");
        }
        [Then(@"Task should have correct project")]
        public void TaskShouldHaveCorrectProject()
        {
            Assert.That(_taskPage.GetProjectName(), Is.EqualTo(taskData.ProjectName), "Project name mismatch");
        }
        [Then(@"Task should have correct dates")]
        public void TaskShouldHaveCorrectDates()
        {
            Assert.That(_taskPage.GetStartDate(), Is.EqualTo(taskData.StartDate), "Start date mismatch");
            Assert.That(_taskPage.GetDueDate(), Is.EqualTo(taskData.DueDate), "Due date mismatch");
        }
        [Then(@"Task should have correct status")]
        public void TaskShouldHaveCorrectStatus()
        {
            Assert.That(_taskPage.GetStatus(), Is.EqualTo(_createTaskPage.TaskData.Status), "Status mismatch");
        }
    }
}