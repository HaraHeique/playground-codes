namespace Others.LeetCode.Solutions;

public class InvertBinaryTreeSolution
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

        public void InvertChildNodes() 
        {
            // Alternativa: (RightChild, LeftChild) = (LeftChild, RightChild);
            var leftNode = LeftChild;
            LeftChild = RightChild;
            RightChild = leftNode;
        }

        public bool HasLeftChild() => LeftChild is not null;
        public bool HasRightChild() => RightChild is not null;
    }

    public static void ShowSolution(params string[] _) 
    {
        Console.WriteLine("Executing Invert Binary Tree Solution");

        var rootNode = TreeNode.Construct(4)
            .WithLeftChild(
                TreeNode.Construct(2)
                    .WithLeftChild(TreeNode.Construct(1))
                    .WithRightChild(TreeNode.Construct(3))
            )
            .WithRightChild(
                TreeNode.Construct(7)
                    .WithLeftChild(TreeNode.Construct(6))
                    .WithRightChild(TreeNode.Construct(9))
            );

        ExecuteSolution(rootNode);
        ShowInvertedTree(rootNode);

        Console.WriteLine("\nInvert Binary Tree Solution has been finished!");
    }

    private static void ExecuteSolution(TreeNode root) 
    {
        Execute(root);

        static void Execute(TreeNode? currentNode) 
        {
            if (currentNode is null) return;

            currentNode.InvertChildNodes();

            Execute(currentNode.LeftChild);
            Execute(currentNode.RightChild);
        }
    }

    private static void ShowInvertedTree(TreeNode? root) 
    {
        if (root is null) return;

        Console.Write("{0} => ", root.Value);

        ShowInvertedTree(root.LeftChild);
        ShowInvertedTree(root.RightChild);
    }
}