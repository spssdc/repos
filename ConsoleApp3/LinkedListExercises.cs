using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace LinkedLists
{
    internal class LinkedListExercises
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ILL<int> myLL = new LL<int>();
            LL<string> newLL = new LL<string>();
            myLL.insertFront(3);
            myLL.insertFront(9);
            myLL.insertFront(1);
            myLL.traverse();
            Console.ReadLine();
        }
    }
}