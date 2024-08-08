using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solution;

public class Week395
{
    public int AddedInteger(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        return 0;
    }

    public static int MinimumAddedInteger(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);


        int min = Int32.MaxValue;
        for (var i = 0; i < 3; i++)
        {
            int diff = nums2[0] - nums1[i];
            if (Check(nums1, nums2, diff))
            {
                min = Math.Min(min, diff);
            }
        }
        return min;
    }

    public static bool Check(int[] nums1, int[] nums2, int diff)
    {
        int i = 0;
        foreach (var num in nums2)
        {
            while (i < nums1.Length && nums1[i]+diff !=num )
            {
                i++;
            }

            if (i >= nums1.Length)
            {
                return false;
            }

            i++;
        }

        return true;
    }

    public long MinEnd(int n, int x)
    {
        // long[] nums = new long[n];
        // long pre = 0;
        // for (int i = 0; i < n; i++)
        // {
        //     long t = pre + 1;
        //     while(t&x==)
        // }
        return 0;
    }

    public long BitWiseAnd(int a, int b)
    {
        return a & b;
    }

    // public static void Main()
    // {
    //     int[] nums1 = new[] { 4, 6, 3, 1, 4, 2, 10, 9, 5 };
    //     int[] nums2 = new[] { 5,10,3,2,6,1,9};
    //     Console.WriteLine(MinimumAddedInteger(nums1,nums2));
    // }
}