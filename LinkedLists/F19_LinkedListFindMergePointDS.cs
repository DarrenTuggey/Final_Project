// source: https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists/problem
// filename: F19_LinkedListFindMergePointDS.cs
// capture date: 01 Dec 2019
// student: Darren Tuggey
// summary: Given pointers to the head nodes of 2 linked lists that merge together at some point, find the Node where the two lists merge.
// It is guaranteed that the two head Nodes will be different, and neither will be NULL.
// In the diagram below, the two lists converge at Node x:
//
// [List #1]    a--->b--->c
//                          \
//                           x--->y--->z--->NULL
//                          /
// [List #2]         p--->q
//
// Complete the int findMergeNode(SinglyLinkedListNode * head1, SinglyLinkedListNode * head2) method so that it finds and returns the data
// value of the Node where the two lists merge.
// Input Format: Do not read any input from stdin/console.
// The findMergeNode(SinglyLinkedListNode, SinglyLinkedListNode) method has two parameters, head1 and head2, which are the non-null head Nodes of two
// separate linked lists that are guaranteed to converge.
// Output Format: Do not write any output to stdout/console.
// Each Node has a data field containing an integer. Return the integer data for the Node where the two lists merge.

using System.Collections.Generic;
using System;

namespace LinkedLists
{
    partial class LinkedListFindMergePointDS
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

        // Solution
        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            // Initialize the int to return
            int result = 0;
            // Create a HashSet to track nodes from the first list
            HashSet<SinglyLinkedListNode> nodeHashSet = new HashSet<SinglyLinkedListNode>();
            // Loop through first list adding to the HashSet
            while (head1 != null)
            {
                nodeHashSet.Add(head1);
                head1 = head1.next;
            }
            // Loop through the second list checking for the first node already in the HashSet and returning the int at that position
            while (head2 != null)
            {
                if (nodeHashSet.Contains(head2))
                {
                    result = head2.data;
                    break;
                }
                head2 = head2.next;
            }
            return result;
        }

        static void Function19()
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

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

                SinglyLinkedListNode ptr1 = llist1.head;
                SinglyLinkedListNode ptr2 = llist2.head;

                for (int i = 0; i < llist1Count; i++)
                {
                    if (i < index)
                    {
                        ptr1 = ptr1.next;
                    }
                }

                for (int i = 0; i < llist2Count; i++)
                {
                    if (i != llist2Count - 1)
                    {
                        ptr2 = ptr2.next;
                    }
                }

                ptr2.next = ptr1;

                int result = findMergeNode(llist1.head, llist2.head);

                Console.WriteLine(result);
            }
        }
    }
}

/*
Sample Input
1
1
3
1
2
3
1
1

Sample Output
2

Actual Output 
2

Sample Input
1
2
3
1
2
3
1
1

Sample Output
3

Actual Output
3

*/
