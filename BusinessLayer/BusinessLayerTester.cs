using System;

namespace BusinessLayer {
   class BusinessLayerTester {
      // Intializes a static BusinessLayer object to be utilized throughout
      // all the methods
      private static BusinessLayer businessL;

      static void Main(string[] args) {
         // Initializes businessL to a new BusinessLayer object
         businessL = new BusinessLayer();
         // Initializes the given menu to 1
         int menuOptions = 1, subMenuChoice = 0;
         // Initializes a menu choice variable
         int menuChoice;
         // Initializes a bool variable for exiting the program
         bool exitProgram = false;

         // Do, while loop to run until the user chooses to exit
         do {
            // Calls the MenuOptions() method with the given menu option as a
            // reference so the method has the ability to change it
            MenuOptions(ref menuOptions, subMenuChoice);
            // Calls the UserMenuChoice() method with the given menu option and
            // sets it to menu choice for the given options
            menuChoice = UserMenuChoice(menuOptions);

            // Switch, case to switch through the cases of menus depending on
            // the menu choice by the user
            switch (menuOptions) {
               // Case 1, calls the MainMenu() method with the given menu 
               // choice, a reference to the menu options, and reference to
               // exit the program
               case 1:
                  MainMenu(menuChoice, ref menuOptions, ref exitProgram);
                  break;
               // Case 2, calls the StandardMenu() method with the given menu
               // choice and a reference to the menu options
               case 2:
                  StandardMenu(menuChoice, ref menuOptions, ref subMenuChoice);
                  break;
               // Case 3, calls the StandardSearchMenu() method with the given
               // menu choice and a reference to the menu options
               case 3:
                  StandardSearchMenu(menuChoice, ref menuOptions);
                  break;
               // Case 4, calls the StandardUpdateMenu() method with the given
               // menu choice and a reference to the menu options
               case 4:
                  StandardUpdateMenu(menuChoice, ref menuOptions);
                  break;
               // Case 5, calls the StudentMenu() method with the given menu
               // choice and a reference to the menu options
               case 5:
                  StudentMenu(menuChoice, ref menuOptions, ref subMenuChoice);
                  break;
               // Case 6, calls the StudentSearchMenu() method with the given
               // menu choice and a reference to the menu options
               case 6:
                  StudentSearchMenu(menuChoice, ref menuOptions);
                  break;
               // Case 7, calls the StudentUpdateMenu() method with the given 
               // menu choice and a reference to the menu options
               case 7:
                  StudentUpdateMenu(menuChoice, ref menuOptions);
                  break;
               // Default case, to run MainMenu() by default
               default:
                  MainMenu(menuChoice, ref menuOptions, ref exitProgram);
                  break;
            }
            // While condition to break when exitProgram is true
         } while (!exitProgram);
      }

