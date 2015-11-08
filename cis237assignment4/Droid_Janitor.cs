// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    /// <summary>
    /// Class for Droids of type Janitor.
    /// Inherits from Utility which inherits from Droid.
    /// </summary>
    class Droid_Janitor : Droid_Utility
    {
        #region Variables

        protected bool hasTrashCompactorBool;
        protected bool hasVacuumBool;

        protected decimal trashCompactorDecimal;
        protected decimal vacuumDecimal;

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Droid_Janitor()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="hasToolBox"></param>
        /// <param name="hasComputerConnection"></param>
        /// <param name="hasArm"></param>
        /// <param name="hasTrashCompactor"></param>
        /// <param name="hasVacuum"></param>
        public Droid_Janitor(string material, string model, string color, bool hasToolBox, bool hasComputerConnection, bool hasArm, bool hasTrashCompactor, bool hasVacuum)
            : base(material, model, color, hasToolBox, hasComputerConnection, hasArm)
        {
            HasTrashCompactor = hasTrashCompactor;
            HasVacuum = hasVacuum;
            numberOfItemsInt = 8;
        }

        #endregion



        #region Properties

        public bool HasTrashCompactor
        {
            set { hasTrashCompactorBool = value; }
            get { return hasTrashCompactorBool; }
        }

        public bool HasVacuum
        {
            set { hasVacuumBool = value; }
            get { return hasVacuumBool; }
        }

        #endregion



        #region Private Methods

        private void CalculateTrashCompactorCost()
        {
            if (hasTrashCompactorBool)
            {
                trashCompactorDecimal = costPerFeatureDecimal;
            }
            else
            {
                trashCompactorDecimal = 0;
            }
        }

        private void CalculateVacuumCost()
        {
            if (hasVacuumBool)
            {
                vacuumDecimal = costPerFeatureDecimal;
            }
            else
            {
                vacuumDecimal = 0;
            }
        }

        #endregion



        #region Protected Methods

        /// <summary>
        /// Creates string for droid type. Needed due to how inheritance works.
        /// </summary>
        /// <returns>String of droid's type.</returns>
        protected override string TypeString()
        {
            return "Janitor ";
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Calculates total cost of a Janitor droid.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            totalCostDecimal += trashCompactorDecimal + vacuumDecimal;
        }

        /// <summary>
        /// Calculates individual feature costs of droid.
        /// </summary>
        public override void CalculateFeatures()
        {
            base.CalculateFeatures();

            CalculateTrashCompactorCost();
            CalculateVacuumCost();
        }

        /// <summary>
        /// Full string for displaying of single droid spanning multiple lines.
        /// </summary>
        /// <returns>Full information regarding single droid.</returns>
        public override string DisplayLongToString()
        {
            return base.DisplayLongToString() +
                "".PadRight(5) + "Trash Compactor: ".PadRight(25) + YesNoString(hasTrashCompactorBool).PadRight(17) + trashCompactorDecimal.ToString("C").PadLeft(10) + Environment.NewLine +
                "".PadRight(5) + "Vacuum: ".PadRight(25) + YesNoString(hasVacuumBool).PadRight(17) + vacuumDecimal.ToString("C").PadLeft(10) + Environment.NewLine;
        }

        #endregion

    }
}
