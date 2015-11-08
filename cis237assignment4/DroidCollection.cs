// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    class DroidCollection
    {
        #region Variables

        private IDroid[] droidCollection;
        private IDroid[] tempArray;

        private int indexInt;
        private int lenghtOfArrayInt;      // Total length of array, including null spots.
        private int droidListSizeInt;      // Number of droids actually taking up spots in array.

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public DroidCollection()
        {
            droidListSizeInt = 0;
            lenghtOfArrayInt = 10;
            droidCollection = new Droid[lenghtOfArrayInt];
        }

        #endregion



        #region Properties

        public int DroidListSize
        {
            get { return droidListSizeInt; }
        }

        public IDroid[] DroidList
        {
            get { return droidCollection; }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Expands array to be one and a half times current size.
        /// </summary>
        public void ExpandArray()
        {
            // Set list size to be one and a half times the size of current.
            lenghtOfArrayInt = droidListSizeInt + (droidListSizeInt / 2);
            tempArray = new Droid[lenghtOfArrayInt];

            indexInt = 0;
            // While not through entire list of droids yet.
            while (indexInt < droidListSizeInt)
            {
                // If reached a null space, force exit of while loop.
                if (droidCollection[indexInt] == null)
                {
                    indexInt = droidListSizeInt;
                }
                else
                {
                    tempArray[indexInt] = droidCollection[indexInt];
                    indexInt++;
                }
                droidCollection = tempArray;
            }
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Adds a single droid to the current list.
        /// </summary>
        /// <param name="aDroid"></param>
        public void AddDroid(IDroid aDroid)
        {
            // If there is room for more items in array.
            if (droidListSizeInt < lenghtOfArrayInt)
            {
                indexInt = 0;

                // While current spot is not empty;
                while (droidCollection[indexInt] != null)
                {
                    indexInt++;
                }

                // Adds droid to first empty spot.
                droidCollection[indexInt] = aDroid;
                droidListSizeInt++;
            }
            else
            {
                ExpandArray();
                AddDroid(aDroid);
            }
        }

        #endregion

    }
}
