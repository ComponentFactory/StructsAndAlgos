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
    public class DynamicArray<T>
    {
        private T[] _data;

        public DynamicArray(int capacity = 1)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException();

            Capacity = capacity;
            _data = new T[Capacity];
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

                return _data[position];
            }

            set
            {
                if ((position < 0) || (position >= Length))
                    throw new ArgumentOutOfRangeException(nameof(position));

                _data[position] = value;
            }
        }

        // O(1) average case, O(n) worst case   
        public int Append(T data)
        {
            CheckForExpand();
            _data[Length++] = data;
            return Length - 1;
        }

        // O(n)
        public void Insert(int position, T data)
        {
            if ((position < 0) || (position > Length))
                throw new ArgumentOutOfRangeException(nameof(position));

            CheckForExpand();

            // Shift data to the right to make room for inserting data
            for (int i = (Length - 1); i >= position; i--)
                _data[i + 1] = _data[i];

            _data[position] = data;
            Length++;
        }

        // O(n)
        public void Delete(int position)
        {
            if ((position < 0) || (position >= Length))
                throw new ArgumentOutOfRangeException(nameof(position));

            // Shift data to the left and overwrite the deleted entry
            for (int i = position; i < (Length - 1); i++)
                _data[i] = _data[i + 1];

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

            int toCopy = Math.Min(resized.Length, _data.Length);
            for (int i = 0; i < toCopy; i++)
                resized[i] = _data[i];

            _data = resized;
        }
    }
}
