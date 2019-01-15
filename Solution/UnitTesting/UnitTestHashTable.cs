using DataStructures;
using System;
using Xunit;

namespace UnitTesting
{
    public class UnitTestHashTable
    {
        [Fact]
        public void Initial()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);
        }

        [Fact]
        public void Add()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            ht.Add(1, 1);
            Assert.Equal(1, ht.Count);
            Assert.Equal(1, ht[1]);

            ht.Add(2, 2);
            Assert.Equal(2, ht.Count);
            Assert.Equal(1, ht[1]);
            Assert.Equal(2, ht[2]);

            ht.Add(3, 4);
            Assert.Equal(3, ht.Count);
            Assert.Equal(1, ht[1]);
            Assert.Equal(2, ht[2]);
            Assert.Equal(4, ht[3]);

            ht.Add(4, 8);
            Assert.Equal(4, ht.Count);
            Assert.Equal(1, ht[1]);
            Assert.Equal(2, ht[2]);
            Assert.Equal(4, ht[3]);
            Assert.Equal(8, ht[4]);
        }

        [Fact]
        public void BulkAdd()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            for (int i = 0; i < 1000000; i++)
                ht.Add(i, i * 3);

            for (int i = 0; i < 1000000; i++)
                Assert.Equal(i * 3, ht[i]);
        }

        [Fact]
        public void BulkAddDelete()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            for (int i = 0; i < 1000000; i++)
                ht.Add(i, i * 3);

            for (int i = 0; i < 1000000; i++)
                Assert.Equal(i * 3, ht[i]);

            for (int i = 0; i < 1000000; i += 2)
                ht.Delete(i);

            for (int i = 1; i < 1000000; i += 2)
                Assert.Equal(i * 3, ht[i]);

            for (int i = 1; i < 1000000; i += 2)
                ht.Delete(i);

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);
        }

        [Fact]
        public void Delete()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            ht.Add(1, 1);
            Assert.Equal(1, ht.Count);
            Assert.Equal(1, ht[1]);

            ht.Delete(1);
            Assert.Equal(0, ht.Count);

            ht.Add(1, 2);
            ht.Add(2, 4);
            Assert.Equal(2, ht.Count);
            Assert.Equal(2, ht[1]);
            Assert.Equal(4, ht[2]);

            ht.Delete(1);
            ht.Delete(2);
            Assert.Equal(0, ht.Count);

            ht.Add(1, 10);
            ht.Add(8, 20);
            ht.Add(15, 30);
            Assert.Equal(3, ht.Count);
            Assert.Equal(10, ht[1]);
            Assert.Equal(20, ht[8]);
            Assert.Equal(30, ht[15]);

            ht.Delete(1);
            ht.Delete(8);
            ht.Delete(15);
            Assert.Equal(0, ht.Count);
        }

        [Fact]
        public void IndexAccess()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            ht.Add(1, 1);
            Assert.Equal(1, ht.Count);
            Assert.Equal(1, ht[1]);

            ht[1] = 2;
            Assert.Equal(1, ht.Count);
            Assert.Equal(2, ht[1]);

            ht[2] = 8;
            Assert.Equal(2, ht.Count);
            Assert.Equal(2, ht[1]);
            Assert.Equal(8, ht[2]);
        }

        [Fact]
        public void CheckExpanding()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);

            for (int i = 0; i < 8; i++)
                ht.Add(i, i);

            Assert.Equal(8, ht.Count);
            Assert.Equal(15, ht.Buckets);

            for (int i = 0; i < 8; i++)
                ht.Add(i + 8, i);

            Assert.Equal(16, ht.Count);
            Assert.Equal(31, ht.Buckets);

            for (int i = 0; i < 16; i++)
                ht.Add(i + 16, i);

            Assert.Equal(32, ht.Count);
            Assert.Equal(63, ht.Buckets);
        }

        [Fact]
        public void CheckShrinking()
        {
            HashTable<int, int> ht = new HashTable<int, int>();

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);

            for (int i = 0; i < 32; i++)
                ht.Add(i, i);

            Assert.Equal(32, ht.Count);
            Assert.Equal(63, ht.Buckets);

            for (int i = 15; i < 32; i++)
                ht.Delete(i);

            Assert.Equal(15, ht.Count);
            Assert.Equal(31, ht.Buckets);

            for (int i = 7; i < 15; i++)
                ht.Delete(i);

            Assert.Equal(7, ht.Count);
            Assert.Equal(15, ht.Buckets);

            for (int i = 0; i < 7; i++)
                ht.Delete(i);

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);
        }
    }
}
