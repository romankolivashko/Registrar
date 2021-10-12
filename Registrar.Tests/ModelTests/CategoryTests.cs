using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registrar.Models;
using System.Collections.Generic;
using System;

namespace Registrar.Tests
{
  [TestClass]
  public class CourseTests : IDisposable
  {
    public void Dispose()
    {
      Course.ClearAll();
    }

    [TestMethod]
    public void CourseConstructor_CreatesInstanceOfCourse_Course()
    {
      Course newCourse = new Course("test category");
      Assert.AreEqual(typeof(Course), newCourse.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Course";
      Course newCourse = new Course(name);

      //Act
      string result = newCourse.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsCourseId_Int()
    {
      //Arrange
      string name = "Test Course";
      Course newCourse = new Course(name);

      //Act
      int result = newCourse.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCourseObjects_CourseList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Course newCourse1 = new Course(name01);
      Course newCourse2 = new Course(name02);
      List<Course> newList = new List<Course> { newCourse1, newCourse2 };

      //Act
      List<Course> result = Course.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCourse_Course()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Course newCourse1 = new Course(name01);
      Course newCourse2 = new Course(name02);

      //Act
      Course result = Course.Find(2);

      //Assert
      Assert.AreEqual(newCourse2, result);
    }

    [TestMethod]
    public void AddStudent_AssociatesStudentWithCourse_StudentList()
    {
      //Arrange
      string description = "Walk the dog.";
      Student newStudent = new Student(description);
      List<Student> newList = new List<Student> { newStudent };
      string name = "Work";
      Course newCourse = new Course(name);
      newCourse.AddStudent(newStudent);

      //Act
      List<Student> result = newCourse.Students;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}