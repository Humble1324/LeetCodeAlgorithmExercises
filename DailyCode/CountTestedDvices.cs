namespace LeetCode.DailyCode;

public class CountTestedDvices
{
    public int CountTestedDevices(int[] batteryPercentages) {
        var lens = batteryPercentages.Length;
        var count = 0;
        for (var i = 0; i < lens; i++)
        { 
            if (batteryPercentages[i] > 0)
            {
                count++;
                for (var j = i + 1; j < lens; j++)
                {
                    if (batteryPercentages[j] > 1)
                    {
                        batteryPercentages[j]--;
                    }
                }
            }
        }

        return count;
    }
}