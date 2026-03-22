using NUnit.Framework;

namespace LeetCodeTestApp;

public class MaxNumberOfBalloonsTask
{
    public int MaxNumberOfBalloons(string text)
    {
        var a = 0;
        var b = 0;
        var l = 0;
        var n = 0;
        var o = 0;

        foreach (var s in text)
        {
            switch (s)
            {
                case 'a': 
                    a++;
                    break;
                case 'b':
                    b++;
                    break;
                case 'l':
                    l++;
                    break;
                case 'n':
                    n++;
                    break;
                case 'o':
                    o++;
                    break;
            }
        }

        return Math.Min(a, Math.Min(b, Math.Min(l / 2, Math.Min(n, o / 2))));

        // var frequencies = new Dictionary<char, int>();
        // foreach (var s in text)
        // {
        //     frequencies.TryAdd(s, 0);
        //     frequencies[s]++;
        // }
        //
        // return Math.Min(frequencies.GetValueOrDefault('b', 0),
        //     Math.Min(frequencies.GetValueOrDefault('a', 0),
        //         Math.Min(frequencies.GetValueOrDefault('n', 0), 
        //             Math.Min(frequencies.GetValueOrDefault('l', 0) / 2, 
        //                 frequencies.GetValueOrDefault('o', 0) / 2))));
    }
}

public class MaxNumberOfBalloonsTask_Tests
{
    [TestCase("nlaebolko", 1)]
    [TestCase("loonbalxballpoon", 2)]
    [TestCase("cewzqp", 0)]
    public void Test(string input, int expected)
    {
        var actual = new MaxNumberOfBalloonsTask().MaxNumberOfBalloons(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}