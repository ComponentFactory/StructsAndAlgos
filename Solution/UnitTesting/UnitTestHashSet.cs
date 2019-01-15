using DataStructures;
using System;
using Xunit;

namespace UnitTesting
{
    public class UnitTestHashSet
    {
        [Fact]
        public void Initial()
        {
            HashSet<int> ht = new HashSet<int>();

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);
        }

        [Fact]
        public void Add()
        {
            HashSet<int> ht = new HashSet<int>();

            ht.Add(1);
            Assert.Equal(1, ht.Count);
            Assert.False(ht.Contains(0));
            Assert.True(ht.Contains(1));

            ht.Add(2);
            Assert.Equal(2, ht.Count);
            Assert.False(ht.Contains(0));
            Assert.True(ht.Contains(1));
            Assert.True(ht.Contains(2));

            ht.Add(3);
            Assert.Equal(3, ht.Count);
            Assert.False(ht.Contains(0));
            Assert.True(ht.Contains(1));
            Assert.True(ht.Contains(2));
            Assert.True(ht.Contains(3));

            ht.Add(4);
            Assert.Equal(4, ht.Count);
            Assert.False(ht.Contains(0));
            Assert.True(ht.Contains(1));
            Assert.True(ht.Contains(2));
            Assert.True(ht.Contains(3));
            Assert.True(ht.Contains(4));
        }

        [Fact]
        public void BulkAdd()
        {
            HashSet<int> ht = new HashSet<int>();

            for (int i = 0; i < 1000; i++)
                ht.Add(i);

            for (int i = 0; i < 1000; i++)
                Assert.True(ht.Contains(i));
        }

        [Fact]
        public void BulkAddDelete()
        {
            HashSet<int> ht = new HashSet<int>();

            for (int i = 0; i < 1000000; i++)
                ht.Add(i);

            for (int i = 0; i < 1000000; i++)
                Assert.True(ht.Contains(i));

            for (int i = 0; i < 1000000; i += 2)
                ht.Delete(i);

            for (int i = 0; i < 1000000; i += 2)
                Assert.False(ht.Contains(i));

            for (int i = 1; i < 1000000; i += 2)
                Assert.True(ht.Contains(i));

            for (int i = 1; i < 1000000; i += 2)
                ht.Delete(i);

            for (int i = 0; i < 1000000; i++)
                Assert.False(ht.Contains(i));

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);
        }

        [Fact]
        public void Delete()
        {
            HashSet<int> ht = new HashSet<int>();

            ht.Add(1);
            Assert.Equal(1, ht.Count);
            Assert.True(ht.Contains(1));

            ht.Delete(1);
            Assert.Equal(0, ht.Count);
            Assert.False(ht.Contains(1));

            ht.Add(1);
            ht.Add(2);
            Assert.Equal(2, ht.Count);
            Assert.True(ht.Contains(1));
            Assert.True(ht.Contains(2));

            ht.Delete(1);
            ht.Delete(2);
            Assert.Equal(0, ht.Count);
            Assert.False(ht.Contains(1));
            Assert.False(ht.Contains(2));

            ht.Add(1);
            ht.Add(8);
            ht.Add(15);
            Assert.Equal(3, ht.Count);
            Assert.True(ht.Contains(1));
            Assert.True(ht.Contains(8));
            Assert.True(ht.Contains(15));

            ht.Delete(1);
            ht.Delete(8);
            ht.Delete(15);
            Assert.False(ht.Contains(1));
            Assert.False(ht.Contains(8));
            Assert.False(ht.Contains(15));
            Assert.Equal(0, ht.Count);
        }

        [Fact]
        public void CheckExpanding()
        {
            HashSet<int> ht = new HashSet<int>();

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);

            for (int i = 0; i < 8; i++)
                ht.Add(i);

            Assert.Equal(8, ht.Count);
            Assert.Equal(15, ht.Buckets);

            for (int i = 0; i < 8; i++)
                ht.Add(i + 8);

            Assert.Equal(16, ht.Count);
            Assert.Equal(31, ht.Buckets);

            for (int i = 0; i < 16; i++)
                ht.Add(i + 16);

            Assert.Equal(32, ht.Count);
            Assert.Equal(63, ht.Buckets);
        }

        [Fact]
        public void CheckShrinking()
        {
            HashSet<int> ht = new HashSet<int>();

            Assert.Equal(0, ht.Count);
            Assert.Equal(7, ht.Buckets);

            for (int i = 0; i < 32; i++)
                ht.Add(i);

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
