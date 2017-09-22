using ILFramework.StepObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;



namespace ILFramework.StepObjects
{
    [Binding]
    public class JobProfileSearchSteps : SpecflowSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Then(@"the last result is shown on the page")]
        public void ThenTheLastResultIsShownOnThePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"there should be (.*) results")]
        public void ThenThereShouldBeResults(string noOfResults)
        {
            string text = TestMethods.GetElementText(_jobProfileSearchPage.SearchCountText);
            string result = Regex.Match(text, @"\d+").ToString();

            Assert.AreEqual(noOfResults, result);
        }

        [Then(@"the Next pagination control is '(.*)'")]
        public void ThenTheNextPaginationControlIsNotShown(string shownFlag)
        {
            if (shownFlag.Contains("not"))
            {
                Assert.That(TestMethods.ElementExists(_jobProfileSearchPage.HasNextPage), Is.False);
            }
            else
            {
                Assert.That(TestMethods.ElementExists(_jobProfileSearchPage.HasNextPage), Is.True);
            }
        }

        [Then(@"the correct text '(.*)' is displayed")]
        public void ThenTheCorrectTextIsDisplayed(string text)
        {
            Assert.AreEqual(text, _jobProfileSearchPage.SearchCountText.Text);
        }


    }
}
