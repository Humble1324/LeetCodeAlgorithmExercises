using System.Collections.Generic;

namespace LeetCode.Solution;

public partial class Solution {
    public int NumberOfPoints(IList<IList<int>> nums)
    {
        HashSet<int> setNums = new HashSet<int>();
        foreach (var num in nums)
        {
            int temp = num[0];
            while (temp <= num[1])
            {
                setNums.Add(temp++);
            }
        }
        return  setNums.Count;
    }
}