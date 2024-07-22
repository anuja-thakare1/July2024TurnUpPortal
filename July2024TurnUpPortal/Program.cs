using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

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

        Thread.Sleep(2000);

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\'TypeCode_listbox\']/li[2]"));
        timeOption.Click();

        // Type Code into Text Box
        IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
        codeTextBox.SendKeys("Anuja_Code");

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

        if (newCode.Text == "Anuja_Code")
        {
            Console.WriteLine("Time Record created successfully");

        }
        else
        {
            Console.WriteLine("New Time record has not created");
        }


        // Click On Edit Button 
        IWebElement clickOnEditButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        clickOnEditButton.Click();


        // Clear and Edit Desciption into Discription Text box
        IWebElement editedDescriptionTextBox = driver.FindElement(By.Id("Description"));
        editedDescriptionTextBox.Clear();
        editedDescriptionTextBox.SendKeys("Edited by Anuja");

        Thread.Sleep(2000);

        // Edit Price into Price Text box

        IWebElement editPriceTagOverlap = driver.FindElement(By.XPath("//*[@id=\'TimeMaterialEditForm\']/div/div[4]/div/span[1]/span/input[1]"));
        editPriceTagOverlap.Clear();


        IWebElement editPriceTextBox = driver.FindElement(By.XPath("//*[@id=\'Price\']"));
        editPriceTextBox.SendKeys("88.88");

        // Click on Save button 

        IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
        saveButton1.Click();


        Thread.Sleep(2000);

        // Check if the Time record has been edited successfully  
        IWebElement goToLastPageEditButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]"));
        goToLastPageEditButton.Click();

        IWebElement newCode1 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode1.Text == "Anuja_Code")
        {
            Console.WriteLine("Time Record edited successfully");

        }
        else
        {
            Console.WriteLine("New Time record has not edited");
        }

        //Click on Delete Button

        Thread.Sleep(5000);
        IWebElement goToLastPageEditButton1 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]"));
        goToLastPageEditButton.Click();
        Thread.Sleep(5000);

        IWebElement newCode2 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));
        newCode2.Click();
        Thread.Sleep(3000);

        IWebElement goToLastPageDeleteButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        goToLastPageDeleteButton.Click();
        Thread.Sleep(5000);

        driver.SwitchTo().Alert().Accept();
        Thread.Sleep(5000);

        driver.Navigate().Refresh();

        // Check if the  record has been deleted successfully  
        IWebElement goToLastPageDeleteButton2 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]"));
        goToLastPageDeleteButton2.Click();

        IWebElement newCode3= driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));

           if (newCode3.Text == "Anuja_Code")
        {
            Console.WriteLine("Time Record has not been Deleted ");

        }
           else
        {
            Console.WriteLine("Time Record has been Deleted successfully");
        }


    }
}
