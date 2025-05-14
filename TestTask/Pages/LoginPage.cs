using OpenQA.Selenium;

namespace TestTask.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement UserNameInput => FindElement(By.Id("login_user"));
        private IWebElement PasswordInput => FindElement(By.Id("login_pass"));
        private IWebElement LoginButton => FindElement(By.Id("login_button"));

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
