using System;
using LinkedListApp.Classes;

namespace LinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList(1, 2, 34, 5);
            linkedList.Append(new Node(234));
            linkedList.Append(new Node(4444));
            Console.WriteLine(linkedList.Tail);
            linkedList.Append(123);
            linkedList.Append(5555);
            Console.WriteLine(linkedList.At(7));
            Console.WriteLine(linkedList);
            Console.WriteLine(linkedList.Tail);
            Console.WriteLine(linkedList.Head);
            Console.WriteLine(linkedList.Size);

            Console.WriteLine(linkedList.Pop());
            Console.WriteLine(linkedList);
            Console.WriteLine(linkedList.Tail);

            Console.WriteLine(linkedList.Contains(1));

            Console.WriteLine(linkedList.Find(34));
            
            linkedList.InsertAt(45, 6);
            Console.WriteLine(linkedList);
            
            linkedList.RemoveAt(4);
            Console.WriteLine(linkedList);
            Console.WriteLine(linkedList.Head);
            Console.WriteLine(linkedList.Tail);
        }
    }
}