using OpenQA.Selenium;
using System;
using System.Linq;

namespace AuthPLEWTests
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }
        public CarDetailPage ClickFirstCarFromList()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            GetElements("div[class='head-ticket']")
                .First()
                .Click();
            return PageFactory.GetPage("CarDetailPage", _driver) as CarDetailPage;
        }
    }
}
