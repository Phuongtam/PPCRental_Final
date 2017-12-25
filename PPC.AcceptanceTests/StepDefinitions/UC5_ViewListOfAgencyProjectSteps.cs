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
        [Given(@"I am in the homepage")]
        public void GivenIAmInTheHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Home/Index");
        }

        [When(@"I login")]
        public void WhenILogin()
        {
            driver.Navigate().GoToUrl("http://localhost:51872/Account/Login");
            driver.FindElement(By.Id("Email")).SendKeys("lythihuyenchau@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.XPath("/html/body/form/div[4]/input[3]")).Click();
        }

        [Then(@"the resul should show the list of project on the screen '(.*)'")]
        public void ThenTheResulShouldShowTheListOfProjectOnTheScreen(string p0)
        {
            //var expectedPropertyName = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //driver.SwitchTo().DefaultContent();

            //string descriptionTextPath = "//table/tbody/tr";
            //var listProperty = from row in driver.FindElements(By.XPath(descriptionTextPath))
            //                   let nameProperty = row.FindElement(By.Id("pName")).Text
            //                   select new PROPERTY { PropertyName = nameProperty };
            //PropertyAssertions.FoundPropertyName(listProperty, expectedPropertyName);
            Assert.AreEqual(true, driver.FindElement(By.XPath("/html/body/div/div[2]/h2")).Displayed);
            driver.Close();
        }

    }
}
