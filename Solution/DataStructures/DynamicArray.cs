using System;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast lookup and append
    //     Cache friendly, data is in a contiguous block
    //
    // Con:
    //     Insert/Delete are slow due to copying entries
    //
    // Notes:
    //     Double in size when full 
    //     Reduce in half when quarter full (not at half full, to avoid hysteresis)
    //
    public sealed class DynamicArray<T>
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
                    throw new ArgumentOutOfRangeException(nameof(position));

                return _storage[position];
            }

            set
            {
                if ((position < 0) || (position >= Length))
                    throw new ArgumentOutOfRangeException(nameof(position));

                _storage[position] = value;
            }
        }

        // O(1) average case, O(n) worst case   
        public void Append(T item)
        {
            CheckForExpand();
            _storage[Length++] = item;
        }

        // O(n)
        public void Insert(int position, T item)
        {
            if ((position < 0) || (position > Length))
                throw new ArgumentOutOfRangeException(nameof(position));

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
            if ((position < 0) || (position >= Length))
                throw new ArgumentOutOfRangeException(nameof(position));

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
                Resize(Capacity * 2);
        }

        private void CheckForShrink()
        {
            // If only a quarter full, then shrink by half
            if ((Capacity > 1) && (Length <= (Capacity / 4)))
                Resize(Capacity / 2);
        }

        private void Resize(int capacity)
        {
            Capacity = capacity;

            T[] resized = new T[Capacity];

            int toCopy = Math.Min(resized.Length, _storage.Length);
            for (int i = 0; i < toCopy; i++)
                resized[i] = _storage[i];

            _storage = resized;
        }
    }
}
