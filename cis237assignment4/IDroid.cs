// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Interface for all droid objects.
    /// Acts as a "universal blueprint/contract" of sorts.
    /// </summary>
    interface IDroid : IComparable
    {
        /// <summary>
        /// Calculates total cost of droid.
        /// </summary>
        void CalculateTotalCost();

        /// <summary>
        /// Calculates individual feature costs of droid.
        /// </summary>
        void CalculateFeatures();

        // Total cost of droid.
        decimal TotalCost { get; set; }


        // Number of individual items influencing droid price.
        int NumberOfItems { get; }


        /// <summary>
        /// Shortened string for displaying of many droids, each in single line format.
        /// </summary>
        /// <returns>Single ine formatted for list of droids.</returns>
        string DisplayShortToString();


        /// <summary>
        /// Full string for displaying of single droid spanning multiple lines.
        /// </summary>
        /// <returns>Full information regarding single droid.</returns>
        string DisplayLongToString();
    }
}
