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
               DisplayStandardsWithID();
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
               + element.StandardName.PadRight(15) + " Description: "
               + element.Description);
         }
         Console.WriteLine();
      }

      public static void DisplayStandardsWithID() {
         Console.Write("Enter a StandardID to display all Students with "
            + "the same " + "StandardID: ");

         int displayStandardID;

         while (!Int32.TryParse(Console.ReadLine(), out displayStandardID)) {
            Console.WriteLine("Invalid input.");
            Console.Write("Enter a StandardID to display all Students with "
            + "the same " + "StandardID: ");
         }

         Console.WriteLine("\nStudents that have the StandardID "
            + displayStandardID + ":");

         var standardsWithID = businessL.SearchForStudent(s =>
         s.StandardId == (displayStandardID));

         foreach (var elements in standardsWithID) {
            Console.WriteLine(elements.StudentID + ": "
               + elements.StudentName);
         }
         Console.WriteLine();
      }

      public static void DisplayStudents() {
         Console.WriteLine("\nCurrent Students:");
         foreach (var element in businessL.GetAllStudents()) {
            Console.WriteLine(element.StudentID + ": "
               + element.StudentName.PadRight(10) + "\t StandardID: "
               + element.StandardId);
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
         Console.Write("Enter a Name: ");
         var name = Console.ReadLine();

         var standardId = GetIntegerInput("Enter a StandardID: ");

         return new DataAccessLayer.Student() {
            StudentName = name,
            StandardId = standardId
         };
      }

      public static DataAccessLayer.Standard DeleteStandard() {
         var standard = businessL.GetStandardByID(GetIntegerInput("Enter the "
          + "StandardID of the standard to delete: "));
         while (standard == null) {
            Console.WriteLine("That student was not found, please try again.");
            standard = businessL.GetStandardByID(GetIntegerInput("Enter the "
               + "StandardID of the standard to delete: "));
         }
         return standard;
      }

      public static DataAccessLayer.Student DeleteStudent() {
         var student = businessL.GetStudentByID(GetIntegerInput("Enter the " +
            "StudentID of the student to delete: "));

         while (student == null) {
            Console.WriteLine("That student was not found, please try again.");
            student = businessL.GetStudentByID(GetIntegerInput("Enter the " +
            "StudentID of the student to delete: "));
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

         int standardId = GetIntegerInput("Enter the new StandardID"
               + " (press enter if not updating): ");

         if (standardId == -1) {
            return student;
         } else {
            student.StandardId = standardId;
         }

         return student;
      }

      public static int GetIntegerInput(string prompt) {
         Console.Write(prompt);

         int standardId;

         string input = Console.ReadLine();

         while (!Int32.TryParse(input, out standardId) && !input.Equals("")) {
            Console.WriteLine("Invalid input.");
            Console.Write(prompt);
            input = Console.ReadLine();
         }
         if (input.Equals("")) {
            standardId = -1;
         }
         return standardId;
      }

      public static DataAccessLayer.Student AskForStudentInfo(int searchChoice) {
         if (searchChoice == 1) {
            return businessL.GetStudentByID(GetIntegerInput("Enter the "
               + "StudentID of the student to update: "));
         } else {
            Console.Write("Enter the name of the Student to update: ");
            return businessL.GetStudentByName(Console.ReadLine());
         }
      }

      public static DataAccessLayer.Standard AskForStandardInfo(int searchChoice) {
         if (searchChoice == 1) {
            return businessL.GetStandardByID(GetIntegerInput("Enter the StandardID of the standard to update: "));
         } else {
            Console.Write("Enter the name of the Standard to update: ");
            return businessL.GetStandardByName(Console.ReadLine());
         }
      }

   }
}
