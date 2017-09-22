using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ILFramework
{
    public class TestMethods
    {

        public static IWebDriver Driver { get; set; }
        public static IWebElement element;

        public static IWebElement FindElementByID(string Id)
        {
            element = Driver.FindElement(By.Id(Id));
            return element;
        }

        public static IWebElement FindElementByClassName(string className)
        {
            element = Driver.FindElement(By.ClassName(className));
            return element;
        }

        public static IWebElement FindElementByCssSelector(string CssSelector)
        {
            element = Driver.FindElement(By.CssSelector(CssSelector));
            return element;
        }

        public static IEnumerable<IWebElement> FindElementsByClassName(string ClassName)
        {
            IEnumerable<IWebElement> element = Driver.FindElements(By.ClassName(ClassName));
            return element;
        }

        public static IEnumerable<IWebElement> FindElementsByCssSelector(string CssSelector)
        {
            IEnumerable<IWebElement> element = Driver.FindElements(By.CssSelector(CssSelector));
            return element;
        }

        public static void ClickLink(IWebElement link)
        {
            link.Click();
        }
        public static void ClickLink(By locator)
        {
            element = Driver.FindElement(locator);
            element.Click();
        }

        public static void WaitForElementToLoad(IWebElement element)
        {
            var wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public static bool ElementExists(By locator)
        {
            try
            {
                element.FindElement(locator);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool ElementExists(IWebElement locator)
        {
            try
            {
                bool exists = locator.Displayed;
                return exists;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SendValueToField(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static bool IsDisplayed(IWebElement locator)
        {
            try
            {
                bool x = locator.Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetBrowserURL()
        {
            string url = Driver.Url;

            return url;
        }

        public static string GetBrowserTitle()
        {
            string title = Driver.Title;
            return title;
        }

        public static void SwitchTabs(int tab)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[tab]);
        }

        public static string GetElementText(IWebElement element)
        {
            return element.GetAttribute("innerText");
        }

    }

}
