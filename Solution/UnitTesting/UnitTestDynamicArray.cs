using DataStructures;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTesting
{
    public class UnitTestDynamicArray
    {
        [Fact]
        public void Initial()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            Assert.Equal(0, da.Length);
            Assert.Equal(1, da.Capacity);
        }

        [Fact]
        public void ExpandingCapacity()
        {
            DynamicArray<int> da = new DynamicArray<int>();
            Assert.Equal(1, da.Capacity);

            da.Append(1);
            Assert.Equal(1, da.Length);
            Assert.Equal(1, da.Capacity);

            da.Append(2);
            Assert.Equal(2, da.Length);
            Assert.Equal(2, da.Capacity);

            da.Append(3);
            Assert.Equal(3, da.Length);
            Assert.Equal(4, da.Capacity);

            da.Append(4);
            Assert.Equal(4, da.Length);
            Assert.Equal(4, da.Capacity);

            da.Append(5);
            Assert.Equal(5, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Append(6);
            Assert.Equal(6, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Append(7);
            Assert.Equal(7, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Append(8);
            Assert.Equal(8, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Append(9);
            Assert.Equal(16, da.Capacity);
        }

        [Fact]
        public void ShrinkingCapacity()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            for (int i = 0; i < 8; i++)
                da.Append(i);
            Assert.Equal(8, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Delete(0);
            Assert.Equal(7, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Delete(0);
            Assert.Equal(6, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Delete(0);
            Assert.Equal(5, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Delete(0);
            Assert.Equal(4, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Delete(0);
            Assert.Equal(3, da.Length);
            Assert.Equal(8, da.Capacity);

            da.Delete(0);
            Assert.Equal(2, da.Length);
            Assert.Equal(4, da.Capacity);

            da.Delete(0);
            Assert.Equal(1, da.Length);
            Assert.Equal(2, da.Capacity);

            da.Delete(0);
            Assert.Equal(0, da.Length);
            Assert.Equal(1, da.Capacity);
        }

        [Fact]
        public void AppendLookup()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            da.Append(1);
            Assert.Equal(1, da.Length);
            Assert.Equal(1, da[0]);

            da.Append(2);
            Assert.Equal(2, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(2, da[1]);

            da.Append(3);
            Assert.Equal(3, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(2, da[1]);
            Assert.Equal(3, da[2]);

            da.Append(4);
            Assert.Equal(4, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(2, da[1]);
            Assert.Equal(3, da[2]);
            Assert.Equal(4, da[3]);
        }

        [Fact]
        public void InsertLookup()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            da.Insert(0, 10);
            Assert.Equal(1, da.Length);
            Assert.Equal(10, da[0]);

            da.Insert(1, 11);
            Assert.Equal(2, da.Length);
            Assert.Equal(10, da[0]);
            Assert.Equal(11, da[1]);

            da.Insert(0, 12);
            Assert.Equal(3, da.Length);
            Assert.Equal(12, da[0]);
            Assert.Equal(10, da[1]);
            Assert.Equal(11, da[2]);

            da.Insert(1, 13);
            Assert.Equal(4, da.Length);
            Assert.Equal(12, da[0]);
            Assert.Equal(13, da[1]);
            Assert.Equal(10, da[2]);
            Assert.Equal(11, da[3]);
        }

        [Fact]
        public void DeleteLookup()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            da.Append(1);
            da.Append(2);
            da.Append(3);
            da.Append(4);
            Assert.Equal(4, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(2, da[1]);
            Assert.Equal(3, da[2]);
            Assert.Equal(4, da[3]);

            da.Delete(1);
            Assert.Equal(3, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(3, da[1]);
            Assert.Equal(4, da[2]);

            da.Delete(2);
            Assert.Equal(2, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(3, da[1]);

            da.Delete(0);
            Assert.Equal(1, da.Length);
            Assert.Equal(3, da[0]);

            da.Delete(0);
            Assert.Equal(0, da.Length);
        }

        [Fact]
        public void UpdateLookup()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            da.Append(1);
            da.Append(2);
            da.Append(3);
            da.Append(4);
            Assert.Equal(4, da.Length);
            Assert.Equal(1, da[0]);
            Assert.Equal(2, da[1]);
            Assert.Equal(3, da[2]);
            Assert.Equal(4, da[3]);

            da[0] = 99;
            Assert.Equal(4, da.Length);
            Assert.Equal(99, da[0]);
            Assert.Equal(2, da[1]);
            Assert.Equal(3, da[2]);
            Assert.Equal(4, da[3]);

            da[3] = 98;
            Assert.Equal(4, da.Length);
            Assert.Equal(99, da[0]);
            Assert.Equal(2, da[1]);
            Assert.Equal(3, da[2]);
            Assert.Equal(98, da[3]);

            da[1] = 97;
            Assert.Equal(4, da.Length);
            Assert.Equal(99, da[0]);
            Assert.Equal(97, da[1]);
            Assert.Equal(3, da[2]);
            Assert.Equal(98, da[3]);

            da[2] = 96;
            Assert.Equal(4, da.Length);
            Assert.Equal(99, da[0]);
            Assert.Equal(97, da[1]);
            Assert.Equal(96, da[2]);
            Assert.Equal(98, da[3]);
        }

        [Fact]
        public void BulkAppendDelete()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            for (int i = 0; i < 1000000; i++)
                da.Append(i);

            for (int i = 999999; i >= 0; i--)
                da.Delete(i);

            Assert.Equal(0, da.Length);
            Assert.Equal(1, da.Capacity);
        }

        [Fact]
        public void BulkInsertDelete()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            for (int i = 0; i < 10000; i++)
                da.Insert(0, i);

            for (int i = 0; i < 10000; i++)
                da.Delete(0);

            Assert.Equal(0, da.Length);
            Assert.Equal(1, da.Capacity);
        }
    }
}
