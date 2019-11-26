// source: https://www.hackerrank.com/challenges/crush/problem
// filename: F06_ArraysManipulationDS.cs
// capture date: 21 Nov 2019
// student: Darren Tuggey
// summary: Starting with a 1-indexed array of zeros and a list of operations, for each operation add a value to each of the array element between two given 
// indices, inclusive. Once all operations have been performed, return the maximum value in your array.
// For example, the length of your array of zeros n =10. Your list of queries is as follows:
// a b k
// 1 5 3
// 4 8 7
// 6 9 1
// Add the values of k between the indices a and b inclusive:

// index->	   1   2   3   4   5   6   7   8   9  10
//          [  0,  0,  0,  0,  0,  0,  0,  0,  0,  0]
//          [  3,  3,  3,  3,  3,  0,  0,  0,  0,  0]
//          [  3,  3,  3, 10, 10,  7,  7,  7,  0,  0]
//          [  3,  3,  3, 10, 10,  8,  8,  8,  1,  0]
// The largest value is 10 after all operations are performed.
//
// Function Description:
// Complete the function arrayManipulation in the editor below.It must return an integer, the maximum value in the resulting array.
// arrayManipulation has the following parameters:   
//  n - the number of elements in your array
//  queries - a two dimensional array of queries where each queries[i] contains three integers, a, b, and k.
// Input Format:   
//  The first line contains two space-separated integers n and m, the size of the array and the number of operations.
// Each of the next m lines contains three space-separated integers a, b and k, the left index, right index and summand.
// Output Format:
// Return the integer maximum value in the finished array.

using System;

namespace Arrays
{
    partial class ArrayManipulationDS
    {
        // Solution explanation from user: Richard Vogt (https://www.hackerrank.com/richardpvogt): https://www.hackerrank.com/challenges/crush/forum/comments/231836
        // For every input line of a-b-k, you are given the range(a to b) where the values increase by k.So instead of keeping track of actual values increasing, just keep track of the rate of change (i.e.a slope)
        // in terms of where the rate started its increase and where it stopped its increase. This is done by adding k to the "a" position of your array and adding -k to the "b+1" position of your array for every
        // input line a-b-k, and that's it. "b+1" is used because the increase still applied at "b". The maximum final value is equivalent to the maximum accumulated "slope" starting from the first position, because it is
        // the spot which incremented more than all other places. Accumulated "slope" means to you add slope changes in position 0 to position 1, then add that to position 2, and so forth, looking for the point where it
        // was the greatest.

        // My original solution was to keep track of the individual values in the array but that was taking too long to pass the test cases so I sought out the correct way to solve this problem and found the explanation above and implemented it below.  
        static long arrayManipulation(int n, int[][] queries)
        {
            long[] myArray = new long[n+1]; // Initialize the array to the size of n + 1.
            long result = 0; // Initialize the result to return.

            // Add the value to the start index and subtract it after the end index.
            for (int x = 0; x < queries.Length; x++)
            {
                long start = queries[x][0] - 1; // -1 because of 0 indexing and the query is inclusive
                long end = queries[x][1]; // same as b+1 because of the 0 indexing
                long value = queries[x][2];
                myArray[start] += value;
                myArray[end] -= value;
            }

            // Calculate cumulative sum using prefix sum algorithm
            for (int x = 1; x < n; x++)
            {
                myArray[x] += myArray[x - 1];
            }

            // Find the max value
            for (int x = 0; x < n; x++)
            {
                if (myArray[x] > result)
                {
                    result = myArray[x];
                }
            }

            return result;
        }

        static void Function06()
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            int[][] queries = new int[m][];
            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }
            long result = arrayManipulation(n, queries);
            Console.WriteLine(result);
        }
    }
}

/*
Test Input:
5 3
1 2 100
2 5 100
3 4 100

Expected Output:
200

Actual Output:
200
*/
/*
Test Input:
10 4
2 6 8
3 5 7
1 8 1
5 9 15

Expected Output:
31

Actual Output:
31
*/

