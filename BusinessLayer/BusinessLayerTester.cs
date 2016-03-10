using System;

namespace BusinessLayer {
    class BusinessLayerTester2 {

        private static BusinessLayer businessL;

        static void Main(string[] args) {
            businessL = new BusinessLayer();


            // HardCoded
            // Student Testing
            Console.WriteLine("Default Student");
            foreach (var element in businessL.getAllStudents()) {
                Console.WriteLine(element.StudentID + ": " + element.StudentName);
            }

            businessL.addStudent(CreateStudent());
            /*
            businessL.addStudent(new DataAccessLayer.Student() {
                StudentName = "Evan",
                StudentID = 4444,
                StandardId = 4
            });

            businessL.addStudent(new DataAccessLayer.Student() {
                StudentName = "Nick",
                StudentID = 7777,
                StandardId = 7
            });*/

            
            Console.WriteLine("\nAdd student (Evan and Nick)");
            foreach (var element in businessL.getAllStudents()) {
                Console.WriteLine(element.StudentID + ": " + element.StudentName);
                Console.WriteLine("StandardId: " + element.StandardId);
            }

            businessL.RemoveStudent(DeleteStudent());
            //businessL.RemoveStudent(businessL.GetStudentByID(11));

            Console.WriteLine("\nRemove student (Last Student)");
            foreach (var element in businessL.getAllStudents()) {
                Console.WriteLine(element.StudentID + ": " + element.StudentName);
                Console.WriteLine("StandardId: " + element.StandardId);
            }
            /*
            businessL.GetStudentByID(2).StudentName = "BlAdam";
            businessL.UpdateStudent(businessL.GetStudentByID(2));

            Console.WriteLine("\nUpdate student (2nd Student => BlAdam)");
            foreach (var element in businessL.getAllStudents()) {
                Console.WriteLine(element.StudentID + ": " + element.StudentName);
            }

            businessL.GetStudentByID(3).StudentName = "Blake";
            businessL.UpdateStudent(businessL.GetStudentByID(3));

            Console.WriteLine("\nUpdate student (3rd Student => Blake)");
            foreach (var element in businessL.getAllStudents()) {
                Console.WriteLine(element.StudentID + ": " + element.StudentName);
            }

            Console.WriteLine("\nSearch For (All students with Student in name)");
            var students = businessL.SearchForStudent(s =>
               s.StudentName.Contains("Student"));

            foreach (var element in students) {
                Console.WriteLine(element.StudentID + ": " + element.StudentName);
            }

            // Standard Testing
            Console.WriteLine("\nDefault Standard");
            foreach (var element in businessL.getAllStandards()) {
                Console.WriteLine(element.StandardId + ": " + element.StandardName);
            }

            businessL.addStandard(new DataAccessLayer.Standard() {
                StandardName = "English-Language Arts",
                Description = "Common Core State Standards for English"
            });

            businessL.addStandard(new DataAccessLayer.Standard() {
                StandardName = "Mathematics",
                Description = "Common Core State Standards for Mathematics"
            });

            Console.WriteLine("\nAdd standards (English and Mathematics)");
            foreach (var element in businessL.getAllStandards()) {
                Console.WriteLine(element.StandardId + ": "
                   + element.StandardName);
            }

            businessL.removeStandard(businessL.GetStandardByID(businessL.getAllStandards().Count));

            Console.WriteLine("\nRemove standard (Last standard)");
            foreach (var element in businessL.getAllStandards()) {
                Console.WriteLine(element.StandardId + ": "
                   + element.StandardName);
            }

            businessL.GetStandardByID(2).StandardName = "History-Social Science";
            businessL.updateStandard(businessL.GetStandardByID(2));

            Console.WriteLine("\nUpdate standard (2nd Standard => History"
               + "-Social Science)");
            foreach (var element in businessL.getAllStandards()) {
                Console.WriteLine(element.StandardId + ": "
                   + element.StandardName);
            }

            Console.WriteLine("\nSearch For (All standards with standard in "
               + "name)");
            var standards = businessL.SearchForStandard(s => s.StandardName.Contains("Standard"));

            foreach (var element in standards) {
                Console.WriteLine(element.StandardId + ": " + element.StandardName);
            }*/
        }

        static DataAccessLayer.Student CreateStudent() {
            Console.Write("Enter a name: ");
            var name = Console.ReadLine();

            Console.Write("Enter a StandardId: ");
            var standardId = Int32.Parse(Console.ReadLine());

            return new DataAccessLayer.Student() {
                StudentName = name,
                StandardId = standardId
            };
        }

        static DataAccessLayer.Student DeleteStudent() {
            Console.Write("Enter the StudentID of the student to delete: ");
            return businessL.GetStudentByID(Int32.Parse(Console.ReadLine()));
        }

       /* static DataAccessLayer.Student UpdateStudent() {
            Console.Write("Enter the StudentID of the student to update: ");
            var studentId = Int32.Parse(Console.ReadLine());

            Console.Write("Enter the new name: ");
            var name = Console.ReadLine();
        }*/

    }
}
