using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        // Open Chrome Browser
        ChromeOptions options = new ChromeOptions();
        options.AddExcludedArgument("enable-automation");
        options.AddArgument("--start-maximized");

        IWebDriver driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("http://horse.industryconnect.io");

        IWebElement userName = driver.FindElement(By.Id("UserName"));
        userName.SendKeys("hari");

        IWebElement password = driver.FindElement(By.Id("Password"));
        password.SendKeys("123123");

        IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        login.Click();

        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("Login Successfully.");
        }
        else
        {
            Console.WriteLine("Login Failed.");
        }
    }
}