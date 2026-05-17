using NUnit.Framework;

namespace LeetCodeTestApp;

public class FurthestDistanceFromOriginTask
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        var l = 0;
        var r = 0;
        var g = moves.Length;
        for (var i = 0; i < g; i++)
        {
            if (moves[i] == 'L') l++;
            else if (moves[i] == 'R') r++;
        }
        g -= (l + r);
        if (r >= l)
            return r - l + g;
        return l - r + g;
    }
}

public class FurthestDistanceFromOriginTask_Tests
{
    [Test]
    [TestCase("L_RL__R", 3)]
    [TestCase("_R__LL_", 5)]
    [TestCase("_______", 7)]
    public void Test(string input, int expected)
    {
        var actual = new FurthestDistanceFromOriginTask().FurthestDistanceFromOrigin(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}