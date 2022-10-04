using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestGoogleSearch
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearchAndDisplayStreetFighterFive()
        {
            int waitingTime = 1000;
            By googleSearchBar = By.Name("q");
            By googleSearchButton = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]");
            By googleResultText = By.XPath(".//h2/span[text()='Street Fighter V']");
            By googleAcceptAllButton = By.Id("L2AGLb");


            IWebDriver webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.google.com/");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleAcceptAllButton).Click();

            webDriver.FindElement(googleSearchBar).SendKeys("Street Fighter V");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchButton).Click();
            webDriver.Manage().Window.Maximize();

            var actualResultText = webDriver.FindElement(googleResultText);

            Assert.IsTrue(actualResultText.Text.Equals("Street Fighter V"));

            webDriver.Quit();
        }
    }
}
