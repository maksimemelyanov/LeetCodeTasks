using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace LeetCodeTestApp;
// 162
public class FindPeakElementTask
{
    public int FindPeakElement(int[] nums) {
        // for (var i = 0; i < nums.Length; i++)
        //     if ((i == 0 || nums[i-1] < nums[i]) && (i == nums.Length - 1 || nums[i] > nums[i+1]))
        //         return i;
        // return 0;

        return FindPeak(nums, 0, nums.Length - 1);
    }

    private int FindPeak(int[] nums, int left, int right)
    {
        if (left == right)
            return left;
        var middle = left + (right - left) / 2;
        if (nums[middle] > nums[middle + 1])
            return FindPeak(nums, left, middle);
        return FindPeak(nums, middle + 1, right);
    }
}

public class FindPeakElementTask_Tests
{
    [TestCase(new[] {1, 2, 3, 1}, 2 )]
    [TestCase(new[] {1,2,1,3,5,6,4}, 5 )]
    [TestCase(new[] {1, 2}, 1)]
    public void Test(int[] nums, int expected)
    {
        var actual = new FindPeakElementTask().FindPeakElement(nums);
        Assert.That(expected, Is.EqualTo(actual));
    }
}