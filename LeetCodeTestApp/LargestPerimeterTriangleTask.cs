using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

// 976
public class LargestPerimeterTriangleTask
{
    public int LargestPerimeter(int[] nums) 
    {
        Array.Sort(nums);
        for (var i = nums.Length - 1; i >= 2; i--)
        {
            var a = nums[i];
            var b = nums[i - 1];
            var c = nums[i - 2];
            if (b + c > a)
                return a + b + c;
        }
        return 0;
    }
}


[TestFixture]
public class LargestPerimeterTriangleTask_Tests
{
    [Test]
    [TestCase(new int[] {2, 1, 2}, 5)]
    [TestCase(new int[] {1, 2, 1, 10}, 0)]
    public void Test(int[] nums, int expected)
    {
        var result = new LargestPerimeterTriangleTask().LargestPerimeter(nums);
        ClassicAssert.AreEqual(expected, result);
    }
}