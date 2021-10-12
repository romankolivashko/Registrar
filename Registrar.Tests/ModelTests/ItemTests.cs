using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Registrar.Models;
using System;
using MySql.Data.MySqlClient;

namespace Registrar.Tests
{
  [TestClass]
  public class StudentTests : IDisposable
  {

    public void Dispose()
    {
      Student.ClearAll();
    }

    public StudentTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
    }

    // [TestMethod]
    // public void StudentConstructor_CreatesInstanceOfStudent_Student()
    // {
    //   Student newStudent = new Student("test");
    //   Assert.AreEqual(typeof(Student), newStudent.GetType());
    // }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";

    //   //Act
    //   Student newStudent = new Student(description);
    //   string result = newStudent.Description;

    //   //Assert
    //   Assert.AreEqual(description, result);
    // }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Student newStudent = new Student(description);

    //   //Act
    //   string updatedDescription = "Do the dishes";
    //   newStudent.Description = updatedDescription;
    //   string result = newStudent.Description;

    //   //Assert
    //   Assert.AreEqual(updatedDescription, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_FromDatabase_StudentList()
    {
      // Arrange
      List<Student> newList = new List<Student> { };

      // Act
      List<Student> result = Student.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsStudents_StudentList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Student newStudent1 = new Student(description01);
      newStudent1.Save();
      Student newStudent2 = new Student(description02);
      newStudent2.Save();
      List<Student> newList = new List<Student> { newStudent1, newStudent2 };

      //Act
      List<Student> result = Student.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetID_StudentsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string description = "Walk the dog";
    //   Student newStudent = new Student(description);

    //   //Act
    //   int result = newStudent.Id;

    //   //Assert
    //   Assert.AreEqual(1, result);
    // }

    [TestMethod]
    public void Find_returnsCorrectStudentFromDatabase_Student()
    {
      //Arrange
      Student newStudent = new Student("Mow the lawn");
      newStudent.Save();
      Student newStudent2 = new Student("Wash dishes");
      newStudent2.Save();

      //Act
      Student foundStudent = Student.Find(newStudent.Id);
      //Assert
      Assert.AreEqual(newStudent, foundStudent);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Student()
    {
      //Arrange, Act
      Student firstStudent = new Student("Mow the lawn");
      Student secondStudent = new Student("Mow the lawn");

      //Assert
      Assert.AreEqual(firstStudent, secondStudent);
    }

    [TestMethod]
    public void Save_SavesToDatabase_StudentList()
    {
      //Arrange
      Student testStudent = new Student("Mow the lawn");

      //Act
      testStudent.Save();
      List<Student> result = Student.GetAll();
      List<Student> testList = new List<Student>{testStudent};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}