using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

/***************************************************************
* In most situations Quick Sort is the fastest sorting algorithm
****************************************************************/
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
                theArray[i] = random.Next(10, 60);
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

        public void PrintHorzArray(int i, int j, int h)
        {
            if (i == j)
                i = i - h;

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

            if (i != -1)
            {
                // Number of spaces to put before the F
                int spacesBeforeFront = 5 * i + 1;

                for (int k = 0; k < spacesBeforeFront; k++)
                    Console.Write(" ");

                Console.Write("I");

                // Number of spaces to put before the R
                int spacesBeforeRear = (5 * j + 1 - 1) - spacesBeforeFront;

                for (int l = 0; l < spacesBeforeRear; l++)
                    Console.Write(" ");

                Console.Write("O");
                Console.Write("\n");
            }
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

        // Sorts indexes at intervals to improve performance over insertion sort
        // Insertion sort will not perform well if there's a big gap between numbers between intervals
        public void ShellSort()
        {
            int inner, outer, temp;
            int interval = 1;

            while (interval <= arraySize / 3)
            {
                // Define an interval sequence
                interval = interval * 3 + 1;
            }

            // Keep looping until the interval is 1
            // Then this becomes an insertion sort
            while (interval > 0)
            {
                // Continue incrementing outer until the end of the array is reached
                for (outer = interval; outer < arraySize; outer++)
                {
                    // Store the value of the array in temp unless it has to be
                    // copied to a space occupied by a bigger number closer to the
                    // beginning of the array
                    temp = theArray[outer];

                    Console.WriteLine("Copy " + theArray[outer] + " into temp");

                    // inner is assigned the value of the highest index to check
                    // against all values the proceed it. Along the way if a
                    // number is greater than temp it will be moved up in the array
                    inner = outer;

                    Console.WriteLine("Checking if " 
                        + theArray[inner - interval] + " in index "
                        + (inner - interval) + " is bigger than " + temp);

                    // While there is a number bigger than temp move it further
                    // up in the array
                    while (inner > interval - 1 && theArray[inner - interval] >= temp)
                    {
                        Console.WriteLine("In While Checking if " + theArray[inner - interval] 
                            + " in index " + (inner - interval) + " is bigger than " + temp);

                        PrintHorzArray(inner, outer, interval);

                        // Make room for the smaller temp by moving values in the array
                        // up one space if they are greater than temp
                        theArray[inner] = theArray[inner - interval];

                        Console.WriteLine(theArray[inner - interval] + " moved to index" + inner);

                        inner -= interval;

                        Console.WriteLine("inner = " + inner);

                        PrintHorzArray(inner, outer, interval);

                        Console.WriteLine("outer = " + outer);
                        Console.WriteLine("temp = " + temp);
                        Console.WriteLine("interval = " + interval);
                    }

                    // Now that everything has been moved into place put the value
                    // stored in temp into the index above the first value smaller than it is
                    theArray[inner] = temp;
                    Console.WriteLine(temp + " moved to index " + inner);
                    PrintHorzArray(inner, outer, interval);
                }

                // Once we get here we have interval sorted our array
                // so we decrement interval and go again
                interval = (interval - 1) / 3;
            }            
        }

        // In most situations Quick Sort is the fastest sorting algorithm
        // Works by partitioning arrays so that the smaller numbers are on the left and larger are on the right
        // It then recursively sends small parts of larger arrays to itself and partitions again
        public void QuickSort(int left, int right)
        {
            if (right - left <= 0) {
                return; // everything is sorted
            }
            else {
                // It doesn't matter what the pivot is, but it must
                // be a value in the array
                int pivot = theArray[right];

                Console.Write("Value in right " + theArray[right] 
                    + " is made the pivot");

                Console.Write("left = " + left + " right= " + right 
                    + " pivot= " + pivot + " sent to be partitioned");

                int pivotLocation = PartitionArray(left, right, pivot);

                Console.Write("Value in left " + theArray[left] 
                    + " is made the pivot");

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

                PrintHorzArray(leftPointer, rightPointer);

                Console.Write(theArray[leftPointer] + " in index " 
                    + leftPointer + " is bigger than the pivot value " + pivot);

                while (rightPointer > 0 && theArray[--rightPointer] > pivot)
                    ;

                PrintHorzArray(leftPointer, rightPointer);


                Console.Write(theArray[rightPointer] + " in index " 
                    + rightPointer + " is smaller than the pivot value "
                    + pivot);

                PrintHorzArray(leftPointer, rightPointer);

                if (leftPointer >= rightPointer)
                {
                    Console.Write("left is >= right so start again");
                    break;
                }
                else
                {
                    SwapValues(leftPointer, rightPointer);

                    Console.Write(theArray[leftPointer] + " was swapped for "
                        + theArray[rightPointer]);
                }
            }

            SwapValues(leftPointer, right);
            return leftPointer;
        }

        static void Main(string[] args)
        {
            var newArray = new ArrayStructures();
            newArray.GenerateRandomArray();
            newArray.PrintArray();

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
            //newArray.InsertionSort();

            //newArray.ShellSort();
            //newArray.QuickSort(0, newArray.arraySize - 1);
            Console.ReadLine();
        }
    }
}