      public static void MenuOptions(ref int menu, int subMenu) {
         switch (menu) {
            case 1:
               Console.WriteLine("Menu:");
               Console.WriteLine("1. Standard Tables");
               Console.WriteLine("2. Student Tables");
               Console.WriteLine("3. Exit Program");
               menu = 1;
               break;
            case 2:
               Console.WriteLine("Standard Menu");
               Console.WriteLine("1. Display all current Standards");
               Console.WriteLine("2. Display all Students by StandardID");
               Console.WriteLine("3. Search for a Standard");
               Console.WriteLine("4. Create new Standard");
               Console.WriteLine("5. Update Standard");
               Console.WriteLine("6. Delete Standard");
               Console.WriteLine("7. Return to Main Menu");
               menu = 2;
               break;
            case 3:
               Console.WriteLine("Student Menu");
               Console.WriteLine("1. Display all current Students");
               Console.WriteLine("2. Search for a Student");
               Console.WriteLine("3. Create new Student");
               Console.WriteLine("4. Update Student");
               Console.WriteLine("5. Delete Student");
               Console.WriteLine("6. Return to Main Menu");
               menu = 5;
               break;
            case 4:
               if (subMenu == 1) {
                  Console.WriteLine("Standard Search Menu");
                  menu = 3;
               } else if (subMenu == 2) {
                  Console.WriteLine("Standard Update Menu");
                  menu = 4;
               } else if (subMenu == 3) {
                  Console.WriteLine("Student Search Menu");
                  menu = 6;
               } else if (subMenu == 4) {
                  Console.WriteLine("Student Update Menu");
                  menu = 7;
               }
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
               return (userChoice > 0 && userChoice <= 7) ? true : false;
            case 3:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            case 4:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            case 5:
               return (userChoice > 0 && userChoice <= 6) ? true : false;
            case 6:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            case 7:
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

      public static void StandardMenu(int menuChoice, ref int menuOptions,
         ref int subMenu) {
         switch (menuChoice) {
            case 1:
               DisplayStandards();
               menuOptions = 2;
               break;
            case 2:
               DisplayStandardsWithID();
               menuOptions = 2;
               break;
            case 3:
               menuOptions = 4;
               subMenu = 1;
               break;
            case 4:
               businessL.AddStandard(CreateStandard());
               menuOptions = 2;
               break;
            case 5:
               menuOptions = 4;
               subMenu = 2;
               break;
            case 6:
               businessL.RemoveStandard(DeleteStandard());
               menuOptions = 2;
               break;
            case 7:
               menuOptions = 1;
               Console.WriteLine("Returning to the Main Menu.");
               break;
         }
      }

      public static void StandardUpdateMenu(int menuChoice,
         ref int menuOptions) {
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

      public static void StandardSearchMenu(int menuChoice,
         ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               Console.WriteLine("Enter the StandardID to display:");
               int displayStandardID;
               while (!Int32.TryParse(Console.ReadLine(), out displayStandardID)) {
                  Console.WriteLine("Invalid input.");
                  Console.WriteLine("Enter the StandardID to display:");
               }

               Console.WriteLine("Standards with the StandardID "
                  + displayStandardID + ": ");

               var standardsWithID = businessL.SearchForStandard(s =>
                  s.StandardId == (displayStandardID));

               foreach (var elements in standardsWithID) {
                  Console.WriteLine(elements.StandardId + ": "
                     + elements.StandardName);
               }
               Console.WriteLine();
               break;
            case 2:
               Console.Write("Enter the Standard Name to display:");
               string standardSearch = "";

               while (standardSearch.Equals("")) {
                  standardSearch = Console.ReadLine();
               }

               var standardName = businessL.SearchForStandard(s =>
                  s.StandardName == (standardSearch));

               foreach (var elements in standardName) {
                  Console.WriteLine(elements.StandardName);
               }
               break;
         }
         menuOptions = 2;
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


      public static void StudentMenu(int menuChoice, ref int menuOptions,
         ref int subMenu) {
         switch (menuChoice) {
            case 1:
               DisplayStudents();
               menuOptions = 3;
               break;
            case 2:
               menuOptions = 4;
               subMenu = 3;
               break;
            case 3:
               businessL.AddStudent(CreateStudent());
               menuOptions = 3;
               break;
            case 4:
               menuOptions = 4;
               subMenu = 4;
               break;
            case 5:
               businessL.RemoveStudent(DeleteStudent());
               menuOptions = 3;
               break;
            case 6:
               menuOptions = 1;
               Console.WriteLine("Returning to Main Menu.");
               break;
         }
      }

      public static void StudentUpdateMenu(int menuChoice,
      ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               businessL.UpdateStudent(UpdateStudent(1));
               break;
            case 2:
               businessL.UpdateStudent(UpdateStudent(2));
               break;
         }
         menuOptions = 5;
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

      public static void StudentSearchMenu(int menuChoice,
         ref int menuOptions) {
         switch (menuChoice) {
            case 1:
               Console.WriteLine("Enter the StudentID to display:");
               int displayStudentID;
               while (!Int32.TryParse(Console.ReadLine(),
                  out displayStudentID)) {
                  Console.WriteLine("Invalid input.");
                  Console.WriteLine("Enter the StudentID to display:");
               }

               Console.WriteLine("Students with the StudentID "
                  + displayStudentID + ": ");

               var studentsWithID = businessL.SearchForStudent(s =>
                  s.StudentID == (displayStudentID));

               foreach (var elements in studentsWithID) {
                  Console.WriteLine(elements.StudentID + ": "
                     + elements.StudentName);
               }
               Console.WriteLine();
               break;
            case 2:
               Console.Write("Enter the Student Name to display:");
               string studentSearch = "";

               while (studentSearch.Equals("")) {
                  studentSearch = Console.ReadLine();
               }

               var studentName = businessL.SearchForStudent(s =>
                  s.StudentName == (studentSearch));

               foreach (var elements in studentName) {
                  Console.WriteLine(elements.StudentName.PadRight(10) + ": "
                     + "StandardID: " + elements.StandardId);
               }
               break;
         }
         menuOptions = 3;
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

      public static DataAccessLayer.Student UpdateStudent(int searchChoice) {
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

      public static DataAccessLayer.Student AskForStudentInfo(
         int searchChoice) {
         if (searchChoice == 1) {
            return businessL.GetStudentByID(GetIntegerInput("Enter the "
               + "StudentID of the student to update: "));
         } else {
            Console.Write("Enter the name of the Student to update: ");
            return businessL.GetStudentByName(Console.ReadLine());
         }
      }

      public static DataAccessLayer.Standard AskForStandardInfo(
         int searchChoice) {
         if (searchChoice == 1) {
            return businessL.GetStandardByID(GetIntegerInput("Enter the "
               + "StandardID of the standard to update: "));
         } else {
            Console.Write("Enter the name of the Standard to update: ");
            return businessL.GetStandardByName(Console.ReadLine());
         }
      }
   }
}
