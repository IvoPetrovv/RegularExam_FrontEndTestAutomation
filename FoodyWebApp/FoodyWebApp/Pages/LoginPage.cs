using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyWebApp.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/User/Login";

        public IWebElement UserNameInput => driver.FindElement(By.XPath("//input[@name='Username']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='Password']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@type='submit']"));


        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string email, string password)
        {

           


            UserNameInput.Clear();
            UserNameInput.SendKeys(email);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);



            LoginButton.Click();

        }
    }
}
