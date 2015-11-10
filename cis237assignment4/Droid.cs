// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Abstract class for Droids. Handles "higher level" thinking/rules.
    /// Derives from IDroid interface.
    /// </summary>
    abstract class Droid : IDroid
    {
        #region Variables

        protected decimal baseCostDecimal;                  // Cost of droid before any extra features. IE, just the material, model, and color cost.
        protected decimal totalCostDecimal;                 // Full cost of droid, including all extra features.
        protected decimal costPerFeatureDecimal = 10;       // Standard cost per most features.
        protected int numberOfItemsInt;                     // Number of individual items influencing droid price.
        public string droidTypeString;

        // All the necessary variables for material selection.
        protected string selectedMaterialString;
        private decimal selectedMaterialDecimal;
        public static string MATERIAL_1_STRING = "Tin";
        public static string MATERIAL_2_STRING = "Steel";
        public static string MATERIAL_3_STRING = "Titanium";
        public static string MATERIAL_4_STRING = "Mythril";
        public static string MATERIAL_5_STRING = "Unobtanium";

        // All the necessary variables for model selection.
        protected string selectedModelString;
        protected decimal selectedModelDecimal;
        public static string MODEL_1_STRING = "TI-84";
        public static string MODEL_2_STRING = "CAT5";
        public static string MODEL_3_STRING = "M7";

        // All the necessary variables for color selection.
        protected string selectedColorString;
        private decimal selectedColorDecimal;
        public static string COLOR_1_STRING = "White";
        public static string COLOR_2_STRING = "Black";
        public static string COLOR_3_STRING = "Blue";
        public static string COLOR_4_STRING = "Red";
        public static string COLOR_5_STRING = "Green";

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Droid()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        public Droid(string material, string model, string color)
        {
            Material = material;
            Model = model;
            Color = color;
        }

        #endregion



        #region Properties

        public string Material
        {
            set { selectedMaterialString = value; }
            get { return selectedMaterialString; }
        }

        public string Model
        {
            set { selectedModelString = value; }
            get { return selectedModelString; }
        }

        public string Color
        {
            set { selectedColorString = value; }
            get { return selectedColorString; }
        }

        public decimal BaseCost
        {
            set { baseCostDecimal = value; }
            get { return baseCostDecimal; }
        }

        public decimal TotalCost
        {
            set { totalCostDecimal = value; }
            get { return totalCostDecimal; }
        }

        public int NumberOfItems
        {
            get { return numberOfItemsInt; }
        }

        #endregion



        #region Protected Methods

        /// <summary>
        /// Creates string for droid type. Needed due to how inheritance works.
        /// </summary>
        /// <returns>String of droid's type.</returns>
        protected abstract string TypeString();

        #endregion



        #region Public Methods

        /// <summary>
        /// Calculates total cost of droid.
        /// </summary>
        public virtual void CalculateTotalCost()
        {
            totalCostDecimal = baseCostDecimal;
        }

        /// <summary>
        /// Determines the base cost of a droid. This is the cost of the droid minus any additional features.
        /// IE, only the cost in regards to the model, material, and color.
        /// </summary>
        public void CalculateBaseCost()
        {
            baseCostDecimal = selectedModelDecimal + selectedMaterialDecimal + selectedColorDecimal;
        }

        /// <summary>
        /// Calculates individual feature costs of droid.
        /// </summary>
        public virtual void CalculateFeatures()
        {
            selectedModelDecimal = costPerFeatureDecimal * 10;
            selectedMaterialDecimal = costPerFeatureDecimal * 5;
            selectedColorDecimal = costPerFeatureDecimal * 1;

            CalculateBaseCost();
        }

        /// <summary>
        /// Shortened string for displaying of many droids, each in single line format.
        /// </summary>
        /// <returns>Single ine formatted for list of droids.</returns>
        public virtual string DisplayShortToString()
        {
            return TypeString().PadRight(11) + (selectedMaterialString + " ").PadRight(11) + (selectedModelString + " ").PadRight(10) + (selectedColorString + " ").PadRight(10) + totalCostDecimal.ToString("C").PadLeft(10) + Environment.NewLine;
        }

        /// <summary>
        /// Full string for displaying of single droid spanning multiple lines.
        /// </summary>
        /// <returns>Full information regarding single droid.</returns>
        public virtual string DisplayLongToString()
        {
            return "".PadRight(5) + TypeString().PadRight(11) + (selectedMaterialString + " ").PadRight(11) + (selectedModelString + " ").PadRight(10) + selectedColorString.PadRight(10) + baseCostDecimal.ToString("C").PadLeft(10) + Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine;
        }

        /// <summary>
        /// Impliments CompareTo with droids, using the totalCost property.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>Returns less than 0, 0, or greater than 0.</returns>
        public int CompareTo(object obj)
        {
            Droid passedDroid = (Droid)obj;
            decimal thisTotalCost = this.totalCostDecimal;
            decimal passedTotalCost = passedDroid.totalCostDecimal;
            return thisTotalCost.CompareTo(passedTotalCost);
        }

        #endregion


        
    }
}
