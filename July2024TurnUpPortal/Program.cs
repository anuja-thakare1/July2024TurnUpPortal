using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

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
          // Create Time and Material Record

         // Navigate to Time and Material Page

            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();

        IWebElement timeandMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeandMaterialOption.Click();

        // Click on Create New Button 
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        // Select Time from dropdown 
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.Click();

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\'TypeCode_listbox\']/li[2]"));
              timeOption.Click();

        // Type Code into Text Box
        IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
        codeTextBox.SendKeys("July2024TurnUpPortal");

        // Type Desciption into Discription Text box
        IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
        descriptionTextBox.SendKeys("This is a discription");

        // Type  Price into price Textbox
        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();

        IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
        priceTextBox.SendKeys("12");
                // Click on Save button 
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();

        Thread.Sleep(2000);

        // Check if the Time record has been created successfully  
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text== "July2024TurnUpPortal")
        {
            Console.WriteLine("Time Record created successfully");

        }
        else
        {
            Console.WriteLine("New Time record has not created");        } 
    }
}