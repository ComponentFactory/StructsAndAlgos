using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    // Pro:
    //     Variable size
    //     Flexible keys, not just integer positions
    //     Ordered enumeration of keys
    //     Balanced O(log n) but degenerate case becomes O(n) 
    //
    // Con:
    //     Cache unfriendly, data is not in a single contiguous block
    //
    // Notes:
    //     Slower than hashtable but ordered
    //
    public class BinarySearchTree<T, U> where T : IComparable<T>
    {
        private class TreeNode
        {
            public T Key { get; set; }
            public U Data { get; set; }

            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        private TreeNode _root;

        public int Count { get; private set; }

        // O(log n) average case, O(n) worst case   
        public bool Contains(T key)
        {
            TreeNode node = _root;
            while(node != null)
            {
                int compare = key.CompareTo(node.Key);
                if (compare == 0)
                    return true;
                else if (compare < 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            return false;
        }

        // O(log n) average case, O(n) worst case   
        public U Find(T key)
        {
            TreeNode node = _root;
            while (node != null)
            {
                int compare = key.CompareTo(node.Key);
                if (compare == 0)
                    return node.Data;
                else if (compare < 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            throw new ApplicationException("Key not found.");
        }

        // O(log n) average case, O(n) worst case   
        public void Insert(T key, U data)
        {
            if (_root == null)
                _root = new TreeNode() { Key = key, Data = data };
            else
            {
                TreeNode node = _root;
                while (node != null)
                {
                    int compare = key.CompareTo(node.Key);
                    if (compare == 0)
                        throw new ApplicationException("Key already used.");
                    else if (compare < 0)
                    {
                        if (node.Left == null)
                        {
                            node.Left = new TreeNode() { Key = key, Data = data };
                            break;
                        }
                        else
                            node = node.Left;
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = new TreeNode() { Key = key, Data = data };
                            break;
                        }
                        else
                            node = node.Right;
                    }
                }
            }

            Count++;
        }

        // O(log n) average case, O(n) worst case   
        public void Delete(T key)
        {
            if (_root != null)
            {
                _root = DeleteImpl(_root, key);
                Count--;
            }
            else
                throw new ApplicationException("Key not found.");
        }

        private TreeNode DeleteImpl(TreeNode node, T key)
        {
            // Is this the node to be deleted
            int compare = key.CompareTo(node.Key);
            if (compare == 0)
            {
                // Has no children, replace this node with null
                if ((node.Left == null) && (node.Right == null))
                    return null;

                // Has one child, replace this node with the one child
                if ((node.Left != null) && (node.Right == null))
                    return node.Left;
                else if ((node.Left == null) && (node.Right != null))
                    return node.Right;

                // Has two children, find successor Key on the right side
                TreeNode next = node.Right;
                while (next.Left != null)
                    next = next.Left;

                // Copy successor node Key/Data to the top node
                node.Key = next.Key;
                node.Data = next.Data;

                // Remove the redundant successor from the right side
                node.Right = DeleteImpl(node.Right, next.Key);
            }
            else if (compare < 0)
            {
                if (node.Left != null)
                    node.Left = DeleteImpl(node.Left, key);
                else
                    throw new ApplicationException("Key not found.");
            }
            else
            {
                if (node.Right != null)
                    node.Right = DeleteImpl(node.Right, key);
                else
                    throw new ApplicationException("Key not found.");
            }

            return node;
        }

        // O(n)
        public List<T> KeysByRecursion()
        {
            List<T> orderedKeys = new List<T>();
            KeysByRecursionImpl(_root, orderedKeys);
            return orderedKeys;
        }

        // O(n)
        public List<T> KeysByQueue()
        {
            List<T> orderedKeys = new List<T>();

            StackByArray<TreeNode> stack = new StackByArray<TreeNode>();
            TreeNode node = _root;

            while ((node != null) || !stack.IsEmpty)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();
                orderedKeys.Add(node.Key);
                node = node.Right;
            }

            return orderedKeys;
        }

        private void KeysByRecursionImpl(TreeNode node, List<T> orderedKeys)
        {
            if (node != null)
            {
                KeysByRecursionImpl(node.Left, orderedKeys);
                orderedKeys.Add(node.Key);
                KeysByRecursionImpl(node.Right, orderedKeys);
            }
        }
    }
}
