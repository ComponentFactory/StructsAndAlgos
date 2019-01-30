using System;

namespace DataStructures
{
    // Pro:
    //     Constant time Add and Contains
    //     Space efficient, using a bit vector
    //     Cache friendly, data is in a contiguous block
    //
    // Con:
    //     Sometimes returns false positives
    //     Need to create the correct size at start
    //
    // Notes:
    //     Use as a filter before calling a longer process
    //     To prevent excessive false positives, size must double number of expected entries
    //
    public class BloomFilter<T>
    {
        private int[] _vector;
        private int _bits;

        public BloomFilter(int capacity = 97)
        {
            _bits = capacity;
            _vector = new int[(_bits / 32) + (_bits % 32 != 0 ? 1 : 0)];
        }

        public int VectorSize
        {
            get { return _vector.Length; }
        }

        // O(1) average case
        public bool Contains(T key)
        {
            HashKey(key, out int hash1, out int hash2);
            return IsBitSet(hash1 % _bits) && IsBitSet(hash2 % _bits);
        }

        // O(1) average case
        public void Add(T key)
        {
            HashKey(key, out int hash1, out int hash2);
            SetBit(hash1 % _bits);
            SetBit(hash2 % _bits);
        }

        private void HashKey(T key, out int hash1, out int hash2)
        {
            hash1 = key.GetHashCode();
            hash2 = (17 + ~hash1) * 23;
        }

        private void SetBit(int bit)
        {
            bit = Math.Abs(bit);
            int index = bit / 32;
            int mask = 1 << (bit - index);
            _vector[index] |= mask;
        }

        private bool IsBitSet(int bit)
        {
            bit = Math.Abs(bit);
            int index = bit / 32;
            int mask = 1 << (bit - index);
            return (_vector[index] & mask) != 0;
        }
    }
}
