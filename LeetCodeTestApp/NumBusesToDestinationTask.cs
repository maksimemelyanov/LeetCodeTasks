using NUnit.Framework;

namespace LeetCodeTestApp;

public class NumBusesToDestinationTask
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        if (source == target)
            return 0;
        var adjustments = new Dictionary<int, List<int>>();
        for (var route = 0; route < routes.Length; route++)
        {
            foreach (var stop in routes[route])
            {
                if (!adjustments.ContainsKey(stop))
                    adjustments[stop] = new List<int>();
                adjustments[stop].Add(route);
            }
        }

        var queue = new Queue<(int stop, int buses)>();
        var visitedBuses = new HashSet<int>();
        var visitedStops = new HashSet<int>();
        
        queue.Enqueue((source, 0));
        while (queue.Count > 0)
        {
            var (currentStop, buses) = queue.Dequeue();
            if (!adjustments.TryGetValue(currentStop, out var adjustment))
                continue;
            foreach (var bus in adjustment)
            {
                if (!visitedBuses.Add(bus))
                    continue;
                foreach (var next in routes[bus])
                {
                    if (next == target)
                        return buses + 1;
                    if (visitedStops.Contains(next)) continue;
                    queue.Enqueue((next, buses + 1));
                    visitedStops.Add(next);
                }
            }
        }
        return -1;
    }
}

public class NumBusesToDestinationTask_Tests
{
    [Test]
    public void Test1()
    {
        var routes = new int[][] { [1, 2, 7], [3, 6, 7] };
        var source = 1;
        var target = 6;
        var expected = 2;
        var actual = new NumBusesToDestinationTask().NumBusesToDestination(routes, source, target);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Test2()
    {
        var routes = new int[][] { [7,12],[4,5,15],[6],[15,19],[9,12,13] };
        var source = 15;
        var target = 12;
        var expected = -1;
        var actual = new NumBusesToDestinationTask().NumBusesToDestination(routes, source, target);
        Assert.That(actual, Is.EqualTo(expected));
    }
}