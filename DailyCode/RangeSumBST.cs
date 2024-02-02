using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public  int sum = 0;
    public int publicLow;
    public int publicHigh;
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        publicLow=low;
        publicHigh = high;
        dfsSum(root);
        return sum;
    }

    public void dfsSum(TreeNode? root)
    {
        if (root == null) return;
        if (root.val >= publicLow && root.val <= publicHigh)
        {
            sum += root.val;
        }
        dfsSum(root.left);
        dfsSum(root.right);
    }
}