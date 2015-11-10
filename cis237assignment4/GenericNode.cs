using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericNode<T>
    {
        public GenericNode<T> Next
        {
            set;
            get;
        }

        public T Data
        {
            set;
            get;
        }
    }
}
