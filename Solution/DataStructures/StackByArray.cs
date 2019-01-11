using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast, all operations are constant time on average
    //
    // Con:
    //     Wasted space because of some empty slots in dynamic array
    //     Cache friendly, data is in a contiguous block
    //
    // Notes:
    //     Use for depth-first search to track next node to process
    //
    public class StackByArray<T>
    {
        private DynamicArray<T> _array = new DynamicArray<T>();

        // O(1)
        public bool IsEmpty
        {
            get { return (_array.Length == 0); }
        }

        // O(1) average case, O(n) worse case       
        public void Push(T item)
        {
            _array.Append(item);
        }

        // O(1) average case, O(n) worse case  
        public T Pop()
        {
            int index = _array.Length - 1;
            T temp = _array[index];
            _array.Delete(index);
            return temp;
        }
    }
}
