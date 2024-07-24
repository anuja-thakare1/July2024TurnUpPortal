using July2024TurnUpPortal.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace July2024TurnUpPortal.Pages
{
    public class HomePage
    {
      public void NavigateToTimeAndMaterialPage(IWebDriver driver) 
        {
            // Navigate to Time and Material Page

            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            Wait.WaitToBeClickable (driver,"XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a",10);

            IWebElement timeandMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeandMaterialOption.Click();

        }
    }
}
