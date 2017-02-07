using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListApp
{
    class Link
    {
        public string BookName { get; set; }

        public int MillionsSold { get; set; }

        public Link Next { get; set; }

        public Link(string bookName, int millionsSold)
        {
            BookName = bookName;
            MillionsSold = millionsSold;
        }

        public void Display()
        {
            Console.WriteLine(BookName + ": " + MillionsSold + ",000,000");
        }

        public override string ToString()
        {
            return BookName;
        }

        /*
        static void Main(string[] args)
        {
            LinkList theLinkedList = new LinkList();
            theLinkedList.InsertFirstLink("Don Quixote", 500);
            theLinkedList.InsertFirstLink("A Tale of Two Cities", 200);
            theLinkedList.InsertFirstLink("The Lord of the Rings", 150);
            theLinkedList.InsertFirstLink("Harry Potter and the Sorcerer's Stone", 107);
            theLinkedList.Display();
            Console.WriteLine("###########################");

            theLinkedList.RemoveFirst();
            theLinkedList.Display();
            Console.WriteLine("###########################");

            Console.WriteLine(theLinkedList.Find("The Lord of the Rings").BookName + " was found.");
            Console.WriteLine();

            Console.WriteLine("###########################");
            theLinkedList.RemoveLink("The Lord of the Rings");
            theLinkedList.Display();

            Console.ReadLine();
        }
        */
    }

    class LinkList
    {
        public Link FirstLink { get; set; }

        public LinkList()
        {
        }

        public bool IsEmpty()
        {
            return FirstLink == null;
        }

        public void InsertFirstLink(string bookName, int millionsSold)
        {
            Link newLink = new Link(bookName, millionsSold);
            newLink.Next = FirstLink;
            FirstLink = newLink;
        }

        public Link RemoveFirst()
        {
            Link linkReference = FirstLink;

            if (!IsEmpty())
                FirstLink = FirstLink.Next;
            else
                Console.WriteLine("Empty LinkedList");

            return linkReference;
        }

        public void Display()
        {
            Link theLink = FirstLink;

            while (theLink != null)
            {
                theLink.Display();
                Console.WriteLine("Next Link: " + theLink.Next);
                theLink = theLink.Next;
                Console.WriteLine();
            }
        }

        public Link Find(string bookName)
        {
            Link theLink = FirstLink;

            if (!IsEmpty())
            {
                while (theLink.BookName != bookName)
                {
                    if (theLink.Next == null)
                    {
                        return null;
                    }
                    else
                    {
                        theLink = theLink.Next;
                    }
                }
            }
            else
            {
                Console.WriteLine("Empty LinkedList");
            }

            return theLink;
        }

        public Link RemoveLink(string bookName)
        {
            Link currentLink = FirstLink;
            Link previousLink = FirstLink;

            while (currentLink.BookName != bookName)
            {
                if (currentLink.Next == null)
                {
                    return null;
                }
                else
                {
                    previousLink = currentLink;
                    currentLink = currentLink.Next;
                }
            }

            if (currentLink == FirstLink)
            {
                FirstLink = FirstLink.Next;
            }
            else
            {
                previousLink.Next = currentLink.Next;
            }

            return currentLink;
        }
    }
}
