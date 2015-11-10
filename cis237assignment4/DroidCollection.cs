// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
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
            }
            droidCollection = tempArray;
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

        /// <summary>
        /// Attempt at bucket sort.
        /// </summary>
        public void SortBucket()
        {
            GenericLinkedList<IDroid> Protocol_Stack = new GenericLinkedList<IDroid>();
            GenericLinkedList<IDroid> Utility_Stack = new GenericLinkedList<IDroid>();
            GenericLinkedList<IDroid> Janitor_Stack = new GenericLinkedList<IDroid>();
            GenericLinkedList<IDroid> Astromech_Stack = new GenericLinkedList<IDroid>();

            GenericLinkedList<IDroid> Droid_Queue = new GenericLinkedList<IDroid>();

            indexInt = 0;
            while (indexInt < droidListSizeInt)
            {
                switch (((Droid)droidCollection[indexInt]).droidTypeString)
                {
                    case "Protocol":
                        Protocol_Stack.Add(droidCollection[indexInt]);
                        break;
                    case "Utility":
                        Utility_Stack.Add(droidCollection[indexInt]);
                        break;
                    case "Janitor":
                        Janitor_Stack.Add(droidCollection[indexInt]);
                        break;
                    case "Astromech":
                        Astromech_Stack.Add(droidCollection[indexInt]);
                        break;
                }
                indexInt++;
            }

            // Technically not needed, but added to be able to see that the list is empty before being popped off the queue. For debugging purposes. Remove in final version.
            indexInt = 0;
            while (indexInt < droidListSizeInt)
            {
                droidCollection[indexInt] = null;
                indexInt++;
            }


            // Take droids off stacks.
            while (Astromech_Stack.HeadNode != null)
            {
                Droid_Queue.Add(Astromech_Stack.HeadNode.Data);
                Astromech_Stack.Delete(1);
            }

            while (Janitor_Stack.HeadNode != null)
            {
                Droid_Queue.Add(Janitor_Stack.HeadNode.Data);
                Janitor_Stack.Delete(1);
            }

            while (Utility_Stack.HeadNode != null)
            {
                Droid_Queue.Add(Utility_Stack.HeadNode.Data);
                Utility_Stack.Delete(1);
            }

            while (Protocol_Stack.HeadNode != null)
            {
                Droid_Queue.Add(Protocol_Stack.HeadNode.Data);
                Protocol_Stack.Delete(1);
            }

            
            // Pop off queue and back into array.
            // Probably currently works as a stack. Likely in reversed order right now. Fix later.
            indexInt = 0;
            while (Droid_Queue.HeadNode != null) 
            {
                droidCollection[indexInt] = Droid_Queue.HeadNode.Data;
                Droid_Queue.Delete(1);
                indexInt++;
            }

        }

        /// <summary>
        /// Attempt at merged sort.
        /// </summary>
        public void SortMergedSort()
        {
            MergedSort.Sort(droidCollection, droidListSizeInt);
        }

        #endregion

    }
}
