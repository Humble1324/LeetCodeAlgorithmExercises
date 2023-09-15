using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode;

public partial class LeetCode75
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        var tree1 = new List<int>();
        var tree2 = new List<int>();

        if (root1 != null) Leaf(root1, tree1);

        if (root2 != null) Leaf(root2, tree2);
        return tree1.SequenceEqual(tree2);
    }

    public void Leaf(TreeNode root, List<int> DFSS)
    {
        if (root.left == null && root.right == null)
            DFSS.Add(root.val);

        else if (root.left != null)
            Leaf(root.left, DFSS);

        else if (root.right != null) Leaf(root.right, DFSS);
    }

    public int GoodNodes(TreeNode root)
    {
        var max = root.val;
        var maxLeafs = new List<int>();
        MaxLeaf(root, max, maxLeafs);
        return maxLeafs.Count;
    }

    public void MaxLeaf(TreeNode root, int max, List<int> MaxLeafs)
    {
        if (root.val <= max)
        {
            MaxLeafs.Add(root.val);
            max = root.val;
        }

        if (root.left != null) MaxLeaf(root.left, max, MaxLeafs);
        if (root.right != null) MaxLeaf(root.right, max, MaxLeafs);
    }

    public int PathSum(TreeNode root, int targetSum)
    {
        if (root == null) return 0;
        var sum = 0;
        sum += RootSum(root, targetSum);
        sum += RootSum(root.left, targetSum);
        sum += RootSum(root.right, targetSum);
        return sum;
    }

    public int RootSum(TreeNode root, long targetSum)
    {
        var ret = 0;

        if (root == null) return 0;

        if (root.val == targetSum) ret++;
        ret += RootSum(root.left, targetSum - root.val);
        ret += RootSum(root.right, targetSum - root.val);
        return ret;
    }

    private int ans = 0;

    public int LongestZigZag(TreeNode root)
    {
        dfs(root);
        return ans;
    }

    private int[] dfs(TreeNode? root)
    {
        if (root == null)
            return new[] { -1, -1 };
        int lMax = dfs(root.left)[1]+1;
        int rMax = dfs(root.right)[0]+1;
        ans = Math.Max(ans, Math.Max(lMax, rMax));
        return new int[]{lMax,rMax};
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)return root;//当前节点为空或当前节点就是p、q就返回当前节点
        TreeNode left = LowestCommonAncestor(root.left, p, q);//不空则往下遍历，带入左右子树
        TreeNode right = LowestCommonAncestor(root.right, p, q);
        if (left != null && right != null)return root;
        //如果同时存在左右子节点，即左右节点包含pq，则返回当前节点，证明当前节点就是最近祖先

        return left != null ? left : right;

    }
}

public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}