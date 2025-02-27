using System;

namespace LeetCode;

public class Probability
{
    public static void Prob()
    {
        int[] ints = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var lens = ints.Length;
        int count = 0;
        int counts = 0;
        for (var i = 0; i < lens; i++)
        {
            for (var j =0; j < lens ; j++)
            {
                for (var k =0; k < lens; k++)
                {
                    counts++;
                    if (Math.Abs(i-k) == 1 || Math.Abs(i-j) == 1 ||Math.Abs(j-k) == 1)
                    {
                        count++;
                    }
                }
            }
        }
        Console.WriteLine(count+"ss"+counts);
    }
    // public static void Main()
    // {
    //     Prob();
    // }
}