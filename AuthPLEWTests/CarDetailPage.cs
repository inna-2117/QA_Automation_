using FluentAssertions;
using OpenQA.Selenium;

namespace AuthPLEWTests
{
    public class CarDetailPage : BasePage
    {
        private string _actualTitle { get; set; }
        public CarDetailPage(IWebDriver driver) : base(driver) 
        {
            _actualTitle = _driver.FindElement(By.XPath("//span[@itemprop='brand']")).Text +
                " " +
                _driver.FindElement(By.XPath("//span[@itemprop='name']")).Text;
        }
        public string GetDetailTitleText()
        {
            return _actualTitle;
        }
        public CarDetailPage CheckAdTitleText(string expectedAdText)
        {
            GetDetailTitleText().Should().Contain(expectedAdText);
            return this;
        }
    }
}
