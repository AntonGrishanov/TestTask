/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestTask.Configuration;
using TestTask.Pages;

namespace TestTask
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.1crmcloud.com/");

            var LoginPage = new LoginPage(driver);
            LoginPage.Login(TestConfiguration.Username, TestConfiguration.Password);
        }

        [Test]
        public void Test1()
        {
            var ProjectManagementPage = new ProjectManagementPage(driver);
            ProjectManagementPage.OpenCreateTaskPage();

            var CreateTaskPage = new CreateTaskPage(driver);
            CreateTaskPage.EnterTaskData();
            CreateTaskPage.ClickSave();
            ProjectManagementPage.OpenCreatedTask(CreateTaskPage.TaskName); 

            var TaskPage = new TaskPage(driver);

            Assert.That(CreateTaskPage.Status, Is.EqualTo(TaskPage.GetStatus()), "Task status does not match");
            Assert.That(CreateTaskPage.TaskName, Is.EqualTo(TaskPage.GetTaskName()), "Task name does not match");
            Assert.That(CreateTaskPage.ProjectName, Is.EqualTo(TaskPage.GetProjectName()), "Project name does not match");
            Assert.That(CreateTaskPage.StartDate, Is.EqualTo(TaskPage.GetStartDate()), "Task start date does not match");
            Assert.That(CreateTaskPage.DueDate, Is.EqualTo(TaskPage.GetDueDate()), "Task due date does not match");

            Thread.Sleep(5000);

        }
        [TearDown] 
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
*/