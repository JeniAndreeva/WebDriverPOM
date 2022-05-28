using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverPOM.Pages;

namespace WebDriverPOM.Tests
{
    public class HomePageTests : BaseTests
    {
        [Test]
        public void Test_HomePage_Url_Heading_Title()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            Assert.That(driver.Url, Is.EqualTo(homePage.GetPageUrl()));
            Assert.That(homePage.GetPageHeading(), Is.EqualTo("Students Registry"));
            Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
        }

        [Test]
        public void Test_HomePage_HomeLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.HomeLink.Click();
            Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(driver.Url, Is.EqualTo(homePage.GetPageUrl()));

        }

        [Test]
        public void Test_HomePage_ViewStudentsLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.ViewStudentsLink.Click();

            var viewStudent = new ViewStudentsPage(driver);
            Assert.That(viewStudent.GetPageTitle, Is.EqualTo("Students"));
            Assert.That(driver.Url, Is.EqualTo(viewStudent.GetPageUrl()));

        }

        [Test]
        public void Test_HomePage_AddStudentsLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AddStudentLink.Click();

            var addStudent = new AddStudentsPage(driver);
            Assert.That(addStudent.GetPageTitle, Is.EqualTo("Add Student"));
            Assert.That(driver.Url, Is.EqualTo(addStudent.GetPageUrl()));

        }

        [Test]
        public void Test_HomePage_ViewStudentsCount()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            Assert.Greater(homePage.GetStudentCount(), 0);
        }
    }
}
