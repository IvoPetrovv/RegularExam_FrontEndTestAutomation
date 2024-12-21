using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace FoodyWebApp.Tests
{
    public class FoodyWebAppTest : BaseTest
    {

        private string? lastFoodName;
        private string? lastFoodDiscription;
        private string? editlastFoodName;
        private string? editlastFoodDiscription;



        [Test, Order(1)]
        public void AddFoodWithInvalidDataTest()
        {
            addFoodPage.OpenPage();


            addFoodPage.FoodName.Clear();
            addFoodPage.DescriptionFood.Clear();
            addFoodPage.AddButton.Click();

            addFoodPage.AssertMainErrorMessage();

            Assert.That(driver.Url, Is.EqualTo(addFoodPage.Url), "The page is not same");
           
        }

        [Test, Order(2)]
        public void AddFoodWithValidDataTest()
        {

            lastFoodName = GenerateRandomFoodName();
            lastFoodDiscription = GenerateRandomDescription();

            addFoodPage.OpenPage();


            addFoodPage.FoodName.Clear();
            addFoodPage.FoodName.SendKeys(lastFoodName);
            addFoodPage.DescriptionFood.Clear();
            addFoodPage.DescriptionFood.SendKeys(lastFoodName);
            addFoodPage.AddButton.Click();


            Assert.That(basePage.LastFoodName.Text.Trim(), Is.EqualTo(lastFoodName), "The food name is not same");

            Assert.That(driver.Url, Is.EqualTo("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/"));
        }

        [Test, Order(3)]
        public void EditLastFood()
        {

            editlastFoodName = GenerateRandomFoodName(); 
            editlastFoodDiscription = GenerateRandomDescription();

            basePage.OpenPage();


            new Actions(driver)
             .ScrollToElement(basePage.LastFoodEditButton)
              .Perform();

            basePage.LastFoodEditButton.Click();

            editFoodPage.EditFoodName.Clear();
            editFoodPage.EditFoodName.SendKeys(editlastFoodName);
            editFoodPage.EditDescriptionFood.Clear();
            editFoodPage.EditDescriptionFood.SendKeys(editlastFoodDiscription);
            editFoodPage.AddButton.Click();



            Assert.AreNotEqual(basePage.LastFoodName.Text.Trim(), editlastFoodName);

            Assert.That(driver.Url, Is.EqualTo("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/"));
        }

        [Test, Order(4)] 
        public void SearchForFoodTitleTest()
        {

            basePage.OpenPage();

            basePage.SearchBar.Clear();
            basePage.SearchBar.SendKeys(lastFoodName);
            basePage.SerchButton.Click();


            new Actions(driver)
             .ScrollToElement(basePage.LastFoodName)
              .Perform();



            Assert.That(addSearchPage.LastFoodNameSearch.Text.Trim(), Is.EqualTo(lastFoodName), "The food name is not same");




        }

        [Test, Order(5)]
        public void Delete()
        {

            basePage.OpenPage();

            
            var count = basePage.AllFood.Count;

            new Actions(driver)
             .ScrollToElement(basePage.LastFoodDeleteButton)
              .Perform();
            
            basePage.LastFoodDeleteButton.Click();

          

            var countAfter = basePage.AllFood.Count;


            Assert.That(count, Is.EqualTo(countAfter + 1));



        }

        [Test, Order(6)]
        public void SearchDelete()
        {

            basePage.OpenPage();

            basePage.SearchBar.Clear();
            basePage.SearchBar.SendKeys(lastFoodName);
            basePage.SerchButton.Click();


            



            Assert.That(basePage.text.Text.Trim(), Is.EqualTo("There are no foods :("), "The food name is not same");




        }

    }
}
