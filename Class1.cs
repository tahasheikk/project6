using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linklist
{
    public class node
    {
        public int Data;
        public node next;
        public node(int data)
        {
            Data = data;
            next = null;
        }

    }

    public class linkedlist
    {
        private node head;// head = first
        private int size;
        public linkedlist()
        {
            head = null;
            size = 0;
        }
        public void INsertAtIndex(int data, int index)
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("out of rang or empty");
            }
            node newnode = new node(data);
            if (index == 0)
            {
                newnode.next = head;//newnode.next = null;
                head = newnode;
            }
            else
            {
                node newp = head;
                for (int i = 0; i < index - 1; i++)//add befor node 
                {
                    newp = newp.next;//shift newp to right
                }
                newnode.next = newp.next;//newnode new of node
                newp.next = newnode;//newp original node


            }
            size++;//count of linkedlist

        }
        public void InsertAtEnd(int data)
        {
            INsertAtIndex(data, size);
        }
        public void InsertAtBegin(int data)
        {
            INsertAtIndex(data, 0);
        }
        public void UpdateNode(int data, int index)//1 -> 2 -> 3 update 2 to 5( 1 -> 5 -> 3 )
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("out of rang or empty");
            }
            node newnode = new node(data);
            if (index == 0)
            {
                newnode.next = head;//newnode.next = null;
                head = newnode;
            }
            else
            {
                node newp = head;
                for (int i = 0; i < index; i++)//add befor node 
                {
                    newp = newp.next;//shift newp to right
                }
                newp.Data = data;


            }
            size++;//count of linkedlist

        }
        public int RemoveNodeAtIndex(int index)
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("out of rang");
            }
            node remove;
            int removedata;
            if (index == 0)
            {
                remove = head;
                head = remove.next;
                removedata = remove.Data;

            }
            else
            {
                node newp = head;
                for (int i = 0; i < index - 1; i++)
                {
                    newp = newp.next;
                }
                removedata = newp.next.Data;
                newp.next = newp.next.next;

            }

            size--;//count of linkedlist
            Console.WriteLine("removed data is :" + removedata);
            return removedata;

        }
        public int RemoveNodeAtEnd(int index)
        {
            return RemoveNodeAtIndex(size - 1);// last index = size - 1
        }
        public int RemoveNodeAtBegin(int index)
        {
            return RemoveNodeAtIndex(0);
        }
        public int SizeOfList()
        {
            return size;
        }
        public void Concatenate(linkedlist linklist2)//mix original linkedlist to linkedlist 2
        {
            if (linklist2 == null)
            {
                Console.WriteLine("linkedlist 2 is null");
                return;//dont do anything
            }

            if (head == null)
            {
                head = linklist2.head;
            }
            else
            {
                node newp = head;
                while (newp != null)
                {
                    newp = newp.next;
                }
                newp.next = linklist2.head;//linklist 2 connectecing to next of linklist
            }
            size += linklist2.size;
        }
        public void Invert()//Important
        {
            node befor = null;//befor node pointed to null
            node newp = head;
            node after = null;//after node pointed to null
            while (newp != null)
            {
                after = newp.next;
                newp.next = befor;
                befor = newp;
                newp = after;
            }
            head = befor;

        }
        public void print()
        {
            node newp = head;
            while (newp != null)
            {
                Console.Write(newp.Data);
                Console.Write(" -> ");
                newp = newp.next;
            }
            Console.WriteLine("Null");
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            linkedlist link = new linkedlist();
            link.INsertAtIndex(1, 0);
            link.INsertAtIndex(2, 1);
            link.INsertAtIndex(3, 2);
            link.print();
            link.InsertAtBegin(0);
            link.print();
            link.InsertAtEnd(5);
            link.print();
            link.RemoveNodeAtBegin(2);
            link.print();
            link.RemoveNodeAtEnd(0);
            link.print();
            link.RemoveNodeAtIndex(2);
            link.print();
            link.Invert();
            link.print();




        }
    }
}
