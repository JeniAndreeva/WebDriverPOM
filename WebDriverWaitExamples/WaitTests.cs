using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace WebDriverWaitExamples
{
    public class WaitTests
    {
        private WebDriver driver;
        private WebDriverWait wait;

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wait_ThreadSleep()
        {
            this.driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            Thread.Sleep(15000);

            var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(textElement);

        }
        [Test]
        public void Test_Wait_ImplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsNotEmpty(textElement);


            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var textElement1 = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsNotEmpty(textElement);
        }

        [Test]
        public void Test_Wait_ExplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            var textElement = this.wait.Until(driver =>
            {
                return driver.FindElement(By.PartialLinkText("This is")).Text;
            });
            Assert.IsNotEmpty(textElement);


            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            var textElement1 = this.wait.Until(driver =>
            {
                return driver.FindElement(By.PartialLinkText("This is")).Text;
            });
            Assert.IsNotEmpty(textElement);
        }
        [Test]
        public void Test_Wait_ExpectedConditions()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            var textElement = this.wait.Until(
                ExpectedConditions.ElementIsVisible(By.PartialLinkText("This is"))).Text;
                
            Assert.IsNotEmpty(textElement);


            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            var textElement1 = this.wait.Until(
                ExpectedConditions.ElementIsVisible(By.PartialLinkText("This is"))).Text;
            Assert.IsNotEmpty(textElement1);
        }
    }
}