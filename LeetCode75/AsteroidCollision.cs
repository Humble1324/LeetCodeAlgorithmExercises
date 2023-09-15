using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();
        var lens = asteroids.Length;
        stack.Push(asteroids[0]);
        for (var i = 1; i < lens; i++)
            if (stack.Count > 0)
            {
                if ((asteroids[i] > 0 && stack.Peek() > 0) || (asteroids[i] < 0 && stack.Peek() < 0))
                    stack.Push(asteroids[i]);
                else if (Math.Abs(asteroids[i]) > Math.Abs(stack.Peek()))
                    while (Math.Abs(asteroids[i]) > Math.Abs(stack.Peek()) || stack.Count > 0)
                        stack.Pop();
            }

        var count = stack.Count;
        var ans = new int[count];
        for (var i = count - 1; i >= 0; i--) ans[i] = stack.Pop();
        return ans;
    }
}