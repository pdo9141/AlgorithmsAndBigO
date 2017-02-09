using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace BigO
{
    /******************************************************************
     * Big O Notation describes the worst case scenario
     *******************************************************************/
    public class BigONotation
    {
        private static Stopwatch sw = new Stopwatch();
        private int[] theArray;
        private int arraySize;
        private int itemsInArray = 0;

        public BigONotation(int size)
        {
            arraySize = size;
            theArray = new int[size];
        }

        static void Main(string[] args)
        {
            BigONotation testAlgo2 = new BigONotation(10000);
            testAlgo2.GenerateRandomArray();

            BigONotation testAlgo3 = new BigONotation(20000);
            testAlgo3.GenerateRandomArray();

            BigONotation testAlgo4 = new BigONotation(300000);
            testAlgo4.GenerateRandomArray();

            BigONotation testAlgo5 = new BigONotation(400000);
            testAlgo5.GenerateRandomArray();

            // O(N)
            //testAlgo2.LinearSearchForValue(20);
            //testAlgo3.LinearSearchForValue(20);
            //testAlgo4.LinearSearchForValue(20);

            // O(N^2)
            //testAlgo2.BubbleSort();
            //testAlgo3.BubbleSort();

            // O(log N)
            //testAlgo2.BinarySearchForValue(20);
            //testAlgo3.BinarySearchForValue(20);

            // O(N log N)
            sw.Reset();
            sw.Start();

            testAlgo5.QuickSort(0, testAlgo5.itemsInArray);

            sw.Stop();
            Console.WriteLine("Quick Sort Took: {0}", sw.ElapsedMilliseconds);

            Console.ReadLine();
        }

        public void GenerateRandomArray()
        {
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
                theArray[i] = random.Next(0, 1000);

            itemsInArray = arraySize - 1;
        }

        private void SwapValues(int indexOne, int indexTwo)
        {
            int temp = theArray[indexOne];
            theArray[indexOne] = theArray[indexTwo];
            theArray[indexTwo] = temp;
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

        /******************************************************************
         * O(1) = Order of 1
         * Executes in same amount of time regardless of amount of data
         * In other words no matter how big the array is   
         * Describes an algorithm that will always execute in the same 
         *      time (or space) regardless of the size of the input data set.
         *******************************************************************/
        public void AddItemToArray(int newItem)
        {
            theArray[itemsInArray++] = newItem;
        }

        public bool IsFirstElementNull(IList<string> elements)
        {
            return elements[0] == null;
        }

        /******************************************************************
         * O(N) = Order of N
         * Time to complete is directly correlated to amount of data
         * Time to complete will grow in direct proportion to amount of data  
         * Describes an algorithm whose performance will grow linearly
         *      and in direct proportion to the size of the input data set
         *******************************************************************/
        public void LinearSearchForValue(int value)
        {
            bool valueInArray = false;

            sw.Reset();
            sw.Start();

            for (int i = 0; i < arraySize; i++)
                if (theArray[i] == value)
                    valueInArray = true;
            
            sw.Stop();
            Console.WriteLine("Value Found: {0}", valueInArray);
            Console.WriteLine("Linear Search Took: {0}", sw.ElapsedMilliseconds);
        }

        public bool ContainsValue(IList<string> elements, string value)
        {
            foreach (var element in elements)
            {
                if (element == value) return true;
            }

            return false;
        }

        /******************************************************************
         * O(N^2) = Order of N squared or Order of N cubed
         * Time to complete will be proportional to the square of the amount of data
         * Algorithms with nested iterations like the bubble sort
         * Very bad and should be avoided
         * Deeper nested iterations will result in O(N3), O(N4) etc.
         *******************************************************************/
        public void BubbleSort()
        {
            sw.Reset();
            sw.Start();

            for (int i = arraySize - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (theArray[j] > theArray[j + 1])
                    {
                        SwapValues(j, j + 1);
                        //PrintHorzArray(i, j);
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("Bubble Sort Took: {0}", sw.ElapsedMilliseconds);
        }

        public bool ContainsDuplicates(IList<string> elements)
        {
            for (var outer = 0; outer < elements.Count; outer++)
            {
                for (var inner = 0; inner < elements.Count; inner++)
                {
                    // Don't compare with self
                    if (outer == inner) continue;

                    if (elements[outer] == elements[inner]) return true;
                }
            }

            return false;
        }

        /******************************************************************
         * O(log N) = Order of log N
         * Data being used is decreased roughly by 50% each time through the algorithm
         * Binary Search is a perfect example of this
         *******************************************************************/
        public void BinarySearchForValue(int value)
        {
            sw.Reset();
            sw.Start();

            int lowIndex = 0;
            int highIndex = arraySize - 1;
            int timesThrough = 0;

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

                timesThrough++;
                //PrintHorzArray(middleIndex, -1);
            }

            sw.Stop();
            Console.WriteLine("Binary Search Took: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Times Through: {0}", timesThrough);
        }

        /******************************************************************
         * O(N log N) = Order of N log N
         * Comparisons = log n!
         * Comparisons = log n + log(n-1) + ..... + log(1)
         * Comparisons = n log n
         * In most situations Quick Sort is the fastest sorting algorithm
         * Works by partitioning arrays so that the smaller numbers are on the left and larger are on the right
         * It then recursively sends small parts of larger arrays to itself and partitions again
         *******************************************************************/
        public void QuickSort(int left, int right)
        {
            if (right - left <= 0)
            {
                return; // everything is sorted
            }
            else
            {
                // It doesn't matter what the pivot is, but it must
                // be a value in the array
                int pivot = theArray[right];
                int pivotLocation = PartitionArray(left, right, pivot);
                QuickSort(left, pivotLocation - 1); // Sorts the left side
                QuickSort(pivotLocation + 1, right);
            }
        }

        public int PartitionArray(int left, int right, int pivot)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            while (true)
            {
                while (theArray[++leftPointer] < pivot)
                    ;
                
                while (rightPointer > 0 && theArray[--rightPointer] > pivot)
                    ;
                
                if (leftPointer >= rightPointer)
                {
                    break;
                }
                else
                {
                    SwapValues(leftPointer, rightPointer);
                }
            }

            SwapValues(leftPointer, right);
            return leftPointer;
        }
    }
}
