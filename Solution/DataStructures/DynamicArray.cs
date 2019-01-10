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
    //     No wasted space because of linked list type pointers, but has wasted space from empty entries
    //
    public class DynamicArray<T>
    {
        private T[] _storage;

        public DynamicArray(int capacity = 1)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException();

            Capacity = capacity;
            _storage = new T[Capacity];
        }

        public int Length { get; private set; }
        public int Capacity { get; private set; }

        // O(1)
        public T this[int position]
        {
            get
            {
                if ((position < 0) || (position >= Length))
                    throw new IndexOutOfRangeException();

                return _storage[position];
            }

            set
            {
                if ((position < 0) || (position >= Length))
                    throw new IndexOutOfRangeException();

                _storage[position] = value;
            }
        }

        // O(1) - average case
        // O(n) - worst case
        public void Append(T item)
        {
            CheckForSpaceToAddOne();
            _storage[Length++] = item;
        }

        // O(n)
        public void Insert(int position, T item)
        {
            if ((position < 0) || (position > Length))
                throw new IndexOutOfRangeException();

            CheckForSpaceToAddOne();

            for (int i = (Length - 1); i >= position; i--)
                _storage[i + 1] = _storage[i];

            _storage[position] = item;
            Length++;
        }

        // O(n)
        public void Delete(int position)
        {
            if ((position < 0) || (position >= Length))
                throw new IndexOutOfRangeException();

            for (int i = position; i < (Length - 1); i++)
                _storage[i] = _storage[i + 1];

            Length--;
            CheckForShrink();
        }

        private void CheckForSpaceToAddOne()
        {
            // Is there space to add another item?
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
            // If only a quarter full, then shrink down
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
