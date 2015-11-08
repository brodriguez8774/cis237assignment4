// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    /// <summary>
    /// Handles main operations of program.
    /// </summary>
    class RunProgram
    {
        #region Variables

        private bool runProgram;
        private bool menusBool;         // Used to exit back to main menu if user decides to. True to stay in menus. False if user typed to exit.
        string displayString;

        private DroidCollection droidCollection;

        // Variables for getting/saving user input.
        private string userInputString;

        private string selectedMaterialString;
        private string selectedModelString;
        private string selectedColorString;
        private int selectedLanguageInt;
        private bool toolBoxBool;
        private bool computerConnectionBool;
        private bool armBool;
        private bool trashCompactorBool;
        private bool vacuumBool;
        private bool fireExtinguisherBool;
        private int selectedNumberOfShipsInt;
        
        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public RunProgram()
        {
            runProgram = true;
            Run();
        }

        #endregion



        #region Properties



        #endregion



        #region Methods

        /// <summary>
        /// Holds program in loop until exit is chosen.
        /// </summary>
        private void Run()
        {
            ResetList();
            while (runProgram)
            {
                // Resets/initializes menu bool to allow user to stay in menus.
                menusBool = true;

                UserInterface.Menus.DisplayMainMenu();
                userInputString = UserInterface.GetUserInput();
                MainMenuSelection();
            }
        }

        /// <summary>
        /// Handles Main Menu Selection.
        /// </summary>
        private void MainMenuSelection()
        {
            switch (userInputString)
            {
                case "1":
                    PurchaseDroid();
                    break;
                case "2":
                    DisplayReciept();
                    break;
                case "3":
                    DisplaySingle();
                    break;
                case "4":
                    ResetList();
                    break;
                case "5":
                    Exit();
                    break;
                case "esc":
                    Exit();
                    break;
                default:
                    UserInterface.DisplayError("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// User selection to add a new droid to list.
        /// </summary>
        private void PurchaseDroid()
        {
            UserInterface.ClearDisplayLine();
            DroidTypeSelection();
        }

        /// <summary>
        /// Displays information for full droid list.
        /// </summary>
        private void DisplayReciept()
        {
            UserInterface.ClearDisplayLine();

            if (droidCollection.DroidList[0] != null)
            {
                DisplayFullList();
            }
            else
            {
                UserInterface.DisplayError("There is no reciept to display.");
            }
        }

        /// <summary>
        /// Displays information for single droid.
        /// </summary>
        private void DisplaySingle()
        {
            UserInterface.ClearDisplayLine();

            if (droidCollection.DroidList[0] != null)
            {
                UserInterface.Menus.DisplaySingleDroidSelectionMenu();

                userInputString = UserInterface.GetUserInput();
                try
                {
                    int tempInt = Convert.ToInt32(userInputString);

                    if (tempInt > 0 && tempInt <= droidCollection.DroidListSize)
                    {
                        tempInt--;
                        DisplaySingleDroid(tempInt);
                    }
                    else
                    {
                        UserInterface.DisplayError("There is no droid associated with that number.");
                    }
                }
                catch
                {
                    UserInterface.DisplayError("You must enter a number.");
                }
            }
            else
            {
                UserInterface.DisplayError("There are no droids to display.");
            }
        }

        /// <summary>
        /// Creates new android list and removes all information pertaining to old one.
        /// </summary>
        private void ResetList()
        {
            UserInterface.ClearDisplayLine();
            UserInterface.ClearList();
            droidCollection = new DroidCollection();
        }

        /// <summary>
        /// Exits program.
        /// </summary>
        private void Exit()
        {
            runProgram = false;
        }

        /// <summary>
        /// Handles user selection of droid Type.
        /// </summary>
        private void DroidTypeSelection()
        {
            UserInterface.Menus.DisplayTypeSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    PurchaseProtocol();

                    // After user selects values for droid, actually create it, add it to the collection, and calculate the various associated prices.
                    if (menusBool)
                    {
                        UserInterface.ClearDisplayLine();
                        IDroid aDroid = new Droid_Protocol(selectedMaterialString, selectedModelString, selectedColorString, selectedLanguageInt);
                        droidCollection.AddDroid(aDroid);
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateFeatures();
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateTotalCost();
                    }
                    break;
                case "2":
                    PurchaseUtility();

                    // After user selects values for droid, actually create it, add it to the collection, and calculate the various associated prices.
                    if (menusBool)
                    {
                        UserInterface.ClearDisplayLine();
                        IDroid aDroid = new Droid_Utility(selectedMaterialString, selectedModelString, selectedColorString, toolBoxBool, computerConnectionBool, armBool);
                        droidCollection.AddDroid(aDroid);
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateFeatures();
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateTotalCost();
                    }
                    break;
                case "3":
                    PurchaseJanitor();

                    // After user selects values for droid, actually create it, add it to the collection, and calculate the various associated prices.
                    if (menusBool)
                    {
                        UserInterface.ClearDisplayLine();
                        IDroid aDroid = new Droid_Janitor(selectedMaterialString, selectedModelString, selectedColorString, toolBoxBool, computerConnectionBool, armBool, trashCompactorBool, vacuumBool);
                        droidCollection.AddDroid(aDroid);
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateFeatures();
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateTotalCost();
                    }
                    break;
                case "4":
                    PurchaseAstromech();

                    // After user selects values for droid, actually create it, add it to the collection, and calculate the various associated prices.
                    if (menusBool)
                    {
                        UserInterface.ClearDisplayLine();
                        IDroid aDroid = new Droid_Astromech(selectedMaterialString, selectedModelString, selectedColorString, toolBoxBool, computerConnectionBool, armBool, fireExtinguisherBool, selectedNumberOfShipsInt);
                        droidCollection.AddDroid(aDroid);
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateFeatures();
                        droidCollection.DroidList[droidCollection.DroidListSize - 1].CalculateTotalCost();
                    }
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    break;
                default:
                    UserInterface.DisplayError("Invalid selection.");
                    DroidTypeSelection();
                    break;
            }
        }

        /// <summary>
        /// Methods to run if purchasing any kind of droid at all (generic).
        /// </summary>
        private void PurchaseGeneric()
        {
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                ModelSelection();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                MaterialSelection();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                ColorSelection();
            }

        }

        /// <summary>
        /// Methods to run if purchasing a droid of type Protocol.
        /// </summary>
        private void PurchaseProtocol()
        {
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                PurchaseGeneric();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                LanguageSelection();
            }
        }

        /// <summary>
        /// Methods to run if purchasing a droid of type Utility.
        /// </summary>
        private void PurchaseUtility()
        {
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                PurchaseGeneric();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                ToolBoxSelection();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                CompConnectionSelection();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                ArmSelection();
            }
        }

        /// <summary>
        /// Methods to run if purchasing a droid of type Janitor.
        /// </summary>
        private void PurchaseJanitor()
        {
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                PurchaseUtility();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                TrashCompactorSelection();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                VacuumSelection();
            }
        }

        /// <summary>
        /// Methods to run if purchasing a droid of type Astromech.
        /// </summary>
        private void PurchaseAstromech()
        {
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                PurchaseUtility();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                FireExtinguisherSelection();
            }
            if (menusBool)
            {
                UserInterface.ClearDisplayLine();
                NumberOfShipsSelection();
            }
        }

        /// <summary>
        /// Displays full list of droids.
        /// </summary>
        private void DisplayFullList()
        {
            displayString = "";
            int index = 0;

            foreach (Droid droid in droidCollection.DroidList)
            {
                if (droid != null)
                {
                    index++;
                    displayString += (" "+ index + ") ").PadRight(5) + droid.DisplayShortToString();
                }
            }

            UserInterface.DisplayList(displayString, index);
        }

        /// <summary>
        /// Displays information regarding a single droid.
        /// </summary>
        private void DisplaySingleDroid(int index)
        {
            displayString = droidCollection.DroidList[index].DisplayLongToString();
            UserInterface.DisplaySingleDroidInfo(displayString, droidCollection.DroidList[index].NumberOfItems, droidCollection.DroidList[index].TotalCost);
        }


        #region Individual Feature Selections

        /// <summary>
        /// Handles user selection of droid Model.
        /// </summary>
        private void ModelSelection()
        {
            UserInterface.Menus.DisplayModelSelectionMenu(Droid.MODEL_1_STRING, Droid.MODEL_2_STRING, Droid.MODEL_3_STRING);
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    selectedModelString = Droid.MODEL_1_STRING;
                    break;
                case "2":
                    selectedModelString = Droid.MODEL_2_STRING;
                    break;
                case "3":
                    selectedModelString = Droid.MODEL_3_STRING;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    ModelSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Material.
        /// </summary>
        private void MaterialSelection()
        {
            UserInterface.Menus.DisplayMaterialSelectionMenu(Droid.MATERIAL_1_STRING, Droid.MATERIAL_2_STRING, Droid.MATERIAL_3_STRING, Droid.MATERIAL_4_STRING, Droid.MATERIAL_5_STRING);
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    selectedMaterialString = Droid.MATERIAL_1_STRING;
                    break;
                case "2":
                    selectedMaterialString = Droid.MATERIAL_2_STRING;
                    break;
                case "3":
                    selectedMaterialString = Droid.MATERIAL_3_STRING;
                    break;
                case "4":
                    selectedMaterialString = Droid.MATERIAL_4_STRING;
                    break;
                case "5":
                    selectedMaterialString = Droid.MATERIAL_5_STRING;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    MaterialSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Color.
        /// </summary>
        private void ColorSelection()
        {
            UserInterface.Menus.DisplayColorSelectionMenu(Droid.COLOR_1_STRING, Droid.COLOR_2_STRING, Droid.COLOR_3_STRING, Droid.COLOR_4_STRING, Droid.COLOR_5_STRING);
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    selectedColorString = Droid.COLOR_1_STRING;
                    break;
                case "2":
                    selectedColorString = Droid.COLOR_2_STRING;
                    break;
                case "3":
                    selectedColorString = Droid.COLOR_3_STRING;
                    break;
                case "4":
                    selectedColorString = Droid.COLOR_4_STRING;
                    break;
                case "5":
                    selectedColorString = Droid.COLOR_5_STRING;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection");
                    ColorSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Language.
        /// </summary>
        private void LanguageSelection()
        {
            UserInterface.Menus.DisplayLanguageSelectionMenu(Droid_Protocol.LANGUAGE_SELECTION_1, Droid_Protocol.LANGUAGE_SELECTION_2, Droid_Protocol.LANGUAGE_SELECTION_3, Droid_Protocol.LANGUAGE_SELECTION_4);
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    selectedLanguageInt = Droid_Protocol.LANGUAGE_SELECTION_1;
                    break;
                case "2":
                    selectedLanguageInt = Droid_Protocol.LANGUAGE_SELECTION_2;
                    break;
                case "3":
                    selectedLanguageInt = Droid_Protocol.LANGUAGE_SELECTION_3;
                    break;
                case "4":
                    selectedLanguageInt = Droid_Protocol.LANGUAGE_SELECTION_4;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection");
                    LanguageSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Tool Box.
        /// </summary>
        private void ToolBoxSelection()
        {
            UserInterface.Menus.DisplayToolBoxSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    toolBoxBool = true;
                    break;
                case "2":
                    toolBoxBool = false;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    ToolBoxSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Computer Connection.
        /// </summary>
        private void CompConnectionSelection()
        {
            UserInterface.Menus.DisplayComputerConnectionSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    computerConnectionBool = true;
                    break;
                case "2":
                    computerConnectionBool = false;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    CompConnectionSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Arm.
        /// </summary>
        private void ArmSelection()
        {
            UserInterface.Menus.DisplayArmSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    armBool = true;
                    break;
                case "2":
                    armBool = false;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    ArmSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Trash Compactor.
        /// </summary>
        private void TrashCompactorSelection()
        {
            UserInterface.Menus.DisplayTrashCompactorSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    trashCompactorBool = true;
                    break;
                case "2":
                    trashCompactorBool = false;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    TrashCompactorSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Vacuum.
        /// </summary>
        private void VacuumSelection()
        {
            UserInterface.Menus.DisplayVacuumSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    vacuumBool = true;
                    break;
                case "2":
                    vacuumBool = false;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    VacuumSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Fire Extinguisher.
        /// </summary>
        private void FireExtinguisherSelection()
        {
            UserInterface.Menus.DisplayFireExtinguisherSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    fireExtinguisherBool = true;
                    break;
                case "2":
                    fireExtinguisherBool = false;
                    break;
                case "esc":
                    UserInterface.ClearDisplayLine();
                    menusBool = false;
                    break;
                default:
                    UserInterface.DisplayError("Invalid Selection.");
                    FireExtinguisherSelection();
                    break;
            }
        }

        /// <summary>
        /// Handles user selection of droid Ship-outfitting number.
        /// </summary>
        private void NumberOfShipsSelection()
        {
            UserInterface.Menus.DisplayNumberOfShipsSelectionMenu();
            userInputString = UserInterface.GetUserInput();

            // If user does not want to back out of menu.
            if (userInputString != "esc")
            {
                // Attempt to convert user input to int.
                try
                {
                    int temptInt = Convert.ToInt32(userInputString);
                    // Makes sure selection is between 0 and 10.
                    if (temptInt > 0 && temptInt < 10)
                    {
                        selectedNumberOfShipsInt = temptInt;
                    }
                    else
                    {
                        UserInterface.DisplayError("Must be between 0 and 10.");
                        NumberOfShipsSelection();
                    }
                }
                catch
                {
                    UserInterface.DisplayError("Not a valid number.");
                    NumberOfShipsSelection();
                }
            }
            else
            {
                UserInterface.ClearDisplayLine();
                menusBool = false;
            }
        }

        #endregion


        #endregion

    }
}
