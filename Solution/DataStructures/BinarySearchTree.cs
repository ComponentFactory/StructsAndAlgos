using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class BinarySearchTree<T, U> where T : IComparable<T>
    {
        private TreeNode<T, U> _root;

        public int Count { get; private set; }

        // O(log n) average case, O(n) worst case   
        public bool Contains(T key)
        {
            TreeNode<T, U> node = _root;
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
            TreeNode<T, U> node = _root;
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
                _root = new TreeNode<T, U>() { Key = key, Data = data };
            else
            {
                TreeNode<T, U> node = _root;
                while (node != null)
                {
                    int compare = key.CompareTo(node.Key);
                    if (compare == 0)
                        throw new ApplicationException("Key already used.");
                    else if (compare < 0)
                    {
                        if (node.Left == null)
                        {
                            node.Left = new TreeNode<T, U>() { Key = key, Data = data };
                            break;
                        }
                        else
                            node = node.Left;
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = new TreeNode<T, U>() { Key = key, Data = data };
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
            // TODO
        }

        public List<T> KeysByRecursion()
        {
            List<T> orderedKeys = new List<T>();
            KeysByRecursionImpl(_root, orderedKeys);
            return orderedKeys;
        }

        public List<T> KeysByQueue()
        {
            List<T> orderedKeys = new List<T>();

            StackByArray<TreeNode<T, U>> stack = new StackByArray<TreeNode<T, U>>();
            TreeNode<T, U> node = _root;

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

        private void KeysByRecursionImpl(TreeNode<T, U> node, List<T> orderedKeys)
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
