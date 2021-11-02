using OpenQA.Selenium;

namespace AuthPLEWTests
{
    public static class PageFactory
    {
        public static BasePage GetPage(string type, IWebDriver driver)
        {
            switch (type)
            {
                case "HomePage": return new HomePage(driver);
                case "SearchResultPage": return new SearchResultPage(driver);
                case "CarDetailPage": return new CarDetailPage(driver);
                default: return null;
            }
        }
    }
}
