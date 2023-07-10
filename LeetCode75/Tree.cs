using System.Collections.Generic;
using System.Linq;

namespace LeetCode;

public partial class LeetCode75
{
    
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> tree1 = new List<int>();
        List<int> tree2 = new List<int>();

        if (root1 != null)
        {
            Leaf(root1,tree1);
        }

        if (root2 != null)
        {
            Leaf(root2,tree2);
        }
        return tree1.SequenceEqual(tree2);
    }
    public void Leaf(TreeNode root, List<int> DFSS)
    {
        if (root.left == null && root.right == null)
        {
            DFSS.Add(root.val);
        }

        else if (root.left != null)
        {
            Leaf(root.left,DFSS);
        }

        else if (root.right != null)
        {
            Leaf(root.right,DFSS);
        }
    }
    public int GoodNodes(TreeNode root)
    {
        int max = root.val;
        List<int> maxLeafs = new List<int>();
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
        if (root.left != null)
        {
            MaxLeaf(root.left, max, MaxLeafs);
        }
        if (root.right != null)
        {
            MaxLeaf(root.right, max, MaxLeafs);
        }
    }
    
    public int PathSum(TreeNode root, int targetSum)
    {
        if (root == null) return 0;
        int sum = 0;
        sum += RootSum(root, targetSum);
        sum+=RootSum(root.left, targetSum);
        sum+=RootSum(root.right, targetSum);
        return sum;
    }

    public int RootSum(TreeNode root, long targetSum)
    {
        int ret = 0;

        if (root == null) {
            return 0;
        }

        if (root.val == targetSum) ret++;
        ret += RootSum(root.left, targetSum - root.val);
        ret += RootSum(root.right, targetSum - root.val);
        return ret;
    }


}
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