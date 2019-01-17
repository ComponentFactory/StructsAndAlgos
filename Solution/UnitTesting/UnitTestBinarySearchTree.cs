using DataStructures;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTesting
{
    public class UnitTestBinarySearchTree
    {
        [Fact]
        public void Initial()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            Assert.Equal(0, bst.Count);
        }

        [Fact]
        public void Insert1()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);

            Assert.Equal(1, bst.Count);
            Assert.True(bst.Contains(10));
            Assert.False(bst.Contains(20));
            Assert.Equal(20, bst.Find(10));

            List<int> keys1  = bst.KeysByRecursion();
            Assert.Single(keys1);
            Assert.Equal(10, keys1[0]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Single(keys2);
            Assert.Equal(10, keys2[0]);
        }

        [Fact]
        public void Insert2L()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);

            Assert.Equal(2, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(10));
            Assert.False(bst.Contains(20));
            Assert.False(bst.Contains(21));
            Assert.Equal(21, bst.Find(5));
            Assert.Equal(20, bst.Find(10));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(2, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(10, keys1[1]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(2, keys2.Count);
            Assert.Equal(5, keys2[0]);
            Assert.Equal(10, keys2[1]);
        }

        [Fact]
        public void Insert2R()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(5, 20);
            bst.Insert(10, 21);

            Assert.Equal(2, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(10));
            Assert.False(bst.Contains(20));
            Assert.False(bst.Contains(21));
            Assert.Equal(20, bst.Find(5));
            Assert.Equal(21, bst.Find(10));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(2, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(10, keys1[1]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(2, keys2.Count);
            Assert.Equal(5, keys2[0]);
            Assert.Equal(10, keys2[1]);
        }

        [Fact]
        public void Insert3()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);
            bst.Insert(15, 22);

            Assert.Equal(3, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(10));
            Assert.True(bst.Contains(15));
            Assert.False(bst.Contains(20));
            Assert.False(bst.Contains(21));
            Assert.False(bst.Contains(22));
            Assert.Equal(21, bst.Find(5));
            Assert.Equal(20, bst.Find(10));
            Assert.Equal(22, bst.Find(15));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(3, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(10, keys1[1]);
            Assert.Equal(15, keys1[2]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(3, keys2.Count);
            Assert.Equal(5, keys2[0]);
            Assert.Equal(10, keys2[1]);
            Assert.Equal(15, keys2[2]);
        }

        [Fact]
        public void Insert3L()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(15, 20);
            bst.Insert(10, 21);
            bst.Insert(5, 22);

            Assert.Equal(3, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(10));
            Assert.True(bst.Contains(15));
            Assert.False(bst.Contains(20));
            Assert.False(bst.Contains(21));
            Assert.False(bst.Contains(22));
            Assert.Equal(22, bst.Find(5));
            Assert.Equal(21, bst.Find(10));
            Assert.Equal(20, bst.Find(15));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(3, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(10, keys1[1]);
            Assert.Equal(15, keys1[2]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(3, keys2.Count);
            Assert.Equal(5, keys2[0]);
            Assert.Equal(10, keys2[1]);
            Assert.Equal(15, keys2[2]);
        }

        [Fact]
        public void Insert3R()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(5, 20);
            bst.Insert(10, 21);
            bst.Insert(15, 22);

            Assert.Equal(3, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(10));
            Assert.True(bst.Contains(15));
            Assert.False(bst.Contains(20));
            Assert.False(bst.Contains(21));
            Assert.False(bst.Contains(22));
            Assert.Equal(20, bst.Find(5));
            Assert.Equal(21, bst.Find(10));
            Assert.Equal(22, bst.Find(15));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(3, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(10, keys1[1]);
            Assert.Equal(15, keys1[2]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(3, keys2.Count);
            Assert.Equal(5, keys2[0]);
            Assert.Equal(10, keys2[1]);
            Assert.Equal(15, keys2[2]);
        }

        [Fact]
        public void Insert5LR()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(9, 21);
            bst.Insert(8, 23);
            bst.Insert(11, 24);
            bst.Insert(12, 25);

            Assert.Equal(5, bst.Count);
            Assert.True(bst.Contains(8));
            Assert.True(bst.Contains(9));
            Assert.True(bst.Contains(10));
            Assert.True(bst.Contains(11));
            Assert.True(bst.Contains(12));
            Assert.False(bst.Contains(20));
            Assert.False(bst.Contains(21));
            Assert.False(bst.Contains(22));
            Assert.False(bst.Contains(23));
            Assert.False(bst.Contains(24));
            Assert.False(bst.Contains(25));
            Assert.Equal(23, bst.Find(8));
            Assert.Equal(21, bst.Find(9));
            Assert.Equal(20, bst.Find(10));
            Assert.Equal(24, bst.Find(11));
            Assert.Equal(25, bst.Find(12));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(5, keys1.Count);
            Assert.Equal(8, keys1[0]);
            Assert.Equal(9, keys1[1]);
            Assert.Equal(10, keys1[2]);
            Assert.Equal(11, keys1[3]);
            Assert.Equal(12, keys1[4]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(5, keys2.Count);
            Assert.Equal(8, keys2[0]);
            Assert.Equal(9, keys2[1]);
            Assert.Equal(10, keys2[2]);
            Assert.Equal(11, keys2[3]);
            Assert.Equal(12, keys2[4]);
        }

        [Fact]
        public void Insert100L()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            for(int i = 100; i >= 1; i--)
                bst.Insert(i, i);

            Assert.Equal(100, bst.Count);

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(100, keys1.Count);
            for (int i = 100; i >= 1; i--)
                Assert.Equal(i, keys1[i - 1]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(100, keys2.Count);
            for (int i = 100; i >= 1; i--)
                Assert.Equal(i, keys2[i - 1]);
        }

        [Fact]
        public void Insert100R()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            for (int i = 1; i <= 100; i++)
                bst.Insert(i, i);

            Assert.Equal(100, bst.Count);

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(100, keys1.Count);
            for (int i = 1; i <= 100; i++)
                Assert.Equal(i, keys1[i - 1]);

            List<int> keys2 = bst.KeysByQueue();
            Assert.Equal(100, keys2.Count);
            for (int i = 1; i <= 100; i++)
                Assert.Equal(i, keys2[i - 1]);
        }

        [Fact]
        public void InsertRandom()
        {
            for(int j = 0; j < 100; j++)
            {
                BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();
                List<int> ordered = new List<int>();

                Random random = new Random();
                for (int i = 1; i <= 1000; i++)
                {
                    int rand = random.Next();
                    if (!bst.Contains(rand))
                    {
                        ordered.Add(rand);
                        bst.Insert(rand, i);
                    }
                }

                ordered.Sort();
                Assert.Equal(ordered.Count, bst.Count);

                List<int> keys1 = bst.KeysByRecursion();
                Assert.Equal(ordered.Count, keys1.Count);
                for (int i = 0; i < ordered.Count; i++)
                    Assert.Equal(ordered[i], keys1[i]);

                List<int> keys2 = bst.KeysByQueue();
                Assert.Equal(ordered.Count, keys2.Count);
                for (int i = 0; i < ordered.Count; i++)
                    Assert.Equal(ordered[i], keys2[i]);
            }
        }

        [Fact]
        public void Delete1()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Delete(10);

            Assert.Equal(0, bst.Count);
        }

        [Fact]
        public void Delete2LA()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);

            bst.Delete(5);
            Assert.Equal(1, bst.Count);
            Assert.True(bst.Contains(10));
            Assert.False(bst.Contains(5));
            Assert.Equal(20, bst.Find(10));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Single(keys1);
            Assert.Equal(10, keys1[0]);
        }

        [Fact]
        public void Delete2LB()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);

            bst.Delete(10);
            Assert.Equal(1, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.False(bst.Contains(10));
            Assert.Equal(21, bst.Find(5));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Single(keys1);
            Assert.Equal(5, keys1[0]);
        }

        [Fact]
        public void Delete2RA()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(5, 21);
            bst.Insert(10, 20);

            bst.Delete(5);
            Assert.Equal(1, bst.Count);
            Assert.True(bst.Contains(10));
            Assert.False(bst.Contains(5));
            Assert.Equal(20, bst.Find(10));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Single(keys1);
            Assert.Equal(10, keys1[0]);
        }

        [Fact]
        public void Delete2RB()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(5, 21);
            bst.Insert(10, 20);

            bst.Delete(10);
            Assert.Equal(1, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.False(bst.Contains(10));
            Assert.Equal(21, bst.Find(5));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Single(keys1);
            Assert.Equal(5, keys1[0]);
        }

        [Fact]
        public void Delete3A()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);
            bst.Insert(15, 22);

            bst.Delete(5);
            Assert.Equal(2, bst.Count);
            Assert.True(bst.Contains(10));
            Assert.True(bst.Contains(15));
            Assert.False(bst.Contains(5));
            Assert.Equal(20, bst.Find(10));
            Assert.Equal(22, bst.Find(15));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(2, keys1.Count);
            Assert.Equal(10, keys1[0]);
            Assert.Equal(15, keys1[1]);
        }

        [Fact]
        public void Delete3B()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);
            bst.Insert(15, 22);

            bst.Delete(10);
            Assert.Equal(2, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(15));
            Assert.False(bst.Contains(10));
            Assert.Equal(21, bst.Find(5));
            Assert.Equal(22, bst.Find(15));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(2, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(15, keys1[1]);
        }

        [Fact]
        public void Delete3C()
        {
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Insert(10, 20);
            bst.Insert(5, 21);
            bst.Insert(15, 22);

            bst.Delete(15);
            Assert.Equal(2, bst.Count);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(10));
            Assert.False(bst.Contains(15));
            Assert.Equal(21, bst.Find(5));
            Assert.Equal(20, bst.Find(10));

            List<int> keys1 = bst.KeysByRecursion();
            Assert.Equal(2, keys1.Count);
            Assert.Equal(5, keys1[0]);
            Assert.Equal(10, keys1[1]);
        }

        [Fact]
        public void DeleteRandom()
        {
            for (int j = 0; j < 100; j++)
            {
                BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();
                List<int> ordered = new List<int>();

                Random random = new Random();
                for (int i = 1; i <= 1000; i++)
                {
                    int rand = random.Next();
                    if (!bst.Contains(rand))
                    {
                        ordered.Add(rand);
                        bst.Insert(rand, i);
                    }
                }

                ordered.Sort();
                Assert.Equal(ordered.Count, bst.Count);

                while(ordered.Count > 0)
                {
                    int rand = random.Next(ordered.Count);
                    bst.Delete(ordered[rand]);
                    ordered.RemoveAt(rand);
                }

                Assert.Equal(0, bst.Count);
            }
        }
    }
}
