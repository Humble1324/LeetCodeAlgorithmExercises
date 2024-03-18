using System.Collections;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public class MyQueue
{ 
    Stack<int> inStack;
    Stack<int> outStack;

    public MyQueue()
    {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }

    public void Push(int x)
    {
        inStack.Push(x);
    }

    public int Pop()
    {
        if (outStack.Count <= 0)
        {
            In2Out();
        }

        return outStack.Pop();
    }

    public int Peek()
    {  if (outStack.Count <= 0)
        {
            In2Out();
        }
        return outStack.Peek();
    }

    public bool Empty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }

    public void In2Out()
    {
        while(inStack.Count>0)
        {
            outStack.Push(inStack.Pop());
        }
    }
}