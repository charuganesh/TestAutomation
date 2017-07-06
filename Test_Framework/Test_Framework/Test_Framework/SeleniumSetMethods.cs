using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Threading;

namespace Test_Framework
{
    public static class SeleniumSetMethods
    {
        
        public static void EnterText(this IWebElement element,string value)
        {
            element.SendKeys(value);
        }

        //click on button, checkbox, option etc
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        public static void SelectDropDown(this IWebElement element, String value)
        {
            var selectElement = new SelectElement(element);            
            selectElement.SelectByText(value);         
        }

        


    }
}
