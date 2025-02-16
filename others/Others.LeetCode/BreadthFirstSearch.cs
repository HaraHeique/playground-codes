using System.Collections;

namespace Others.LeetCode;

public class BreadthFirstSearchSolution
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

    public static void Execute(params string[] _) 
    {
        Console.WriteLine("Executing BFS Solution");

        var rootNode = TreeNode.Construct(1)
            .WithLeftChild(
                TreeNode.Construct(2)
                    .WithLeftChild(
                        TreeNode.Construct(4)
                            .WithLeftChild(
                                TreeNode.Construct(7)
                                    .WithLeftChild(TreeNode.Construct(9))
                                    .WithRightChild(TreeNode.Construct(10))
                            )
                            .WithRightChild(TreeNode.Construct(8))
                    )
            )
            .WithRightChild(
                TreeNode.Construct(3)
                    .WithLeftChild(TreeNode.Construct(5))
                    .WithRightChild(TreeNode.Construct(6))
            );

        MilanSolution(rootNode);
        Console.WriteLine();

        Console.WriteLine();
        RecursionSolution(rootNode);
        Console.WriteLine();

        Console.WriteLine("BFS Solution has been finished!");
    }

    /// <summary>
    /// Solução delete mostrada aqui: https://www.youtube.com/watch?v=WIVkVToFmrY
    /// </summary>
    /// <param name="root"></param>
    private static void MilanSolution(TreeNode root) 
    {
        Queue<(TreeNode Node, int Level)> queue = new();

        queue.Enqueue((root, 1));
        int currentLevel = queue.Peek().Level;

        while (queue.Count > 0)
        {
            (TreeNode currentNode, int level) = queue.Dequeue();

            if (currentLevel < level) 
            {
                Console.WriteLine();
                currentLevel = level;
            }

            Console.Write($"{currentNode.Value} ");

            if (currentNode.HasLeftChild())
            {
                queue.Enqueue((currentNode.LeftChild!, level + 1));
            }

            if (currentNode.HasRightChild())
            {
                queue.Enqueue((currentNode.RightChild!, level + 1));
            }
        }
    }

    /// <summary>
    /// Minha solução usando recursão, que não é melhor que a do Milan
    /// </summary>
    /// <param name="root"></param>
    private static void RecursionSolution(TreeNode root) 
    {
        PriorityQueue<(int Value, int Level), string> values = new();

        values.Enqueue((root.Value, 1), "1");
        int numberOfSteps = 0;

        Execute(root, currentLevel: 1);
        ShowResult();

        void Execute(TreeNode? currentNode, int currentLevel) 
        {
            if (currentNode is null) return;

            int nextLevel = currentLevel + 1;

            if (currentNode.HasLeftChild()) 
                values.Enqueue((currentNode.LeftChild!.Value, nextLevel), $"{nextLevel}.{numberOfSteps++}");

            if (currentNode.HasRightChild()) 
                values.Enqueue((currentNode.RightChild!.Value, nextLevel), $"{nextLevel}.{numberOfSteps++}");

            Execute(currentNode.LeftChild, currentLevel + 1);
            Execute(currentNode.RightChild, currentLevel + 1);
        }

        void ShowResult() 
        {
            int currentLevel = 1;

            while (values.TryDequeue(out var item, out var _))
            {
                if (currentLevel != item.Level) Console.WriteLine();

                Console.Write($"{item.Value} ");

                currentLevel = item.Level;
            }
        }
    }
}