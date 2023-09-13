using System;

namespace LeetCode.Solution;

public partial class Solution
{
    public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
    {
        int step = Math.Max(Math.Abs(fx-sx),Math.Abs(fy-sy));
        return step==0?t!=1:step<=t;
    }
}