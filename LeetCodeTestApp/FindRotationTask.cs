using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

public class FindRotationTask
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        if (AreEqual(mat, target))
            return true;
        var mat90 = Rotate(mat);
        if (AreEqual(mat90, target))
            return true;
        var mat180 = Rotate(mat90);
        if (AreEqual(mat180, target))
            return true;
        var mat270 = Rotate(mat180);
        if (AreEqual(mat270, target))
            return true;
        return false;
    }

    private int[][] Rotate(int[][] source)
    {
        var n = source.Length;
        var result = new int[n][];
        for (var i = 0; i < n; i++)
        {
            result[i] = new int[n];
        }
        for (var x = 0; x < n; x++)
        for (var y = 0; y < n; y++)
            result[x][n-1-y] = source[y][x];
        return result;
    }

    private bool AreEqual(int[][] mat1, int[][] mat2)
    {
        var n = mat1.Length;
        for (var x = 0; x < n; x++)
        for (var y = 0; y < n; y++)
            if (mat1[x][y] != mat2[x][y])
                return false;
        return true;
    }
}

public class FindRotationTask_Tests
{
    [Test]
    public void Test1()
    {
        var mat = new[] { new[] { 0, 1 }, new[] { 1, 0 } };
        var target = new[] { new[] { 1, 0 }, new[] { 0, 1 } };
        var result = new FindRotationTask().FindRotation(mat, target);
        ClassicAssert.True(result);
    }
    
    [Test]
    public void Test2()
    {
        var mat = new[] { new[] { 0, 1 }, new[] { 1, 1 } };
        var target = new[] { new[] { 1, 0 }, new[] { 0, 1 } };
        var result = new FindRotationTask().FindRotation(mat, target);
        ClassicAssert.False(result);
    }
    
    [Test]
    public void Test3()
    {
        var mat = new[] { new[] { 0, 0, 0 }, new[] { 0, 1, 0 }, new[] {1, 1, 1} };
        var target = new[] { new[] { 1, 1, 1 }, new[] { 0, 1, 0 }, new[] {0, 0, 0} };
        var result = new FindRotationTask().FindRotation(mat, target);
        ClassicAssert.True(result);
    }
}