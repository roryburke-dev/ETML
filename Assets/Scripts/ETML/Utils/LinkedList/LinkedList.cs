// @djanesh : https://github.com/djanesh/LinkedList-in-Csharp/tree/master/linked-list1

using System;

namespace ETML.Utils.LinkedList
{
  public class LinkedList
    {
        /* a -> b -> c -> d
         * Constructor
         * [x]LinkedList() - Initializes the private fields
         * 
         * Private Fields:
         * [x]Node head - Is a reference to the first node in the list 
         * [x]int size - The current size of the list (basically how many items are in the list)
         * 
         * Public Properties:
         * [x] Empty - If the list is empty 
         * [x] Count - How many items are in the list 
         * [x] Indexer - Access data like an array ;
         * 
         * Methods: 
         * [x] Add(int index, object o) - Add an item to the list at specified index 
         * [x] Add(object o) - Add an item to the END of the list 
         * [x] Remove(int index) - Remove the item in the list at the specified index
         * [x] Clear() - Clear the list 
         * [x] IndexOf(object o) - gets the idex of the item in the list, if not in the list return -1
         * [x] Contains(object o) - TRUE / FALSE if the list contains the object
         * [x] Get(int index) - Gets items at the specified index 
         */

        private Node head;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.count = 0;
        }

        public bool Empty
        {
            get { return this.count == 0; }
        }

        public int Count
        {
            get { return this.count; }
        }


        // Indexer
        public object this[int index]
        {
            get { return this.Get(index); }
        }

        // a ->b -> c
        public object Add(int index, object o)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index: " + index); ;
            }
            if (index > count)
                index = count;

            Node current = this.head;

            if (this.Empty || index == 0)
            {
                // beginning of the list
                this.head = new Node(o, this.head);
            } 
            else
            {
                for (int i = 0; i < index - 1; i ++)
                {
                    current = current.Next;
                }

                current.Next = new Node(o, current.Next);
            }
            count++;

            return o;
            
        }

        // Add at the end
        public object Add(object o)
        {
            return this.Add(count, o);
        }

        // Function to remove data from linked list
        public object Remove(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index :" + index);

            if (this.Empty)
                return null;

            if (index >= this.count)
                index = count - 1;

            Node current = this.head;
            object result = null;

            if (index ==0)
            {
                result = current.Data;
                this.head = current.Next;
            } else
            {
                for (int i = 0; i < index - i; i++)
                    current = current.Next;

                result = current.Next.Data;

                current.Next = current.Next.Next;
            }

            count--;
            
            return result;
        }

        // Clear Method 
        // All we are doing is changing the head to null
        public void Clear()
        {
            //a -> b -> c
            this.head = null;
        }

        // Index of Item
        public int IndexOf(object o)
        {
            Node current = this.head;

            for (int i =0; i < this.count; i ++)
            {
                if (current.Data.Equals(o))
                    return i;

                current = current.Next;
            }
            return -1;

        }

        // Public boolean to say if the item is in the list

        public bool Contains(object o)
        {
            return this.IndexOf(o) >= 0;
        }

        // get the item from the linked list using the index
        public object Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index " + index);

            if (this.Empty)
                return null;

            if (index >= this.count)
                index = this.count - 1;

            Node current = this.head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }
    }
}
