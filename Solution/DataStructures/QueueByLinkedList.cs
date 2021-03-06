﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Fast, all operations are constant time
    //
    // Con:
    //     Wasted space because of next pointer per node
    //     Cache unfriendly, data is split over many allocations
    //
    // Notes:
    //     Use for breadth-first search to track next node to process
    //
    public class QueueByLinkedList<T>
    {
        private class Link
        {
            public T Data { get; set; }
            public Link Next { get; set; }
        }

        private Link _head;
        private Link _tail;

        // O(1)
        public bool IsEmpty
        {
            get { return (_head == null); }
        }

        // O(1)
        public void Enqueue(T data)
        {
            Link tail = new Link() { Data = data };

            if (_tail != null)
                _tail.Next = tail;

            _tail = tail;

            if (_head == null)
                _head = _tail;
        }

        // O(1)
        public T Dequeue()
        {
            if (IsEmpty)
                throw new ArgumentException("Queue is empty.");

            Link head = _head;

            _head = head.Next;
            if (_head == null)
                _tail = null;

            return head.Data;
        }
    }
}
