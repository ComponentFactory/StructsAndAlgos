using DataStructures;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace UnitTesting
{
    public class UnitTestBinaryHeap
    {
        [Fact]
        public void Initial()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void One()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            Assert.Equal(1, bh.Count);

            var r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void TwoA()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(2, 22);
            Assert.Equal(2, bh.Count);

            var r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void TwoB()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(1, 21);
            Assert.Equal(2, bh.Count);

            var r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void ThreeA()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(2, 22);
            bh.Add(3, 23);
            Assert.Equal(3, bh.Count);

            var r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void ThreeB()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(3, 23);
            bh.Add(2, 22);
            Assert.Equal(3, bh.Count);

            var r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void ThreeC()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(1, 21);
            bh.Add(3, 23);
            Assert.Equal(3, bh.Count);

            var r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void ThreeD()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(3, 23);
            bh.Add(1, 21);
            Assert.Equal(3, bh.Count);

            var r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void ThreeE()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(2, 22);
            bh.Add(1, 21);
            Assert.Equal(3, bh.Count);

            var r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void ThreeF()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(1, 21);
            bh.Add(2, 22);
            Assert.Equal(3, bh.Count);

            var r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four1A()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(2, 22);
            bh.Add(3, 23);
            bh.Add(4, 24);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four1B()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(3, 23);
            bh.Add(2, 22);
            bh.Add(4, 24);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four1C()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(1, 21);
            bh.Add(3, 23);
            bh.Add(4, 24);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four1D()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(3, 23);
            bh.Add(1, 21);
            bh.Add(4, 24);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four1E()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(2, 22);
            bh.Add(1, 21);
            bh.Add(4, 24);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four1F()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(1, 21);
            bh.Add(2, 22);
            bh.Add(4, 24);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four2A()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(2, 22);
            bh.Add(4, 24);
            bh.Add(3, 23);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four2B()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(3, 23);
            bh.Add(4, 24);
            bh.Add(2, 22);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four2C()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(1, 21);
            bh.Add(4, 24);
            bh.Add(3, 23);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four2D()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(3, 23);
            bh.Add(4, 24);
            bh.Add(1, 21);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four2E()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(2, 22);
            bh.Add(4, 24);
            bh.Add(1, 21);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four2F()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(1, 21);
            bh.Add(4, 24);
            bh.Add(2, 22);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four3A()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(4, 24);
            bh.Add(2, 22);
            bh.Add(3, 23);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four3B()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(1, 21);
            bh.Add(4, 24);
            bh.Add(3, 23);
            bh.Add(2, 22);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four3C()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(4, 24);
            bh.Add(1, 21);
            bh.Add(3, 23);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four3D()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(2, 22);
            bh.Add(4, 24);
            bh.Add(3, 23);
            bh.Add(1, 21);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four3E()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(4, 24);
            bh.Add(2, 22);
            bh.Add(1, 21);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four3F()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(3, 23);
            bh.Add(4, 24);
            bh.Add(1, 21);
            bh.Add(2, 22);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four4A()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(4, 24);
            bh.Add(1, 21);
            bh.Add(2, 22);
            bh.Add(3, 23);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four4B()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(4, 24);
            bh.Add(1, 21);
            bh.Add(3, 23);
            bh.Add(2, 22);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four4C()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(4, 24);
            bh.Add(2, 22);
            bh.Add(1, 21);
            bh.Add(3, 23);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four4D()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(4, 24);
            bh.Add(2, 22);
            bh.Add(3, 23);
            bh.Add(1, 21);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four4E()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(4, 24);
            bh.Add(3, 23);
            bh.Add(2, 22);
            bh.Add(1, 21);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Four4F()
        {
            BinaryHeap<int, int> bh = new BinaryHeap<int, int>();

            bh.Add(4, 24);
            bh.Add(3, 23);
            bh.Add(1, 21);
            bh.Add(2, 22);
            Assert.Equal(4, bh.Count);

            var r = bh.Pop();
            Assert.Equal(4, r.Item1);
            Assert.Equal(24, r.Item2);
            Assert.Equal(3, bh.Count);

            r = bh.Pop();
            Assert.Equal(3, r.Item1);
            Assert.Equal(23, r.Item2);
            Assert.Equal(2, bh.Count);

            r = bh.Pop();
            Assert.Equal(2, r.Item1);
            Assert.Equal(22, r.Item2);
            Assert.Equal(1, bh.Count);

            r = bh.Pop();
            Assert.Equal(1, r.Item1);
            Assert.Equal(21, r.Item2);
            Assert.Equal(0, bh.Count);
        }

        [Fact]
        public void Random()
        {
            // Test with between 2 and 100 nodes
            for (int count = 2; count < 100; count++)
            {
                // Test 100 times with the same number of nodes
                for (int j = 0; j < 100; j++)
                {
                    DataStructures.HashSet<int> hashSet = new DataStructures.HashSet<int>();
                    List<int> ordered = new List<int>();

                    Random random = new Random();
                    for (int i = 0; i < count; i++)
                    {
                        // Only use unique numbers
                        int rand = random.Next();
                        if (!hashSet.Contains(rand))
                        {
                            ordered.Add(rand);
                            hashSet.Add(rand);
                        }
                    }

                    BinaryHeap<int, int> bh = new BinaryHeap<int, int>();
                    foreach (int i in ordered)
                        bh.Add(i, i);

                    Assert.Equal(ordered.Count, bh.Count);

                    ordered.Sort();
                    ordered.Reverse();
                    foreach (int i in ordered)
                        Assert.Equal(i, bh.Pop().Item1);
                }
            }
        }
    }
}
