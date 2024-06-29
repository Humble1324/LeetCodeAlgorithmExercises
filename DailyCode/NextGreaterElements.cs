using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int[] NextGreaterElements(int[] nums)
    {
        var n = nums.Length;
        var res = new int[n];
        var stack = new MonoStack();
        res.AsSpan().Fill(-1);
        for (int i = 0; i < n * 2 - 1; i++)
        {
            while (!stack.IsEmpty() && nums[stack.Peek()] < nums[i % n])
            {
                res[stack.Pop()] = nums[i % n];
            }

            stack.Push(i % n);
        }

        return res;
    }
}

public class MonoStack
{
    private Stack<int> stack = new Stack<int>();

    public void Push(int num)
    {
        while (stack.Count > 0 && stack.Peek() < num)
        {
            stack.Pop();
        }

        stack.Push(num);
    }

    public int Pop()
    {
        return stack.Pop();
    }

    public int Peek()
    {
        return stack.Peek();
    }

    public bool IsEmpty()
    {
        return stack.Count == 0;
    }
}