// source: https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list/problem
// filename: F11_LinkedListDeleteANode.cs
// capture date: 25 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head node of a linked list and the position of a node to delete. Delete the node at the given position and return the head node.
// A position of 0 indicates head, a position of 1 indicates one node away from the head and so on. The list may become empty after you delete the node.
// Input Format: You have to complete the deleteNode(SinglyLinkedListNode* llist, int position) method which takes two arguments - the head of the linked list and the position
// of the node to delete.You should NOT read any input from stdin/console.position will always be at least 0 and less than the number of the elements in the list.
// The first line of input contains an integer n, denoting the number of elements in the linked list. The next n lines contain an integer each in a new line, denoting the elements
// of the linked list in the order. The last line contains an integer position denoting the position of the node that has to be deleted form the linked list.
// Output Format: Delete the node at the given position and return the head of the updated linked list.Do NOT print anything to stdout/console. The code in the editor will print
// the updated linked list in a single line separated by spaces.

using System;

namespace LinkedLists
{
    partial class LinkedListDeleteANodeDS
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

        static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            SinglyLinkedListNode node = head; // To keep head at the original value
            
            if (position == 0) // Checks if the position is 0 and if true sets the head to the next node, nulls out the node, and returns the head.
            {
                head = node.next;
                node = null;
                return head;
            }
            else
            {
                for (int i = 0; i < position -1; i++) // Moves to the position before the input position
                {
                    node = node.next;
                }

                SinglyLinkedListNode nextNode = node.next.next; // To keep track of the next node that comes after the deleted position

                node.next = null; // Nulls out the next node
                node.next = nextNode; // Assign node.next to the position after the deleted node
            }

            return head;
        }

        static void Function11()
        {
            SinglyLinkedList llist = new SinglyLinkedList();
            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            int position = Convert.ToInt32(Console.ReadLine());
            SinglyLinkedListNode llist1 = deleteNode(llist.head, position);
            PrintSinglyLinkedList(llist1, " ");
            Console.WriteLine();
        }
    }
}

/*
Sample Input
8
20
6
2
19
7
4
15
9
3

Sample Output
20 6 2 7 4 15 9

Actual Output
20 6 2 7 4 15 9

Sample Input
7
11
12
8
18
16
5
18
0

Sample Output
12 8 18 16 5 18

Actual Output
12 8 18 16 5 18
*/
