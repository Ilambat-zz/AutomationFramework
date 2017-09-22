using ILFramework.StepObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ILFramework
{
    [Binding]
    public class HomepageSteps : SpecflowSteps
    {
        public HomepageSteps()
        { }

        #region Given Steps
        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            TestMethods.ElementExists(_homepage.Header);
        }
        #endregion

        #region When Steps

        [When(@"I search for (.*)")]
        public void WhenISearchFor(string term)
        {
            TestMethods.SendValueToField(_homepage.SearchField, term);
            TestMethods.ClickLink(_homepage.Submit);
        }
        #endregion

        #region Thens
        [Then(@"the user is redirected to the search page")]
        public void ThenTheUserRemainsOnTheHomepage()
        {
            Assert.IsTrue(TestMethods.ElementExists(_jobProfileSearchPage.SearchCountText));
        }

        [Then(@"the search box is displayed")]
        public void ThenTheSearchBoxIsDisplayed()
        {
            TestMethods.ElementExists(_homepage.SearchField);
        }
        #endregion
    }
}



//[When(@"I select the (.*) link")]
//public void WhenISelectTheLink(string link)
//{
//    var x = new Dictionary<string, Action>
//    {

//    };

//    if (x.ContainsKey(link))
//    {
//        x[link].Invoke();
//    }
//}
