using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{

    public long TotalCost(int[] costs, int k, int candidates)
    {
        long ans = 0;
        
        return ans;
    }
    public class CustomComparer : IComparer<int>
    {
        private int[] costs;

        public CustomComparer(int[] costs)
        {
            this.costs = costs;
        }

        public int Compare(int e1, int e2)
        {
            if (costs[e1] != costs[e2])
            {
                return costs[e1] - costs[e2];
            }
            else
            {
                return e1 - e2;
            }
        }
    }
    public int GuessNumber(int n)
    {
        if (n == 1) return 1;
        int left = 1;
        int right = n;
        while (left<right)
        {
            int mid = left + (right - left) / 2; 
            if(guess(mid)<=0)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;

    }

    public int guess(int num)
    {
        return 0;
    }
}