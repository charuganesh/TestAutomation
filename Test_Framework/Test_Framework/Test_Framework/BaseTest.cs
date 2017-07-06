using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test_Framework
{
    public class BaseTest
    {
        public ExtentReports extent = ExtentManager.GetInstance();

        public static void takeScreenShot(string filename, IWebDriver driver)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile($"C:\\Users\\Cganesh\\Documents\\Visual Studio 2017\\Projects\\Test_Framework\\ErrorScreenshot\\{filename}.jpeg", ScreenshotImageFormat.Gif);
        } 
    }
}
