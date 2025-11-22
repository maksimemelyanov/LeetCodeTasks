using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

// 463
public class IslandPerimeterTask
{
    public int IslandPerimeter(int[][] grid)
    {
        var height = grid.Length;
        var width = grid[0].Length;
        var result = 0;
        for(var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            if (grid[y][x] == 1)
            {
                result += 4;
                if (y > 0 && grid[y - 1][x] == 1)
                    result -= 1;
                if (y < height-1 && grid[y + 1][x] == 1)
                    result -= 1;
                if (x > 0 && grid[y][x-1] == 1)
                    result -= 1;
                if (x < width - 1 && grid[y][x+1] == 1)
                    result -= 1;
            }
        }

        return result;
    }
}

[TestFixture]
public class IslandPerimeterTask_Tests
{
    [Test]
    public void Test1()
    {
        var map = new[] { new[] { 0, 1, 0, 0 }, new[] { 1, 1, 1, 0 }, new[] { 0, 1, 0, 0 }, new[] { 1, 1, 0, 0 } };
        var result = new IslandPerimeterTask().IslandPerimeter(map);
        ClassicAssert.AreEqual(16, result);
    }
    
    [Test]
    public void Test2()
    {
        var map = new[] { new[] { 1 }};
        var result = new IslandPerimeterTask().IslandPerimeter(map);
        ClassicAssert.AreEqual(4, result);
    }
    
    [Test]
    public void Test3()
    {
        var map = new[] { new[] { 1, 0 }};
        var result = new IslandPerimeterTask().IslandPerimeter(map);
        ClassicAssert.AreEqual(4, result);
    }
}