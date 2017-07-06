using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Threading;
using NUnit.Framework;

namespace Test_Framework
{
    public class PeoplePage 
    {
        private IWebDriver driver;

        public PeoplePage(IWebDriver driver)
        {
            //PageFactory.InitElements(PropertyCollections.driver, this);
            //this.driver = browser;
            PageFactory.InitElements(driver, this);           
            this.driver = driver;
                         
            
        }

        [FindsBy(How = How.CssSelector, Using = ".inputOne div input")]
        public IWebElement TxtSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".form-control.string-search2")]
        public IWebElement TxtPostcode { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inputOne div span span")]
        public IWebElement SearchIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inputTwo div span span")]
        public IWebElement SearchPostCodeIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".selectTwo div div li a>span[class$='check-mark']")]
        public IList<IWebElement> CheckBox { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".selectOne div button span.caret")]
        public IWebElement SelectDropDownMenu { get; set; }

        [FindsBy(How = How.ClassName, Using = "selectpicker")]
        public IWebElement SortOrder { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cta.pink > span")]
        public IWebElement ClickContinue { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".content>h2")]
        public IList<IWebElement> SearchResults { get; set; } 
        

        public PeoplePage SearchText(String searchText)
        {
            TxtSearch.EnterText(searchText);
            SearchIcon.Clicks();
            return this;
        }

        public String GetText()
        {
            return TxtSearch.GetText();           
            
        }

        public PeoplePage SearchPostCode(String postCode, int value)
        {
            CheckBox[value].Clicks();
            TxtPostcode.EnterText(postCode);
            SearchPostCodeIcon.Clicks();
            return this;
        }

        public PeoplePage SearchTextandTeam(String text, int value)
        {
            TxtSearch.EnterText(text);
            CheckBox[value].Clicks();
            SearchIcon.Clicks();
            return this;
        }

        public PeoplePage HandleDialog()
        {            
            ClickContinue.Clicks();
            return this;          
            
        }

        public PeoplePage ScrollpageDown()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,950)");
            return this;
        }

        public String GetNthResultName(int value)
        {
            return SearchResults[value].Text;            
           
        }    

        public PeoplePage SelectSortOrder(String value)
        {
            SelectDropDownMenu.Clicks();
            SortOrder.SelectDropDown(value);
            return this;
        }

        public int GetResultSize()
        {
            return SearchResults.Count();
        }

        public Boolean IsTextDisplayed(String actual, String expected)
        {           
           
           if (expected == actual)
           {               
                return true;              
           }
           else
           {
              return false;
           }         
                      
        }


    }
}
