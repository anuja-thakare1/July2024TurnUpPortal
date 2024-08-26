using July2024TurnUpPortal.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace July2024TurnUpPortal
{
    public class Program
    {
        public static void Main()
        {
            // Open Chrome Browser
            ChromeOptions options = new ChromeOptions();

            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--start-maximized");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            Thread.Sleep(1000);

            IWebDriver driver = new ChromeDriver(options);


            //Login page initialization and defination 
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page initialization and defination 
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTimeAndMaterialPage(driver);

            //Time and Material Page Initialization and defination 
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage();
            timeAndMaterialPageObj.CreateTimeRecord(driver);

            timeAndMaterialPageObj.EditTimeRecord(driver);
            timeAndMaterialPageObj.DeleteTimeRecord(driver);
            driver.Quit();
        }
    }
}
