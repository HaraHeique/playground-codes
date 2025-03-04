namespace Others.LeetCode.Solutions;

public class LinkedListSolution
{
    public class LinkedList<T> 
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }

        public static LinkedList<T> Create(T value) 
        {
            var firstNode = LinkedListNode<T>.Construct(value);

            var instance = new LinkedList<T> 
            {
                Head = firstNode,
                Tail = firstNode
            };

            return instance;
        }

        public LinkedList<T> WithNextNode(T value) 
        {
            var newTailNode = Tail.WithLastNode(value);
            Tail = newTailNode;

            return this;
        }

        public LinkedList<T> WithHeaderNode(T value) 
        {
            var newHeaderNode = LinkedListNode<T>.Construct(value)
                .WithNextNode(Head); 
            Head = newHeaderNode;

            return this;
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

        public LinkedListNode<T> WithLastNode(T value)
        {
            var newNode = new LinkedListNode<T>
            {
                Value = value,
                Next = null
            };

            Next = newNode;

            return newNode;
        }

        public LinkedListNode<T> WithNextNode(LinkedListNode<T> newNode)
        {
            Next = newNode;

            return newNode;
        }
    }

    public static void ShowSolution(params string[] _) 
    {
        var linkedList = LinkedList<int>.Create(1)
            .WithNextNode(10)
            .WithNextNode(20)
            .WithNextNode(30)
            .WithHeaderNode(-10)
            .WithNextNode(110);

        var currentNode = linkedList.Head;

        while (currentNode is not null)
        {
            Console.Write($"{currentNode.Value} => ");
            currentNode = currentNode.Next;
        }

        Console.Write("NULL");
    }
}