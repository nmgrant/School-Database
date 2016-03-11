﻿using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq.Expressions;
using System.Linq;

namespace BusinessLayer {
    public interface IBusinessLayer {
        IList<Standard> GetAllStandards();
        IQueryable<Standard> SearchForStandard(
           Expression<Func<Standard, bool>> predicate);
        Standard GetStandardByID(int id);
        void AddStandard(Standard standard);
        void UpdateStandard(Standard standard);
        void RemoveStandard(Standard standard);
        Standard GetSingle(Func<Standard, bool> where,
           params Expression<Func<Standard, object>>[] navigationProperties);
        IList<Student> GetAllStudents();
        IQueryable<Student> SearchForStudent(Expression<Func<Student,
           bool>> predicate);
        Student GetStudentByID(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
        Student GetSingle(Func<Student, bool> where,
           params Expression<Func<Student, object>>[] navigationProperties);
    }
    public class BusinessLayer : IBusinessLayer {
        private readonly IStandardRepository _standardRepository;
        private readonly IStudentRepository _studentRepository;

        public BusinessLayer() {
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository();
        }

        public void AddStandard(Standard standard) {
            _standardRepository.Insert(standard);
        }

        public void AddStudent(Student student) {
            _studentRepository.Insert(student);
        }

        public IList<Standard> GetAllStandards() {
            return (IList<Standard>)_standardRepository.GetAll();
        }

        public Standard GetSingle(Func<Standard, bool> where,
           params Expression<Func<Standard, object>>[] navigationProperties) {
           return _standardRepository.GetSingle(where, navigationProperties);
        }

        public Student GetSingle(Func<Student, bool> where,
           params Expression<Func<Student, object>>[] navigationProperties) {
           return _studentRepository.GetSingle(where, navigationProperties);
        }

        public IList<Student> GetAllStudents() {
            return (IList<Student>)_studentRepository.GetAll();
        }

        public Standard GetStandardByID(int id) {
            return _standardRepository.GetById(id);
        }

        public Student GetStudentByID(int id) {
            return _studentRepository.GetById(id);
        }

        public void RemoveStandard(Standard standard) {
            _standardRepository.Delete(standard);
        }

        public void RemoveStudent(Student student) {
            _studentRepository.Delete(student);
        }

        public IQueryable<Standard> SearchForStandard(Expression<Func<Standard,
           bool>> predicate) {
            return _standardRepository.SearchFor(predicate);
        }

        public IQueryable<Student> SearchForStudent(Expression<Func<Student,
           bool>> predicate) {
            return _studentRepository.SearchFor(predicate);
        }

        public void UpdateStandard(Standard standard) {
            _standardRepository.Update(standard);
        }

        public void UpdateStudent(Student student) {
            _studentRepository.Update(student);
        }
    }
}
