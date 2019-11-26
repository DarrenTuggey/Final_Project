// source: https://www.hackerrank.com/challenges/insert-a-node-at-the-tail-of-a-linked-list/problem
// filename: F08_LinkedListInsertNodeTailDS.cs
// capture date: 23 Nov 2019
// student: Darren Tuggey
// summary: You are given the pointer to the head node of a linked list and an integer to add to the list. Create a new node with the given integer. Insert this node at the tail of the linked list and return the head
// node of the linked list formed after inserting this new node. The given head pointer may be null, meaning that the initial list is empty.
// Input Format: You have to complete the SinglyLinkedListNode insertAtTail(SinglyLinkedListNode head, int data) method.
// It takes two arguments: the head of the linked list and the integer to insert at tail.You should not read any input from the stdin/console.
// The input is handled by code editor and is as follows:
// The first line contains an integer, denoting the elements of the linked list.
// The next lines contain an integer each, denoting the element that needs to be inserted at tail.
// Output Format: Insert the new node at the tail and just return the head of the updated linked list.Do not print anything to stdout/console.
// The output is handled by code in the editor and is as follows:
// Print the elements of the linked list from head to tail, each in a new line.

using System;

namespace LinkedLists
{
    partial class LinkedListInsertNodeTailDS
    {
        #region Default code to create the LinkedList/Print but modified to use console vice textwriter
        private class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        private class SinglyLinkedList
        {
            public SinglyLinkedListNode head;

            public SinglyLinkedList()
            {
                this.head = null;
            }
        }

        private static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
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
        private static SinglyLinkedListNode InsertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            if (head == null) // Checks if head is null and if true creates a new node with the data at the head. Needed if the linked list is empty.
            {
                head = new SinglyLinkedListNode(data);
            }
            else
            {
                SinglyLinkedListNode node = head; // Needed to retain the value of head to return and use node to traverse.
                while (node.next != null) // Finds the next node that is null.
                {
                    node = node.next;
                }
                node.next = new SinglyLinkedListNode(data); // Creates a new node with data at the next node
            }
            return head; 
        }
        
        private static void Function08()
        {
            SinglyLinkedList linkList = new SinglyLinkedList();

            int linkListCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < linkListCount; i++)
            {
                int linkListItem = Convert.ToInt32(Console.ReadLine());
                SinglyLinkedListNode linkListHead = InsertNodeAtTail(linkList.head, linkListItem);
                linkList.head = linkListHead;
            }

            Console.WriteLine();
            PrintSinglyLinkedList(linkList.head, "\n");
            Console.WriteLine();
        }
    }
}

/*
Sample Input
5
141
302
164
530
474

Sample Output
141
302
164
530
474

Actual Output
141
302
164
530
474

Sample Input
3
236
326
937

Sample Output
236
326
937

Actual Output
236
326
937

*/
