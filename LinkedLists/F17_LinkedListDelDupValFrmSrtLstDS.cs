// source: https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list/problem
// filename: F17_LinkedListDelDupValFrmSrtLstDS.cs
// capture date: 30 Nov 2019
// student: Darren Tuggey
// summary: You're given the pointer to the head node of a sorted linked list, where the data in the nodes is in ascending order. Delete as few nodes as
// possible so that the list does not contain any value more than once. The given head pointer may be null indicating that the list is empty.
// Input Format: You have to complete the SinglyLinkedListNode* removeDuplicates(SinglyLinkedListNode* head) method which takes one argument - the head of
// the sorted linked list.You should NOT read any input from stdin/console.
// The input is handled by the code in the editor and the format is as follows:
// The first line contains an integer t, denoting the number of test cases.The format for each test case is as follows:
// The first line contains an integer n, denoting the number of elements in the linked list.
// The next n lines contain an integer each, denoting the elements of the linked list.
// Output Format: Delete as few nodes as possible to ensure that no two nodes have the same data.Adjust the next pointers to ensure that the remaining
// nodes form a single sorted linked list.Then return the head of the sorted updated linked list. Do NOT print anything to stdout/console. The output is
// handled by the code in the editor and the format is as follows: For each test case, print in a new line, the data of the linked list after removing the
// duplicates separated by space.

using System;

namespace LinkedLists
{
    partial class LinkedListDelDupValFrmSrtLstDS
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
        static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)
        {
            // Use node to traverse and keep original head position
            SinglyLinkedListNode node = head;

            // Check if input is an empty list
            if (head != null)
            {
                // Iterate through the list
                while (node.next != null)
                {
                    // Move to the next position if data is not equal
                    if (node.data != node.next.data)
                    {
                        node = node.next;
                    }
                    // If the current and next node are equal and the position after the next node is not null then delete the next node and reassign to
                    // the following node
                    else if (node.data == node.next.data && node.next.next != null)
                    {
                        SinglyLinkedListNode nextNode = node.next.next;
                        node.next = null;
                        node.next = nextNode;
                    }
                    // If the current and next node are equal but there is no following node then delete the next node and break from the loop
                    else if (node.data == node.next.data && node.next.next == null)
                    {
                        node.next = null;
                        break;
                    }
                }
            }

            return head;
        }

        static void Function17()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                SinglyLinkedListNode llist1 = removeDuplicates(llist.head);

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
2
3
4

Sample Output
1 2 3 4 

Actual Output 
1 2 3 4 

Sample Input
1
6
3
3
3
4
5
5

Sample Output
3 4 5 

Actual Output
3 4 5 

*/
