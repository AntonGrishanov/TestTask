using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestTask.Helpers;

namespace TestTask.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement UserNameInput => WaitAndFind(By.Id("login_user"));
        private IWebElement PasswordInput => WaitAndFind(By.Id("login_pass"));
        private IWebElement LoginButton => WaitAndFind(By.Id("login_button"));

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void EnterUserName(string username)
        {
            UserNameInput.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }
    }
}
