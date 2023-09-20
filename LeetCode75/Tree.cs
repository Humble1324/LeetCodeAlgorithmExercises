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
        int lMax = dfs(root.left)[1] + 1;
        int rMax = dfs(root.right)[0] + 1;
        ans = Math.Max(ans, Math.Max(lMax, rMax));
        return new int[] { lMax, rMax };
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q) return root; //当前节点为空或当前节点就是p、q就返回当前节点
        TreeNode left = LowestCommonAncestor(root.left, p, q); //不空则往下遍历，带入左右子树
        TreeNode right = LowestCommonAncestor(root.right, p, q);
        if (left != null && right != null) return root;
        //如果同时存在左右子节点，即左右节点包含pq，则返回当前节点，证明当前节点就是最近祖先

        return left != null ? left : right;
    }

    public IList<int> RightSideView(TreeNode root)
    {
        List<int> res = new List<int>();
        if (root == null) return res;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            int n = q.Count;
            for (int i = 0; i < n; i++)
            {
                var node = q.Dequeue();
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
                if (i == n - 1) res.Add(node.val);
            }
        }

        return res;
    }

    public int MaxLevelSum(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        List<int> maxLevel = new List<int>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            int n = q.Count;
            int temp = 0;
            for (int i = 0; i < n; i++)
            {
                var node = q.Dequeue();
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
                temp += node.val;
            }

            maxLevel.Add(temp);
        }

        int max = Int32.MinValue, level = 0;
        for (int i = 0; i < maxLevel.Count; i++)
        {
            if (maxLevel[i] > max)
            {
                max = maxLevel[i];
                level = i;
            }
        }

        return level + 1;
    }

    public TreeNode SearchBST(TreeNode root, int val)
    {
        while (true)
        {
            //二叉搜索树满足如下性质：
            //左子树所有节点的元素值均小于根的元素值；
            //右子树所有节点的元素值均大于根的元素值。
            if (root == null || root.val == val) return root;
            if (root.val > val)
            {
                root = root.left;
                continue;
            }

            root = root.right;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}