namespace DataAccessLayer {
   // Creates an interface of IStandardRepository that extends IRepository with
   // type Standard
   public interface IStandardRepository : IRepository<Standard> { }

   // Creates an interface of IStudentRepository that extends IRepository with
   // type Student
   public interface IStudentRepository : IRepository<Student> { }

   // Creates a class of StandardRepository that extends Repository and 
   // IStandardRepository
   public class StandardRepository : Repository<Standard>, IStandardRepository {
      // Initializes the constructor with the base constructor with
      // SchoolDBEntities
      public StandardRepository() : base(new SchoolDBEntities()) { }
   }

   // Creates a class of StudentRepository that extends Repository and 
   // IStudentRepository
   public class StudentRepository : Repository<Student>, IStudentRepository {
      // Initializes the constructor with the base constructor with
      // SchoolDBEntities
      public StudentRepository() : base(new SchoolDBEntities()) { }
   }
}
