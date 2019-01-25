using System;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast add and pop
    //     Cache friendly, data is in a contiguous block
    //
    // Con:
    //     Cannot get an ordered list of the keys
    //
    // Notes:
    //     Use as a priority queue, the key is the priority level
    //     Complete binary tree, uses all nodes at level before adding another level
    //     This is a max-heap because parent nodes are larger than/equal to its children
    //     Is not order preserving for equal key values
    //
    public class BinaryHeap<T,U> where T : IComparable<T>
    {
        private class Node
        {
            public T Key { get; set; }
            public U Data { get; set; }
        }

        private DynamicArray<Node> _array = new DynamicArray<Node>();

        public int Count { get { return _array.Length; } }

        // O(1) average case, O(log n) worst case   
        public void Add(T key, U data)
        {
            Node add = new Node()
            {
                Key = key,
                Data = data
            };

            // Append to bottom level of the heap
            int child = _array.Append(add);

            // Process child nodes until we reach the root
            while (child > 0)
            {
                // If the parent is smaller than the child 
                int parent = Parent(child);
                if (_array[parent].Key.CompareTo(_array[child].Key) < 0)
                {
                    // Swap them to ensure we maintain a max-heap
                    Node temp = _array[parent];
                    _array[parent] = _array[child];
                    _array[child] = temp;

                    // Process up another level
                    child = parent;
                }
                else
                    break;
            }
        }

        // O(log n)
        public Tuple<T, U> Pop()
        {
            if (Count == 0)
                throw new ArgumentException("Binary heap is empty.");

            Tuple<T, U> ret = new Tuple<T, U>(_array[0].Key, _array[0].Data);

            // Replace the root element with the last node
            _array[0] = _array[Count - 1];
            _array.Delete(Count - 1);

            int parent = 0;
            int largest = 0;

            while(true)
            {
                largest = parent;
                int left = FirstChild(parent);
                int right = SecondChild(parent);

                // Do we need to swap the root with the left?
                if ((left < Count) && _array[largest].Key.CompareTo(_array[left].Key) < 0)
                    largest = left;

                // Do we need to swap the root with the right?
                if ((right < Count) && _array[largest].Key.CompareTo(_array[right].Key) < 0)
                    largest = right;

                if (largest != parent)
                {
                    // Swap root and largest child
                    Node temp = _array[parent];
                    _array[parent] = _array[largest];
                    _array[largest] = temp;

                    // Process down into child
                    parent = largest;
                }
                else
                    break;
            }

            return ret;
        }

        private int Parent(int child)
        {
            return (child - 1) / 2;
        }

        private int FirstChild(int parent)
        {
            return (parent * 2) + 1;
        }

        private int SecondChild(int parent)
        {
            return FirstChild(parent) + 1;
        }
    }
}
