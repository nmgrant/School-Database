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

      // MenuOptions() method that takes in a reference to the menu to print
      // out and a variable for the subMenu for case 4
      public static void MenuOptions(ref int menu, int subMenu) {
         switch (menu) {
            // Case 1, prints out the main menu to the user and sets menu to 1
            case 1:
               Console.WriteLine("Menu:");
               Console.WriteLine("1. Standard Tables");
               Console.WriteLine("2. Student Tables");
               Console.WriteLine("3. Exit Program");
               menu = 1;
               break;
            // Case 2, prints out the standard menu to the user and sets the 
            // menu to 2
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
            // Case 3, prints out the student menu to the user and sets the
            // menu to 5
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
            // Case 4, prints out the search menu based on the submenu that 
            // was called by the user using the subMenu variable
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
            // Default case, sets the menu to 1
            default:
               menu = 1;
               break;
         }
      }

      // UserMenuChoice() method to get the user's choice for a menu and 
      // validate the input for the menu
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

      // IsValidMenuChoice() method to bound check each of the menu options
      public static bool IsValidMenuChoice(int userChoice, int menu) {
         switch (menu) {
            // Case 1, bounds check for the Main menu
            case 1:
               return (userChoice > 0 && userChoice <= 3) ? true : false;
            // Case 2, bounds check for the Standard menu
            case 2:
               return (userChoice > 0 && userChoice <= 7) ? true : false;
            // Case 3, bounds check for the Standard search submenu
            case 3:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            // Case 4, bounds check for the Standard update submenu
            case 4:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            // Case 5, bounds check for the Student menu
            case 5:
               return (userChoice > 0 && userChoice <= 6) ? true : false;
            // Case 6, bounds check for the Student search submenu
            case 6:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            // Case 7, bounds check for the Student update submenu
            case 7:
               return (userChoice > 0 && userChoice <= 2) ? true : false;
            // Default case, returns false by default
            default:
               return false;
         }
      }

      // MainMenu() method taking in the user's menu choice, a reference to the
      // menu option, and a reference to the exitProgram variable to print out 
      // either the Standard or Student menu and exit the program if the user 
      // exits
      public static void MainMenu(int menuChoice, ref int menuOption,
         ref bool exitProgram) {
         switch (menuChoice) {
            // Case 1, sets menuOption to 2
            case 1:
               menuOption = 2;
               break;
            // Case 2, sets menuOption to 3
            case 2:
               menuOption = 3;
               break;
            // Case 3, sets the exitProgram to true
            case 3:
               exitProgram = true;
               Console.WriteLine("User has exited program.");
               break;
         }
      }

      // StandardMenu() method taking in the user's menu choice, a reference
      // to the menu option, and a reference to the submenu to call methods 
      // respective to the menu options
      public static void StandardMenu(int menuChoice, ref int menuOptions,
         ref int subMenu) {
         switch (menuChoice) {
            // Case 1, calls DisplayStandards() to display all the current
            // Standards and sets menuOptions to 2
            case 1:
               DisplayStandards();
               menuOptions = 2;
               break;
            // Case 2, calls DisplayStudentsWithID() to display the Students
            // with a given StandardID and sets menuOptions to 2 
            case 2:
               DisplayStudentsWithID();
               menuOptions = 2;
               break;
            // Case 3, sets menuOptions to 4 and subMenu to 1
            case 3:
               menuOptions = 4;
               subMenu = 1;
               break;
            // Case 4, calls CreateStandard() and adds the Standard to 
            // businessL and sets menuOptions to 2
            case 4:
               businessL.AddStandard(CreateStandard());
               menuOptions = 2;
               break;
            // Case 5, sets menuOptions to 4 and subMenu to 2
            case 5:
               menuOptions = 4;
               subMenu = 2;
               break;
            // Case 6, calls DeleteStandard() and removes the Standard from
            // businessL and sets menuOptions to 2
            case 6:
               businessL.RemoveStandard(DeleteStandard());
               menuOptions = 2;
               break;
            // Case 7, sets menuOptions to 1 and returns to the main menu
            case 7:
               menuOptions = 1;
               Console.WriteLine("Returning to the Main Menu.");
               break;
         }
      }

      // StandardUpdateMenu() method that takes in the menu choice and a 
      // reference to the menu options to update the given standard dependent 
      // on search by ID or name
      public static void StandardUpdateMenu(int menuChoice,
         ref int menuOptions) {
         switch (menuChoice) {
            // Case 1, calls UpdateStadard() to update the given Standard by ID
            case 1:
               businessL.UpdateStandard(UpdateStandard(1));
               break;
            // Case 2, calls UpdateStandard to update the given Standard by
            // name
            case 2:
               businessL.UpdateStandard(UpdateStandard(2));
               break;
         }
         // Sets menuOptions to 2
         menuOptions = 2;
      }

      // StandardSearchMenu() to search the Standard repository for a given 
      // StandardID or Standard Name with a menu choice and reference to the
      // menu options
      public static void StandardSearchMenu(int menuChoice,
         ref int menuOptions) {
         // Switch case to search by StandardID or Standard Name
         switch (menuChoice) {
            // Case 1, search the repository by StandardID
            case 1:
               Console.WriteLine("Enter the StandardID to display:");
               // Initialize a variable to hold the ID to be searched
               int displayStandardID;
               // While loop to parse the input from the user until it is an
               // int value
               while (!Int32.TryParse(Console.ReadLine(), 
                  out displayStandardID)) {
                  Console.WriteLine("Invalid input.");
                  Console.WriteLine("Enter the StandardID to display:");
               }

               Console.WriteLine("Standards with the StandardID "
                  + displayStandardID + ": ");

               // Sets a var variable to hold all IDs that match in the 
               // repository
               var standardsWithID = businessL.SearchForStandard(s =>
                  s.StandardId == (displayStandardID));

               // Foreach loop to run through standardsWithID and print out
               foreach (var elements in standardsWithID) {
                  Console.WriteLine(elements.StandardId + ": "
                     + elements.StandardName);
               }
               Console.WriteLine();
               break;
            // Case 2, search the repository by Standard Name
            case 2:
               Console.Write("Enter the Standard Name to display:");
               // Initialize a variable to hold the name to be searched
               string standardSearch = "";

               // While loop to run until a non empty string is entered
               while (standardSearch.Equals("")) {
                  standardSearch = Console.ReadLine();
               }

               // Sets a var variable to hold all the names that match in the
               // repository
               var standardName = businessL.SearchForStandard(s =>
                  s.StandardName == (standardSearch));

               // Foreach loop to run through standardName and print out
               foreach (var elements in standardName) {
                  Console.WriteLine(elements.StandardName);
               }
               break;
         }
         // Sets the menu options to 2
         menuOptions = 2;
      }

      // DisplayStandards() method to display all current standards
      public static void DisplayStandards() {
         Console.WriteLine("\nCurrent Standards:");
         // Calls GetAllStandards and for each element in businessL prints it
         foreach (var element in businessL.GetAllStandards()) {
            Console.WriteLine(element.StandardId + ": "
               + element.StandardName.PadRight(15) + " Description: "
               + element.Description);
         }
         Console.WriteLine();
      }

      // DisplayStudentsWithID() method to display all students with a given
      // StandardID
      public static void DisplayStudentsWithID() {
         Console.Write("Enter a StandardID to display all Students with "
            + "the same " + "StandardID: ");
         // Initialize a variable to hold the StandardID to be searched for
         int displayStandardID;

         // While loop to parse the input from the user until it is an
         // int value
         while (!Int32.TryParse(Console.ReadLine(), out displayStandardID)) {
            Console.WriteLine("Invalid input.");
            Console.Write("Enter a StandardID to display all Students with "
            + "the same " + "StandardID: ");
         }

         Console.WriteLine("\nStudents that have the StandardID "
            + displayStandardID + ":");

         // Sets a var variable to hold all Students that match in the 
         // repository
         var studentsWithID = businessL.SearchForStudent(s =>
         s.StandardId == (displayStandardID));

         // Foreach loop to run through studentsWithID and print out
         foreach (var elements in studentsWithID) {
            Console.WriteLine(elements.StudentID + ": "
               + elements.StudentName);
         }
         Console.WriteLine();
      }

      // CreateStandard() method that returns a new Standard
      public static DataAccessLayer.Standard CreateStandard() {
         // Grabs a name entered by the user
         Console.Write("Enter a name: ");
         var name = Console.ReadLine();

         // Grabs a description entered by the user
         Console.Write("Enter a Standard Description: ");
         var standardDesc = Console.ReadLine();

         // Returns the new Standard with the given data from the user
         return new DataAccessLayer.Standard() {
            StandardName = name,
            Description = standardDesc
         };
      }

      // UpdateStandard() method that takes in searchChoice to return the given
      // Standard and update it
      public static DataAccessLayer.Standard UpdateStandard(int searchChoice) {
         // Calls AskForStandardInfo() method and sets it to a var variable
         var standard = AskForStandardInfo(searchChoice);
         // While loop to run until the Standard that exists is entered
         while (standard == null) {
            Console.WriteLine("That standard does not exist.");
            standard = AskForStandardInfo(searchChoice);
         }

         // Grabs the new name for the Standard or if left empty, keeps the 
         // original name
         Console.Write("Enter the new name (press enter if not updating): ");
         var name = Console.ReadLine();

         // If the name is left blank, keeps the original name
         if (!name.Equals("")) {
            standard.StandardName = name;
         }

         // Grabs the new description for the Standard or if left empty, keeps
         // the original description
         Console.Write("Enter the new Standard Description"
          + " (press enter if not updating): ");
         string input = Console.ReadLine();

         // If the description is left blank, return the original description
         if (input.Equals("")) {
            return standard;
         } else {
            standard.Description = input;
         }

         // Return the updated Standard
         return standard;
      }

      // DeleteStandard() method to remove a given standard
      public static DataAccessLayer.Standard DeleteStandard() {
         // Calls GetStandardByID() with GetIntegerInput() to set the ID to 
         // search for the Standard to remove and sets it to a var variable
         var standard = businessL.GetStandardByID(GetIntegerInput("Enter the "
          + "StandardID of the standard to delete: "));
         // While loop to run until a Standard is found
         while (standard == null) {
            Console.WriteLine("That Standard was not found, please try again.");
            standard = businessL.GetStandardByID(GetIntegerInput("Enter the "
               + "StandardID of the Standard to delete: "));
         }
         // Return the Standard to be removed
         return standard;
      }


      // StudentMenu() method taking in the user's menu choice, a reference to 
      // the menu option, and a reference to the submenu to call methods
      // respective to the menu options
      public static void StudentMenu(int menuChoice, ref int menuOptions,
         ref int subMenu) {
         switch (menuChoice) {
            // Case 1, calls DisplayStudents() to display all current Students
            // and set menuOptions to 3
            case 1:
               DisplayStudents();
               menuOptions = 3;
               break;
            // Case 2, sets menuOptions to 4 and subMenu to 3
            case 2:
               menuOptions = 4;
               subMenu = 3;
               break;
            // Case 3, calls CreateStudent() and adds the Student to
            // businessL and sets menuOptions to 3
            case 3:
               businessL.AddStudent(CreateStudent());
               menuOptions = 3;
               break;
            // Case 4, sets menuOptions to 4 and subMenu to 4
            case 4:
               menuOptions = 4;
               subMenu = 4;
               break;
            // Case 5, calls DeleteStudent() and removes the given Student
            // from businessL and sets menuOptions to 3
            case 5:
               businessL.RemoveStudent(DeleteStudent());
               menuOptions = 3;
               break;
            // Case 6, sets menuOptions to 1 to return to the main menu
            case 6:
               menuOptions = 1;
               Console.WriteLine("Returning to Main Menu.");
               break;
         }
      }

      // StudentUpdateMenu() method that takes in the menu choice and a 
      // reference to the menu options to update the given Student dependent 
      // on search by ID or name
      public static void StudentUpdateMenu(int menuChoice,
      ref int menuOptions) {
         switch (menuChoice) {
            // Case 1, calls UpdateStadard() to update the given Standard by ID
            case 1:
               businessL.UpdateStudent(UpdateStudent(1));
               break;
            // Case 2, calls UpdateStadard() to update the given Standard by 
            // name
            case 2:
               businessL.UpdateStudent(UpdateStudent(2));
               break;
         }
         // Sets menuOptions to 5
         menuOptions = 5;
      }

      // DisplayStudents() method to display all current Students in businessL
      public static void DisplayStudents() {
         Console.WriteLine("\nCurrent Students:");
         Console.WriteLine("\nCurrent Standards:");
         // Calls GetAllStudents and for each element in businessL prints it
         foreach (var element in businessL.GetAllStudents()) {
            Console.WriteLine(element.StudentID + ": "
               + element.StudentName.PadRight(10) + "\t StandardID: "
               + element.StandardId);
         }
         Console.WriteLine();
      }

      // StudentSearchMenu() to search the Student repository for a given 
      // StudentID or Student Name with a menu choice and reference to the
      // menu options
      public static void StudentSearchMenu(int menuChoice,
         ref int menuOptions) {
         // Switch case to search by StudentID or Student Name
         switch (menuChoice) {
            // Case 1, search the repository by StandardID
            case 1:
               // Initialize a variable to hold the ID to be searched
               Console.WriteLine("Enter the StudentID to display:");
               int displayStudentID;
               // While loop to parse the input from the user until it is an
               // int value
               while (!Int32.TryParse(Console.ReadLine(),
                  out displayStudentID)) {
                  Console.WriteLine("Invalid input.");
                  Console.WriteLine("Enter the StudentID to display:");
               }

               Console.WriteLine("Students with the StudentID "
                  + displayStudentID + ": ");
               // Sets a var variable to hold all IDs that match in the 
               // repository
               var studentsWithID = businessL.SearchForStudent(s =>
                  s.StudentID == (displayStudentID));

               // Foreach loop to run through studentsWithID and print out
               foreach (var elements in studentsWithID) {
                  Console.WriteLine(elements.StudentID + ": "
                     + elements.StudentName);
               }
               Console.WriteLine();
               break;
            // Case 2, search the repository by Standard Name
            case 2:
               Console.Write("Enter the Student Name to display:");
               // Initialize a variable to hold the name to be searched
               string studentSearch = "";

               // While loop to run until a non empty string is entered
               while (studentSearch.Equals("")) {
                  studentSearch = Console.ReadLine();
               }

               // Sets a var variable to hold all the names that match in the
               // repository
               var studentName = businessL.SearchForStudent(s =>
                  s.StudentName == (studentSearch));

               // Foreach loop to run through standardName and print out
               foreach (var elements in studentName) {
                  Console.WriteLine(elements.StudentName.PadRight(10) + ": "
                     + "StandardID: " + elements.StandardId);
               }
               break;
         }
         // Sets menuOptions to 3
         menuOptions = 3;
      }

      // CreateStudentd() method that returns a new Student
      public static DataAccessLayer.Student CreateStudent() {
         // Grabs a name entered by the user
         Console.Write("Enter a Name: ");
         var name = Console.ReadLine();

         // Grabs a StandardID from the user
         var standardId = GetIntegerInput("Enter a StandardID: ");
         
         // Returns the new Student with the given data from the user
         return new DataAccessLayer.Student() {
            StudentName = name,
            StandardId = standardId
         };
      }

      // UpdateStudent() method that takes in searchChoice to return the given
      // Student and update it
      public static DataAccessLayer.Student UpdateStudent(int searchChoice) {
         // Calls AskForStudentInfo() method and sets it to a var variable
         var student = AskForStudentInfo(searchChoice);
         // While loop to run until the Student that exists is entered
         while (student == null) {
            Console.WriteLine("That student does not exist.");
            student = AskForStudentInfo(searchChoice);
         }

         // Grabs the new name for the Student or if left empty, keeps the 
         // original name
         Console.Write("Enter the new name (press enter if not updating): ");
         var name = Console.ReadLine();

         // If the name is left blank, keeps the original name
         if (!name.Equals("")) {
            student.StudentName = name;
         }

         // Grabs the new StandardID for the Student or if left empty, keeps
         // the original StandardID
         int standardId = GetIntegerInput("Enter the new StandardID"
               + " (press enter if not updating): ");

         // If the standardID is left blank, return the original standrdID
         if (standardId == -1) {
            return student;
         } else {
            student.StandardId = standardId;
         }

         // Return the updated Student
         return student;
      }

      // DeleteStudent() method to delete a given Student
      public static DataAccessLayer.Student DeleteStudent() {
         // Calls GetStudentByID() with GetIntegerInput() to set the ID to 
         // search for the Student to remove and sets it to a var variable
         var student = businessL.GetStudentByID(GetIntegerInput("Enter the " +
            "StudentID of the student to delete: "));
         
         // While loop to run until a Standard is found
         while (student == null) {
            Console.WriteLine("That student was not found, please try again.");
            student = businessL.GetStudentByID(GetIntegerInput("Enter the " +
            "StudentID of the student to delete: "));
         }
         // Return the student to be removed
         return student;
      }

      // GetIntegerInput() method that takes in a string message to print out
      // to the user and verify that the input from the user is an int value
      public static int GetIntegerInput(string prompt) {
         Console.Write(prompt);

         int standardId;
         string input = Console.ReadLine();

         // While loop to run through continiously until an int value is 
         // entered by the user
         while (!Int32.TryParse(input, out standardId) && !input.Equals("")) {
            Console.WriteLine("Invalid input.");
            Console.Write(prompt);
            input = Console.ReadLine();
         }
         // If the StandardID is left empty, returns -1
         if (input.Equals("")) {
            standardId = -1;
         }
         // Returns the new standardID
         return standardId;
      }
     
      // AskForStudentInfo() method to either search by ID or by name and print
      // out the corresponding message and then return the Student
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

      // AskForStandardInfo() method to either search by ID or by name and 
      // print out the corresponding message and then return the Standard
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
