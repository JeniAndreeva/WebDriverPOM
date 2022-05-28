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
    public class ViewStudentPageTests : BaseTests
    {
        [Test]
        public void Test_ViewStudent_Url_Heading_Title()
        {
            var studentPage = new ViewStudentsPage(driver);
            studentPage.Open();
            Assert.That(driver.Url, Is.EqualTo(studentPage.GetPageUrl()));
            Assert.That(studentPage.GetPageHeading(), Is.EqualTo("Registered Students"));
            Assert.That(studentPage.GetPageTitle(), Is.EqualTo("Students"));
        }

        [Test]
        public void Test_Check_Students()
        {
            var studentPage = new ViewStudentsPage(driver);
            studentPage.Open();
            var students = studentPage.GetRegisteredStudents();

            foreach (var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
            }

        }
    }
}
