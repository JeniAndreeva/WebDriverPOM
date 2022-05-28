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
    public class AddStudentTests : BaseTests
    {
        [Test]
        public void Test_AddStudent_Url_Heading_Title()
        {
            var addStudent = new AddStudentsPage(driver);
            addStudent.Open();
            Assert.That(driver.Url, Is.EqualTo(addStudent.GetPageUrl()));
            Assert.That(addStudent.GetPageHeading(), Is.EqualTo("Register New Student"));
            Assert.That(addStudent.GetPageTitle(), Is.EqualTo("Add Student"));
        }

        [Test]
        public void Test_AddStudentPage_EmptyField()
        {
            var addStudent = new AddStudentsPage(driver);
            addStudent.Open();

            Assert.That(addStudent.FieldStudentEmail.Text, Is.EqualTo(""));

        }

        [Test]
        public void  Test_TestAddStudentPage_AddValidStudent()
        {
            var addStudent = new AddStudentsPage(driver);
            addStudent.Open();

            string name = "Jeni" + DateTime.Now.Ticks;
            string email = "Jeni" + DateTime.Now.Ticks + "@abv.bg";
            addStudent.AddStudent(name, email);

            var viewStudent = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudent.isOpen());

            var students = viewStudent.GetRegisteredStudents();
            var lastStudent = students.Last();
            string expected = name + "(" + email + ")";
            Assert.Contains(lastStudent, students);

        }

        [Test]

        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            var add_Student = new AddStudentsPage(driver);
            add_Student.Open();
            string name = "";
            string email = "";
            add_Student.AddStudent(name, email);
            Assert.IsTrue(add_Student.isOpen());
            Assert.That(add_Student.ElementErrorMsg.Text, Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }

    }
}
