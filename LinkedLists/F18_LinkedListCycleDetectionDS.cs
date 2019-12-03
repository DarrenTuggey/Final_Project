// source: https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle/problem
// filename: F18_LinkedListCycleDetectionDS.cs
// capture date: 01 Dec 2019
// student: Darren Tuggey
// summary: A linked list is said to contain a cycle if any node is visited more than once while traversing the list. Complete the function provided
// for you in your editor. It has one parameter: a pointer to a Node object named head that points to the head of a linked list. Your function must
// return a boolean denoting whether or not there is a cycle in the list. If there is a cycle, return true; otherwise, return false.
// Note: If the list is empty, head will be null.
// Input Format: Our hidden code checker passes the appropriate argument to your function. You are not responsible for reading any input from stdin.
// Output Format: If the list contains a cycle, your function must return true. If the list does not contain a cycle, it must return false. The
// binary integer corresponding to the boolean value returned by your function is printed to stdout by our hidden code checker.

using System;
using System.Collections.Generic;

namespace LinkedLists
{
    partial class LinkedListCycleDetectionDS
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
        static bool hasCycle(SinglyLinkedListNode head)
        {
            // Check for a empty list
            if (head != null)
            {
                // Create a HashSet to contain a list of nodes already traversed
                HashSet<SinglyLinkedListNode> nodeHashSet = new HashSet<SinglyLinkedListNode>();

                // Loop through list
                while (head.next != null)
                {
                    // Search the HashSet for the current node and if found return true 
                    if (nodeHashSet.Contains(head))
                    {
                        return true;
                    }
                    nodeHashSet.Add(head);
                    head = head.next;
                }
            }
            return false;
        }

        static void Function18()
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
                SinglyLinkedListNode temp = llist.head;

                for (int i = 0; i < llistCount; i++)
                {
                    if (i == index)
                    {
                        extra = temp;
                    }

                    if (i != llistCount - 1)
                    {
                        temp = temp.next;
                    }
                }

                temp.next = extra;

                bool result = hasCycle(llist.head);

                Console.WriteLine((result ? 1 : 0));
            }
        }
    }
}

/*
Sample Input
1
-1
1
1

Sample Output
0

Actual Output 
0

Sample Input
1
1
3
1
2
3

Sample Output
1

Actual Output
1

*/
