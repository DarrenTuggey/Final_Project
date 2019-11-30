// source: https://www.hackerrank.com/challenges/merge-two-sorted-linked-lists/problem
// filename: F15_LinkedListMergeSortedListsDS.cs
// capture date: 28 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head nodes of two sorted linked lists. The data in both lists will be sorted in ascending order.
// Change the next pointers to obtain a single, merged linked list which also has data in ascending order. Either head pointer given may be null
// meaning that the corresponding list is empty.
// Input Format: You have to complete the SinglyLinkedListNode MergeLists(SinglyLinkedListNode headA, SinglyLinkedListNode headB) method which
// takes two arguments - the heads of the two sorted linked lists to merge.You should NOT read any input from stdin/console. The input is handled
// by the code in the editor and the format is as follows:
// The first line contains an integer t, denoting the number of test cases.
// The format for each test case is as follows:
// The first line contains an integer n, denoting the length of the first linked list.
// The next n lines contain an integer each, denoting the elements of the linked list.
// The next line contains an integer m, denoting the length of the second linked list.
// The next m lines contain an integer each, denoting the elements of the second linked list.
// Output Format: Change the next pointer of individual nodes so that nodes from both lists are merged into a single list.Then return the head of
// this merged list. Do NOT print anything to stdout/console.
// The output is handled by the editor and the format is as follows:
// For each test case, print in a new line, the linked list after merging them separated by spaces.

using System;

namespace LinkedLists
{
    partial class LinkedListMergeSortedListsDS
    {
        #region Default code but modified to use console vice Console
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
        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            // Create a new Linked List
            SinglyLinkedList newList = new SinglyLinkedList(); 

            // Loop through both lists until both are nulls     
            while (head1 != null || head2 != null)
            {
                // If at the end of the first list continue adding the second
                if (head1 == null)
                {
                    newList.InsertNode(head2.data);
                    head2 = head2.next;
                }
                // If at the end of the second list continue adding the first
                else if (head2 == null)
                {
                    newList.InsertNode(head1.data);
                    head1 = head1.next;
                }
                // Determine and insert the lesser value into the new list
                else if (head1.data <= head2.data)
                {
                    newList.InsertNode(head1.data);
                    head1 = head1.next;
                }
                else
                {
                    newList.InsertNode(head2.data);
                    head2 = head2.next;
                }
            }
            return newList.head;
        }

        static void Function15()
        {
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

                SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

                PrintSinglyLinkedList(llist3, " ");
                Console.WriteLine();
            }
        }
    }
}

/*
Sample Input
1
3
1
2
3
2
3
4

Sample Output
1 2 3 3 4 

Actual Output 
1 2 3 3 4 

Sample Input
1
3
4
5
6
3
1
2
10

Sample Output
1 2 4 5 6 10 

Actual Output
1 2 4 5 6 10 

*/
