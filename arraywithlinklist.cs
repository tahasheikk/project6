using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using arraywithlinklist;
using linklist;

namespace arraywithlinklist
{
    class arraywithlinkedkist
    {
        private linkedlist linklist;
        public arraywithlinkedkist()
        {
            linklist = new linkedlist();
        }
        public void insertatindex(int data , int index)
        {
              linklist.INsertAtIndex(data  , index);
        }
        public void InsertAtEnd(int data)
        {
            linklist.InsertAtEnd( data);
        }
        public void InsertAtBegin(int data)
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
        public void RemoveNodeAtBegin(int index)
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
            arraywithlinkedkist array = new arraywithlinkedkist();
            array.InsertAtBegin(22);
            array.SizeOfList();
            array.print();
            //is working for else functions
            
        }
    }
}
