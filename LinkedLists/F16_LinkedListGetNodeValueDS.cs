// source: https://www.hackerrank.com/challenges/get-the-value-of-the-node-at-a-specific-position-from-the-tail/problem
// filename: F16_LinkedListGetNodeValueDS.cs
// capture date: 29 Nov 2019
// student: Darren Tuggey
// summary: You’re given the pointer to the head node of a linked list and a specific position. Counting backwards from the tail node of the linked list, get the
// value of the node at the given position. A position of 0 corresponds to the tail, 1 corresponds to the node before the tail and so on.
// Input Format: You have to complete the int getNode(SinglyLinkedListNode* head, int positionFromTail) method which takes two arguments - the head of the linked
// list and the position of the node from the tail.positionFromTail will be at least 0 and less than the number of nodes in the list.You should NOT read any input
// from stdin/console. The first line will contain an integer t, the number of test cases.
// Each test case has the following format: The first line contains an integer n, the number of elements in the linked list.
// The next n lines contains, an element each denoting the element of the linked list. The last line contains an integer positionFromTail denoting the position
// from the tail, whose value needs to be found out and returned.
// Output Format: Find the node at the given position counting backwards from the tail. Then return the data contained in this node.Do NOT print anything to
// stdout/console. The code in the editor handles output. For each test case, print the value of the node, each in a new line.

using System;

namespace LinkedLists
{
    partial class LinkedListGetNodeValueDS
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
        static int getNode(SinglyLinkedListNode head, int positionFromTail)
        {
            // Keep track of the position
            int countPos = 0; 

            // Node to traverse the list
            SinglyLinkedListNode node = head;

            // Result node 
            SinglyLinkedListNode resNode = head;

            // Loop through the list
            while (node != null)
            {
                // Starts moving the result node when the current position is greater then the number of nodes you need to count backwards from the tail
                if (countPos > (positionFromTail))
                {
                    resNode = resNode.next;
                }
                countPos++;
                node = node.next;
            }

            // Return the result node data.
            return resNode.data;
        }

        static void Function16()
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

                int position = Convert.ToInt32(Console.ReadLine());

                int result = getNode(llist.head, position);

                Console.WriteLine();
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}

/*
Sample Input
2
1
1
0
3
3
2
1
2

Sample Output
1
3

Actual Output 
1
3

Sample Input
1
4
4
3
2
1
2

Sample Output
3

Actual Output
3

*/
