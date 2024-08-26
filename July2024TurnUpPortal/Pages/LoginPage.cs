using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using July2024TurnUpPortal.Utilities;

namespace July2024TurnUpPortal.Pages
{
    public class LoginPage
    {
        //Functions that allows user to Login to TurnUp Portal
        public void LoginActions( IWebDriver driver)
        {
            // Open Chrome Browser
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--start-maximized");
            Thread.Sleep(1000);

           // IWebDriver driver = new ChromeDriver(options);

            //Launch TurnUp Portal

            driver.Navigate().GoToUrl("http://horse.industryconnect.io");

         
            //Identify User Name text box and enter valid username

            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys("hari");

            Wait.WaitToBeVisible(driver, "Id", "Password", 5);

            //Identify Password  text box and enter valid password

            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            //Identify LoginButton and and click on it
            IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            login.Click();

            Wait.WaitToBeClickable(driver,"XPath","//*[@id=\"loginForm\"]/form/div[3]/input[1]",5);
            //Thread.Sleep(2000);
            
        }
    }
}
