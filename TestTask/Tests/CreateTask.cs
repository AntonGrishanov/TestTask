using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using System;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestTask.Configuration;
using TestTask.Drivers;
using TestTask.Pages;

namespace TestTask.StepDefinitions
{
    [Binding]
    public class CreateTask
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly ProjectManagementPage projectPage;
        private readonly CreateTaskPage createTaskPage;
        private readonly TaskPage taskPage;

        public CreateTask(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            projectPage = new ProjectManagementPage(driver);
            createTaskPage = new CreateTaskPage(driver);
            taskPage = new TaskPage(driver);
        }

        [Given(@"I am logged into the system")]
        public void GivenIAmLoggedIn()
        {
            loginPage.EnterUserName(TestConfiguration.Username);
            loginPage.EnterPassword(TestConfiguration.Password);
            loginPage.ClickLogin();
        }

        [Given(@"I opened the Project Management tab")]
        public void IOpenedTheProjectManagementTab()
        {
            projectPage.OpenProjectManagementTab();
        }
        [Given(@"I opened My Opened Project tasks module")]
        public void IOpenedMyOpenedProjectTasksModule()
        {
            projectPage.OpenProjectTasksPage();
        }
        [When(@"I click the Create button")]
        public void IClickTheCreateButton()
        {
            projectPage.ClickCreateTask();
        }
        [When(@"I enter task name")]
        public void IEnterTaskName()
        {
            createTaskPage.EnterTaskName();
        }
        [When(@"I select start and due dates")]
        public void ISelectStartAndDueDates()
        {
            createTaskPage.EnterStartDate();
            createTaskPage.EnterDueDate();
        }
        [When(@"I select a project")]
        public void ISelectAProject()
        {
            createTaskPage.SelectProject();
        }
        [When(@"I leave the default status")]
        public void ILeaveTheDefaultStatus()
        {
            createTaskPage.GetStatus();
        }
        [When(@"I save the task")]
        public void ISaveTheTask()
        {
            createTaskPage.ClickSave();
        }
        [When(@"I click Return to list button")]
        public void IClickReturnToList()
        {
            createTaskPage.ClickReturn();
        }
        [Then(@"I should be able to find task using search")]
        public void IShouldBeAbleToFindTaskUsingSearch()
        {
            projectPage.SearchForATask(createTaskPage.TaskName);
            projectPage.OpenFoundTask();
        }
        [Then(@"The task should be visible with correct name")]
        public void TaskShouldBeVisibleWithCorrectName()
        {
            Assert.That(taskPage.GetTaskName(), Is.EqualTo(createTaskPage.TaskName), "Task name mismatch");
        }
        [Then(@"Task should have correct project")]
        public void TaskShouldHaveCorrectProject()
        {
            Assert.That(taskPage.GetProjectName(), Is.EqualTo(createTaskPage.ProjectName), "Project name mismatch");
        }
        [Then(@"Task should have correct dates")]
        public void TaskShouldHaveCorrectDates()
        {
            Assert.That(taskPage.GetStartDate(), Is.EqualTo(createTaskPage.StartDate), "Start date mismatch");
            Assert.That(taskPage.GetDueDate(), Is.EqualTo(createTaskPage.DueDate), "Due date mismatch");
        }
        [Then(@"Task should have correct status")]
        public void TaskShouldHaveCorrectStatus()
        {
            Assert.That(taskPage.GetStatus(), Is.EqualTo(createTaskPage.Status), "Status mismatch");
        }
    }
}