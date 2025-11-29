using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCodeTestApp;

// 1029
public class TwoCitySchedCostTask
{
    public int TwoCitySchedCost(int[][] costs)
    {
        var n = costs.Length / 2;
        var q = new List<Tuple<int, int, int>>();
        foreach (var c in costs)
        {
            var a = c[0];
            var b = c[1];
            q.Add(Tuple.Create(a, b, a-b));
        }

        var sortedQ = q.OrderBy(x => x.Item3).ToList();
        var sum = 0;
        for (var i = 0; i < n; i++)
        {
            sum += sortedQ[i].Item1;
        }
        for (var i = n; i < 2*n; i++)
        {
            sum += sortedQ[i].Item2;
        }

        return sum;
    }
}

[TestFixture]
public class TwoCitySchedCost_Tests
{
    [Test]
    public void Test1()
    {
        var input = new[] {new[] {10, 20}, new[] {30, 200}, new[] {400, 50}, new[] {30, 20}};
        var output = 110;
        var result = new TwoCitySchedCostTask().TwoCitySchedCost(input);
        ClassicAssert.AreEqual(output, result);
    }
    
    [Test]
    public void Test2()
    {
        var input = new[] {new[]{259,770},new[]{448,54},new[]{926,667},new[]{184,139},new[]{840,118},new[]{577,469}};
        var output = 1859;
        var result = new TwoCitySchedCostTask().TwoCitySchedCost(input);
        ClassicAssert.AreEqual(output, result);
    }
    
    [Test]
    public void Test3()
    {
        var input = new[] {new[] {515,563},new[] {451,713 },new[] {537,709},new[] {343,819},new[] {855,779},new[] {457,60},new[] {650,359},new[] {631,42}};
        var output = 3086;
        var result = new TwoCitySchedCostTask().TwoCitySchedCost(input);
        ClassicAssert.AreEqual(output, result);
    }
}