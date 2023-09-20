using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public class StockSpanner
{
    Stack<Tuple<int, int>> stack;
    int idx;

    public StockSpanner()
    {
        stack = new Stack<Tuple<int, int>>();
        stack.Push(new Tuple<int, int>(-1, int.MaxValue));
        idx = -1;
    }

    public int Next(int price)
    {
        return 0;
    }
}
/**  * Your StockSpanner object will be instantiated and called as such:
  * StockSpanner obj = new StockSpanner();  * int param_1 = obj.Next(price);
   * */