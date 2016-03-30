using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Testing.Resources;

namespace Testing.Tests

{
    [TestClass]
    public class GettingStartedTest
    {
        private string path;

        [TestMethod]
        public void GettingStarted_BasicFireFoxGET_LoadsPage()
        {
            using (FirefoxDriver driver = new FirefoxDriver())
            {
                Practice.GenericDriver(driver);
            }
        }

        [TestMethod]
        public void GettingStarted_BasicChromeGET_LoadsPage()
        {
            IWebDriver driver =
                new ChromeDriver(Screenshots.GridPath());

            Practice.GenericDriver(driver);
        }

        [TestMethod]
        public void GettingStarted_BasicIEGET_LoadsPage()
        {
            IWebDriver driver =
                new InternetExplorerDriver(Screenshots.GridPath());

            Practice.GenericDriver(driver);
        }
    }
}
