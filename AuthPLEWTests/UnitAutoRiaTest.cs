using NUnit.Framework;
using System;

namespace AuthPLEWTests
{
    public class UnitAutoRiaTest
    {
        private HomePage _homePage { get; set; }

        [SetUp]
        public void Setup()
        {
             _homePage = new HomePage(new OpenQA.Selenium.Firefox.FirefoxDriver());
        }

        [Test]
        public void TestRia()
        {
            const string expectedAdTitle = "Audi Q8";
            string actualAdTitle = _homePage
                .GoToHomePage()
                .SelectRegionFromDropDown("Харків")
                .SelectCarBrandFromDropDown("Audi")
                .SelectCarModelFromDropDown("Q8")
                .SelectCarCategoryFromDropDown("Легкові")
                .ClickSearchButton("Пошук")
                .ClickFirstCarFromList()
                .CheckAdTitleText(expectedAdTitle)
                .GetDetailTitleText();
            Assert.AreEqual(expectedAdTitle, actualAdTitle);
        }
        [TearDown]
        public void EndRiaTest()
        {
            _homePage.Quit();
        }
    }
}
