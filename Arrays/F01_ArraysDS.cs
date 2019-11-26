// source: https://www.hackerrank.com/challenges/arrays-ds/problem
// filename: F01_ArraysDS.cs
// capture date: 17 Nov 2019
// student: Darren Tuggey
// summary: Given an array, A , of N integers, print each element in reverse order as a single line of space-separated integers.
// modifications: Modified Main to work as a console app with sample input/output.
// input format: The first line contains an integer, N (the number of integers in A). The second line contains N space-separated integers describing A.

using System;

namespace Arrays
{
    partial class ArrayDS
    {
        // Solution was to instantiate a new int array(solution), index variable (idx) and create a for loop that started from the end of the
        // input array (a) and added items to the new array until exiting and returning the new array.
        private static int[] reverseArray(int[] a)
        {
            int[] solution = new int[a.Length];
            int idx = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                solution.SetValue(a[i], idx);
                idx++;
            }
            return solution;
        }

        private static void Function01()
        {
            // Output Test 1
            // Input(stdin)
            // 8
            // 6676 3216 4063 8373 423 586 8850 6762
            // Expected Output
            // 6762 8850 586 423 8373 4063 3216 6676
            string var1 = "8";
            string var2 = "6676 3216 4063 8373 423 586 8850 6762";

            int arrCount = Convert.ToInt32(var1);
            int[] arr = Array.ConvertAll(var2.Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int[] res = reverseArray(arr);
            Console.WriteLine(string.Join(" ", res));

            // Output Test 2
            // Input(stdin)
            // 9
            // 305 97 1290 5591 5930 9317 440 6533 7470
            // Expected Output
            // 7470 6533 440 9317 5930 5591 1290 97 305
            string var3 = "9";
            string var4 = "305 97 1290 5591 5930 9317 440 6533 7470";

            int arrCount2 = Convert.ToInt32(var3);
            int[] arr2 = Array.ConvertAll(var4.Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int[] res2 = reverseArray(arr2);
            Console.WriteLine(string.Join(" ", res2));

            Console.ReadKey();

            // Output:
            // 6762 8850 586 423 8373 4063 3216 6676
            // 7470 6533 440 9317 5930 5591 1290 97 305
        }
    }
}