using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyWebApp.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected WebDriverWait wait;

        protected static string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement LoginLink => driver.FindElement(By.XPath("//a[text()='Logout']"));
        public IWebElement AddFoodLink => driver.FindElement(By.XPath("//a[text()='Add Food']"));
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[text()='Logout']"));

        public IReadOnlyCollection<IWebElement> AllFood => driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));

        public IWebElement LastFoodName => AllFood.Last().FindElement(By.XPath(".//h2"));
        public IWebElement LastFoodEditButton => AllFood.Last().FindElement(By.XPath(".//a[text()='Edit']"));

        public IWebElement LastFoodDeleteButton => AllFood.Last().FindElement(By.XPath(".//a[text()='Delete']"));

        public IWebElement SearchBar => driver.FindElement(By.XPath("//input[@name='keyword']"));

        public IWebElement SerchButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement text => driver.FindElement(By.XPath("//div[@class='col-lg-6 order-lg-1']//h2")); 


        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);        
        }
    }
}
