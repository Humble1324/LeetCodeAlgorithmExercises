using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int[] FindColumnWidth(int[][] grid) {
        int m = grid.Length;
        int n =grid[0].Length;
        List<int> ans = new();
        for(int i =0;i<m;i++){
            int max =0;
            for(int j =0;j<n;j++){
                var temp=0;
                
                temp = grid[i][j].ToString().Length;
                if(grid[i][j]<0)
                    temp++;
                max=Math.Max(max,temp);
            }
            ans.Add(max);
        }
        return ans.ToArray();
    }
}
