using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPC.Models;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class UC5_ViewListOfAgencyProjectSteps
    {
        IWebDriver driver;
        [Given(@"I have enter the adminpage")]
        public void GivenIHaveEnterTheAdminpage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Admin/ProjectAdmin/Index");
        }

        [Then(@"the resul should show the list of project on the screen '(.*)'")]
        public void ThenTheResulShouldShowTheListOfProjectOnTheScreen(string p0)
        {
            var expectedPropertyName = p0.Split(',').Select(t => t.Trim().Trim('\''));
            driver.SwitchTo().DefaultContent();

            string descriptionTextPath = "//table/tbody/tr";
            var listProperty = from row in driver.FindElements(By.XPath(descriptionTextPath))
                               let nameProperty = row.FindElement(By.Id("pName")).Text
                               select new PROPERTY { PropertyName = nameProperty };
            PropertyAssertions.FoundPropertyName(listProperty, expectedPropertyName);
            driver.Close();
        }

    }
}
