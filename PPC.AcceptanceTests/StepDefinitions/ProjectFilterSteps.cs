using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PPC.Models;
using System.Linq;
using PPC.AcceptanceTests.Drivers;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    public class ProjectFilterSteps
    {
     
        private readonly SearchDriver _searchDriver;
        public ProjectFilterSteps(SearchDriver driver)
        {
            _searchDriver = driver;
        }


      
        [When(@"I search for projects by the phrase '(.*)','(.*)','(.*)'")]
        public void WhenISearchForProjectsByThePhrase(string p0, int p1, int p2)
        {

            _searchDriver.Search(p0,p1,p2);
        }

        [Then(@"project should display project with projectname follow '(.*)'")]
        public void ThenProjectShouldDisplayProjectWithProjectnameFollow(string expectedTitles)
        {
            _searchDriver.ShowProperty(expectedTitles);
        }

        


    }
}
