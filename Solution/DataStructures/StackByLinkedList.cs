using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast, all operations are constant time
    //
    // Con:
    //     Wasted space because of next pointer per node
    //     Cache unfriendly, data is split over many allocations
    //
    // Notes:
    //     Use for depth-first search to track next node to process
    //
    public sealed class StackByLinkedList<T>
    {
        private class Link
        {
            public T Item { get; set; }
            public Link Next { get; set; }
        }

        private Link _head;

        // O(1)
        public bool IsEmpty
        {
            get { return (_head == null); }
        }

        // O(1)
        public void Push(T item)
        {
            _head = new Link()
            {
                Item = item,
                Next = _head
            };
        }

        // O(1)
        public T Pop()
        {
            if (IsEmpty)
                throw new ArgumentException("Stack is empty.");

            Link temp = _head;
            _head = _head.Next;
            return temp.Item;
        }
    }
}
