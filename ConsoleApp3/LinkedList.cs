using System;

public interface ILL<T>
{
    void insertFront(T n);
    void traverse();
    //void LL();
}

// Using generics <T> type can be set when instance of LL
// class is instantiated
internal class LL<T> : ILL<T>
{
    private Node head = null;

    // Private node class, not accessible outside LL
    // Payload of data takes on generic T data type
    private class Node
    {
        internal T data;
        internal Node next;

        // New node has a data payload and pointer
        // to the next node (initially null)
        internal Node(T value)
        {
            this.data = value;
            this.next = null;
        }
    }

    // Initialise LL with head as null pointer
    public LL()
    {
        this.head = null;
    }

    public void insertFront(T n)
    {
        Node newNode = new Node(n);
        newNode.next = this.head;
        this.head = newNode;
    }

    public void traverse()
    {
        Node current;
        current = this.head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }
}
