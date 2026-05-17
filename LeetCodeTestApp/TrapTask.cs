using NUnit.Framework;

namespace LeetCodeTestApp;

public class TrapTask
{
    public int Trap(int[] height)
    {
        if (height.Length < 3)
            return 0;
        var left = 0;
        var right = height.Length - 1;
        var leftMax = 0;
        var rightMax = 0;
        var water = 0;
        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    water += leftMax - height[left];
                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    water += rightMax - height[right];
                right--;
            }
        }
        return water;
    }
}

public class TrapTask_Tests
{
    [Test]
    [TestCase(new[] {0,1,0,2,1,0,1,3,2,1,2,1}, 6)]
    [TestCase(new[] {4,2,0,3,2,5}, 9)]
    public void Test(int[] heights, int expected)
    {
        var actual = new TrapTask().Trap(heights);
        Assert.That(actual, Is.EqualTo(expected));
    }
}