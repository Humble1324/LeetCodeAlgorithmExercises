using System;
using System.Collections.Generic;
using System.IO;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    Dictionary<TreeNode, int> f = new(); //f为选择当前节点的权重

    Dictionary<TreeNode, int> g = new(); //g为未选择当前节点情况的权重


    public int Rob(TreeNode root)
    {
        //局部最优与当前结果做对比，取最优
        //每个节点遍历写出选当前节点的权重和未选中当前节点的权重，取最高
        //f(o)=g(l)+g(r)
        //g(o)=Max(Max(f(l),g(l)),Max(g(r),f(r)))
        dfs(root);
        return Math.Max(GetOrDefault(f, root, 0), GetOrDefault(g, root, 0));
    }

    public void dfs(TreeNode? root)
    {
        if (root == null) return;

        dfs(root.left);
        dfs(root.right);
        f.Add(root, root.val + GetOrDefault(g, root.left, 0) + GetOrDefault(g, root.right, 0));
        g.Add(root,
            Math.Max(GetOrDefault(f, root.left, 0), GetOrDefault(g, root.left, 0)) +
            Math.Max(GetOrDefault(f, root.right, 0), GetOrDefault(g, root.right, 0)));
    }

    public int GetOrDefault(Dictionary<TreeNode, int> dic, TreeNode node, int defaultValue)
    {
        if (node == null)
            return defaultValue;
        if (dic.ContainsKey(node)) return dic[node];
        return defaultValue;
    }
}