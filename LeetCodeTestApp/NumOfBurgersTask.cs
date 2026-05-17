using NUnit.Framework;

namespace LeetCodeTestApp;

public class NumOfBurgersTask
{
    public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
    {
        if (tomatoSlices % 2 != 0 || tomatoSlices < 2 * cheeseSlices || tomatoSlices > 4 * cheeseSlices)
            return new List<int>();
        var jumbo = tomatoSlices / 2 - cheeseSlices;
        var small = cheeseSlices - jumbo;
        return new List<int>() {jumbo, small};
    }
}

public class NumOfBurgersTask_Tests
{
    [Test]
    [TestCase(16, 7, new[] {1, 6})]
    [TestCase(17, 4, new int[0])]
    [TestCase(4, 17, new int[0])]
    public void Test(int tomatoSlices, int cheeseSlices, int[] expected)
    {
        var actual = new NumOfBurgersTask().NumOfBurgers(tomatoSlices, cheeseSlices).ToArray();
        Assert.That(actual, Is.EqualTo(expected));
    }
}