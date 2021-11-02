using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using SeleniumExtras.WaitHelpers;

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
            GetElement("#categories")
                .Click();
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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='button']")))
                .Click();
            return PageFactory.GetPage("SearchResultPage", _driver) as SearchResultPage;
        }
        private void SelectFromDropDownByXPath(string cssPattern)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cssPattern)))
                .Click();
        }
        private void SelectFromDropDown(string choose, string cssPattern)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(cssPattern)))
                .Where(a => a.Text.Contains(choose))
                .First()
                .Click();
        }
    }
}