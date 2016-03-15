using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq.Expressions;
using System.Linq;

namespace BusinessLayer {
   public interface IBusinessLayer {
      IList<Standard> GetAllStandards();
      IQueryable<Standard> SearchForStandard(
         Expression<Func<Standard, bool>> predicate);
      Standard GetStandardByName(string standardName);
      Standard GetStandardByID(int id);
      void AddStandard(Standard standard);
      void UpdateStandard(Standard standard);
      void RemoveStandard(Standard standard);
      Standard GetSingle(Func<Standard, bool> where,
         params Expression<Func<Standard, object>>[] navigationProperties);
      IList<Student> GetAllStudents();
      IQueryable<Student> SearchForStudent(Expression<Func<Student,
         bool>> predicate);
      Student GetStudentByName(string studentName);
      Student GetStudentByID(int id);
      void AddStudent(Student student);
      void UpdateStudent(Student student);
      void RemoveStudent(Student student);
      Student GetSingle(Func<Student, bool> where,
         params Expression<Func<Student, object>>[] navigationProperties);
   }
}
