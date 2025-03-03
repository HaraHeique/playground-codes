namespace Others.LeetCode.Solutions;

public class DepthFirstSearchSolution
{
    internal class TreeNode 
    {
        // TODO: Aqui poderia usar generics ou seja T & Node<T>
        public int Value { get; private set; }

        public TreeNode? LeftChild { get; private set; }

        public TreeNode? RightChild { get; private set; }

        private TreeNode() {}

        public static TreeNode Construct(int value) 
        {
            var instance = new TreeNode
            {
                Value = value
            };

            return instance;
        }

        public TreeNode WithLeftChild(TreeNode node) 
        {
            ArgumentNullException.ThrowIfNull(node);
            if (LeftChild is not null) throw new InvalidOperationException("LeftChild is already not null");

            LeftChild = node;

            return this;
        }

        public TreeNode WithRightChild(TreeNode node) 
        {
            ArgumentNullException.ThrowIfNull(node);
            if (RightChild is not null) throw new InvalidOperationException("RightChild is already not null");

            RightChild = node;

            return this;
        }

        public bool HasLeftChild() => LeftChild is not null;
        public bool HasRightChild() => RightChild is not null;
    }

    public static void ShowSolution(params string[] _) 
    {
        Console.WriteLine("Executing DFS Solution");

        var rootNode = TreeNode.Construct(1)
            .WithLeftChild(
                TreeNode.Construct(2)
                    .WithLeftChild(TreeNode.Construct(3))
                    .WithRightChild(TreeNode.Construct(4))
            )
            .WithRightChild(
                TreeNode.Construct(5)
                    .WithLeftChild(TreeNode.Construct(6))
                    .WithRightChild(TreeNode.Construct(7))
            );

        ExecuteSolution(rootNode);
        Console.WriteLine();
        ExecuteSolutionWithOutsideStack(rootNode);
        Console.WriteLine();
        ExecuteCommonSolution(rootNode);
        Console.WriteLine();

        Console.WriteLine("DFS Solution has been finished!");
    }

    /// <summary>
    /// Minha solução usando recursão
    /// </summary>
    /// <param name="root"></param>
    private static void ExecuteSolution(TreeNode root) 
    {
        Execute(root);

        static void Execute(TreeNode? currentNode) 
        {
            if (currentNode is null) return;

            Console.Write($"{currentNode.Value} => ");

            Execute(currentNode.LeftChild);
            Execute(currentNode.RightChild);
        }
    }
    
    /// <summary>
    /// Minha solução usando recursão e uma pilha à parte, mas acaba dando na mesma soluçao acima, só que mais complexo...
    /// </summary>
    /// <param name="root"></param>
    private static void ExecuteSolutionWithOutsideStack(TreeNode root) 
    {
        Stack<(TreeNode Node, int Level)> sequenceOfNodes = new();

        sequenceOfNodes.Push((root, 1));

        Execute();

        void Execute()
        {
            if (sequenceOfNodes.Count == 0) return;

            var (currentNode, level) = sequenceOfNodes.Pop();
            int nextLevel = level + 1;

            Console.Write($"{currentNode.Value} => ");

            if (currentNode.HasLeftChild()) 
            {
                sequenceOfNodes.Push((currentNode.LeftChild, nextLevel)!);
                Execute();
            }
                
            if (currentNode.HasRightChild()) 
            {
                sequenceOfNodes.Push((currentNode.RightChild, nextLevel)!);
                Execute();
            }
        }
    }
    
    /// <summary>
    /// Minha solução usando recursão e uma pilha à parte, ao invés de usar a pilha de chamadas de funções
    /// </summary>
    /// <param name="root"></param>
    private static void ExecuteCommonSolution(TreeNode root) 
    {
        Stack<(TreeNode Node, int Level)> sequenceOfNodes = new();

        sequenceOfNodes.Push((root, 1));

        while (sequenceOfNodes.Count > 0)
        {
            var (currentNode, level) = sequenceOfNodes.Pop();
            int nextLevel = level + 1;

            Console.Write($"{currentNode.Value}-{level} => ");

            if (currentNode.HasRightChild())
                sequenceOfNodes.Push((currentNode.RightChild!, nextLevel));

            if (currentNode.HasLeftChild())
                sequenceOfNodes.Push((currentNode.LeftChild!, nextLevel));
        }
    }
}