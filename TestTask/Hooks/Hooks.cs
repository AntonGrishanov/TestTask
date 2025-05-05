using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using OpenQA.Selenium;
using TestTask.Drivers; // или твой путь
using BoDi;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _container;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var client = new HttpClient();
        var payload = new
        {
            username = "admin",
            password = "admin",
            captcha = "",
            remember = "",
            gmto = -60,
            in_frame = false,
            language = "en_us",
            login_action = "",
            login_layout = "",
            login_module = "",
            login_record = "",
            mobile = "0",
            new_ui = "",
            res_height = 1066,
            res_width = 1514,
            theme = "Flex"
        };

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://demo.1crmcloud.com/json.php?action=login", content);
        response.EnsureSuccessStatusCode();

        var cookies = response.Headers.TryGetValues("Set-Cookie", out var cookieHeaders) ? cookieHeaders : null;

        var driver = DriverFactory.CreateDriver();
        driver.Navigate().GoToUrl("https://demo.1crmcloud.com"); // обязательная первая навигация

        if (cookies != null)
        {
            foreach (var rawCookie in cookies)
            {
                var cookieParts = rawCookie.Split(';')[0].Split('=');
                var name = cookieParts[0];
                var value = cookieParts.Length > 1 ? cookieParts[1] : "";

                var seleniumCookie = new Cookie(name.Trim(), value.Trim(), ".1crmcloud.com", "/", null);
                driver.Manage().Cookies.AddCookie(seleniumCookie);
            }
        }

        driver.Navigate().Refresh(); // обновить страницу, чтобы cookies применились
        _container.RegisterInstanceAs<IWebDriver>(driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        var driver = _container.Resolve<IWebDriver>();
        driver.Quit();
    }
}