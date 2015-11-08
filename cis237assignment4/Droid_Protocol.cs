// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    /// <summary>
    /// Class for Droids of type Protocol.
    /// Inherits only from Droid.
    /// </summary>
    class Droid_Protocol : Droid
    {
        #region Variables

        protected int numberOfLanguagesInt;
        protected const decimal COST_PER_LANGUAGE = 1;        // Temp cost placeholder.
        protected decimal totalLanguageDecimal;

        // Language selection constants
        public const int LANGUAGE_SELECTION_1 = 1;
        public const int LANGUAGE_SELECTION_2 = 3;
        public const int LANGUAGE_SELECTION_3 = 7;
        public const int LANGUAGE_SELECTION_4 = 15;

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Droid_Protocol()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="numberOfLanguages"></param>
        public Droid_Protocol(string material, string model, string color, int numberOfLanguages)
            : base(material, model, color)
        {
            NumberOfLanguages = numberOfLanguages;
            numberOfItemsInt = 4;
        }

        #endregion



        #region Properties

        public int NumberOfLanguages
        {
            set { numberOfLanguagesInt = value; }
            get { return numberOfLanguagesInt; }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Determines total language cost for droid.
        /// </summary>
        private void CalculateLanguageCost()
        {
            totalLanguageDecimal = numberOfLanguagesInt * COST_PER_LANGUAGE;
        }

        #endregion



        #region Protected methods

        /// <summary>
        /// Creates string for droid type. Needed due to how inheritance works.
        /// </summary>
        /// <returns>String of droid's type.</returns>
        protected override string TypeString()
        {
            return "Protocol ";
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Calculates total cost of a Protocol droid.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            totalCostDecimal += totalLanguageDecimal;
        }

        /// <summary>
        /// Calculates individual feature costs of droid.
        /// </summary>
        public override void CalculateFeatures()
        {
            base.CalculateFeatures();

            CalculateLanguageCost();
        }

        /// <summary>
        /// Full string for displaying of single droid spanning multiple lines.
        /// </summary>
        /// <returns>Full information regarding single droid.</returns>
        public override string DisplayLongToString()
        {
            return base.DisplayLongToString() +
                "".PadRight(5) + "Languages: ".PadRight(25) + numberOfLanguagesInt.ToString().PadRight(17) + totalLanguageDecimal.ToString("C").PadLeft(10) + Environment.NewLine;
        }

        #endregion

    }
}
