
using System;
using System.Text;

namespace LinkedListApp.Classes
{
    public class LinkedList
    {
        public int Size { get; private set; }
        public Node Head { get; private set; }
        
        public Node Tail { get; private set; }

        public LinkedList()
        {
            Size = 0;
            Head = null;
            Tail = Head;
        }

        public LinkedList(params int[] values)
        {
            Head = new Node(values[0]);
            var prevNode  = Head;
            Size++;
            
            foreach (var value in values[1..^0])
            {
                var node = new Node(value);
                prevNode.Next = node;
                
                prevNode = node;
                Size++;
            }

            Tail = prevNode;
        }

        private Node GetTailWithLoop()
        {
            var node = Head;
            while (node.Next is not null)
            {
                node = node.Next;
            }

            return node;
        }

        public void Prepend(Node head)
        {
            head.Next = Head;
            Head = head;
            Size++;
        }

        public void Prepend(int value)
        {
            var head = new Node(value)
            {
                Next = Head
            };
            Head = head;
            Size++;
        }

        public void Append(Node next)
        {
            Tail.Next = next;
            Tail = next;
            Size++;
        }

        public void Append(int value)
        {
            var next = new Node(value);
            Tail.Next = next;
            Tail = next;
            Size++;
        }

        public Node At(int index)
        {
            var i = 0;
            var node = Head;
            while (node.Next is not null)
            {
                if (index == i)
                {
                    return node;
                }
                
                node = node.Next;
                i++;
            }

            if (index != i)
            {
                throw new IndexOutOfRangeException();
            }

            return node;
        }

        public void InsertAt(int value, int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            
            var node = new Node(value);
            if (index == 0)
            {
                node.Next = Head;
                Head = node;
                Size++;
                return;
            }

            if (index == Size - 1)
            {
                Tail.Next = node;
                Tail = node;
                Size++;
                return;
            }
            
            var prevNode = Head;
            var i = 1;
            while (prevNode.Next is not null)
            {
                if (index == i)
                {
                    node.Next = prevNode.Next;
                    prevNode.Next = node;

                    Size++;
                    return;
                }

                prevNode = prevNode.Next;
                i++;
            }
        }

        public void InsertAt(Node node, int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (index == 0)
            {
                node.Next = Head;
                Head = node;
                Size++;
                return;
            }

            if (index == Size - 1)
            {
                Tail.Next = node;
                Tail = node;
                Size++;
                return;
            }
            
            var prevNode = Head;
            var i = 1;
            while (prevNode.Next is not null)
            {
                if (index == i)
                {
                    node.Next = prevNode.Next;
                    prevNode.Next = node;

                    Size++;
                    return;
                }

                prevNode = prevNode.Next;
                i++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            var prevNode = Head;
            var i = 1;
            while (prevNode.Next is not null)
            {
                if (index == i)
                {
                    if (index == Size - 1)
                    {
                        Tail = prevNode;
                    }
                    prevNode.Next = prevNode.Next.Next;
                    Size--;
                    return;
                }

                prevNode = prevNode.Next;
                i++;
            }
        }

        public Node Pop()
        {
            var node = Head;
            var prevNode = node;
            while (node.Next is not null)
            {
                prevNode = node;
                node = node.Next;
            }

            Tail = prevNode;
            Tail.Next = null;

            Size--;

            return node;
        }

        public bool Contains(Node node)
        {
            var nextNode = Head;
            while (nextNode.Next is not null)
            {
                if (node.Value == nextNode.Value)
                {
                    return true;
                }
                nextNode = nextNode.Next;
            }

            return node.Value == nextNode.Value;
        }

        public bool Contains(int value)
        {
            var nextNode = Head;
            while (nextNode.Next is not null)
            {
                if (value == nextNode.Value)
                {
                    return true;
                }
                nextNode = nextNode.Next;
            }

            return value == nextNode.Value;
        }

        public int? Find(int value)
        {
            var index = 0;
            var nextNode = Head;
            while (nextNode.Next is not null)
            {
                if (value == nextNode.Value)
                {
                    return index;
                }
                nextNode = nextNode.Next;
                index++;
            }

            return value == nextNode.Value ? index : null;
        }

        public int? Find(Node node)
        {
            var index = 0;
            var nextNode = Head;
            while (nextNode.Next is not null)
            {
                if (node.Value == nextNode.Value)
                {
                    return index;
                }
                nextNode = nextNode.Next;
                index++;
            }

            return node.Value == nextNode.Value ? index : null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            var node = Head;
            sb.Append('[');
            sb.Append(node.Value);
            while (node.Next is not null)
            {
                node = node.Next;
                sb.Append(", ");
                sb.Append(node.Value);
            }

            sb.Append(']');

            return sb.ToString();
        }
    }
}