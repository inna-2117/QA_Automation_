using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthPLEWTests
{
    public class HomePage : BasePage
    {
        public const string url = "https://auto.ria.com/";
        public HomePage(IWebDriver driver) : base(driver) { }
        public HomePage GoToHomePage() 
        { 
            GoToPage(url); 
            return this; 
        }
        public HomePage SelectCarCategoryFromDropDown(string type)
        {
            _driver.FindElement(By.Id("categories")).Click();
            SelectFromDropDown(type, "option");
            return this;
        }
        public HomePage SelectRegionFromDropDown(string city)
        {
            GetElement("label[for='brandTooltipBrandAutocompleteInput-region']")
                .Click();
            SelectFromDropDownByXPath("//a[text()='"+ city +"']");
            return this;
        }
        public HomePage SelectCarBrandFromDropDown(string brand)
        {
            GetElement("label[for='brandTooltipBrandAutocompleteInput-brand']")
                .Click();
            SelectFromDropDownByXPath("//a[text()='" + brand + "']");
            return this;
        }
        public HomePage SelectCarModelFromDropDown(string model)
        {
            GetElement("label[for='brandTooltipBrandAutocompleteInput-model']")
                .Click();
            SelectFromDropDownByXPath("//a[text()='" + model + "']");
            return this;
        }
        public SearchResultPage ClickSearchButton(string name)
        {
            _driver.FindElement(By.XPath("//span[text()=' " + name + " ']"))
                .Click();
            return PageFactory.GetPage("SearchResultPage", _driver) as SearchResultPage;
        }
        private void SelectFromDropDownByXPath(string cssPattern)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cssPattern)))
                .Click();
        }
        private void SelectFromDropDown(string choose, string cssPattern)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(cssPattern)))
                .Where(a => a.Text.Contains(choose))
                .First()
                .Click();
        }
    }
}