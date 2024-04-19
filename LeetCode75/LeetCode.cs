using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public string MergeAlternately(string word1, string word2)
    {
        if (word1.Length == 0 && word2.Length != 0)
            return word2;
        if (word1.Length != 0 && word2.Length == 0)
            return word1;
        if (word1.Length == 0 && word2.Length == 0)
            return "";

        var temp1 = 0;
        var temp2 = 0;
        var word = "";
        while (word1.Length >= temp1 + 1 && word2.Length >= temp2 + 1)
        {
            word += word1[temp1++];
            word += word2[temp2++];
        }

        if (word1.Length > temp1) word += word1.Substring(temp1);

        if (word2.Length > temp2) word += word2.Substring(temp1);

        return word;
    }

    public string GcdOfStrings(string str1, string str2)
    {
        if (!(str1 + str2).Equals(str2 + str1))
            return "";
        return str1.Substring(0, gcd(str1.Length, str2.Length));
    }

    public int gcd(int a, int b)
    {
        var remainder = a % b;
        while (remainder != 0)
        {
            a = b;
            b = remainder;
            remainder = a % b;
        }

        return b;
    }

    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var max = 0;
        IList<bool> kidsWithCandies = new List<bool>();
        foreach (var candy in candies)
            if (candy > max)
                max = candy;

        for (var i = 0; i < candies.Length; i++)
            if (candies[i] + extraCandies >= max)
                kidsWithCandies.Add(true);
            else
                kidsWithCandies.Add(false);

        return kidsWithCandies;
    }

    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (flowerbed.Length < 2) return flowerbed[0] == n;
        if (flowerbed.Length <= 2)
            if (flowerbed[0] == 0 && flowerbed[1] == 0)
                return n == 1;
        var count = 0;
        if (flowerbed[flowerbed.Length - 2] == 0 && flowerbed[flowerbed.Length - 1] == 0)
        {
            flowerbed[flowerbed.Length - 1] = 1;
            count++;
        }

        for (var i = 0; i + 1 < flowerbed.Length; i++)
            if (i == 0)
            {
                if (flowerbed[i + 1] == 0 && flowerbed[i] == 0)
                {
                    flowerbed[i] = 1;
                    count++;
                }
            }
            else
            {
                if (flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0 && flowerbed[i] == 0)
                {
                    flowerbed[i] = 1;
                    count++;
                }
            }

        return count == n;
    }



    // public static void Main(string[] args)
    // {
    //     int[] candies = new int[] { 1,0,0,0,1,0,0 };
    //     Console.WriteLine("Test Log");
    //     var leet = new LeetCode75();
    //     Console.WriteLine(leet.CanPlaceFlowers(candies, 3));
    // }
}