// source: https://www.hackerrank.com/challenges/reverse-a-linked-list/problem
// filename: F13_LinkedListReverseListDS.cs
// capture date: 26 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head node of a linked list. Change the next pointers of the nodes so that their order is reversed.
// The head pointer given may be null meaning that the initial list is empty.
// Input Format: You have to complete the SinglyLinkedListNode reverse(SinglyLinkedListNode head) method which takes one argument - the head
// of the linked list.You should NOT read any input from stdin/console.
// The input is handled by the code in the editor and the format is as follows:
// The first line contains an integer t, denoting the number of test cases.
// Each test case is of the following format:
// The first line contains an integer n, denoting the number of elements in the linked list.
// The next n lines contain an integer each, denoting the elements of the linked list.
// Output Format:
// Change the next pointers of the nodes that their order is reversed and return the head of the reversed linked list.
// Do NOT print anything to stdout/console.
// The output is handled by the code in the editor.
// The output format is as follows:
// For each test case, print in a new line the elements of the linked list after reversing it, separated by spaces.

using System;

namespace LinkedLists
{
    partial class LinkedListReverseListDS
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

        static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode prevNode = null;       // Previous node    
            SinglyLinkedListNode curNode = head;        // curNode node
            SinglyLinkedListNode tempNode = null;       // tempNode node
            while (curNode != null)
            {
                tempNode = curNode.next;                // Assign tempNode node to next node        
                curNode.next = prevNode;                // Assign curNode.next to prevNode
                prevNode = curNode;                     // Assign prevNode to curNode      
                curNode = tempNode;                     // Assign curNode node to tempNode          
            }
            head = prevNode;                            // Assign head node to previous node
            return head;
        }

        static void Function13()
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
                SinglyLinkedListNode llist1 = reverse(llist.head);
                PrintSinglyLinkedList(llist1, " ");
                Console.WriteLine();
            }
        }
    }
}

/*
Sample Input
1
5
1
2
3
4
5

Sample Output
5 4 3 2 1 

Actual Output
5 4 3 2 1 

Sample Input
1
4
3
4
2
5

Sample Output
5 2 4 3

Actual Output
5 2 4 3

*/
