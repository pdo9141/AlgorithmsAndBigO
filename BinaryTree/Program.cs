using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Node
    {
        private int key;
        private string name;

        Node leftChild;
        Node rightChild;

        public Node(int key, string name)
        {
            this.key = key;
            this.name = name;
        }

        public override string ToString()
        {
            return name + " has a key " + key;
        }
    }
}
