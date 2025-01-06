using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using linklist;


namespace stackoflinkedlist
{
    class stackwithlinkedlist
    {
        private linkedlist linklist;
        public stackwithlinkedlist()
        {
            linklist = new linkedlist();
        }
        public void insertatindex(int data, int index)
        {
            linklist.INsertAtIndex(data, index);
        }
        public void InsertAtEnd(int data)
        {
            linklist.InsertAtEnd(data);
        }
        public void push(int data)
        {
            linklist.InsertAtBegin(data);
        }
        public void UpdateNode(int data, int index)
        {
            linklist.UpdateNode(data, index);
        }
        public void RemoveNodeAtIndex(int index)
        {
            linklist.RemoveNodeAtIndex(index);
        }
        public void RemoveNodeAtEnd(int index)
        {
            linklist.RemoveNodeAtEnd(index);
        }
        public void pop(int index)
        {
            linklist.RemoveNodeAtBegin(index);
        }
        public void SizeOfList()
        {
            linklist.SizeOfList();
        }
        public void Invert()
        {
            linklist.Invert();
        }
        public void print()
        {
            linklist.print();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            stackwithlinkedlist stack = new stackwithlinkedlist();
            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.print();
            stack.pop(1);
            stack.print();
            stack.Invert();
            stack.print();
            //
        }
    }
}
