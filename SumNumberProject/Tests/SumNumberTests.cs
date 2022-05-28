using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SumNumberProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumberProject
{
    public class SumNumberPagesTests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void Close()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Valid_Numbers()
        {
            var sumPage = new SumNumberPage(this.driver);
            sumPage.OpenPage();
            var result = sumPage.AddNumbers("5", "6");

            Assert.That(result, Is.EqualTo("Sum: 11"));
        }
    }
}