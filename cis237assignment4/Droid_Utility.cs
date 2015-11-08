// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    /// <summary>
    /// Class for Droids of type Utility.
    /// Inherits only from Droid.
    /// </summary>
    class Droid_Utility : Droid
    {
        #region Variables

        protected bool hasToolBoxBool;
        protected bool hasComputerConnectiontBool;
        protected bool hasArmBool;

        protected decimal toolBoxDecimal;
        protected decimal computerConnectionDecimal;
        protected decimal armDecimal;

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Droid_Utility()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="hasToolbox"></param>
        /// <param name="hasComputerConnection"></param>
        /// <param name="hasArm"></param>
        public Droid_Utility(string material, string model, string color, bool hasToolBox, bool hasComputerConnection, bool hasArm)
            : base(material, model, color)
        {
            HasToolBox = hasToolBox;
            HasComputerConnection = hasComputerConnection;
            HasArm = hasArm;
            numberOfItemsInt = 6;
        }

        #endregion



        #region Properties

        public bool HasToolBox
        {
            set { hasToolBoxBool = value; }
            get { return hasToolBoxBool; }
        }

        public bool HasComputerConnection
        {
            set { hasComputerConnectiontBool = value; }
            get { return hasComputerConnectiontBool; }
        }

        public bool HasArm
        {
            set { hasArmBool = value; }
            get { return hasArmBool; }
        }

        #endregion



        #region Private Methods

        private void CalculateToolBoxCost()
        {
            if (hasToolBoxBool)
            {
                toolBoxDecimal = costPerFeatureDecimal;
            }
            else
            {
                toolBoxDecimal = 0;
            }
        }

        private void CalculateConnectionCost()
        {
            if (hasComputerConnectiontBool)
            {
                computerConnectionDecimal = costPerFeatureDecimal;
            }
            else
            {
                computerConnectionDecimal = 0;
            }
        }

        private void CalculateArmCost()
        {
            if (hasArmBool)
            {
                armDecimal = costPerFeatureDecimal;
            }
            else
            {
                armDecimal = 0;
            }
        }

        #endregion



        #region Protected Methods

        /// <summary>
        /// Mostly used for UI display. Transforms bool display from "true/false" to "yes/no."
        /// </summary>
        /// <param name="validationBool">Bool to convert for display.</param>
        /// <returns>Appropriate string based on bool.</returns>
        protected virtual string YesNoString(bool validationBool)
        {
            string displayString;

            if (validationBool)
            {
                displayString = "Yes";
            }
            else
            {
                displayString = "No";
            }

            return displayString;
        }

        /// <summary>
        /// Creates string for droid type. Needed due to how inheritance works.
        /// </summary>
        /// <returns>String of droid's type.</returns>
        protected override string TypeString()
        {
            return "Utility ";
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Calculates total cost of a Utility droid.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            totalCostDecimal += toolBoxDecimal + computerConnectionDecimal + armDecimal;
        }

        /// <summary>
        /// Calculates individual feature costs of droid.
        /// </summary>
        public override void CalculateFeatures()
        {
            base.CalculateFeatures();

            CalculateToolBoxCost();
            CalculateConnectionCost();
            CalculateArmCost();
        }

        /// <summary>
        /// Full string for displaying of single droid spanning multiple lines.
        /// </summary>
        /// <returns>Full information regarding single droid.</returns>
        public override string DisplayLongToString()
        {
            return base.DisplayLongToString() +
                "".PadRight(5) + "Toolbox: ".PadRight(25) + YesNoString(hasArmBool).PadRight(17) + toolBoxDecimal.ToString("C").PadLeft(10) + Environment.NewLine +
                "".PadRight(5) + "Computer Connection: ".PadRight(25) + YesNoString(hasComputerConnectiontBool).PadRight(17) + computerConnectionDecimal.ToString("C").PadLeft(10) + Environment.NewLine +
                "".PadRight(5) + "Arm: ".PadRight(25) + YesNoString(hasArmBool).PadRight(17) + armDecimal.ToString("C").PadLeft(10) + Environment.NewLine;
        }

        #endregion

    }
}
