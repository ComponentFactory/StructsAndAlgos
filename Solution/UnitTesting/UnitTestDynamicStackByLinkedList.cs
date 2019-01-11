using DataStructures;
using System;
using Xunit;

namespace UnitTesting
{
    public class UnitTestDynamicStackByLinkedList
    {
        [Fact]
        public void None()
        {
            StackByLinkedList<int> sl = new StackByLinkedList<int>();
            Assert.True(sl.IsEmpty);
        }

        [Fact]
        public void One()
        {
            StackByLinkedList<int> sl = new StackByLinkedList<int>();

            sl.Push(1);
            Assert.Equal(1, sl.Pop());
            Assert.True(sl.IsEmpty);
        }

        [Fact]
        public void Two()
        {
            StackByLinkedList<int> sl = new StackByLinkedList<int>();

            sl.Push(1);
            sl.Push(2);
            Assert.Equal(2, sl.Pop());
            Assert.False(sl.IsEmpty);
            Assert.Equal(1, sl.Pop());
            Assert.True(sl.IsEmpty);
        }

        [Fact]
        public void Five()
        {
            StackByLinkedList<int> sl = new StackByLinkedList<int>();

            sl.Push(1);
            sl.Push(2);
            sl.Push(3);
            sl.Push(4);
            sl.Push(5);
            Assert.Equal(5, sl.Pop());
            Assert.False(sl.IsEmpty);
            Assert.Equal(4, sl.Pop());
            Assert.False(sl.IsEmpty);
            Assert.Equal(3, sl.Pop());
            Assert.False(sl.IsEmpty);
            Assert.Equal(2, sl.Pop());
            Assert.False(sl.IsEmpty);
            Assert.Equal(1, sl.Pop());
            Assert.True(sl.IsEmpty);
        }
    }
}
