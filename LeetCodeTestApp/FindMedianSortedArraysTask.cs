using NUnit.Framework;

namespace LeetCodeTestApp;

public class FindMedianSortedArraysTask
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);
 
        var m = nums1.Length;
        var n = nums2.Length;
        
        int left = 0, right = m;
        var totalLeft = (m + n + 1) / 2;

        while (left <= right)
        {
            var num1Part = (left + right) / 2;
            var num2Part = totalLeft - num1Part;
            
            var maxLeftPart1 = num1Part == 0 ? int.MinValue : nums1[num1Part-1];
            var minRightPart1 = num1Part == m ? int.MaxValue : nums1[num1Part];
            
            var maxLeftPart2 = num2Part == 0 ? int.MinValue : nums2[num2Part-1];
            var minRightPart2 = num2Part == n ? int.MaxValue : nums2[num2Part];

            if (maxLeftPart1 <= minRightPart2 && maxLeftPart2 <= minRightPart1)
            {
                if ((m + n) % 2 == 0)
                    return (Math.Max(maxLeftPart1, maxLeftPart2) + Math.Min(minRightPart1, minRightPart2)) / 2.0;
                return Math.Max(maxLeftPart1, maxLeftPart2);
            }
            if (maxLeftPart1 > minRightPart2)
                right = num1Part - 1;
            else
                left = num1Part + 1;
        }

        return 0;
    }
}

public class FindMedianSortedArraysTask_Tests
{
    [Test]
    [TestCase(new int[] { 1, 3 }, new int[] { 2 }, 2)]
    [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5)]
    [TestCase(new int[0], new int[] { 1 }, 1)]
    public void Test(int[] first, int[] second, double expected)
    {
        var actual = new FindMedianSortedArraysTask().FindMedianSortedArrays(first, second);
        Assert.That(actual, Is.EqualTo(expected));
    }
}