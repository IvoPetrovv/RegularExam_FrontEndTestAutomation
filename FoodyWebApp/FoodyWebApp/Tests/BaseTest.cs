using FoodyWebApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FoodyWebApp.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public BasePage basePage;

        public LoginPage loginPage;

        public AddFoodPage addFoodPage;

        public EditFoodPage editFoodPage;

        public AddSearchPage addSearchPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");


            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            basePage = new BasePage(driver);
            loginPage = new LoginPage(driver);
            addFoodPage = new AddFoodPage(driver);
            editFoodPage = new EditFoodPage(driver);
            addSearchPage = new AddSearchPage(driver);

            loginPage.OpenPage();
            loginPage.PerformLogin("Ivo007", "123456");


        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


        public string GenerateRandomFoodName()
        {
            var random = new Random();
            return "Food Name: " + random.Next(10000, 1000000);
        }

        public string GenerateRandomDescription()
        {
            var random = new Random();
            return "Description: " + random.Next(10000, 1000000);
        }

    }
}