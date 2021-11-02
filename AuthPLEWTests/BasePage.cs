using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthPLEWTests
{
    public class BasePage
    {
        public IWebDriver _driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public BasePage() { }
        public void Quit()
        {
            if (_driver != null)
                _driver.Quit();
        }
        protected void GoToPage(string url) => _driver.Navigate().GoToUrl(url);
        protected IWebElement GetElement(string cssPattern) =>
            _driver.FindElement(By.CssSelector(cssPattern));
        protected List<IWebElement> GetElements(string cssPattern) =>
            _driver.FindElements(By.CssSelector(cssPattern)).ToList();
    }
}
