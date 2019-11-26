// source: https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list/problem
// filename: F12_LinkedListPrintInReverseDS.cs
// capture date: 26 Nov 2019
// student: Darren Tuggey
// summary: You are given the pointer to the head node of a linked list and you need to print all its elements in reverse order from tail to head, 
// one element per line. The head pointer may be null meaning that the list is empty - in that case, do not print anything! 
// Input Format: You have to complete the void reversePrint(SinglyLinkedListNode* head) method which takes one argument - the head of the linked 
// list. You should NOT read any input from stdin/console. The first line of input contains t, the number of test cases. The input of each test 
// case is as follows: The first line contains an integer n, denoting the number of elements in the list. The next n lines contain one element each, 
// denoting the elements of the linked list in the order.
// Output Format: Complete the reversePrint function in the editor below and print the elements of the linked list in the reverse order, each in 
// a new line.

using System.Collections.Generic;
using System;

namespace LinkedLists
{
    partial class LinkedListPrintInReverseDS
    {
        #region Default code but modified to use console vice textwriter
        class SinglyLinkedListNode 
        {
            public int data;
            public SinglyLinkedListNode next;
            public SinglyLinkedListNode(int nodeData) {
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

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep) 
        {        
            while (node != null) 
            {
                Console.Write(node.data);
                node = node.next;
                if (node != null) 
                {
                    Console.Write(sep);
                }
            }
        }
        #endregion

        static void reversePrint(SinglyLinkedListNode head)
        {
            List<int> revList = new List<int>();
            SinglyLinkedListNode node = head;
            while (node != null)
            {
                revList.Add(node.data);
                if (node.next == null)
                {
                    break;
                }
                else
                {
                    node = node.next;
                }
            }
            revList.Reverse();
            foreach (var item in revList)
            {
                Console.WriteLine(item);
            }

        }

        static void Main() 
        {
            int tests = Convert.ToInt32(Console.ReadLine());
            for (int testsItr = 0; testsItr < tests; testsItr++) 
            {
                SinglyLinkedList llist = new SinglyLinkedList();
                int llistCount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < llistCount; i++) 
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                Console.WriteLine();
                reversePrint(llist.head);
                Console.WriteLine();
            }
        }
    }
}

/*
Sample Input
3
5
16
12
4
2
5
3
7
3
9
5
5
1
18
3
13

Sample Output
5
2
4
12
16
9
3
7
13
3
18
1
5

Actual Output


Sample Input


Sample Output


Actual Output


*/
