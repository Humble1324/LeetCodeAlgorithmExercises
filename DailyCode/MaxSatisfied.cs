using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        int lens = grumpy.Length;
        if (minutes > lens)
        {
            int temp = 0;
            for (var i = 0; i < lens; i++)
            {
                if (grumpy[i] == 1)
                {
                    temp += customers[i];
                }
            }

            return temp;
            
        }

        int total = 0;
        for (var i = 0; i < lens; i++)
        {
            if (grumpy[i] == 1)
            {
                total += customers[i];
            }
        }
        
        int increase = 0;
        for (int i = 0; i < minutes; i++)
        {
            increase += customers[i]*grumpy[i];;
        }

        int Max = increase;
        for (int i = minutes; i < lens; i++)
        {
            increase = increase - customers[i - minutes] * grumpy[i - minutes] + customers[i] * grumpy[i];
            Max = Math.Max(Max, increase);
        }

        return Max + total;
    }
}