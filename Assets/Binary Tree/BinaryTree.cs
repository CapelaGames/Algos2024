using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AAI.BinaryTree
{
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }

    public class BinaryTree : MonoBehaviour
    {
        private TreeNode root;

        private void Start()
        {
            root = new TreeNode(5);
            
            Insert(3, root);
            Insert(10, root);
            Insert(8, root);
            Insert(7, root);
            Insert(1, root);
            Insert(9, root);
            Insert(2, root);
            Insert(0, root);
            Insert(12, root);
            Insert(11, root);
            Insert(13, root);
            
           PrintInOrder(root);

           root = Delete(15, root);
           Debug.Log("Found: " + Search(10, root).value);
           PrintInOrder(root);

            
        }

        public void Insert(int value, TreeNode current)
        {
            if (value < current.value)
            {
                if (current.left == null)
                    current.left = new TreeNode(value);
                else
                    Insert(value, current.left);
            }
            if (value >= current.value)
            {
                if (current.right == null)
                    current.right = new TreeNode(value);
                else
                    Insert(value, current.right);
            }
        }

        public TreeNode Search(int value, TreeNode current)
        {
            if (value == current.value) return current;

            if (value < current.value)
            {
                if (current.left == null)
                    return null;
                else
                    return Search(value, current.left);
            }
            if (value > current.value)
            {
                if (current.right == null)
                    return null;
                else
                    return Search(value, current.right);
            }

            return null;
        }
        

        void PrintInOrder(TreeNode node)
        {
            if (node == null) return;
            PrintInOrder(node.left);
            Debug.Log(node.value);
            PrintInOrder(node.right);
        }
        
        void PrintInPreOrder(TreeNode node)
        {
            if (node == null) return;
            Debug.Log(node.value);
            PrintInPreOrder(node.left);
            PrintInPreOrder(node.right);
        }
        
        void PrintInPostOrder(TreeNode node)
        {
            if (node == null) return;
            PrintInPostOrder(node.left);
            PrintInPostOrder(node.right);
            Debug.Log(node.value);
        }

        public TreeNode Delete(int value, TreeNode current)
        {
            if (current == null) return current;
            
            if(value < current.value)
            {
                current.left = Delete( value,current.left);
            }
            else if (value > current.value)
            {
                current.right = Delete( value,current.right);
            }
            else
            {
                if (current.left == null)
                {
                    return current.right;
                }

                if (current.right == null)
                {
                    return current.left;
                }

                TreeNode successor = GetSuccessor(current);
                current.value = successor.value;
                current.right = Delete(successor.value, current.right);
            }

            return current;
        }

        public TreeNode GetSuccessor(TreeNode current)
        {
            current = current.right;
            while (current != null && current.left != null)
            {
                current = current.left;
            }

            return current;
        }
    }
}