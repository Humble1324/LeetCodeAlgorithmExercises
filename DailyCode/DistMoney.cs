using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int DistMoney(int money, int children)
    {
        
        // 所有的钱都必须被分配。
        // 每个儿童至少获得 1 美元。=>至少钱≥人数
        // 没有人获得 4 美元。
        // 请你按照上述规则分配金钱，并返回 最多 有多少个儿童获得 恰好 8 美元。如果没有任何分配方案，返回 -1 。
        if (children > money) return -1;
        if (children == 1 && money == 4) return -1;
        money -= children;
        int cnt = Math.Min(money/7,children);
        money -= cnt * 7;
        children -= cnt;
        if (children == 0 && money > 0 || children == 1 && money == 3) cnt--;
        
        return cnt;
    }
}