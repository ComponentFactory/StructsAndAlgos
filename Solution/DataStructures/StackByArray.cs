using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast, all operations are constant time on average
    //     Cache friendly, dynamic array uses a contiguous block
    //
    // Con:
    //     Wasted space because of some empty slots in dynamic array
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

        // O(1) average case, O(n) worst case       
        public void Push(T data)
        {
            _array.Append(data);
        }

        // O(1) average case, O(n) worst case  
        public T Pop()
        {
            if (IsEmpty)
                throw new ArgumentException("Stack is empty.");

            int index = _array.Length - 1;
            T temp = _array[index];
            _array.Delete(index);
            return temp;
        }
    }
}
