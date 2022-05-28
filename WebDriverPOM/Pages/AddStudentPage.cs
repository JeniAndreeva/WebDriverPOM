using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPOM.Pages
{
    public class AddStudentsPage : BasePage
    {
        public AddStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement FieldStudentName => driver.FindElement(By.Id("name"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.Id("email"));
        public IWebElement ButtonAdd => driver.FindElement(By.CssSelector("body > form > button"));
        public IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));
        
        public void AddStudent(string name, string email)
        {
            this.FieldStudentName.SendKeys(name);
            this.FieldStudentEmail.SendKeys(email);
            this.ButtonAdd.Click();
        }

        //public string GetErrorMsg()
        //{
        //    return ElementErrorMsg.Text;
        //}
    }
}
