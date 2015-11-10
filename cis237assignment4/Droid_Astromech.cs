// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Class for Droids of type Astromech.
    /// Inherits from Utility which inherits from Droid.
    /// </summary>
    class Droid_Astromech : Droid_Utility
    {
        #region Variables

        protected bool hasFireExtinguisherBool;
        protected int numberOfShipsInt;

        protected decimal fireExtinguisherDecimal;
        protected decimal numberOfShipsDecimal;

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Droid_Astromech()
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
        /// <param name="hasFireExtinguisher"></param>
        /// <param name="numberOfShips"></param>
        public Droid_Astromech(string material, string model, string color, bool hasToolBox, bool hasComputerConnection, bool hasArm, bool hasFireExtinguisher, int numberOfShips)
            : base(material, model, color, hasToolBox, hasComputerConnection, hasArm)
        {
            HasFireExtinguisher = hasFireExtinguisher;
            NumberOfShips = numberOfShips;
            numberOfItemsInt = 8;
            droidTypeString = "Astromech";
        }

        #endregion



        #region Properties

        public bool HasFireExtinguisher
        {
            set { hasFireExtinguisherBool = value; }
            get { return hasFireExtinguisherBool; }
        }

        public int NumberOfShips
        {
            set { numberOfShipsInt = value; }
            get { return numberOfShipsInt; }
        }

        #endregion



        #region Private Methods

        private void CalculateFireExtinguisherCost()
        {
            if (hasFireExtinguisherBool)
            {
                fireExtinguisherDecimal = costPerFeatureDecimal;
            }
            else
            {
                fireExtinguisherDecimal = 0;
            }
        }

        private void CalculateNumberOfShipsCost()
        {
            numberOfShipsDecimal = numberOfShipsInt * costPerFeatureDecimal;
        }

        #endregion



        #region Protected Methods

        /// <summary>
        /// Creates string for droid type. Needed due to how inheritance works.
        /// </summary>
        /// <returns>String of droid's type.</returns>
        protected override string TypeString()
        {
            return "Astromech ";
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Calculates total cost of a Astromech droid.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            totalCostDecimal += fireExtinguisherDecimal + numberOfShipsDecimal;
        }

        /// <summary>
        /// Calculates individual feature costs of droid.
        /// </summary>
        public override void CalculateFeatures()
        {
            base.CalculateFeatures();

            CalculateFireExtinguisherCost();
            CalculateNumberOfShipsCost();
        }

        /// <summary>
        /// Full string for displaying of single droid spanning multiple lines.
        /// </summary>
        /// <returns>Full information regarding single droid.</returns>
        public override string DisplayLongToString()
        {
            return base.DisplayLongToString() +
                "".PadRight(5) + "Fire Extinguisher: ".PadRight(25) + YesNoString(hasFireExtinguisherBool).PadRight(17) + fireExtinguisherDecimal.ToString("C").PadLeft(10) + Environment.NewLine +
                "".PadRight(5) + ("Outfitted for " + numberOfShipsInt + " ships.").PadRight(42) + numberOfShipsDecimal.ToString("C").PadLeft(10) + Environment.NewLine;
        }

        #endregion

    }
}
