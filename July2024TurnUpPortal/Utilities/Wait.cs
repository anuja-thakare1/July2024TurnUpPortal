using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace July2024TurnUpPortal.Utilities
{
    public class Wait
    {
        //Generic function to wait for an Element to be Clickable 
        public static void WaitToBeClickable(IWebDriver driver,string locaterType, string locaterValue,int Seconds )
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0,Seconds));

            if (locaterType == "Xpath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locaterValue)));
            }
            if (locaterType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locaterValue)));
            }

       
        }
        public static void WaitToBeVisible(IWebDriver driver, String locaterType, String locaterValue, int Seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
            if (locaterType == "Xpath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locaterValue)));
            }
            if (locaterType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locaterValue)));
            }
        }
    }
}
