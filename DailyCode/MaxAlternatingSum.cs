using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public long MaxAlternatingSum(int[] nums)
    {
        long even = nums[0], odd = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            even = Math.Max(even, odd + nums[i]);
            odd=Math.Max(odd, even - nums[i]);
        }
        return even;
    }    public long MaxAlternatingSumII(int[] nums)
    {

            int lens = nums.Length;
            int[] prices = new int[lens+1];
            for (int i = 0; i < lens; i++)
            {
                prices[i + 1] = nums[i];
            }
            long maxProfit = 0;
            for(int i = 1; i < prices.Length; ++i){
                maxProfit += Math.Max(prices[i] - prices[i-1], 0);      
            }
            return maxProfit;

            
    }
}