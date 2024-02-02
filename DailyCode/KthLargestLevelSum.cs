using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        var queue = new Queue<TreeNode>();
        var level = new List<long>();
        int index = 0;
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            int n = queue.Count;
            
            level.Add(0);
            for (int i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                level[index] += node.val;
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
                
                //if (i == n - 1) res.Add(node.val);
            }
            index++;
        }
        level.Sort();
        level.Reverse();
        return level[k-1];
    }

    // public static void Main()
    // {
    //     KthLargestLevelSum();
    // }
}