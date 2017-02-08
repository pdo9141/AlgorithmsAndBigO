using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***************************************************************
* You can use recursion to calculate triangular numbers and factorials
* You used it to updated parent IDs of children properties
****************************************************************/
namespace RecursionApp
{
    public class Recursion
    {
        static void Main(string[] args)
        {
            Recursion recursionTool = new Recursion();

            // Demonstrate what a triangular number is
            // Triangular numbers can be visualized as triangles
            // Equals itself plus every number before it to 1
            // TN of 5 = 5+4+3+2+1

            recursionTool.calculateSquaresToPrint(10);

            Console.WriteLine("\nTriangular Number: " + recursionTool.getTriangularNum(3) + "\n");

            Console.WriteLine("GET TRIANGULAR NUMBER");

            Console.WriteLine("Recursion Triangular Number: " + recursionTool.getTriangularNumR(6));

            Console.WriteLine("\nGET FACTORIAL");

            Console.WriteLine("Factorial: " + recursionTool.getFactorial(3));

            Console.ReadLine();
        }

        // Calculate triangular number not using recursion

        public int getTriangularNum(int number)
        {

            int triangularNumber = 0;

            while (number > 0)
            {

                triangularNumber = triangularNumber + number;
                number--;

            }

            // If number equals 3, you find TN by adding 3+2+1 = 6

            return triangularNumber;

        }

        // Calculate triangular number using recursion

        public int getTriangularNumR(int number)
        {

            // Every recursive method must have a condition that
            // leads to the method no longer making another method
            // call on itself. This is known as the base case

            Console.WriteLine("Method " + number);

            if (number == 1)
            {

                Console.WriteLine("Returned 1");

                return 1;

            }
            else
            {

                int result = number + getTriangularNumR(number - 1);

                Console.Write("Return " + result);

                Console.WriteLine(" : " + number + " + getFactorial(" + number + " - 1)");

                return result;

            }

        }

        // Returns the factorial of a number
        // factorial(3) = 3 * 2 * 1

        public int getFactorial(int number)
        {

            Console.WriteLine("Method " + number);

            if (number == 1)
            {

                Console.WriteLine("Returned 1");

                return 1;

            }
            else
            {

                int result = number * getFactorial(number - 1);

                Console.Write("Return " + result);

                Console.WriteLine(" : " + number + " * getFactorial(" + number + " - 1)");

                return result;

            }

        }


        // USED TO DEMONSTRATE TRIANGULAR NUMBERS --------------------

        // Draws the number of squares that are passed in horizontally 

        public void drawSquares(int howManySquares)
        {

            for (int i = 0; i < howManySquares; i++) Console.Write(" --  ");

            Console.WriteLine();

            for (int i = 0; i < howManySquares; i++) Console.Write("|" + howManySquares + " | ");

            Console.WriteLine();

            for (int i = 0; i < howManySquares; i++) Console.Write(" --  ");

            Console.WriteLine("\n");

        }

        // Outputs the number of squares to print to represent a triangle

        public void calculateSquaresToPrint(int number)
        {

            for (int i = 1; i <= number; i++)
            {

                for (int j = 1; j < i; j++)
                {

                    drawSquares(j);


                }

                Console.WriteLine("Triangular Number: " + calcTriangularNum(i));

            }
        }

        public double calcTriangularNum(int number)
        {

            return .5 * number * (1 + number);

        }
    }
}

