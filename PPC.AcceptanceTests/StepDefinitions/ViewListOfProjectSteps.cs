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
    class ViewListOfProjectSteps
    {
        IWebDriver driver;
        [Given(@"I have enter the homepage")]
        public void GivenIHaveEnterTheHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Home/Index");
        }

        [Given(@"I have click login")]
        public void GivenIHaveClickLogin()
        {
            driver.FindElement(By.Id("loginLink")).Click();
        }

        [When(@"I entered username and password")]
        public void WhenIEnteredUsernameAndPassword()
        {
            driver.FindElement(By.Id("Email")).SendKeys("lythihuyenchau@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
        }

        [When(@"click submit")]
        public void WhenClickSubmit()
        {
            driver.FindElement(By.ClassName("login-btn")).Click();
        }

        [Then(@"the result should show the list of project on the screen '(.*)'")]
        public void ThenTheResultShouldShowTheListOfProjectOnTheScreen(string p0)
        {
            var expectedPropertyName = p0.Split(',').Select(t => t.Trim().Trim('\''));
            driver.SwitchTo().DefaultContent();

            string descriptionTextPath = "//table/tbody/tr";
            var listProperty = from row in driver.FindElements(By.XPath(descriptionTextPath))
                               let nameProperty = row.FindElement(By.Id("pName")).Text
                               select new PROPERTY { PropertyName = nameProperty };
            PropertyAssertions.FoundPropertyName(listProperty, expectedPropertyName);
        }

    }
}
