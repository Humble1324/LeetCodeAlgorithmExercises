using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    private int ans = 0;
    private int depth = -1;//起始节点高度
    public int AmountOfTime(TreeNode? root, int start)
    {
        TreeDfs(root,0,start);
        return ans;
    }
    public int TreeDfs(TreeNode? root, int level, int start)
    {
        if (root == null)
        {
            return 0;
        }

        if (root.val == start)//找到中毒目标
        {
            depth = level;
        }

        var l = TreeDfs(root.left, level + 1, start);
        bool isLeft = depth != -1;
        var r = TreeDfs(root.right, level + 1, start);
        if (root.val == start)//当前遍历如果是中毒目标
        {
            ans = Math.Max(ans, Math.Max(l, r));
        }

        if (isLeft)//如果中毒目标在左子树
        {
            ans = Math.Max(ans, depth - level + r);
        }
        else
        {
            ans = Math.Max(ans, depth - level + l);
        }

        return Math.Max(l, r) + 1;

    }
}
