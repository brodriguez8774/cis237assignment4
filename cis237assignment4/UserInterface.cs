// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    /// <summary>
    /// Handles all display to user and reading of user input.
    /// Having one class handle everything UI helps create consistency.
    /// 
    /// Note: Having the interface methods accept parameters instead of directly calling static variables prevents the
    /// interface from having to directly access multiple classes itself. Preferably, only RunProgram will access multiple classes
    /// due to it being the "binding" between all the classes.
    /// 
    /// Instead, Interface just tells RunProgram what it needs to work and never deals directly with other classes.
    /// </summary>
    static class UserInterface
    {
        #region Variables

        private static string userInputString;
        private static int previousListSizeInt;

        #endregion



        #region Constructor



        #endregion



        #region Properties



        #endregion



        #region Private Methods

        /// <summary>
        /// Sets cursor position for menus.
        /// </summary>
        private static void SetMenuCursor()
        {
            Console.SetCursorPosition(0, 1);
        }

        private static void ResetMenuDisplay()
        {
            // Section to remove everything currently displayed.
            SetMenuCursor();
            Console.WriteLine(
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine);

            // Section to add back "esc to go back" display section.
            // Recreated each time incase a menu string at some point is too long and writes over it.
            SetMenuCursor();
            Console.WriteLine("Type 'esc' at any point to exit out. ".PadLeft(Console.WindowWidth - 1));

            // Sets cursor for new menu to actually display.
            SetMenuCursor();
        }

        private static void ResetDroidDisplay()
        {

        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Gets user input from console.
        /// </summary>
        /// <returns>String of user's input.</returns>
        public static string GetUserInput()
        {
            Console.SetCursorPosition(1, 9);

            userInputString = Console.ReadLine().Trim().ToLower();
            
            // Removing of user input after recieving it.
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("".PadRight(Console.WindowWidth - 1));

            return userInputString;
        }

        /// <summary>
        /// Displays a line to console.
        /// </summary>
        /// <param name="displayString">String to display.</param>
        public static void DisplayLine(string displayString)
        {
            ClearDisplayLine();
            Console.WriteLine(displayString);
        }

        /// <summary>
        /// Displays an error line to console.
        /// </summary>
        /// <param name="displayString">String of error to display.</param>
        public static void DisplayError(string displayString)
        {
            ClearDisplayLine();

            Console.SetCursorPosition(1, 8);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(displayString.PadRight(Console.WindowWidth - 1));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Clears display line from console.
        /// </summary>
        public static void ClearDisplayLine()
        {
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("".PadRight(Console.WindowWidth - 1));
        }

        /// <summary>
        /// Struct to hold overbloated list of menus.
        /// </summary>
        public struct Menus
        {
            /// <summary>
            /// Displays Main Menu to user.
            /// </summary>
            public static void DisplayMainMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Select an option: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Purchase Droid" + Environment.NewLine +
                    "   2) Display Full Reciept" + Environment.NewLine +
                    "   3) Display Single Item" + Environment.NewLine +
                    "   4) New Customer" + Environment.NewLine +
                    "   5) Exit");
            }

            /// <summary>
            /// Displays droid Type selection to user.
            /// </summary>
            public static void DisplayTypeSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Select a Droid Type: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Protocol Droid" + Environment.NewLine +
                    "   2) Utility Droid" + Environment.NewLine +
                    "   3) Janitor Droid" + Environment.NewLine +
                    "   4) Astromech Droid" + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Model selection to user.
            /// </summary>
            /// <param name="model1">Droid Model 1.</param>
            /// <param name="model2">Droid Model 2.</param>
            public static void DisplayModelSelectionMenu(string model1, string model2, string model3)
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Select a Droid Model: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) " + model1 + Environment.NewLine +
                    "   2) " + model2 + Environment.NewLine +
                    "   3) " + model3 + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Material selection to user.
            /// </summary>
            /// <param name="material1">Droid Material 1.</param>
            /// <param name="material2">Droid Material 2.</param>
            /// <param name="material3">Droid Material 3.</param>
            /// <param name="material4">Droid Material 4.</param>
            /// <param name="material5">Droid Material 5.</param>
            public static void DisplayMaterialSelectionMenu(string material1, string material2, string material3, string material4, string material5)
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Select a Droid Material: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) " + material1 + Environment.NewLine +
                    "   2) " + material2 + Environment.NewLine +
                    "   3) " + material3 + Environment.NewLine +
                    "   4) " + material4 + Environment.NewLine +
                    "   5) " + material5 + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Color selection to user.
            /// </summary>
            /// <param name="color1">Droid Color 1.</param>
            /// <param name="color2">Droid Color 2.</param>
            /// <param name="color3">Droid Color 3.</param>
            /// <param name="color4">Droid Color 4.</param>
            /// <param name="color5">Droid Color 5.</param>
            public static void DisplayColorSelectionMenu(string color1, string color2, string color3, string color4, string color5)
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Select a Droid Color: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) " + color1 + Environment.NewLine +
                    "   2) " + color2 + Environment.NewLine +
                    "   3) " + color3 + Environment.NewLine +
                    "   4) " + color4 + Environment.NewLine +
                    "   5) " + color5 + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Language selection to user.
            /// </summary>
            /// <param name="langSelection1">Droid Language 1.</param>
            /// <param name="langSelection2">Droid Language 2.</param>
            /// <param name="langSelection3">Droid Language 3.</param>
            /// <param name="langSelection4">Droid Language 4.</param>
            public static void DisplayLanguageSelectionMenu(int langSelection1, int langSelection2, int langSelection3, int langSelection4)
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Select number of Built in Languages: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) " + langSelection1 + Environment.NewLine +
                    "   2) " + langSelection2 + Environment.NewLine +
                    "   3) " + langSelection3 + Environment.NewLine +
                    "   4) " + langSelection4 + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Tool Box selection to user.
            /// </summary>
            public static void DisplayToolBoxSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Add Toolbox Functionality? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Yes" + Environment.NewLine +
                    "   2) No" +Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Computer Connection selection to user.
            /// </summary>
            public static void DisplayComputerConnectionSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Add Network Functionality? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Yes" + Environment.NewLine +
                    "   2) No" + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Arm selection to user.
            /// </summary>
            public static void DisplayArmSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Add Mechanical Arm Functionality? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Yes" + Environment.NewLine +
                    "   2) No" + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Color selection to user.
            /// </summary>
            public static void DisplayTrashCompactorSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Add Trash Compactor Functionality? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Yes" + Environment.NewLine +
                    "   2) No" + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Vacuum selection to user.
            /// </summary>
            public static void DisplayVacuumSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Add Vacuum Functionality? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Yes" + Environment.NewLine +
                    "   2) No" + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Fire Extinguisher selection to user.
            /// </summary>
            public static void DisplayFireExtinguisherSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Add built in Fire Extinguisher? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   1) Yes" + Environment.NewLine +
                    "   2) No" + Environment.NewLine);
            }

            /// <summary>
            /// Displays droid Ship-outfitting Number selection to user.
            /// </summary>
            public static void DisplayNumberOfShipsSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine(
                    "   Program for how many ship types? " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   Note: We can only program up to 9 ship types.");
            }

            public static void DisplaySingleDroidSelectionMenu()
            {
                ResetMenuDisplay();

                Console.WriteLine("   Input Droid Number: " + Environment.NewLine +
                    "" + Environment.NewLine +
                    "   If needed, droid numbers can be viewed on the reciept." + Environment.NewLine);
            }
        }


        /// <summary>
        /// Displays list of droids to console.
        /// </summary>
        /// <param name="displayString">String of droids to display.</param>
        /// <param name="currentListSize">Current size of droid list.</param>
        public static void DisplayList(string displayString, int currentListSize)
        {
            ClearList();
            previousListSizeInt = currentListSize;

            Console.SetCursorPosition(0, 10);

            Console.WriteLine(" ".PadRight(5) + "Type".PadRight(11) + "Material".PadRight(11) + "Model".PadRight(10) + "Color".PadRight(10) + "Total Cost".PadLeft(10) + Environment.NewLine);

            Console.WriteLine(displayString);
        }

        /// <summary>
        /// Clears currently displayed list of androids.
        /// </summary>
        public static void ClearList()
        {
            // Clear lines equal to size of last displayed droid list.
            Console.SetCursorPosition(0, 10);
            int index = 0;
            while (index < previousListSizeInt + 5)
            {
                Console.WriteLine("".PadRight(Console.WindowWidth - 1));
                index++;
            }

        }

        /// <summary>
        /// Displays list of droids to console.
        /// </summary>
        /// <param name="displayString">String of droids to display.</param>
        /// <param name="currentListSize">Number of items which effect droid's price.</param>
        public static void DisplaySingleDroidInfo(string displayString, int numberOfItemsForDroid, decimal totalCost)
        {
            ClearList();
            previousListSizeInt = numberOfItemsForDroid;

            Console.SetCursorPosition(0, 10);

            Console.WriteLine(" ".PadRight(5) + "Type".PadRight(11) + "Material".PadRight(11) + "Model".PadRight(10) + "Color".PadRight(10) + "Base Cost".PadLeft(10) + Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
                "".PadRight(5) + "Feature".PadRight(25) + "Selection".PadRight(17) + "Cost".PadLeft(10));

            Console.SetCursorPosition(0, 11);
            Console.WriteLine(displayString);

            Console.WriteLine("".PadRight(5) + "Total Droid Cost: ".PadRight(25) + totalCost.ToString("C").PadLeft(15));
        }

        #endregion

    }
}
