using NUnit.Framework;

namespace LeetCodeTestApp;

public class DistributeCandiesTask
{
    public int[] DistributeCandies(int candies, int num_people)
    {
        var result = new int[num_people];
        var n = candies;
        var r = 0;
        while (n > 0)
        {
            for (var i = 0; i < num_people; i++)
            {
                var count = Math.Min(r * num_people + i + 1, n);
                n -= count;
                result[i] += count;
            }
            r++;
        }

        return result;
    }
}

public class DistributeCandiesTask_Tests
{
    [TestCase(7, 4, new[] {1,2,3,1})]
    [TestCase(10, 3, new[] {5, 2, 3})]
    public void Test(int candies, int people, int[] expected)
    {
        var actual = new DistributeCandiesTask().DistributeCandies(candies, people);
        Assert.That(actual.Length, Is.EqualTo(expected.Length));
        for (var i = 0; i < actual.Length; i++)
        {
            Assert.That(actual[i], Is.EqualTo(expected[i]));
        }
    }
}