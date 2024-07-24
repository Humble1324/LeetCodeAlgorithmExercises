using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode

{
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        int sum = 0;
        int xx = x;
        while (x > 0)
        {
            int temp = x % 10;
            sum += temp;
            x /= 10;
        }

        return xx % sum == 0 ? sum : -1;
    }

    public int[][] ModifiedMatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        for (int i = 0; i < n; i++)
        {
            int tempMax = -2;
            List<int> tempIndex = new List<int>();
            for (int j = 0; j < m; j++)
            {
                if (matrix[j][i] == -1)
                {
                    tempIndex.Add(j);
                }
                else
                {
                    tempMax = Math.Max(tempMax, matrix[j][i]);
                }
            }

            if (tempIndex.Count != 0)
            {
                foreach (var i1 in tempIndex)
                {
                    matrix[i1][i] = tempMax;
                }
            }
        }

        return matrix;
    }

    public int PivotIndex(int[] nums)
    {
        int total = nums.Sum();
        int sum = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (2 * sum + nums[i] == total) return i;
            sum += nums[i];
        }

        return -1;
    }

    public int[] NumberGame(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i += 2)
        {
            (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
        }

        return nums;
    }

    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        List<int> res = new List<int>();
        res.Add(0);
        res.Add(0);
        int lens1 = nums1.Length;
        int lens2 = nums2.Length;
        int index1 = 0;
        while (index1 < lens1)
        {
            int tempindex = 0;
            while (tempindex < lens2 && nums1[index1] != nums2[tempindex])
            {
                tempindex++;
            }
            if(tempindex<lens1)  res[0]++;
            index1++;
          
        }

        int index2 = 0;
        while (index2 < lens2)
        {
            int tempindex = 0;
            while (tempindex < lens1 && nums2[index2] != nums1[tempindex])
            {
                tempindex++;
            }

            if(tempindex<lens2)  res[1]++;
            index2++;
        }

        return res.ToArray();
    }
    // public int IncremovableSubarrayCount(int[] nums)
    // {
    //     return 0;
    // }

    // public bool isIncresing(int[] nums, int l, int r)
    // {
    //     for(int i=0;i<nums.Length;i++)
    //     {
    //         if (i < l || i > r)
    //         {
    //             if (i + 1 < nums.Length && nums[i] > nums[i + 1])
    //             {
    //                 return false;
    //             }
    //         }
    //     }
    // }
    // public static void Main()
    // {
    //     Console.Write(SumOfTheDigitsOfHarshadNumber(18));
    // }
}