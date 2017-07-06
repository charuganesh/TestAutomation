using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace Test_Framework
{
    public class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                htmlReporter = new ExtentHtmlReporter(@"C:\Users\Cganesh\Documents\Visual Studio 2017\Projects\Test_Framework\Reports.html");

                htmlReporter.Configuration().Theme = Theme.Dark;

                htmlReporter.Configuration().DocumentTitle = "CharuDocument";

                htmlReporter.Configuration().ReportName = "CharuReport";

                /*htmlReporter.Configuration().JS = "$('.brand-logo').text('test image').prepend('<img src=@"file:///D:\Users\jloyzaga\Documents\FrameworkForJoe\FrameworkForJoe\Capgemini_logo_high_res-smaller-2.jpg"> ')";*/
                htmlReporter.Configuration().JS = "$('.brand-logo').text('').append('<img src=C:\\Users\\Cganesh\\Documents\\Visual Studio 2017\\Projects\\Test_Framework\\Capgemini_logo_high_res-smaller-2.jpg>')";
                extent = new ExtentReports();

                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}
