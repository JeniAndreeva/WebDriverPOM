using OpenQA.Selenium;
using System;
using NUnit.Framework;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumberProject.Pages
{
    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        const string PageUrl = "https://sum-numbers.nakov.repl.co";

        //public IWebElement fieldfNum1 => driver.FindElements(By.CssSelector("#number1"));

        public IWebElement fieldNum1 => driver.FindElement(By.CssSelector("#number1"));
        public IWebElement fieldNum2 => driver.FindElement(By.CssSelector("#number2"));
        public IWebElement calculateButton => driver.FindElement(By.CssSelector("#calcButton"));
        public IWebElement resetButton => driver.FindElement(By.CssSelector("#resetButton"));
        public IWebElement resultField => driver.FindElement(By.CssSelector("#result"));
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
        public void ResetForm()
        {
            resetButton.Click();
        }
        public bool IsFormEmpty()
        {
            return fieldNum1.Text + fieldNum2.Text + resultField.Text == "";
        }

        public string AddNumbers(string num1, string num2)
        {
            fieldNum1.SendKeys(num1);
            fieldNum2.SendKeys(num2);
            calculateButton.Click();
            string result = resultField.Text;
            return result;
        }
    }
}
