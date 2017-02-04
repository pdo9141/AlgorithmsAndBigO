using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp
{
    public class BinaryTree
    {
        Node Root;

        public void AddNode(int key, string name)
        {
            Node newNode = new Node(key, name);
            if (Root == null)
            {
                Root = newNode;
            }
            else {
                Node focusNode = Root;
                Node parent;

                while (true)
                {
                    parent = focusNode;
                    if (key < focusNode.Key)
                    {
                        focusNode = focusNode.LeftChild;

                        if (focusNode == null)
                        {
                            parent.LeftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        focusNode = focusNode.RightChild;

                        if (focusNode == null)
                        {
                            parent.RightChild = newNode;
                            return;
                        }
                    }
                }                                    
            }
        }

        public void InOrderTraverseTree(Node focusNode)
        {
            if (focusNode != null)
            {
                InOrderTraverseTree(focusNode.LeftChild);
                Console.WriteLine(focusNode);
                InOrderTraverseTree(focusNode.RightChild);
            }
        }

        public void PreOrderTraverseTree(Node focusNode)
        {
            if (focusNode != null)
            {
                Console.WriteLine(focusNode);
                PreOrderTraverseTree(focusNode.LeftChild);
                PreOrderTraverseTree(focusNode.RightChild);
            }
        }

        public void PostOrderTraverseTree(Node focusNode)
        {
            if (focusNode != null)
            {
                PostOrderTraverseTree(focusNode.LeftChild);
                PostOrderTraverseTree(focusNode.RightChild);
                Console.WriteLine(focusNode);
            }
        }

        public Node FindNode(int key)
        {
            Node focusNode = Root;

            while (focusNode.Key != key)
            {
                if (key < focusNode.Key)
                    focusNode = focusNode.LeftChild;
                else 
                    focusNode = focusNode.RightChild;

                if (focusNode == null)
                    return null;
            }

            return focusNode;
        }

        public bool RemoveNode(int key)
        {
            Node focusNode = Root;
            Node parent = Root;

            bool isItALeftChild = true;

            while (focusNode.Key != key)
            {
                parent = focusNode;

                if (key < focusNode.Key)
                {
                    isItALeftChild = true;
                    focusNode = focusNode.LeftChild;
                }
                else {
                    isItALeftChild = false;
                    focusNode = focusNode.RightChild;
                }

                if (focusNode == null)
                    return false;
            }

            if (focusNode.LeftChild == null && focusNode.RightChild == null)
            {
                if (focusNode == Root)
                {
                    Root = null;
                }
                else if (isItALeftChild)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
            }
            else if (focusNode.RightChild == null)
            {
                if (focusNode == Root)
                    Root = focusNode.LeftChild;
                else if (isItALeftChild)
                    parent.LeftChild = focusNode.LeftChild;
                else
                    parent.RightChild = focusNode.LeftChild;
            }
            else if (focusNode.LeftChild == null)
            {
                if (focusNode == Root)
                    Root = focusNode.RightChild;
                else if (isItALeftChild)
                    parent.LeftChild = focusNode.RightChild;
                else
                    parent.RightChild = focusNode.LeftChild;
            }
            else {
                Node replacement = GetReplacementNode(focusNode);
                if (focusNode == Root)
                    Root = replacement;
                else if (isItALeftChild)
                    parent.LeftChild = replacement;
                else
                    parent.RightChild = replacement;

                replacement.LeftChild = focusNode.LeftChild;
            }

            return true;
        }

        private Node GetReplacementNode(Node replacedNode)
        {
            Node replacementParent = replacedNode;
            Node replacement = replacedNode;

            Node focusNode = replacedNode.RightChild;

            while (focusNode != null)
            {
                replacementParent = replacement;
                replacement = focusNode;
                focusNode = focusNode.LeftChild;
            }

            if (replacement != replacedNode.RightChild)
            {
                replacementParent.LeftChild = replacement.RightChild;
                replacement.RightChild = replacedNode.RightChild;
            }

            return replacement;
        }

        static void Main(string[] args)
        {
            BinaryTree theTree = new BinaryTree();
            theTree.AddNode(50, "Boss");
            theTree.AddNode(25, "Vice Pres");
            theTree.AddNode(15, "Office Manager");
            theTree.AddNode(30, "Secretary");
            theTree.AddNode(75, "Sales Manager");
            theTree.AddNode(85, "Salesman 1");
            
            Console.WriteLine("##### InOrder #####");
            theTree.InOrderTraverseTree(theTree.Root);

            Console.WriteLine();
            Console.WriteLine("##### PreOrder #####");
            theTree.PreOrderTraverseTree(theTree.Root);

            Console.WriteLine();
            Console.WriteLine("##### PostOrder #####");
            theTree.PostOrderTraverseTree(theTree.Root);

            Console.WriteLine();
            Console.WriteLine("Search for 30");
            Console.WriteLine(theTree.FindNode(30));

            Console.WriteLine();
            Console.WriteLine("Remove key 25");
            Console.WriteLine(theTree.RemoveNode(25));
            theTree.PostOrderTraverseTree(theTree.Root);

            Console.ReadLine();
        }
    }

    public class Node
    {
        public int Key;
        public string Name;

        public Node LeftChild;
        public Node RightChild;

        public Node(int key, string name)
        {
            this.Key = key;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name + " has a key " + Key;
        }
    }
}
