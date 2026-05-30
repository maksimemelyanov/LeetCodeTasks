using NUnit.Framework;

namespace LeetCodeTestApp;

public class ThreeSumTask
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (var i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1])
                        left++;
                    while (left < right && nums[right] == nums[right - 1])
                        right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                    left++;
                else
                    right--;
            }
        }

        return result;
    }
}

public class ThreeSumTask_Tests
{
    [Test]
    [TestCase(new[] {-1,0,1,2,-1,-4}, 2)]
    [TestCase(new[] {0,1,1}, 0)]
    [TestCase(new[] {0,0, 0}, 1)]
    public void Test(int[] nums, int expected)
    {
        var actual = new ThreeSumTask().ThreeSum(nums);
        Assert.That(actual.Count, Is.EqualTo(expected));
    }
}