using System;

namespace DataStructures
{
    public sealed class TreeNode<T, U>
    {
        public T Key { get; set; }
        public U Data { get; set; }

        public TreeNode<T, U> Left;
        public TreeNode<T, U> Right;
    }
}
