using System;

namespace linklist
{
    // Node class representing an element in the linked list
    public class node
    {
        public int Data; // Data of the node
        public node next; // Pointer to the next node

        public node(int data)
        {
            Data = data; // Initialize the data
            next = null; // Initially, the pointer to the next node is null
        }
    }

    // Circular linked list class
    public class circlelinkedlist
    {
        private node head; // Pointer to the first node
        private int size; // Size of the list

        public circlelinkedlist()
        {
            head = null; // Initially, the list is empty
            size = 0; // Size of the list is zero
        }

        // Method to insert a node at a specific index
        public void INsertAtIndex(int data, int index)
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("out of range or empty");
                return; // If the index is invalid, exit the method
            }

            node newnode = new node(data); // Create a new node
            if (index == 0) // If the index is 0
            {
                if (head == null) // If the list is empty
                {
                    head = newnode; // The new node becomes the head
                    newnode.next = head; // Point to itself (circular)
                }
                else
                {
                    node tail = head;
                    while (tail.next != head) // Find the last node
                    {
                        tail = tail.next;
                    }
                    tail.next = newnode; // Link the last node to the new node
                    newnode.next = head; // New node points to head
                    head = newnode; // Update head to the new node
                }
            }
            else // If the index is not 0
            {
                node newp = head;
                for (int i = 0; i < index - 1; i++) // Move to the node before the index
                {
                    newp = newp.next;
                }
                newnode.next = newp.next; // Link new node to the next node
                newp.next = newnode; // Link previous node to new node
            }
            size++; // Increment the size of the list
        }

        // Method to insert at the end of the list
        public void InsertAtEnd(int data)
        {
            INsertAtIndex(data, size); // Insert at index equal to the size of the list
        }

        // Method to insert at the beginning of the list
        public void InsertAtBegin(int data)
        {
            INsertAtIndex(data, 0); // Insert at index 0
        }

        // Method to update the data of a node at a specific index
        public void UpdateNode(int data, int index)//update data of node
        {
            if (index < 0 || index >= size) // Check for valid index
            {
                Console.WriteLine("out of range or empty");
                return; // If the index is invalid, exit the method
            }

            node newp = head;
            for (int i = 0; i < index; i++) // Move to the node at the specified index
            {
                newp = newp.next;
            }
            newp.Data = data; // Update the data of the node
        }

        // Method to remove a node at a specific index
        public int RemoveNodeAtIndex(int index)
        {
            if (index < 0 || index >= size) // Check for valid index
            {
                Console.WriteLine("out of range");
                return -1; // Return -1 for invalid index
            }

            node remove; // Node to be removed
            int removedata; // Data of the removed node
            if (index == 0) // If the head needs to be removed
            {
                remove = head; // Store the head node to be removed
                if (size == 1) // If there's only one node
                {
                    head = null; // The list becomes empty
                }
                else
                {
                    node tail = head;
                    while (tail.next != head) // Find the last node
                    {
                        tail = tail.next;
                    }
                    tail.next = head.next; // Link last node to the second node
                    head = head.next; // Move head to the next node
                }
                removedata = remove.Data; // Store the data of the removed node
           
            }
            else // If a node other than the head needs to be removed
            {
                node newp = head;
                for (int i = 0; i < index - 1; i++) // Move to the node before the index
                {
                    newp = newp.next;
                }
                remove = newp.next; // Node to be removed
                newp.next = remove.next; // Bypass the removed node
                removedata = remove.Data; // Store the data of the removed node
            }

            size--; // Decrement the size of the list
            Console.WriteLine("removed data is: " + removedata); // Print the removed data
            return removedata; // Return the data of the removed node
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

        // Method to invert the circular linked list
        public void Invert()
        {
            if (head == null) return; // If the list is empty, do nothing

            node prev = null; // Previous node
            node current = head; // Current node
            node next = null; // Next node
            node tail = head; // To find the tail

            // Find the tail node
            while (tail.next != head)
            {
                tail = tail.next; // Move to the last node
            }

            // Invert the list
            do
            {
                next = current.next; // Store the next node
                current.next = prev; // Reverse the link
                prev = current; // Move prev to current
                current = next; // Move to the next node
            } while (current != head);

            head.next = prev; // Link the last node to the new head
            head = prev; // Update head to the new head
        }

        // Method to print the list
        public void print()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty"); // If the list is empty
                return;
            }

            node newp = head; // Start from the head
            do
            {
                Console.Write(newp.Data); // Print the data of each node
                Console.Write(" -> "); // Indicate the link to the next node
                newp = newp.next; // Move to the next node
            } while (newp != head); // Continue until we loop back to the head
            Console.WriteLine(" (back to head)"); // Indicate that we are back to the head
        }
    }

    // Main program to test the circular linked list
    class Program
    {
        static void Main(string[] args)
        {
            circlelinkedlist link = new circlelinkedlist(); // Create a new circular linked list
            link.INsertAtIndex(1, 0); // Insert 1 at index 0
            link.INsertAtIndex(2, 1); // Insert 2 at index 1
            link.INsertAtIndex(3, 2); // Insert 3 at index 2
            link.print(); // Display the list

            link.InsertAtBegin(0); // Insert 0 at the beginning
            link.print(); // Display the list

            link.InsertAtEnd(5); // Insert 5 at the end
            link.print(); // Display the list

            link.RemoveNodeAtBegin(); // Remove the head node
            link.print(); // Display the list

            link.RemoveNodeAtEnd(); // Remove the last node
            link.print(); // Display the list

            link.RemoveNodeAtIndex(2); // Remove the node at index 2
            link.print(); // Display the list

            link.Invert(); // Invert the circular linked list
            link.print(); // Display the inverted list
        }
    }
}