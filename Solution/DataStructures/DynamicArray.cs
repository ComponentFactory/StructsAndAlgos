using System;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast lookup
    //     Cache friendly, data is in a contiguous block
    // Con:
    //     Append has slow worst case
    //     Insert/Delete are slow
    //
    // Notes:
    //     Double in size when full 
    //     Reduce in half when quarter full (not at half full, to avoid hysteresis)
    //
    public class DynamicArray<T>
    {
        private T[] _storage;

        public DynamicArray(int capacity = 1)
        {
            Capacity = capacity;
            _storage = new T[Capacity];
        }

        public int Length { get; private set; }
        public int Capacity { get; private set; }

        // O(1)
        public T this[int position]
        {
            get { return _storage[position]; }
            set { _storage[position] = value; }
        }

        // O(1) - average case
        // O(n) - worst case
        public void Append(T item)
        {
            CheckForExpand();
            _storage[Length++] = item;
        }

        // O(n)
        public void Insert(int position, T item)
        {
            CheckForExpand();

            // Shift items to the right to make room for insert item
            for (int i = (Length - 1); i >= position; i--)
                _storage[i + 1] = _storage[i];

            _storage[position] = item;
            Length++;
        }

        // O(n)
        public void Delete(int position)
        {
            // Shift items to the left and overwrite the deleted entry
            for (int i = position; i < (Length - 1); i++)
                _storage[i] = _storage[i + 1];

            Length--;
            CheckForShrink();
        }

        private void CheckForExpand()
        {
            // If full then double in size
            if (Length == Capacity)
            {
                Capacity *= 2;

                T[] doubled = new T[Capacity];
                for (int i = 0; i < _storage.Length; i++)
                    doubled[i] = _storage[i];

                _storage = doubled;
            }
        }

        private void CheckForShrink()
        {
            // If only a quarter full, then shrink by half
            if ((Capacity > 1) && (Length <= (Capacity / 4)))
            {
                Capacity /= 2;

                T[] halfed = new T[Capacity];
                for (int i = 0; i < Length; i++)
                    halfed[i] = _storage[i];

                _storage = halfed;
            }
        }
    }
}
