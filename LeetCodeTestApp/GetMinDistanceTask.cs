using NUnit.Framework;

namespace LeetCodeTestApp;

public class GetMinDistanceTask
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        var left = start;
        var right = start;
        var count = nums.Length;
        while (left >= 0 || right < count)
        {
            if (left >= 0 && nums[left] == target)
                return start - left;

            if (right < count && nums[right] == target)
                return right - start;

            left--;
            right++;
        }

        return 0;
    }
}

public class GetMinDistanceTask_Tests
{
    [Test]
    [TestCase(new[] {1,2,3,4,5}, 5, 3 , 1)]
    [TestCase(new[] {1}, 1, 0 , 0)]
    [TestCase(new[] {1,1,1,1,1,1,1,1,1,1}, 1, 0 , 0)]
    public void Test(int[] nums, int target, int start, int expected)
    {
        var actual = new GetMinDistanceTask().GetMinDistance(nums, target, start);
        Assert.That(actual, Is.EqualTo(expected));
    }
}