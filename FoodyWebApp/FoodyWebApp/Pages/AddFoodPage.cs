using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyWebApp.Pages
{
    public class AddFoodPage : BasePage
    {
        public AddFoodPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Food/Add";

        public  IWebElement FoodName => driver.FindElement(By.XPath("//input[@name='Name']"));
        public IWebElement DescriptionFood => driver.FindElement(By.XPath("//input[@name='Description']"));
        public IWebElement AddPictureFood => driver.FindElement(By.XPath("//input[@name='Url']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));


        public void AssertMainErrorMessage()
        {
            Assert.That(MainErrorMessage.Text.Trim(), Is.EqualTo("Unable to add this food revue!"), "Main error massage was not expected ");
        }
        public void OpenPage() 
        { 
            driver.Navigate().GoToUrl(Url);
        }



    }
}
