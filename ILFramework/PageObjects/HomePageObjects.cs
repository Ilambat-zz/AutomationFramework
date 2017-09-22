using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILFramework.PageObjects
{
    public class HomePageObjects
    {
        public HomePageObjects()
        {

        }

        [FindsBy(How = How.Id, Using = "site-header")]
        public IWebElement Header { get; set; }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.ClassName, Using = "submit")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.ClassName, Using = "lede")]
        public IWebElement text { get; set; }
    }
}
