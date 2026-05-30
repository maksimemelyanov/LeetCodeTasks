using NUnit.Framework;

namespace LeetCodeTestApp;


public class TreeNode { 
    public int val; 
    public TreeNode left; 
    public TreeNode right; 
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) { 
        this.val = val; 
        this.left = left; 
        this.right = right; 
    }
}


public class FindBottomLeftValueTask
{
    public int FindBottomLeftValue(TreeNode root) 
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var result = 0;
        while (queue.Count > 0)
        {
            var levelSize = queue.Count;
            result = queue.Peek().val;
            for (var i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }
        return result;
    }
}

public class FindBottomLeftValueTask_Tests
{
    [Test]
    public void Test1()
    {
        var left = new TreeNode(1);
        var right = new TreeNode(3);
        var tree = new TreeNode(2, left,  right);
        var actual = new FindBottomLeftValueTask().FindBottomLeftValue(tree);
        Assert.That(actual, Is.EqualTo(1));
    }

    [Test]
    public void Test2()
    {
        var tree = new TreeNode(
            1,
            new TreeNode(
                2,
                new TreeNode(
                    4)),
            new TreeNode(
                3,
                new TreeNode(
                    5,
                    new TreeNode(
                        7)),
                new TreeNode(
                    6)));
        var actual = new FindBottomLeftValueTask().FindBottomLeftValue(tree);
        Assert.That(actual, Is.EqualTo(7));
    }
}