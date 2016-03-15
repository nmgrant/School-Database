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
                  StandardMenu(menuChoice, ref menuOptions);
                  break;
               case 3:
                  StudentMenu(menuChoice, ref menuOptions);
                  break;
               case 4:
                  StudentSubMenu(menuChoice, ref menuOptions);
                  break;
               case 5:
                  StandardSubMenu(menuChoice, ref menuOptions);
                  break;
            }
         } while (!exitProgram);


         /* HardCoded
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
               Console.WriteLine("5. Display all Students by StandardID");
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
            case 4:
               Console.WriteLine("Student Update Menu");
               Console.WriteLine("1. Search by ID");
               Console.WriteLine("2. Search by name");
               break;
            case 5:
               Console.WriteLine("Standard Update Menu");
               Console.WriteLine("1. Search by ID");
               Console.WriteLine("2. Search by name");
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
               } else {
                  Console.WriteLine("\nInvalid menu option entered.");
               }
            } else {
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
            case 4:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            case 5:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
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

      public static void StandardMenu(int menuChoice, ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               DisplayStandards();
               break;
            case 2:
               businessL.AddStandard(CreateStandard());
               break;
            case 3:
               menuOptions = 5;
               break;
            case 4:
               businessL.RemoveStandard(DeleteStandard());
               break;
            case 5:
               break;
            case 6:
               menuOptions = 1;
               Console.WriteLine("Returning to the Main Menu.");
               break;
         }
      }

      public static void StudentMenu(int menuChoice, ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               DisplayStudents();
               break;
            case 2:
               businessL.AddStudent(CreateStudent());
               break;
            case 3:
               menuOptions = 4;
               break;
            case 4:
               businessL.RemoveStudent(DeleteStudent());
               break;
            case 5:
               menuOptions = 1;
               Console.WriteLine("Returning to Main Menu.");
               break;
         }
      }

      public static void StandardSubMenu(int menuChoice, ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               businessL.UpdateStandard(UpdateStandard(1));
               break;
            case 2:
               businessL.UpdateStandard(UpdateStandard(2));
               break;
         }
         menuOptions = 2;
      }

      public static void StudentSubMenu(int menuChoice, ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               businessL.UpdateStudent(UpdateStudent(1));
               break;
            case 2:
               businessL.UpdateStudent(UpdateStudent(2));
               break;
         }
         menuOptions = 3;
      }

      public static void DisplayStandards() {
         Console.WriteLine("\nCurrent Standards:");
         foreach (var element in businessL.GetAllStandards()) {
            Console.WriteLine(element.StandardId + ": "
               + element.StandardName);
         }
         Console.WriteLine();
      }

      public static void DisplayStudents() {
         Console.WriteLine("\nCurrent Students:");
         foreach (var element in businessL.GetAllStudents()) {
            Console.WriteLine(element.StudentID + ": " + element.StudentName);
         }
         Console.WriteLine();
      }

      public static DataAccessLayer.Standard CreateStandard() {
         Console.Write("Enter a name: ");
         var name = Console.ReadLine();

         Console.Write("Enter a Standard Description: ");
         var standardDesc = Console.ReadLine();

         return new DataAccessLayer.Standard() {
            StandardName = name,
            Description = standardDesc
         };
      }

      public static DataAccessLayer.Student CreateStudent() {
         Console.Write("Enter a name: ");
         var name = Console.ReadLine();

         Console.Write("Enter a StandardId: ");
         var standardId = Int32.Parse(Console.ReadLine());

         return new DataAccessLayer.Student() {
            StudentName = name,
            StandardId = standardId
         };
      }

      public static DataAccessLayer.Standard DeleteStandard() {
         Console.Write("Enter the StandardID of the standard to delete: ");
         var standard = businessL.GetStandardByID(Int32.Parse(Console.ReadLine()));
         while (standard == null) {
            Console.WriteLine("That student was not found, please try again.");
            standard = businessL.GetStandardByID(Int32.Parse(Console.ReadLine()));
         }
         return standard;
      }

      public static DataAccessLayer.Student DeleteStudent() {
         Console.Write("Enter the StudentID of the student to delete: ");
         var student = businessL.GetStudentByID(Int32.Parse(Console.ReadLine()));
         while (student == null) {
            Console.WriteLine("That student was not found, please try again.");
            student = businessL.GetStudentByID(Int32.Parse(Console.ReadLine()));
         }
         return student;
      }

      public static DataAccessLayer.Standard UpdateStandard(int searchChoice) {

         var standard = AskForStandardInfo(searchChoice);
         while (standard == null) {
            Console.WriteLine("That standard does not exist.");
            standard = AskForStandardInfo(searchChoice);
         }

         Console.Write("Enter the new name (press enter if not updating): ");
         var name = Console.ReadLine();

         if (!name.Equals("")) {
            standard.StandardName = name;
         }

         Console.Write("Enter the new Standard Description"
          + " (press enter if not updating): ");

         string input = Console.ReadLine();

         if (input.Equals("")) {
            return standard;
         } else {
            standard.Description = input;
         }

         return standard;
      }

      static DataAccessLayer.Student UpdateStudent(int searchChoice) {

         var student = AskForStudentInfo(searchChoice);
         while (student == null) {
            Console.WriteLine("That student does not exist.");
            student = AskForStudentInfo(searchChoice);
         }

         Console.Write("Enter the new name (press enter if not updating): ");
         var name = Console.ReadLine();

         if (!name.Equals("")) {
            student.StudentName = name;
         }

         Console.Write("Enter the new StandardID"
          + " (press enter if not updating): ");

         string input = Console.ReadLine();

         if (input.Equals("")) {
            return student;
         } else {
            int standardId;
            while (!Int32.TryParse(input, out standardId) && !input.Equals("")) {
               Console.WriteLine("Invalid input.");
               Console.Write("Enter the new StandardID"
                  + " (press enter if not updating): ");
               input = Console.ReadLine();
            }
            if (!input.Equals("")) {
               student.StandardId = standardId;
            }
         }

         return student;
      }

      public static DataAccessLayer.Student AskForStudentInfo(int searchChoice) {
         if (searchChoice == 1) {
            Console.Write("Enter the StudentID of the student to update: ");
            return businessL.GetStudentByID(Int32.Parse(Console.ReadLine()));
         } else {
            Console.Write("Enter the name of the Student to update: ");
            return businessL.GetStudentByName(Console.ReadLine());
         }
      }

      public static DataAccessLayer.Standard AskForStandardInfo(int searchChoice) {
         if (searchChoice == 1) {
            Console.Write("Enter the StandardID of the standard to update: ");
            return businessL.GetStandardByID(Int32.Parse(Console.ReadLine()));
         } else {
            Console.Write("Enter the name of the Standard to update: ");
            return businessL.GetStandardByName(Console.ReadLine());
         }
      }
   }
}
