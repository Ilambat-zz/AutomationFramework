using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILFramework.PageObjects
{
    public class JobProfileSearchPage
    {

        [FindsBy(How = How.ClassName, Using = "result-count")]
        public IWebElement SearchCountText { get; set; }

        [FindsBy(How = How.ClassName, Using = "dfc-code-search-next")]
        public IWebElement HasNextPage { get; set; }

    }
}
