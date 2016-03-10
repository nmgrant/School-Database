namespace DataAccessLayer {
    public interface IStandardRepository : IRepository<Standard> { }

    public interface IStudentRepository : IRepository<Student> { }

    public class StandardRepository : Repository<Standard>, IStandardRepository {
        public StandardRepository() : base(new SchoolDBEntities()) { }
    }

    public class StudentRepository : Repository<Student>, IStudentRepository {
        public StudentRepository() : base(new SchoolDBEntities()) { }
    }
}
