using System.Collections.Generic;
using System.Security.Policy;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int n = grid.Length;
        HashSet<int> row = new HashSet<int>();
        List<int> ans = new List<int>();
        foreach (var ints in grid)
        {
            foreach (var i in ints)
            {
                if (row.Contains(i))
                {
                    ans.Add(i);
                }
                else
                {
                    row.Add(i);
                }
            }
        }

        for (int i = 1; i <= n*n; i++)
        {
            if (!row.Contains(i))
                ans.Add(i);
        }

        return ans.ToArray();
    }
}