using NUnit.Framework;

namespace LeetCodeTestApp;

public class LemonadeChangeTask
{
    public bool LemonadeChange(int[] bills)
    {
        var doll5 = 0;
        var doll10 = 0;
        var doll20 = 0;

        foreach (var bill in bills)
        {
            switch (bill)
            {
                case 5:
                    doll5++;
                    break;
                case 10:
                    doll10++;
                    break;
                default:
                    doll20++;
                    break;
            }

            var change = bill - 5;
            while (change > 0)
            {
                if (change >= 10 && doll10 > 0)
                {
                    change -= 10;
                    doll10--;
                }
                else if (change >= 5 && doll5 > 0)
                {
                    change -= 5;
                    doll5--;
                }
                else return false;
            }
        }
        return true;
    }
}

public class LemonadeChangeTask_Tests
{
    [Test]
    [TestCase(new[] {5,5,5,10,20}, true)]
    [TestCase(new[] {5,5,10,10,20}, false)]
    public void Test(int[] bills, bool expected)
    {
        var actual = new LemonadeChangeTask().LemonadeChange(bills);
        Assert.That(actual, Is.EqualTo(expected));
    }
}