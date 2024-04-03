namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
    {
        
        return dfs(original, cloned, target);;
    }
    public TreeNode? dfs(TreeNode? original, TreeNode? cloned, TreeNode target)
    {
        if (original == null) return null;
        if(original==target) return cloned;
        var left = dfs(original.left, cloned.left, target);
        var right = dfs(original.right, cloned.right, target);
        return left ?? right;

    }
}