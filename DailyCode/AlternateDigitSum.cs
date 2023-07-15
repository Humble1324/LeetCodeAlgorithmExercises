using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int AlternateDigitSum(int n)
    {
        Stack<int> AlterStack = new();
        while (n > 0)
        {
            AlterStack.Push(n%10);
            n /= 10;
        }

        int sum = 0;
        bool isPositive = true;
        while (AlterStack.Count > 0)
        {
            if (isPositive)
            {
                sum += AlterStack.Pop();
            }
            else
            {
                sum-=AlterStack.Pop();
            }
            
            isPositive = !isPositive;
            
        }
        return sum;
    }
}