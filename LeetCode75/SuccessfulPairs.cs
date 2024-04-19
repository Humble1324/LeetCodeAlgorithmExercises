using System;
using System.Collections.Generic;
using LeetCode.Tools;

namespace LeetCode;

public partial class LeetCode75
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        int n = spells.Length, m = potions.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            long t = (success + spells[i] - 1) / spells[i] - 1;
            res[i] = m - BinarySearch(potions, 0, m - 1, t);
        }
        return res;
    }

    public int BinarySearch(int[] arr, int lo, int hi, long target) {
        int res = hi + 1;
        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (arr[mid] > target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }


    // public static void Main()
    // {
    //     int[] spells = new[] { 39, 34, 6, 35, 18, 24, 40 };
    //     int[] potions = new[] { 27, 37, 33, 34, 14, 7, 23, 12, 22, 37 };
    //     int success = 43;
    //     Console.Write(SuccessfulPairs(spells, potions, success));
    // }
}