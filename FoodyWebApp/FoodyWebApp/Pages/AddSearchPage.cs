using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace FoodyWebApp.Pages
{
    public class AddSearchPage : BasePage
    {
        public AddSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public IReadOnlyCollection<IWebElement> AllFoodSearch => driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));

        public IWebElement LastFoodNameSearch => AllFood.Last().FindElement(By.XPath(".//h2"));
    }
}
