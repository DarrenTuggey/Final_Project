// source: https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list/problem
// filename: F07_LinkedListDS.cs
// capture date: 23 Nov 2019
// student: Darren Tuggey
// summary: Given a pointer to the head node of a linked list, print its elements in order, one element per line. If the head pointer is null (indicating the list is empty), don’t print anything.
// Input Format:
// The first line of input contains, the number of elements in the linked list.
// The next  lines contain one element each, which are the elements of the linked list.
// Note: Do not read any input from stdin/console.Complete the printLinkedList function in the editor below.
// Output Format: Print the integer data for each element of the linked list to stdout/console(e.g.: using printf, cout, etc.). There should be one element per line.

using System;

namespace LinkedLists
{
    partial class LinkedListDS
    {
        #region Creates the LinkedList
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
        #endregion

        // My solution was to make the the function recursive
        static void printLinkedList(SinglyLinkedListNode head)
        {
            // Checks if the head is null
            if (head != null)
            {
                Console.WriteLine(head.data); // Prints the int
                var newHead = head.next; // Gets the next node
                printLinkedList(newHead); // Calls the function
            }
        }

        static void Function07(string[] args)
        {
            SinglyLinkedList linkList = new SinglyLinkedList();

            int linkListCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < linkListCount; i++)
            {
                int linkListItem = Convert.ToInt32(Console.ReadLine());
                linkList.InsertNode(linkListItem);
            }

            printLinkedList(linkList.head);
        }
    }
}
/*
Sample Input
2
16
13

Sample Output
16
13

Actual Output
16
13

Sample Input
4
17
19
5
12

Sample Output
17
19
5
12

Actual Output
17
19
5
12

*/
