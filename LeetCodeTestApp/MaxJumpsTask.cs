using NUnit.Framework;

namespace LeetCodeTestApp;

public class MaxJumpsTask
{
    public int MaxJumps(int[] arr, int d)
    {
        var n = arr.Length;
        var dp = new int[n];
        Array.Fill(dp, 1);
        
        var indexes = Enumerable.Range(0, n).ToArray();
        
        Array.Sort(indexes, (a, b) => arr[a].CompareTo(arr[b]));

        foreach (var i in indexes)
        {
            
            for (var s = 1; s <= d; s++)
            {
                var j = i - s;
                if (j < 0)
                    break;
                if (arr[j] >= arr[i])
                    break;
                dp[i] = Math.Max(dp[i], 1 + dp[j]);
            }
            
            for (var s = 1; s <= d; s++)
            {
                var j = i + s;
                if (j >= n)
                    break;
                if (arr[j] >= arr[i])
                    break;
                dp[i] = Math.Max(dp[i], 1 + dp[j]);
            }

        }

        return dp.Max();

        // var result = 0;
        //
        // for (var i = 0; i < n; i++)
        // {
        //     result = Math.Max(result, DFS(arr, i, d, dp));
        // }
        //
        // return result;
    }

    private int DFS(int[] arr, int i, int d, int[] dp)
    {
        if (dp[i] != 0)
            return dp[i];

        var steps = 1;

        for (var k = 1; k <= d; k++)
        {
            var next = i + k;
            if (next >= arr.Length)
                break;
            if (arr[next] >= arr[i])
                break;
            steps = Math.Max(steps, 1 + DFS(arr, next, d, dp));
        }
        
        for (var k = 1; k <= d; k++)
        {
            var next = i - k;
            if (next < 0)
                break;
            if (arr[next] >= arr[i])
                break;
            steps = Math.Max(steps, 1 + DFS(arr, next, d, dp));
        }

        dp[i] = steps;
        return steps;
    }
}

public class MaxJumpTask_Tests
{
    [Test]
    [TestCase(new[] {6,4,14,6,8,13,9,7,10,6,12}, 2, 4)]
    [TestCase(new[] {3,3,3,3,3}, 3, 1)]
    [TestCase(new[] {7,6,5,4,3,2,1}, 1, 7)]
    public void Test(int[] arr, int d, int expected)
    {
        var actual = new MaxJumpsTask().MaxJumps(arr, d);
        Assert.That(actual, Is.EqualTo(expected));
    }
}