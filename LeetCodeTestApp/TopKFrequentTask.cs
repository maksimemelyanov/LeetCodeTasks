using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class TopKFrequentTask
{
    // 347
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequencies = new Dictionary<int, int>();
        foreach (var i in nums)
        {
            frequencies.TryAdd(i, 0);
            frequencies[i]++;
        }

        var sortedFrequencies = frequencies.OrderByDescending(x => x.Value).ToList();
        var result = new int[k];
        for (var i = 0; i < k; i++)
        {
            result[i] = sortedFrequencies[i].Key;
        }

        return result;
    }
}

[TestFixture]
public class TopKFrequent_Tests
{
    [Test]
    [TestCase(new [] {1,1,1,2,2,3}, 2, new[] {1,2})]
    [TestCase(new [] {1}, 1, new[] {1})]
    [TestCase(new [] {1,2,1,2,1,2,3,1,3,2}, 2, new[] {1,2})]
    public void Test(int[] nums, int k, int[] expected)
    {
        var result = new TopKFrequentTask().TopKFrequent(nums, k);
        Array.Sort(result);
        Array.Sort(expected);
        ClassicAssert.AreEqual(k, result.Length);
        for (var i = 0; i < k; i++)
        {
            ClassicAssert.AreEqual(expected[i], result[i]);
        }
    }
}