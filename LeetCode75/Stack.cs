using System.Collections.Generic;

namespace LeetCode;

public class Stack
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        //右往左
        int lens = temperatures.Length;
        int[] ans = new int[lens];
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < lens; i++) {
            int temperature = temperatures[i];
            while (stack.Count > 0 && temperature > temperatures[stack.Peek()])//当新的温度比栈顶的温度高
            {
                var pre = stack.Pop();//小于当前温度的出栈
                ans[pre] = i - pre;//序号差值就是时长

            }
            stack.Push(i);//空栈或者当前温度比所有温度都低和
        }

        return ans;
    }
    
}

public class MonotoneStack
{

}