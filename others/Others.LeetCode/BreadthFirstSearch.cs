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
    }

    public static void Execute(params string[] _) 
    {
        Console.WriteLine("Executing BFS Solution");

        var rootNode = TreeNode.Construct(1)
            .WithLeftChild(
                TreeNode.Construct(2)
                    .WithLeftChild(
                        TreeNode.Construct(4)
                            .WithLeftChild(TreeNode.Construct(7))
                            .WithRightChild(TreeNode.Construct(8))
                    )
            )
            .WithRightChild(
                TreeNode.Construct(3)
                    .WithLeftChild(TreeNode.Construct(5))
                    .WithRightChild(TreeNode.Construct(6))
            );

        Console.WriteLine("BFS Solution has been finished!");
    }
}