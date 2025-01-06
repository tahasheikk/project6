using System;

namespace DoublyLinkedList
{
    // Node class representing an element in the doubly linked list
    public class Node
    {
        public int Data; // Data of the node
        public Node Next; // Pointer to the next node
        public Node Befor; // Pointer to the befor node ( 'Befor')

        public Node(int data)
        {
            Data = data; // Initialize the data
            Next = null; // Initially, the pointer to the next node is null
            Befor = null; // Initially, the pointer to the  node is null
        }
    }

    // Doubly linked list class
    public class DoublyLinkedList
    {
        private Node head; // Pointer to the first node
        private int size; // Size of the list

        public DoublyLinkedList()
        {
            head = null; // Initially, the list is empty
            size = 0; // Size of the list is zero
        }

        // Method to insert a node at a specific index
        public void InsertAtIndex(int data, int index)
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("Out of range or empty");
                return; // If the index is invalid, exit the method
            }

            Node newNode = new Node(data); // Create a new node
            if (index == 0) // If the index is 0
            {
                if (head == null) // If the list is empty
                {
                    head = newNode; // The new node becomes the head
                }
                else
                {
                    newNode.Next = head; // New node points to the current head
                    head.Befor = newNode; // Current head's previous points to new node
                    head = newNode; // Update head to the new node
                }
            }
            else // If the index is not 0
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++) // Move to the node before the index
                {
                    current = current.Next;
                }
                newNode.Next = current.Next; // Link new node to the next node
                if (current.Next != null) // If not inserting at the end
                {
                    current.Next.Befor = newNode; // Link next node's previous to new node
                }
                current.Next = newNode; // Link previous node to new node
                newNode.Befor = current; // Link new node's previous to current
            }
            size++; // Increment the size of the list
        }

        // Method to insert at the end of the list
        public void InsertAtEnd(int data)
        {
            InsertAtIndex(data, size); // Insert at index equal to the size of the list
        }

        // Method to insert at the beginning of the list
        public void InsertAtBegin(int data)
        {
            InsertAtIndex(data, 0); // Insert at index 0
        }

        // Method to update the data of a node at a specific index
        public void UpdateNode(int data, int index) // Update data of node
        {
            if (index < 0 || index >= size) // Check for valid index
            {
                Console.WriteLine("Out of range or empty");
                return; // If the index is invalid, exit the method
            }

            Node current = head;
            for (int i = 0; i < index; i++) // Move to the node at the specified index
            {
                current = current.Next;
            }
            current.Data = data; // Update the data of the node
        }

        // Method to remove a node at a specific index
        public int RemoveNodeAtIndex(int index)
        {
            if (index < 0 || index >= size) // Check for valid index
            {
                Console.WriteLine("Out of range");
                return -1; // Return -1 for invalid index
            }

            Node remove; // Node to be removed
            int removedData; // Data of the removed node
            if (index == 0) // If the head needs to be removed
            {
                remove = head; // Store the head node to be removed
                head = head.Next; // Move head to the next node
                if (head != null) // If the list is not empty after removal
                {
                    head.Befor = null; // Update the new head's previous to null
                }
                removedData = remove.Data; // Store the data of the removed node
            }
            else // If a node other than the head needs to be removed
            {
                Node current = head;
                for (int i = 0; i < index; i++) // Move to the node at the specified index
                {
                    current = current.Next;
                }
                remove = current; // Node to be removed
                removedData = remove.Data; // Store the data of the removed node

                // Bypass the removed node
                if (remove.Next != null) // If it's not the last node
                {
                    remove.Next.Befor = remove.Befor; // Link the next node's befor to the previous node
                }
                if (remove.Befor != null) // If it's not the first node
                {
                    remove.Befor.Next = remove.Next; // Link the previous node's next to the next node
                }
            }

            size--; // Decrement the size of the list
            Console.WriteLine("Removed data is: " + removedData); // Print the removed data
            return removedData; // Return the data of the removed node
        }

        // Method to remove a node at the end of the list
        public int RemoveNodeAtEnd()
        {
            return RemoveNodeAtIndex(size - 1); // Remove the last node
        }

        // Method to remove a node at the beginning of the list
        public int RemoveNodeAtBegin()
        {
            return RemoveNodeAtIndex(0); // Remove the head node
        }

        // Method to get the size of the list
        public int SizeOfList()
        {
            return size; // Return the size of the list
        }

        // Method to print the list
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty"); // If the list is empty
                return;
            }

            Node current = head; // Start from the head
            while (current != null) 
            {
                Console.Write(current.Data); // Print the data of each node
                if (current.Next != null)
                {
                    Console.Write(" <-> "); 
                }
                current = current.Next; // Move to the next node
            }
            Console.WriteLine(); 
        }
    }

    // Main program to test the doubly linked list
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList(); // Create a new doubly linked list
            list.InsertAtIndex(1, 0); // Insert 1 at index 0
            list.InsertAtIndex(2, 1); // Insert 2 at index 1
            list.InsertAtIndex(3, 2); // Insert 3 at index 2
            list.Print(); // Display the list

            list.InsertAtBegin(0); // Insert 0 at the beginning
            list.Print(); // Display the list

            list.InsertAtEnd(4); // Insert 4 at the end
            list.Print(); // Display the list

            list.RemoveNodeAtBegin(); // Remove the head node
            list.Print(); // Display the list

            list.RemoveNodeAtEnd(); // Remove the last node
            list.Print(); // Display the list

            list.RemoveNodeAtIndex(1); // Remove the node at index 1
            list.Print(); // Display the list

            list.UpdateNode(5, 0); // Update the first node's data to 5
            list.Print(); // Display the list
        }
    }
}