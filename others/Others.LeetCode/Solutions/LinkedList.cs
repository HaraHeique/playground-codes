using System.Text;

namespace Others.LeetCode.Solutions;

public class LinkedListSolution
{
    public class LinkedList<T> 
    {
        public LinkedListNode<T>? Head { get; private set; }
        public LinkedListNode<T>? Tail { get; private set; }
        public int Count { get; private set; } = 0;

        public static LinkedList<T> Create(T value) 
        {
            var firstNode = LinkedListNode<T>.Construct(value);

            var instance = new LinkedList<T> 
            {
                Head = firstNode,
                Tail = firstNode,
                Count = 1
            };

            return instance;
        }

        public LinkedList<T> WithNextNode(T value) 
        {
            Tail!.WithLastNode(value);
            Tail = Tail.Next;

            Count++;

            return this;
        }

        public LinkedList<T> WithHeaderNode(T value) 
        {
            var newHeaderNode = LinkedListNode<T>.Construct(value);
            newHeaderNode.WithNextNode(Head!); 
            Head = newHeaderNode;

            Count++;

            return this;
        }

        public override string ToString()
        {
            var currentNode = Head;
            var representationAsStr = new StringBuilder();

            while (currentNode != null) 
            {
                representationAsStr.Append($"{currentNode.Value} => ");
                currentNode = currentNode.Next;
            }

            representationAsStr.Append("NULL");

            return representationAsStr.ToString();
        }
    }

    public class LinkedListNode<T>
    {
        public T Value { get; private set; }
        public LinkedListNode<T>? Next { get; private set; }

        public LinkedListNode()
        {
            Value = default!;
        }

        public static LinkedListNode<T> Construct(T value)
        {
            var instance = new LinkedListNode<T>
            {
                Value = value
            };

            return instance;
        }

        public void WithLastNode(T value)
        {
            var newNode = new LinkedListNode<T>
            {
                Value = value,
                Next = null
            };

            Next = newNode;
        }

        public void WithNextNode(LinkedListNode<T> newNode) => Next = newNode;
    }

    public static void ShowSolution(params string[] _) 
    {
        var linkedList = LinkedList<int>.Create(1)
            .WithNextNode(10)
            .WithNextNode(20)
            .WithNextNode(30)
            .WithHeaderNode(-10)
            .WithNextNode(110)
            .WithHeaderNode(-100);

        Console.WriteLine(linkedList.ToString());
        Console.WriteLine("Total number of nodes: {0}", linkedList.Count);
    }
}