using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq.Expressions;
using System.Linq;

namespace BusinessLayer {
   public class BusinessLayer : IBusinessLayer {
      // Initialize readonly objects for Student and Standard repositories
      private readonly IStandardRepository _standardRepository;
      private readonly IStudentRepository _studentRepository;

      // A constructor to iniitialze the Standard and Student repositories
      public BusinessLayer() {
         _standardRepository = new StandardRepository();
         _studentRepository = new StudentRepository();
      }

      // GetAllStandards() method to return all Standards
      public IList<Standard> GetAllStandards() {
         return (IList<Standard>)_standardRepository.GetAll();
      }

      // SearchForStandard() method to search through the Standard repository
      // for a given Standard that matches the given predicate
      public IQueryable<Standard> SearchForStandard(Expression<Func<Standard,
         bool>> predicate) {
         return _standardRepository.SearchFor(predicate);
      }

      // GetStandardByName() method to return the first instance of a Standard
      // that matches the given query using GetSingle()
      public Standard GetStandardByName(string standardName) {
         return _standardRepository.GetSingle(
            d => d.StandardName.Equals(standardName),
            d => d.Students);
      }

      // GetStandardByID() method to return a Standard with the given ID
      public Standard GetStandardByID(int id) {
         return _standardRepository.GetById(id);
      }

      // AddStandard() method to add a Standard to the Standard repository
      public void AddStandard(Standard standard) {
         _standardRepository.Insert(standard);
      }

      // UpdateStandard() to update a given Standard in the Standard repository
      public void UpdateStandard(Standard standard) {
         _standardRepository.Update(standard);
      }

      // RemoveStandard() to remove a given Standard in the Standard repository
      public void RemoveStandard(Standard standard) {
         _standardRepository.Delete(standard);
      }

      // GetSingle() to return a Standard where the given query matches the
      // first instance in the Standard repository
      public Standard GetSingle(Func<Standard, bool> where,
         params Expression<Func<Standard, object>>[] navigationProperties) {
         return _standardRepository.GetSingle(where, navigationProperties);
      }


      // GetAllStudents() method to return all Students
      public IList<Student> GetAllStudents() {
         return (IList<Student>)_studentRepository.GetAll();
      }

      // SearchForStudent() method to search through the Student repository
      // for a given Student that matches the given predicate
      public IQueryable<Student> SearchForStudent(Expression<Func<Student,
         bool>> predicate) {
         return _studentRepository.SearchFor(predicate);
      }

      // GetStudentByName() method to return the first instance of a Student
      // that matches the given query using GetSingle()
      public Student GetStudentByName(string studentName) {
         return _studentRepository.GetSingle(
            d => d.StudentName.Equals(studentName),
            d => d.Courses);
      }

      // GetStudentByID() method to return a Student with the given ID
      public Student GetStudentByID(int id) {
         return _studentRepository.GetById(id);
      }

      // AddStudent() method to add a Student to the Student repository
      public void AddStudent(Student student) {
         _studentRepository.Insert(student);
      }

      // UpdateStudent() to update a given Student in the Student repository
      public void UpdateStudent(Student student) {
         _studentRepository.Update(student);
      }

      // RemoveStudent() to remove a given Student in the Student repository
      public void RemoveStudent(Student student) {
         _studentRepository.Delete(student);
      }

      // GetSingle() to return a Student where the given query matches the
      // first instance in the Student repository
      public Student GetSingle(Func<Student, bool> where,
         params Expression<Func<Student, object>>[] navigationProperties) {
         return _studentRepository.GetSingle(where, navigationProperties);
      }
   }
}
