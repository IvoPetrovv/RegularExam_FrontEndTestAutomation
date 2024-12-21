using OpenQA.Selenium;

namespace FoodyWebApp.Pages
{
    public class EditFoodPage : BasePage
    {
        public EditFoodPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Food/Edit";


        public IWebElement EditFoodName => driver.FindElement(By.XPath("//input[@name='Name']"));
        public IWebElement EditDescriptionFood => driver.FindElement(By.XPath("//input[@name='Description']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));


        public void OpenPage() 
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
