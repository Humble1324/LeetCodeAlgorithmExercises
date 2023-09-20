namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int PassThePillow(int n, int time)
    {
        //从头开始，time次

        time %= (n - 1) / 2;
        return time < n ? time + 1 : n * 2 - 1 - time;

    }
}