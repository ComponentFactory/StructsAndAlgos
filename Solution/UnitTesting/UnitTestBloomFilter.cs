using DataStructures;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTesting
{
    public class UnitTestBloomFilter
    {
        [Fact]
        public void VectorSize31()
        {
            BloomFilter<int> bf = new BloomFilter<int>(31);
            Assert.Equal(1, bf.VectorSize);
        }

        [Fact]
        public void VectorSize32()
        {
            BloomFilter<int> bf = new BloomFilter<int>(32);
            Assert.Equal(1, bf.VectorSize);
        }

        [Fact]
        public void VectorSize33()
        {
            BloomFilter<int> bf = new BloomFilter<int>(33);
            Assert.Equal(2, bf.VectorSize);
        }

        [Fact]
        public void VectorSize63()
        {
            BloomFilter<int> bf = new BloomFilter<int>(63);
            Assert.Equal(2, bf.VectorSize);
        }

        [Fact]
        public void VectorSize64()
        {
            BloomFilter<int> bf = new BloomFilter<int>(64);
            Assert.Equal(2, bf.VectorSize);
        }

        [Fact]
        public void VectorSize65()
        {
            BloomFilter<int> bf = new BloomFilter<int>(65);
            Assert.Equal(3, bf.VectorSize);
        }

        [Fact]
        public void Add1()
        {
            BloomFilter<int> bf = new BloomFilter<int>();

            bf.Add(1);
            Assert.True(bf.Contains(1));
        }

        [Fact]
        public void ContainsMillion()
        {
            for(int i=0; i<1000000; i++)
            {
                BloomFilter<int> bf = new BloomFilter<int>();

                bf.Add(i);
                Assert.True(bf.Contains(i));
            }
        }

        [Fact]
        public void UniqueMillion()
        {
            BloomFilter<int> bf = new BloomFilter<int>();
            bf.Add(0);
            Assert.True(bf.Contains(0));

            for (int i = 1; i < 2000000; i++)
                Assert.False(bf.Contains(i));
        }

        [Fact]
        public void Random()
        {
            Random random = new Random();
            for (int i=0; i<5000; i++)
            {
                BloomFilter<int> bf = new BloomFilter<int>();
                List<int> values = new List<int>();

                for (int j=0; j<50; j++)
                {
                    DataStructures.HashSet<int> hashSet = new DataStructures.HashSet<int>();
                    int rand = random.Next();
                    if (!hashSet.Contains(rand))
                    {
                        values.Add(rand);
                        hashSet.Add(rand);
                        bf.Add(rand);
                    }
                }

                foreach (int check in values)
                    Assert.True(bf.Contains(check));
            }
        }
    }
}
