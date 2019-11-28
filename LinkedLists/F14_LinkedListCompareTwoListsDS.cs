// source: https://www.hackerrank.com/challenges/compare-two-linked-lists/problem
// filename: F14_LinkedListCompareTwoListsDS.cs
// capture date: 27 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head nodes of two linked lists. Compare the data in the nodes of the linked lists to check if they are equal.
// The lists are equal only if they have the same number of nodes and corresponding nodes contain the same data. Either head pointer given may be null
// meaning that the corresponding list is empty.
// Input Format: You have to complete the int CompareLists(Node* headA, Node* headB) method which takes two arguments - the heads of the two linked lists
// to compare.You should NOT read any input from stdin/console.
// The input is handled by the code in the editor and the format is as follows: The first line contains t, the number of test cases.
// The format for each test case is as follows:
// The first line contains an integer n, denoting the number of elements in the first linked list.
// The next n lines contain an integer each, denoting the elements of the first linked list.
// The next line contains an integer m, denoting the number of elements in the second linked list.
// The next m lines contain an integer each, denoting the elements of the second linked list.
// Output Format:
// Compare the two linked lists and return 1 if the lists are equal. Otherwise, return 0. Do NOT print anything to stdout/console.
// The output is handled by the code in the editor and it is as follows:
// For each test case, in a new line, print 1 if the two lists are equal, else print 0.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinkedLists
{
    partial class LinkedListCompareTwoListsDS
    {
        #region Default code but modified to use console vice textwriter
        class SinglyLinkedListNode
        {
            public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }
        #endregion

        static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {


        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(Console.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(Console.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                bool result = CompareLists(llist1.head, llist2.head);

                textWriter.WriteLine((result ? 1 : 0));
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

/*
Sample Input
2
2
1
2
1
1
2
1
2
2
1
2

Sample Output
0
1

Actual Output
5 4 3 2 1 

Sample Input
1
4
3
4
2
5

Sample Output
5 2 4 3

Actual Output
5 2 4 3

*/
