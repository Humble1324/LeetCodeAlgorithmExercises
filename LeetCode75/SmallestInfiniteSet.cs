using System.Collections.Generic;
using System.Linq;

namespace LeetCode;

public class SmallestInfiniteSet
{
    private HashSet<int> nums;
    private int minNum = 0;
    public SmallestInfiniteSet()
    {
        nums = new ();
        for (int i = 1; i < 1001; i++)
        {
            nums.Add(i);
        }
    }

    public int PopSmallest()
    {
        if (nums.Count == 0) return -1;
        
        var t=minNum++;
        
        nums.Remove(t);
        return t;
    }

    public void AddBack(int num)
    {
        if (nums.Count < 1) return;
        nums.Add(num);
    }
}