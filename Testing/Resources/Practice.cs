using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Testing.Resources
{
    public class Practice
    {
        public static void GenericDriver(IWebDriver driver)
        {
            driver.Url = "https://bfc-test.bftcloud.com";
            driver.Navigate();

            Screenshots.TakeScreenshot("TestRun", driver);

            StandardChecksThenClose(driver);
        }

        public static void StandardChecksThenClose(IWebDriver driver)
        {
            Assert.AreEqual("Business Finance Comparison | Business finance Solutions | UK Business finance", driver.Title);
            driver.Quit();
        }


    }
}
