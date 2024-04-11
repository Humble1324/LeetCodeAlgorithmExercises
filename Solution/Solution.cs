using System;
using System.Collections.Generic;

namespace LeetCode.Solution;

public partial class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> hashNums = new HashSet<int>();
        foreach (var num in nums)
            hashNums.Add(num);
        int longest = 0;
        foreach (var num in hashNums)//遍历所有数
        {
            if (!hashNums.Contains(num - 1))//如果这个数的前一个数不存在，那么这个数就是一个连续序列的开始
            {
                int currentNum = num;
                int currentLongest = 1;
                //重新计算当前最长序列
                
                while (hashNums.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentLongest++;
                }//有就加

                longest = Math.Max(longest, currentLongest);
                //和最长比长
            }
        }
        return 0;
    }
}