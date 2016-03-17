using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq.Expressions;
using System.Linq;

namespace BusinessLayer {
   public interface IBusinessLayer {
      // Get all Standards method signature
      IList<Standard> GetAllStandards();
      // Search for a given Standard method signature
      IQueryable<Standard> SearchForStandard(
         Expression<Func<Standard, bool>> predicate);
      // Return a Standard by name method signature
      Standard GetStandardByName(string standardName);
      // Return a Standard by ID method signature
      Standard GetStandardByID(int id);
      // Add a given Standard method signature
      void AddStandard(Standard standard);
      // Update a Standard method signature
      void UpdateStandard(Standard standard);
      // Remove a given Standard method signature
      void RemoveStandard(Standard standard);
      // Return a Standard where a given query matches method signature
      Standard GetSingle(Func<Standard, bool> where,
         params Expression<Func<Standard, object>>[] navigationProperties);

      // Get all Students method signature
      IList<Student> GetAllStudents();
      // Search for a given Student method signature
      IQueryable<Student> SearchForStudent(Expression<Func<Student,
         bool>> predicate);
      // Return a Student by name method signature
      Student GetStudentByName(string studentName);
      // Return a Student by ID method signature
      Student GetStudentByID(int id);
      // Add a given Student method signature
      void AddStudent(Student student);
      // Update a Student method signature
      void UpdateStudent(Student student);
      // Remove a given Student method signature
      void RemoveStudent(Student student);
      // Return a Student where a given query matches method signature
      Student GetSingle(Func<Student, bool> where,
         params Expression<Func<Student, object>>[] navigationProperties);
   }
}
