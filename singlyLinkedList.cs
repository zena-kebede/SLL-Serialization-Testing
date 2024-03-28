using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    public class singlyLinkedList : ILinkedListADT
    {
        private Node head;
        private int listSize = 0;

        public bool IsEmpty()
        {
            //if the list is empty it will return true
            //and False if the head is not null 
            //meaning there must be somthing in the list.
            if (head == null)
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            //sets the head to null & the list size to 0
            //effectively clearing the linked list.
            head = null;
            listSize = 0;
        }

        public void Append(object data)
        {
            //creates a new node with the given data.
            Node newnode = new Node(data);
            //if the head is empty the new node becomes the head.
            if (head == null)
            {
                head = newnode;
                //increase list size by one.
                listSize++;
                //exit since we dont need to loop through now.
                return;
            }
            // otherwise we point to the head and begin to iterate through the items until we find the end of the list
            //once the end is found we have the node point to our new node effectively adding it to the SLL
            Node currentnode = head;
            while (currentnode.Next != null)
            {
                //moving through the SLL Nodes
                currentnode = currentnode.Next;
            }
            //after the end it found. we add a new node on. and incraese the list size 
            currentnode.Next = newnode;
            listSize++;



        }

        public void Prepend(object data)
        {
            //creates a new node with the given data
            Node newnode = new Node(data);
            //set the old head to the next of the new node
            newnode.Next = head;
            //set the head to the new node
            head = newnode;
            //increase the list size by one. 
            listSize++;
        }

        public void Insert(object data, int index)
        {
            //checks if the index is valid.
            //by checking if the index is greater or less than the existing list size.
            if (index > listSize || index < 0)
            {
                throw new IndexOutOfRangeException("this index does not exist in the list");
            }
            // if the index is 0 its the same as prepending.
            if (index == 0)
            {
                Prepend(data);
                //no need to increase list size since the prepend function will handle that.
                return;
            }
            //creating the new node. 
            Node newnode = new Node(data);
            //creating counter to keep track of index 
            int counter = 0;
            //starting at the top of the SLL
            Node currentnode = head;
            //getting the old node variable ready to hold the preveous nodes
            Node oldNode = null;
            //counting unitl the conter = index
            while (counter != index)
            {
                //mkaing the current node the old node before moving to the next node. 
                oldNode = currentnode;
                //moving tothe next node.
                currentnode = currentnode.Next;
                //adding one to the counter.
                counter++;
            }
            newnode.Next = currentnode;
            oldNode.Next = newnode;
            listSize++;

        }

        public void Replace(object data, int index)
        {
            //checks if the index is valid.
            //by checking if the index is greater or less than the existing list size.
            if (index > listSize || index < 0)
            {
                throw new IndexOutOfRangeException("this index does not exist in the list");
            }
            // if the index is 0 its the same as prepending.
            if (index == 0)
            {
                Prepend(data);
                return;
            }
            //creating the new node. 
            Node newnode = new Node(data);
            //creating counter to keep track of index 
            int counter = 0;
            //starting at the top of the SLL
            Node currentnode = head;
            //to keep track of the node beofre the current. 
            Node oldnode = null;
            while (counter != index)
            {
                //moving the old node foward one
                oldnode = currentnode;
                //moving the current node foward one
                currentnode = currentnode.Next;
                //increasing the current index
                counter++;
            }
            //once at the right index
            //set the new nodes next to match the one its replacing
            newnode.Next = currentnode.Next;
            //setting the node beofre this one to point to the new node.
            oldnode.Next = newnode;


        }

        public int Size()
        {
            return listSize;
        }

        public void Delete(int index)
        {
            //checks if the index is valid.
            //by checking if the index is greater or less than the existing list size.
            if (index > listSize || index < 0)
            {
                throw new IndexOutOfRangeException("this index does not exist in the list");
            }

            int counter = 0;
            Node currentnode = head;
            Node oldnode = null;
            while (counter != index)
            {
                //moving the old node foward one
                oldnode = currentnode;
                //moving the current node foward one
                currentnode = currentnode.Next;
                //increasing the current index
                counter++;
            }
            oldnode.Next = currentnode.Next;
            listSize--;
        }

        public object Retrieve(int index)
        {
            //checks if the index is valid.
            //by checking if the index is greater or less than the existing list size.
            if (index > listSize || index < 0)
            {
                throw new IndexOutOfRangeException("this index does not exist in the list");
            }
            int counter = 0;
            Node currentnode = head;
            while (counter != index)
            {
                //moving the current node foward one
                currentnode = currentnode.Next;
                //increasing the current index
                counter++;
            }
            return currentnode.Data;


        }

        public int IndexOf(Object Data)
        {
            if (head == null)
            {
                return -1;
            }
            Node currentnode = head;
            int counter = 0;
            //keepis going until an empty node or the object is found. 
            while (currentnode != null)
            {
                //checks the current nodes data to the search
                if (currentnode.Data == Data)
                {
                    //if it matches return the counter index
                    return counter;
                }
                //if no match move the node to the next node. 
                currentnode = currentnode.Next;
                //increase the counter.
                counter++;
            }
            return -1;

        }

        public bool Contains(Object Data)
        {
            if (head == null)
            {
                return false;
            }
            Node currentnode = head;
            int counter = 0;
            //keepis going until an empty node or the object is found. 
            while (currentnode != null)
            {
                //checks the current nodes data to the search
                if (currentnode.Data == Data)
                {
                    //if it matches return true
                    return true;
                }
                //if no match move the node to the next node. 
                currentnode = currentnode.Next;
                //increase the counter.
                counter++;
            }
            return false;

        }

        public void Display()
        {
            // Iterate or traverse through the SLL
            Node currentNode = head;
            while (currentNode != null)
            {
                User person = currentNode.Data as User;
                // Perform operations on the current node
                Console.Write(person.ToString() + " ");

                // Move to the next node
                currentNode = currentNode.Next;
            }

            Console.WriteLine();
        }

        public bool Join(singlyLinkedList two)
        {
            //Check if the list is to be added is empty
            if (two.IsEmpty() == true)
            {
                //returning false on a faliure
                return false;
            }
            //getting the location of the last node
            int lastnode = listSize;
            //start at 1 since were on the first node
            int currentindex = 1;
            //Setting the first node to last
            Node currentnode = head;
            //comparing the current location to the last node location until they match
            while (currentindex < lastnode)
            {
                //moving node forward
                currentnode = currentnode.Next;
                //increasing counter
                currentindex++;
            }
            //setting the next of the last node of list 1 to be the head of list 2
            currentnode.Next = two.head;
            listSize += two.listSize;
            //returning true if succeded
            return true;
        }
    }
}
