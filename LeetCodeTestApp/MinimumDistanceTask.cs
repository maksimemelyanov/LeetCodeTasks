using NUnit.Framework;

namespace LeetCodeTestApp;

public class MinimumDistanceTask // {1, 1, 2, 3, 2, 1, 2, 1}
{
    public int MinimumDistance(int[] nums) 
    {
        var positions = new Dictionary<int, Queue<int>>();
        var minDist = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (!positions.ContainsKey(nums[i]))
                positions.Add(nums[i], new Queue<int>());
            positions[nums[i]].Enqueue(i);
            if (positions[nums[i]].Count >= 3)
            {
                if (positions[nums[i]].Count > 3)
                    positions[nums[i]].Dequeue();
                var left = positions[nums[i]].Peek();
                var distance = 2 * (i - left);
                minDist = Math.Min(minDist, distance);
            }
        }
        return minDist != int.MaxValue ? minDist : -1;
    }
}

public class MinimumDistanceTask_Tests
{
    [Test]
    [TestCase(new[] {1, 2, 1, 1 ,3}, 6)]
    [TestCase(new[] {1, 1, 2, 3, 2, 1, 2}, 8)]
    [TestCase(new[] {1}, -1)]
    public void Test(int[] input, int expected)
    {
        var actual = new MinimumDistanceTask().MinimumDistance(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}