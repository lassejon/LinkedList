using System.Net.NetworkInformation;

namespace LinkedListApp.Classes
{
    public class Node
    {
        public int? Value { get; set; }
        public Node Next { get; set; }

        public Node()
        {
            Value = null;
            Next = null;
        }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
        
        public override string ToString()
        {
            return $"Node(Value: {Value}, Next.Value: {(Next is null ? "null" : Next.Value)})";
        }
    }
}