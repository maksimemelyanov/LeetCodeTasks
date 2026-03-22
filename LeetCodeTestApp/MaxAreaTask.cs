using NUnit.Framework;

namespace LeetCodeTestApp;

public class MaxAreaTask
{
    public int MaxArea(int[] height)
    {
        var max = 0;
        var left = 0;
        var rigth = height.Length - 1;
        while (left < rigth)
        {
            var h = Math.Min(height[left], height[rigth]);
            var w = rigth - left;
            max = Math.Max(max, h * w);
            if (height[left] < height[rigth])
                left++;
            else
                rigth--;
        }
        return max;
    }
}

public class MaxAreaTask_Tests
{
    [TestCase(new[] {1,8,6,2,5,4,8,3,7}, 49)]
    public void Test(int[] height, int expected)
    {
        var actual = new MaxAreaTask().MaxArea(height);
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Test_WithBigCount()
    {
        var s = File.ReadAllText("../../../Files/11.txt");
        var height = s.Split(",").Select(int.Parse).ToArray();
        var expected = 705634720;
        var actual = new MaxAreaTask().MaxArea(height);
        Assert.That(expected, Is.EqualTo(actual));
    }
}
