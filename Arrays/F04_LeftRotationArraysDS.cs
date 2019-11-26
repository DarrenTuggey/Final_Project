// source: https://www.hackerrank.com/challenges/array-left-rotation/problem
// filename: F04_LeftRotationArraysDS.cs
// capture date: 20 Nov 2019
// student: Darren Tuggey
// summary: A left rotation operation on an array of size n shifts each of the array's elements 1 unit to the left. For example, if 2 left rotations are performed on array [1,2,3,4,5], then the array would become [3,4,5,1,2].
// Given an array of n integers and a number, d, perform d left rotations on the array.Then print the updated array as a single line of space-separated integers.
// input format: The first line contains two space-separated integers denoting the respective values of(the number of integers) and(the number of left rotations you must perform).
// The second line contains  space-separated integers describing the respective elements of the array's initial state.

using System.Collections.Generic;
using System.Linq;
using System;

namespace Arrays
{
    partial class LeftRotationArrayDS
    {
        // Solution was to convert the array to a list and just remove the first element and add it to the end the designated number of times.
        static void Function04()
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));


            List<int> b = a.ToList();
            for (int i = 0; i < d; i++)
            {
                var tempInt = b[0];
                b.RemoveAt(0);
                b.Add(tempInt);
            }

            Console.WriteLine(string.Join(" ", b));

            Console.ReadKey();

        }
    }
}
/*
Sample input to copy and paste:

61 48
431 397 149 275 556 362 852 789 601 357 516 575 670 507 127 888 284 405 806 27 495 879 976 467 342 356 908 750 769 947 425 643 754 396 653 595 108 75 347 394 935 252 683 966 553 724 629 567 93 494 693 965 328 187 728 389 70 288 509 252 449
*/

/*
Expected output:
93 494 693 965 328 187 728 389 70 288 509 252 449 431 397 149 275 556 362 852 789 601 357 516 575 670 507 127 888 284 405 806 27 495 879 976 467 342 356 908 750 769 947 425 643 754 396 653 595 108 75 347 394 935 252 683 966 553 724 629 567
*/
/*
Actual Output:
93 494 693 965 328 187 728 389 70 288 509 252 449 431 397 149 275 556 362 852 789 601 357 516 575 670 507 127 888 284 405 806 27 495 879 976 467 342 356 908 750 769 947 425 643 754 396 653 595 108 75 347 394 935 252 683 966 553 724 629 567
*/
