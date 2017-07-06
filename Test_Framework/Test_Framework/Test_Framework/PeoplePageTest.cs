using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports;

namespace Test_Framework
{   
    [TestFixture]
    public class PeoplePageTest : BaseTest
    {  
           
        public IWebDriver Driver { get; set; } 
                
        [SetUp] 
        public void Pretest()
        {
            Driver = new FirefoxDriver();
            Driver.Url = "https://octopusinvestments.com/adviser/about-us/our-people";
            var peoplePage = new PeoplePage(Driver);
            string currentHandle = Driver.CurrentWindowHandle;
            peoplePage.HandleDialog();
            Driver.SwitchTo().DefaultContent();
            peoplePage.ScrollpageDown();

        }        

        [Test]
        //verify search by text works
        public void SearchText()
        {
            var test = extent.CreateTest("Search Test started");
            try
            {
                PeoplePage peoplePage = new PeoplePage(Driver);                
                peoplePage.SearchText("Tom");
                var txt = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt, "Tom Robinson");
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                takeScreenShot("Search Error screenshot", Driver);
                test.Fail("Assertion Failed");
                throw;
            }            
           
        }

        //Verify search by text and team works
        [Test]
        public void SearchTextAndTeamTest()
        {
            var test = extent.CreateTest("Search Text and Team test started");
            try
            {
                PeoplePage peoplePage = new PeoplePage(Driver);
                peoplePage.SearchTextandTeam("Tom", 0);
                var txt1 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt1, "Tom Wood");
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                takeScreenShot("Search text and team Error screenshot", Driver);
                test.Fail("Assertion Failed");
                throw;
            }
        } 
        
        //Verify Accending and descending order works on default page
        [Test]
        public void SortOrderOnDefaultPage()
        {
            var test = extent.CreateTest("Sort order on default test started");
            try
            {
                PeoplePage peoplePage = new PeoplePage(Driver);
                peoplePage.SelectSortOrder("Z-A");
                var txt2 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt2, "Vince Keen");
                peoplePage.SelectSortOrder("A-Z");
                var txt3 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt3, "Abigail Rayner");
                test.Pass("Assertion passed");
            }
            catch (Exception)
            {
                takeScreenShot("Sort order on default page test error", Driver);
                test.Fail("Assertion Failed");
                throw;
            }

        }

        //verify Accending and descending order works with search text
        [Test]
        public void SearchTextSortOrderTests()
        {
            var test = extent.CreateTest("Search text and sort order test");
            try
            {
                PeoplePage peoplePage = new PeoplePage(Driver);
                peoplePage.SearchText("Tom");
                Assert.AreEqual(peoplePage.GetResultSize(), 4);
                Assert.AreEqual(peoplePage.GetNthResultName(3), "Tom Woolerton");
                peoplePage.SelectSortOrder("Z-A");
                var txt2 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt2, "Tom Woolerton");
                peoplePage.SelectSortOrder("A-Z");
                var txt3 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt3, "Tom Robinson");
                test.Pass("Assertion passed");
            }
            catch (Exception)
            {
                takeScreenShot("Search Text and sort order error screenshot", Driver);
                test.Fail("Assertion Failed");
                throw;
            }

        }

        //verify select team and search works with sort order
        [Test]
        public void SelectTeamSortOrderTests()
        {
            var test = extent.CreateTest("Select team sort order test started");
            try
            {
                PeoplePage peoplePage = new PeoplePage(Driver);
                peoplePage.SearchTextandTeam("Tom", 3);
                peoplePage.ScrollpageDown();
                Assert.AreEqual(peoplePage.GetResultSize(), 3);
                Assert.AreEqual(peoplePage.GetNthResultName(2), "Tom Woolerton");
                peoplePage.SelectSortOrder("Z-A");
                var txt2 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt2, "Tom Woolerton");
                peoplePage.SelectSortOrder("A-Z");
                var txt3 = peoplePage.GetNthResultName(0);
                Assert.AreEqual(txt3, "Tom Robinson");
                test.Pass("Assertion passed");
            }
            catch (Exception)
            {
                test.Fail("Assertion Failed");
                throw;
            }
        }    


        [TearDown]
        public void TeardownTest()
        {
            Driver.Quit();
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {           
            extent.Flush();            
        }


    }
}
