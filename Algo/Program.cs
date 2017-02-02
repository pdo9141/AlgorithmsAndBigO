using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace Algo
{
    public class ArrayStructures
    {
        private int[] theArray = new int[10];

        private int arraySize { get { return theArray.Length; } }

        public void GenerateRandomArray()
        {
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
                theArray[i] = random.Next(10, 19);
        }

        public void PrintArray()
        {
            Console.WriteLine("---------");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("| " + i + " | ");
                Console.WriteLine(theArray[i] + " |");
                Console.WriteLine("---------");
            }
        }

        public int GetValueAtIndex(int index)
        {
            if (index < arraySize)
                return theArray[index];
            return 0;
        }

        public bool DoesArrayContainThisValue(int searchValue)
        {
            bool valueInArray = false;

            for (int i = 0; i < arraySize; i++)
            {
                if (theArray[i] == searchValue)
                {
                    valueInArray = true;
                    break;
                }
            }

            return valueInArray;
        }

        public void DeleteIndex(int index)
        {
            if (index < arraySize)
            {
                for (int i = index; i < (arraySize - 1); i++)
                    theArray[i] = theArray[i + 1];

                Array.Resize(ref theArray, theArray.Length - 1);
            }
        }

        public void InsertValue(int value)
        {
            Array.Resize(ref theArray, theArray.Length + 1);
            theArray[theArray.Length - 1] = value;
        }

        public string LinearSearchForValue(int value)
        {
            bool valueInArray = false;
            string indexesWithValue = "";

            for (int i = 0; i < theArray.Length; i++)
            {
                if (theArray[i] == value)
                {
                    valueInArray = true;
                    indexesWithValue += i + " ";
                }

                PrintHorzArray(i, -1);
            }

            if (!valueInArray)
            {
                indexesWithValue = "None";
            }

            Console.WriteLine("The value was found in the following: " + indexesWithValue);
            Console.WriteLine("");

            return indexesWithValue;
        }

        public void PrintHorzArray(int i, int j)
        {
            for (int n = 0; n < 51; n++)
                Console.Write("-");

            Console.WriteLine();

            for (int n = 0; n < arraySize; n++)
            {
                Console.Write("| " + n + "  ");
            }

            Console.WriteLine("|");

            for (int n = 0; n < 51; n++)
                Console.Write("-");

            Console.WriteLine();

            for (int n = 0; n < arraySize; n++)
            {
                Console.Write("| " + theArray[n] + " ");
            }

            Console.WriteLine("|");

            for (int n = 0; n < 51; n++)
                Console.Write("-");

            Console.WriteLine();

            // END OF FIRST PART

            // ADDED FOR BUBBLE SORT            
            if (j != -1)
            {
                // ADD THE +2 TO FIX SPACING
                for (int k = 0; k < ((j * 5) + 2); k++)
                    Console.Write(" ");

                Console.Write(j);
            }

            // THEN ADD THIS CODE
            if (i != -1)
            {
                // ADD THE -1 TO FIX SPACING
                for (int l = 0; l < (5 * (i - j) - 1); l++)
                    Console.Write(" ");
                Console.Write(i);
            }

            Console.WriteLine();
        }

        public void BubbleSort()
        {
            for (int i = arraySize - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (theArray[j] > theArray[j + 1])
                    {
                        SwapValues(j, j + 1);
                        PrintHorzArray(i, j);
                    }
                }
            }
        }

        private void SwapValues(int indexOne, int indexTwo)
        {
            int temp = theArray[indexOne];
            theArray[indexOne] = theArray[indexTwo];
            theArray[indexTwo] = temp;
        }

        public void BinarySearchForValue(int value)
        {
            int lowIndex = 0;
            int highIndex = arraySize - 1;

            while (lowIndex <= highIndex)
            {
                int middleIndex = (highIndex + lowIndex) / 2;

                if (theArray[middleIndex] < value)
                {
                    lowIndex = middleIndex + 1;
                }
                else if (theArray[middleIndex] > value)
                {
                    highIndex = middleIndex - 1;
                }
                else
                {
                    Console.WriteLine("\nFound a Match for " + value + " at Index " + middleIndex);
                    lowIndex = highIndex + 1;
                }

                PrintHorzArray(middleIndex, -1);
            }
        }

        // Selection sort search for the smallest number in the array
        // saves it in the minimum spot and then repeats searching
        // through the entire array each time
        public void SelectionSort()
        {
            for (int x = 0; x < arraySize; x++)
            {
                int minimum = x;
                for (int y = x; y < arraySize; y++)
                {
                    // To change direction of sort just change
                    // this from > to <
                    if (theArray[minimum] > theArray[y])
                    {
                        minimum = y;
                    }
                }

                SwapValues(x, minimum);
                PrintHorzArray(x, -1);
            }
        }

        // The Insertion Sort is normally the best of
        // the elementary sorts. Unlike the other sorts that
        // had a group sorted at any given time, groups are
        // only partially sorted here.
        public void InsertionSort()
        {
            for (int i = 1; i < arraySize; i++)
            {
                int j = i;
                int toInsert = theArray[i];
                while ((j > 0) && (theArray[j - 1] > toInsert))
                {
                    theArray[j] = theArray[j - 1];
                    j--;

                    PrintHorzArray(i, j);
                }

                theArray[j] = toInsert;
                PrintHorzArray(i, j);

                Console.WriteLine("\nArray[i] = " + theArray[i] + " Array[j] = " + theArray[j] + " toInsert = " + toInsert + "\n");
            }
        }

        static void Main(string[] args)
        {
            var newArray = new ArrayStructures();
            newArray.GenerateRandomArray();

            var newArray1 = new ArrayStructures();
            newArray1.GenerateRandomArray();
            
            //newArray.PrintArray();

            /*
            Console.WriteLine(newArray.GetValueAtIndex(3));
            Console.WriteLine(newArray.DoesArrayContainThisValue(18));

            newArray.DeleteIndex(4);
            newArray.PrintArray();

            newArray.InsertValue(19);
            newArray.PrintArray();
            */

            //newArray.LinearSearchForValue(17);
            //newArray.BubbleSort();
            //newArray.BinarySearchForValue(15);

            //newArray.SelectionSort();
            newArray.InsertionSort();
            
            Console.ReadLine();
        }
    }
}
