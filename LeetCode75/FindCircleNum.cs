namespace LeetCode;

public partial class LeetCode75
{
    

    public int FindCircleNum(int[][] isConnected)
    {    
        int lens = isConnected.Length;
        bool[] visited = new bool[lens];
        int count = 0;
        for (int i = 0; i < lens; i++)
        {
            if (!visited[i])
            {
                CityDfs(isConnected, visited, lens, i);
                count++;
            }
        }

        return count;
    }

    public void CityDfs(int[][] citys, bool[] visited, int cityLens, int i)
    {
        for (var t = 0; t < cityLens; t++)
        {
            if (citys[i][t] == 1 && !visited[t])
            {
                visited[t] = true;
                CityDfs(citys, visited, cityLens, t);
            }
        }
        //循环找直到没有城市可以访问
    }
}