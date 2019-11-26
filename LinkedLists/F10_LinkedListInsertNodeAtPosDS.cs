// source: https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list/problem
// filename: F10_LinkedListInsertNodeAtPosDS.cs
// capture date: 24 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head node of a linked list, an integer to add to the list and the position at which the integer must be inserted. Create a new node with the given integer, insert this node at
// the desired position and return the head node. A position of 0 indicates head, a position of 1 indicates one node away from the head and so on.The head pointer given may be null meaning that the initial list is empty.
// As an example, if your list starts as 1 -> 2 -> 3 and you want to insert a node at position 2 with data = 4, your new list should be 1 -> 2 -> 4 -> 3.
// Function Description Complete the function insertNodeAtPosition in the editor below. It must return a reference to the head node of your finished list.
// insertNodeAtPosition has the following parameters: 
// head: a SinglyLinkedListNode pointer to the head of the list
// data: an integer value to insert as data in your new node
// position: an integer position to insert the new node, zero based indexing
// Input Format: The first line contains an integer n, the number of elements in the linked list. Each of the next n lines contains an integer SinglyLinkedListNode[i].data. The next line contains an integer data denoting
// the data of the node that is to be inserted. The last line contains an integer position.
// Output Format: Return a reference to the list head.Locked code prints the list for you.

using System;

namespace LinkedLists
{
    partial class LinkedListInsertNodeAtPosDS
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
        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            // Check if the head is null and creates a node if so
            if (head == null)  
            { 
                head = new SinglyLinkedListNode(data);
            }
            else
            {
                SinglyLinkedListNode node = head; // To keep head at the original value
                
                for (int i = 0; i < position - 1; i++) // Moves to the position before the inputted position
                {
                    node = node.next;
                }

                SinglyLinkedListNode nextNode = node.next; // To keep track of the next node that comes after our input
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(data); // Create the new node with data
                node.next = newNode; // Assign the new node to the input position
                node.next.next = nextNode; // Assign the previous node.next to the position after the newNode
            }
            return head;

        }

        static void Function10()
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            int data = Convert.ToInt32(Console.ReadLine());

            int position = Convert.ToInt32(Console.ReadLine());

            SinglyLinkedListNode llist_head = insertNodeAtPosition(llist.head, data, position);
           
            Console.WriteLine();
            PrintSinglyLinkedList(llist_head, " ");
            Console.WriteLine();
        }



    }
}

/*
Sample Input
3
16
13
7
1
2

Sample Output
16 13 1 7

Actual Output

Sample Input
5
11
9
19
10
4
20
3

Sample Output
11 9 19 20 10 4

Actual Output
11 9 19 20 10 4
*/
