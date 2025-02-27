using System;

namespace LeetCode.MidSolution;

public class Solution
{
    public static int Trap(int[] height)
    {
        int lens = height.Length;
        int[] leftMax = new int[lens];
        int[] rightMax = new int[lens];
        leftMax[0] = height[0];
        rightMax[lens - 1] = height[lens - 1];
        for (int i = 1; i < lens; i++)
        {
            leftMax[i]=Math.Max(leftMax[i-1], height[i]);

        }
        for (int i = lens - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i+1], height[i]);
        }
        int sum = 0;
        for (int i = 0; i < lens; i++)
        {
            int min = Math.Min(leftMax[i], rightMax[i]);
            if (min > height[i])
            {
                sum += (min - height[i]);
            }
        }

        return sum;
    }


}