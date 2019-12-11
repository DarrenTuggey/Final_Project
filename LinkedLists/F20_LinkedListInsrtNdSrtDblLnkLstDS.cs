// source: https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list/problem
// filename: F20_LinkedListInsrtNdSrtDblLnkLstDS.cs
// capture date: 01 Dec 2019
// student: Darren Tuggey
// summary: Given a reference to the head of a doubly-linked list and an integer, data, create a new DoublyLinkedListNode object having data value data
// and insert it into a sorted linked list while maintaining the sort.
// Function Description: Complete the sortedInsert function in the editor below.It must return a reference to the head of your modified DoublyLinkedList.
// sortedInsert has two parameters:
// head: A reference to the head of a doubly-linked list of DoublyLinkedListNode objects.
// data: An integer denoting the value of the data field for the DoublyLinkedListNode you must insert into the list.
// Note: Recall that an empty list (i.e., where head = null) and a list with one element are sorted lists.
// Input Format: The first line contains an integer t, the number of test cases.
// Each of the test case is in the following format:
// The first line contains an integer n, the number of elements in the linked list.
// Each of the next n lines contains an integer, the data for each node of the linked list.
// The last line contains an integer data which needs to be inserted into the sorted doubly-linked list.
// Output Format: Do not print anything to stdout.Your method must return a reference to the head of the same list that was passed to it as a parameter.
// The ouput is handled by the code in the editor and is as follows:
// For each test case, print the elements of the sorted doubly-linked list separated by spaces on a new line.

using System;

namespace LinkedLists
{
    partial class LinkedListInsrtNdSrtDblLnkLstDS
    {
        #region Default code but modified to use console vice textwriter
        class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
                this.prev = null;
            }
        }

        class DoublyLinkedList
        {
            public DoublyLinkedListNode head;
            public DoublyLinkedListNode tail;

            public DoublyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                    node.prev = this.tail;
                }

                this.tail = node;
            }
        }

        static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
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

        // Solution
        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
        {
            // Create a new node with data
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);

            // Create a node to traverse instead of using head
            DoublyLinkedListNode node = head;

            // Loop through the list
            while (node != null)
            {   
                // Check if the new node data is greater than the current node data
                if (data > node.data)
                {
                    // Check if the next node is null/end of list and if so insert the new node as the next node and then break from the loop
                    // and if not move to the next node
                    if (node.next == null)
                    {
                        node.next = newNode;
                        break;
                    }
                    else
                    {
                        node = node.next;
                    }
                }
                else
                {
                    // Checks if the previous node is null/beginning of list and if so assigns the current node as the next after the new node 
                    // and assigns the new node as the head then breaks from the loop.
                    if (node.prev == null)
                    {
                        newNode.next = node;
                        head = newNode;
                        break;
                    }
                    else
                    {
                        // Assigns the previous node's next to the new node
                        node.prev.next = newNode;
                        // Then the new node's next to the current node
                        newNode.next = node;
                        // Then new node's previous to the current node's previous
                        newNode.prev = node.prev;
                        // Then the current node's previous to the new node
                        node.prev = newNode;
                        // Then breaks from the loop
                        break;
                    }
                }
            }
            return head;
        }

        static void Function20()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DoublyLinkedList llist = new DoublyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                int data = Convert.ToInt32(Console.ReadLine());

                DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

                PrintDoublyLinkedList(llist1, " ");
                Console.WriteLine();
            }
        }
    }
}

/*
Sample Input
1
4
1
3
4
10
5

Sample Output
1 3 4 5 10

Actual Output 
1 3 4 5 10

Sample Input
1
3
2
3
4
1

Sample Output
1 2 3 4

Actual Output
1 2 3 4

*/
