// source: https://www.hackerrank.com/challenges/sparse-arrays/problem
// filename: F05_SparseArraysDS.cs
// capture date: 20 Nov 2019
// student: Darren Tuggey
// summary: There is a collection of input strings and a collection of query strings. For each query string, determine how many times it occurs in the list of input strings.
// For example, given input strings = ['ab',' ab',abc'] and queries = ['ab',' abc',' bc'], we find 2 instances of 'ab', 1 of 'abc' and 0 of 'bc'. For each query, we add an 
// element to our return array, results = [2,1,0].
// Function Description
// Complete the function matchingStrings in the editor below.The function must return an array of integers representing the frequency of occurrence of each query string in strings.
// matchingStrings has the following parameters:
// strings - an array of strings to search
// queries - an array of query strings
// Input Format:
// The first line contains an integer n, the size of strings.
// Each of the next n lines contains a string strings[i].
// The next line contains q, the size of the queries.
// Each of the next q lines contains a string q[i].

using System;

namespace Arrays
{
    partial class SparseArrayDS
    {   
        // Solution was to create the result int array with the length of the queries array, then iterate through the queries with a loop that iterates through
        // the strings array incrementing a count when a match is found and then setting the count to the result index that matches the query index.
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int matchCount = 0;
                foreach (var item in strings)
                {
                    if (item == queries[i])
                    {
                        matchCount++;
                    }
                }
                result.SetValue(matchCount, i);
            }
            return result;
        }

        static void Function05()
        {
            int stringsCount = Convert.ToInt32(Console.ReadLine());
            string[] strings = new string[stringsCount];
            for (int i = 0; i < stringsCount; i++)
            {
                string stringsItem = Console.ReadLine();
                strings[i] = stringsItem;
            }
            int queriesCount = Convert.ToInt32(Console.ReadLine());
            string[] queries = new string[queriesCount];
            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries[i] = queriesItem;
            }
            int[] res = matchingStrings(strings, queries);
            Console.WriteLine(string.Join("\n", res));
            Console.ReadKey();
        }
    }
}

/*
Test Input:
13
abcde
sdaklfj
asdjf
na
basdn
sdaklfj
asdjf
na
asdjf
na
basdn
sdaklfj
asdjf
5
abcde
sdaklfj
asdjf
na
basdn

Expected Output:
1
3
4
3
2

Actual Output:
1
3
4
3
2
*/
/*
Test Input:
3
def
de
fgh
3
de
lmn
fgh

Expected Output:
1
0
1

Actual Output:
1
0
1
*/

