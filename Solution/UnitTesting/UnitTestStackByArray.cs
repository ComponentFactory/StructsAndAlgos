using DataStructures;
using System;
using Xunit;

namespace UnitTesting
{
    public class UnitTestStackByArray
    {
        [Fact]
        public void None()
        {
            StackByArray<int> sa = new StackByArray<int>();
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void One()
        {
            StackByArray<int> sa = new StackByArray<int>();

            sa.Push(1);
            Assert.Equal(1, sa.Pop());
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void Two()
        {
            StackByArray<int> sa = new StackByArray<int>();

            sa.Push(1);
            sa.Push(2);
            Assert.Equal(2, sa.Pop());
            Assert.False(sa.IsEmpty);
            Assert.Equal(1, sa.Pop());
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void Five()
        {
            StackByArray<int> sa = new StackByArray<int>();

            sa.Push(1);
            sa.Push(2);
            sa.Push(3);
            sa.Push(4);
            sa.Push(5);
            Assert.Equal(5, sa.Pop());
            Assert.False(sa.IsEmpty);
            Assert.Equal(4, sa.Pop());
            Assert.False(sa.IsEmpty);
            Assert.Equal(3, sa.Pop());
            Assert.False(sa.IsEmpty);
            Assert.Equal(2, sa.Pop());
            Assert.False(sa.IsEmpty);
            Assert.Equal(1, sa.Pop());
            Assert.True(sa.IsEmpty);
        }
    }
}
