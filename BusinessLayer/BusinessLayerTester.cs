using System;

namespace BusinessLayer {
   class BusinessLayerTester {

      private static BusinessLayer businessL;

      static void Main(string[] args) {
         businessL = new BusinessLayer();
         int menuOptions = 1;
         int menuChoice;
         bool exitProgram = false;

         do {
            MenuOptions(ref menuOptions);
            menuChoice = UserMenuChoice(menuOptions);
            switch (menuOptions) {
               case 1:
                  MainMenu(menuChoice, ref menuOptions, ref exitProgram);
                  break;
               case 2:
                  StandardMenu(menuChoice, ref exitProgram);
                  break;
               case 3:
                  StudentMenu(menuChoice, ref exitProgram);
                  break;
            }
         } while (!exitProgram);


         /* HardCoded
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
         });


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

      public static void MenuOptions(ref int menu) {
         switch (menu) {
            case 1:
               Console.WriteLine("Menu:");
               Console.WriteLine("1. Standard Tables");
               Console.WriteLine("2. Student Tables");
               Console.WriteLine("3. Exit Program");
               break;
            case 2:
               Console.WriteLine("Standard Menu");
               Console.WriteLine("1. Display all current Standards");
               Console.WriteLine("2. Create new Standard");
               Console.WriteLine("3. Update Standard");
               Console.WriteLine("4. Delete Standard");
               Console.WriteLine("5. Display all Standards by an ID");
               Console.WriteLine("6. Return to Main Menu");
               break;
            case 3:
               Console.WriteLine("Student Menu");
               Console.WriteLine("1. Display all current Students");
               Console.WriteLine("2. Create new Student");
               Console.WriteLine("3. Update Student");
               Console.WriteLine("4. Delete Student");
               Console.WriteLine("5. Return to Main Menu");
               break;
            default:
               menu = 1;
               break;
         }
      }

      public static int UserMenuChoice(int menu) {
         int userIntChoice;
         while (true) {
            string userStringChoice = Console.ReadLine();
            if (Int32.TryParse(userStringChoice, out userIntChoice)) {
               if (IsValidMenuChoice(userIntChoice, menu)) {
                  return userIntChoice;
               }
               else {
                  Console.WriteLine("\nInvalid menu option entered.");
               }
            }
            else {
               Console.WriteLine("Invalid input entered.");
            }
         }
      }

      public static bool IsValidMenuChoice(int userChoice, int menu) {
         switch (menu) {
            case 1:
               return (userChoice > 0 && userChoice <= 3) ? true : false;
            case 2:
               return (userChoice > 0 && userChoice <= 6) ? true : false;
            case 3:
               return (userChoice > 0 && userChoice <= 5) ? true : false;
            default:
               return false;
         }
      }

      public static void MainMenu(int menuChoice, ref int menuOption, 
         ref bool exitProgram) {
         switch (menuChoice) {
            case 1:
               menuOption = 2;
               break;
            case 2:
               menuOption = 3;
               break;
            case 3:
               exitProgram = true;
               Console.WriteLine("User has exited program.");
               break;
         }
      }

      public static void StandardMenu(int menuChoice, ref bool exitProgram) {
         switch (menuChoice) {
            case 1:
               break;
            case 2:
               break;
            case 3:
               break;
            case 4:
               break;
            case 5:
               break;
            case 6:
               break;
         }
      }

      public static void StudentMenu(int menuChoice, ref bool exitProgram) {
         switch (menuChoice) {
            case 1:
               break;
            case 2:
               break;
            case 3:
               break;
            case 4:
               break;
            case 5:
               break;
         }
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
