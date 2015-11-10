using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Code coppied over from inclass. Too tired to be able to figure out how it works. Seems to function correctly?
    /// I think it currently functions as a stack....maybe. O..or is it a queue? Confused. Can't decipher code.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericLinkedList<T>
    {

        #region Variables

        //private GenericNode<T> headNode;        // First position in list. ...not needed? Not sure where we establish head node without this variable.
        private GenericNode<T> currentNode;     // Current position in list.
        private GenericNode<T> lastNode;        // Last position in list?

        #endregion


        #region Constructor

        public GenericLinkedList()
        {
            HeadNode = null;
        }

        #endregion


        #region Properties

        public GenericNode<T> HeadNode
        {
            set;
            get;
        }

        #endregion


        #region Methods

        public void Add(T content)
        {
            GenericNode<T> node = new GenericNode<T>();

            node.Data = content;

            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else
            {
                lastNode.Next = node;
            }
            lastNode = node;
        }

        public bool Delete(int Position)
        {
            currentNode = HeadNode;
            if (Position == 1)
            {
                HeadNode = currentNode.Next;
                currentNode.Next = null;
                currentNode = null;
                return true;
            }
            else
            {
                if (Position > 1)
                {
                    GenericNode<T> tempNode = HeadNode;
                    GenericNode<T> previousTempNode = null;

                    int count = 0;
                    while (tempNode != null)
                    {
                        if (count == Position - 1)
                        {
                            previousTempNode.Next = tempNode.Next;

                            if (tempNode.Next == null)
                            {
                                lastNode = previousTempNode;
                            }

                            tempNode.Next = null;
                            return true;
                        }
                        count++;
                        previousTempNode = tempNode;
                        tempNode = tempNode.Next;
                    }
                }
            }
            return false;
        }

        public GenericNode<T> Retrieve(int Position)
        {
            GenericNode<T> tempNode = HeadNode;
            GenericNode<T> returnNode = null;

            int count = 0;
            while (tempNode != null)
            {
                if (count == Position - 1)
                {
                    return tempNode;
                    break;  // ...why is there a break after a return? Doesn't make sense.
                }
                count++;
                tempNode = tempNode.Next;
            }
            return returnNode;
        }

        #endregion
    }
}
