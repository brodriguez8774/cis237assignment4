﻿// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Generic Merged Sort class.
    /// </summary>
    class MergedSort
    {
        private static IComparable[] tempArray;

        /// <summary>
        /// Creates the temp array and starts the recursive mergeSorting.
        /// </summary>
        /// <param name="comparableCollection">Collection to sort.</param>
        /// <param name="sizeInt">Total size of collection.</param>
        public static void Sort(IComparable[] comparableCollection, int sizeInt)
        {
            tempArray = new IDroid[sizeInt];
            SortArray(comparableCollection, 0, sizeInt - 1);
        }

        /// <summary>
        /// First half of recursion.
        /// "Sorts" the array by dividing it up into smaller and smaller sections.
        /// </summary>
        /// <param name="comparableCollection">Passed in collection to sort.</param>
        /// <param name="lowInt">Current low int of section.</param>
        /// <param name="highInt">Current high int of section.</param>
        private static void SortArray(IComparable[] comparableCollection, int lowInt, int highInt)
        {
            // If higher is less or equal to lower, then back out of recursion to stop sorting (that specific section).
            if (highInt <= lowInt)
            {
                return;
            }

            int midInt = lowInt + (highInt - lowInt) / 2;           // Determine middle int. Not sure why it uses an average plus low?
            SortArray(comparableCollection, lowInt, midInt);             // Sort left half.
            SortArray(comparableCollection, midInt + 1, highInt);        // Sort right half.
            MergeArray(comparableCollection, lowInt, midInt, highInt);   // Combined separated sections.

        }

        /// <summary>
        /// Merges the separated sections back into a fully sorted array.
        /// </summary>
        /// <param name="comparableCollection">Passed in collection to sort.</param>
        /// <param name="lowInt">Current low int of section.</param>
        /// <param name="midInt">Current middle int of section.</param>
        /// <param name="hightInt">Current high int of section.</param>
        private static void MergeArray(IComparable[] comparableCollection, int lowInt, int midInt, int hightInt)
        {
            int leftHolder = lowInt;
            int rightHolder = midInt + 1;

            for (int index = lowInt; index <= hightInt; index++)
            {
                if (comparableCollection[index] != null)
                {
                    tempArray[index] = comparableCollection[index];
                }
            }

            for (int index = lowInt; index <= hightInt; index++)
            {
                // If left side is done but right is not.
                if (leftHolder > midInt)
                {
                    comparableCollection[index] = tempArray[rightHolder++];
                }
                else
                {
                    // If right side is done but left is not.
                    if (rightHolder > hightInt)
                    {
                        comparableCollection[index] = tempArray[leftHolder++];
                    }
                    // Else actually compare the current left holder and right holder values.
                    else
                    {
                        if (tempArray[rightHolder].CompareTo(tempArray[leftHolder]) <= 0)
                        {
                            comparableCollection[index] = tempArray[rightHolder++];
                        }
                        else
                        {
                            comparableCollection[index] = tempArray[leftHolder++];
                        }
                    }
                }
            }
        }
    }
}
