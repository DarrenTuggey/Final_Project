// source: https://www.hackerrank.com/challenges/insert-a-node-at-the-head-of-a-linked-list/problem
// filename: F09_LinkedListInsertNodeHeadDS.cs
// capture date: 24 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head node of a linked list and an integer to add to the list. Create a new node with the given integer, insert this node at the head of the linked list and return the new
// head node. The head pointer given may be null meaning that the initial list is empty. 
// Input Format: You have to complete the SinglyLinkedListNode Insert(SinglyLinkedListNode head, int data) method which takes two arguments - the head of the linked list and the integer to insert.You should NOT read
// any input from stdin/console. The input is handled by code in the editor and is as follows: The first line contains an integer n, denoting the number of elements to be inserted at the head of the list. The next n
// lines contain an integer each, denoting the element to be inserted.
// Output Format: Insert the new node at the head and return the head of the updated linked list.Do NOT print anything to stdout/console. The output is handled by the code in the editor and it is as follows:
// Print the elements of linked list from head to tail, each in a new line.

// NOTE: The IDE on the site is bugged for C# due to a -> in place of a period in Main. You can however switch to Java and use the same solution and it will pass.

using System;

namespace LinkedLists
{
    partial class LinkedListInsertNodeHeadDS
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

        // Solution was to create a new node with the data and then assigned the node.next to the input node parameter and then return the newly created node
        static SinglyLinkedListNode InsertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(data);
            node.next = llist;
            return node;
        }

        static void Function09(string[] args)
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                SinglyLinkedListNode llist_head = InsertNodeAtHead(llist.head, llistItem);
                llist.head = llist_head;
            }

            Console.WriteLine();
            PrintSinglyLinkedList(llist.head, "\n");
            Console.WriteLine();
        }
    }
}

/*
Sample Input
5
383
484
392
975
321

Sample Output
321
975
392
484
383

Actual Output
321
975
392
484
383

Sample Input
10
321
641
653
524
952
337
955
891
590
133

Sample Output
133
590
891
955
337
952
524
653
641
321

Actual Output
133
590
891
955
337
952
524
653
641
321

*/
