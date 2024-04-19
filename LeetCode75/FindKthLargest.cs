using System;

namespace LeetCode;

public partial class LeetCode75
{


    public static int FindKthLargest(int[] nums, int k)
    {

        return QuickSort(nums, 0, nums.Length - 1, nums.Length - k);
    }

    private static int QuickSort(int[] nums, int start, int end,int k)
    {
        if (start >= end) return nums[k];
        var t = nums[start];
        var left = start;
        var right = end;
        while (left < right)
        {
            while (left < right && nums[right] >= t) right--;
            while (left < right && nums[left] <= t) left++;
            if (left >= right) break;
            (nums[left], nums[right]) = (nums[right], nums[left]);
        }

        (nums[left], nums[start]) = (nums[start], nums[left]);
        if (k <= right)
        {
           return QuickSort(nums, start, left,k);
        }
        else
        {
            return QuickSort(nums, right + 1, end,k);
        }
    }


// static void Main()
//     {
//         int[] nums = new[] { -1,2,0};
//         Console.Write(FindKthLargest(nums, 2));
//          for (var i = 0; i < nums.Length; i++)
//          {
//              Console.Write($"nums[i]{nums[i]} ");
//          }
//     }
 }