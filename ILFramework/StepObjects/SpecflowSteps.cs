using ILFramework.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ILFramework.StepObjects
{
    public class SpecflowSteps: Steps
    {
        public HomePageObjects _homepage = new HomePageObjects();
        public JobProfileSearchPage _jobProfileSearchPage = new JobProfileSearchPage();
        public SpecflowSteps()
        {
            PageFactory.InitElements(TestMethods.Driver, _homepage);
            PageFactory.InitElements(TestMethods.Driver, _jobProfileSearchPage);
        }

    }

}
