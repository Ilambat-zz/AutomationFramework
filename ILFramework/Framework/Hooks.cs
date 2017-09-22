using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Configuration;
using ILFramework.Framework;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace ILFramework
{
    [Binding]
    public class Hooks
    {

        public static string environment = ConfigurationManager.AppSettings["BaseUrl"];
        [BeforeScenario]
        public static void BeforeScenario()
        {

            TestMethods.Driver = InstantiateDriver(ConfigurationManager.AppSettings["Browser"]);
            // TestMethods.Driver.Manage().Window.Maximize();
            TestMethods.Driver.Navigate().GoToUrl(environment);

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TestSettings.Driver.Dispose();
            if (environment.Equals("browserstack"))
                BrowserStackService.CheckTestFailing((RemoteWebDriver)TestMethods.Driver);
            Thread.Sleep(3000);

            TestMethods.Driver.Close();
            TestMethods.Driver.Quit();
        }

        private static IWebDriver InstantiateDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    TestMethods.Driver = new ChromeDriver(@"C:/");
                    break;
                case "browserstack":
                    InitBrowserStackInstance();
                    break;
            }
            return TestMethods.Driver;
        }

        public static void InitBrowserStackInstance()
        {
            TestMethods.Driver = BrowserStackService.Init();
            TestMethods.Driver.Manage().Cookies.DeleteAllCookies();
            TestMethods.Driver.Manage().Window.Maximize();
        }

    }


}
