// source: https://www.hackerrank.com/challenges/2d-array/problem
// filename: F02_2DArraysDS.cs
// capture date: 17 Nov 2019
// student: Darren Tuggey
// modifications: Modified Main to work as a console app with sample input/output.
// summary: Given a 6x6 2D Array, arr :
// We define an hourglass in  to be a subset of values with indices falling in this pattern in arr's graphical representation:
// a b c
//   d
// e f g
// There are 16 hourglasses in arr, and an hourglass sum is the sum of an hourglass' values.
// Calculate the hourglass sum for every hourglass in arr, then print the maximum hourglass sum.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    class TwoDArrayDS
    {
        // Solution was to instantiate a new List<int> (sums) and create a nested for loop that sums each possible hourglass
        // and adds it to sums. Then I returned sums.Max.
        private static int hourglassSum(int[][] arr)
        {
            List<int> sums = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    int arrsum = arr[i][j - 1] + arr[i][j] + arr[i][j + 1] + arr[i + 1][j] + arr[i + 2][j - 1] + arr[i + 2][j] + arr[i + 2][j + 1];
                    sums.Add(arrsum);
                }
            }
            return sums.Max();
        }

        private static void Function02()
        {
            // Output Test 1
            // Input(stdin):
            // 1 1 1 0 0 0
            // 0 1 0 0 0 0
            // 1 1 1 0 0 0
            // 0 0 2 4 4 0
            // 0 0 0 2 0 0
            // 0 0 1 2 4 0
            // Expected Output:
            // 19
            int[][] arr = new int[6][];
            arr[0] = Array.ConvertAll("1 1 1 0 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[1] = Array.ConvertAll("0 1 0 0 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[2] = Array.ConvertAll("1 1 1 0 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[3] = Array.ConvertAll("0 0 2 4 4 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[4] = Array.ConvertAll("0 0 0 2 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[5] = Array.ConvertAll("0 0 1 2 4 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = hourglassSum(arr);

            // Output Test 2
            // Input(stdin):
            // -9 -9 -9  1 1 1
            //  0 -9  0  4 3 2
            // -9 -9 -9  1 2 3
            //  0  0  8  6 6 0
            //  0  0  0 -2 0 0
            //  0  0  1  2 4 0
            // Expected Output:
            // 28
            int[][] arr2 = new int[6][];
            arr2[0] = Array.ConvertAll("-9 -9 -9 1 1 1".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr2[1] = Array.ConvertAll("0 -9 0 4 3 2".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr2[2] = Array.ConvertAll("-9 -9 -9 1 2 3".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr2[3] = Array.ConvertAll("0 0 8 6 6 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr2[4] = Array.ConvertAll("0 0 0 -2 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr2[5] = Array.ConvertAll("0 0 1 2 4 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result2 = hourglassSum(arr2);

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();

            // Output:
            // 19
            // 28
        }
    }
}