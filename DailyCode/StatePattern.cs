using System;
using System.Reflection.Metadata;

namespace LeetCode.DailyCode;

public enum State
{
    Rain,
    Sunny,
    Thursday
}

interface IState
{
    public void Handle();
}

class RainState : IState
{
    public void Handle()
    {
        Console.WriteLine("下雨天要坐公交");
    }
}

class SunnyState : IState
{
    public void Handle()
    {
        Console.WriteLine("晴天骑车");
    }
}

class ThursdayState : IState
{
    public void Handle()
    {
        Console.WriteLine("疯狂星期四");
    }
}

class Worker
{
    private string _name;
    private IState _iState;

    public void OneDay()
    {
        Console.WriteLine(_name+"起床");
        _iState.Handle();
        Console.WriteLine("睡觉");
    }


    public Worker(string name,IState iState)
    {
        _name = name;
        _iState = iState;
    }
}

// public class StatePattern
// {
//     public static void Main()
//     {
//         Console.WriteLine();
//         Worker wk = new Worker("张三", new ThursdayState());
//         wk.OneDay();
//     }
// }