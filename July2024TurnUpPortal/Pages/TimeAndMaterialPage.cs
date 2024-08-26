using July2024TurnUpPortal.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace July2024TurnUpPortal.Pages
{
    public class TimeAndMaterialPage
    {
        public void CreateTimeRecord(IWebDriver driver )
        {
            // Click on Create New Button 
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            
             Wait.WaitToBeClickable(driver,"XPath","//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span",6);

            // Select Time from dropdown 
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\'TypeCode_listbox\']/li[2]"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\'TypeCode_listbox\']/li[2]", 6);
            timeOption.Click();

            // Type Code into Text Box
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("Anuja_Code");

            // Type Desciption into Discription Text box
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("This is a discription");

            //Type Price into price Textbox
           IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("12");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton",5);

            // Click on Save button 
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[1]", 6);

            // Check if the Time record has been created successfully  
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span",6);
            goToLastPageButton.Click();

            Thread.Sleep(1000);
            
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "Anuja_Code")
            {
                Console.WriteLine("Time Record created successfully");

            }
            else
            {
                Console.WriteLine("New Time record has not created");
            }


        }

        public void EditTimeRecord(IWebDriver driver) 
        {
            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[1]", 6);

            // Check if the Time record has been created successfully  
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 6);
            goToLastPageButton.Click();

            Thread.Sleep(2000);

            // Click On Edit Button 
            IWebElement clickOnEditButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            clickOnEditButton.Click();


            // Clear and Edit Desciption into Discription Text box
            IWebElement editedDescriptionTextBox = driver.FindElement(By.Id("Description"));
            editedDescriptionTextBox.Clear();
            editedDescriptionTextBox.SendKeys("Edited by Anuja");

            
             //Thread.Sleep(2000);

            // Edit Price into Price Text box

            IWebElement editPriceTagOverlap = driver.FindElement(By.XPath("//*[@id=\'TimeMaterialEditForm\']/div/div[4]/div/span[1]/span/input[1]"));
            editPriceTagOverlap.Click();


            IWebElement editPriceTextBox = driver.FindElement(By.XPath("//*[@id=\'Price\']"));
            editPriceTextBox.Clear();

            editPriceTagOverlap.Click();
            editPriceTextBox.SendKeys("88.88");

            // Click on Save button 

            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();
            

            Thread.Sleep(1000);

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

        }

        public void DeleteTimeRecord(IWebDriver driver) 
        {
            //Click on Delete Button
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\'tmsGrid\']/div[4]/a[4]", 5);
;            //Thread.Sleep(5000);
            IWebElement goToLastPageEditButton1 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]"));
            goToLastPageEditButton1.Click();


            //Thread.Sleep(5000);
            Wait.WaitToBeClickable(driver, "XPath","//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]", 5);
            IWebElement newCode2 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));
            newCode2.Click();
            //Thread.Sleep(3000);

            IWebElement goToLastPageDeleteButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);
            goToLastPageDeleteButton.Click();
            //Thread.Sleep(3000);

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            driver.Navigate().Refresh();

            // Check if the  record has been deleted successfully  
            IWebElement goToLastPageDeleteButton2 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\'tmsGrid\']/div[4]/a[4]", 5);
            goToLastPageDeleteButton2.Click();
            Thread.Sleep(1000);

            IWebElement newCode3 = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[3]/table/tbody/tr[last()]/td[1]"));

            //if (newCode3.Text == "Anuja_Code")
            //{
            //    Console.WriteLine("Time Record has not been Deleted ");

            //}
            //else
            //{
            //    Console.WriteLine("Time Record has been Deleted successfully");
            //}

        }

    }

}
