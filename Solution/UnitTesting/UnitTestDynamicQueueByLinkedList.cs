using DataStructures;
using System;
using Xunit;

namespace UnitTesting
{
    public class UnitTestDynamicQueueByLinkedList
    {
        [Fact]
        public void None()
        {
            QueueByLinkedList<int> sa = new QueueByLinkedList<int>();
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void One()
        {
            QueueByLinkedList<int> sa = new QueueByLinkedList<int>();

            sa.Enqueue(1);
            Assert.Equal(1, sa.Dequeue());
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void Two()
        {
            QueueByLinkedList<int> sa = new QueueByLinkedList<int>();

            sa.Enqueue(1);
            sa.Enqueue(2);
            Assert.Equal(1, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(2, sa.Dequeue());
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void Five()
        {
            QueueByLinkedList<int> sa = new QueueByLinkedList<int>();

            sa.Enqueue(1);
            sa.Enqueue(2);
            sa.Enqueue(3);
            sa.Enqueue(4);
            sa.Enqueue(5);
            Assert.Equal(1, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(2, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(3, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(4, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(5, sa.Dequeue());
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void TwoTwo()
        {
            QueueByLinkedList<int> sa = new QueueByLinkedList<int>();

            sa.Enqueue(1);
            sa.Enqueue(2);
            Assert.Equal(1, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(2, sa.Dequeue());
            Assert.True(sa.IsEmpty);

            sa.Enqueue(3);
            sa.Enqueue(4);
            Assert.Equal(3, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(4, sa.Dequeue());
            Assert.True(sa.IsEmpty);
        }

        [Fact]
        public void Nested()
        {
            QueueByLinkedList<int> sa = new QueueByLinkedList<int>();

            sa.Enqueue(1);
            sa.Enqueue(2);
            Assert.Equal(1, sa.Dequeue());
            Assert.False(sa.IsEmpty);

            sa.Enqueue(3);
            sa.Enqueue(4);
            Assert.Equal(2, sa.Dequeue());
            Assert.False(sa.IsEmpty);

            Assert.Equal(3, sa.Dequeue());
            Assert.False(sa.IsEmpty);
            Assert.Equal(4, sa.Dequeue());
            Assert.True(sa.IsEmpty);
        }
    }
}
