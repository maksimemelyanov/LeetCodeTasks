using NUnit.Framework;

namespace LeetCodeTestApp;

public class JumpGame3Task
{
    public bool CanReach_BFS(int[] arr, int start) 
    {
        var len = arr.Length;
        var visited =  new bool[len];
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            if (arr[curr] == 0)
                return true;
            var left = curr - arr[curr];
            var right = curr + arr[curr];
            if (left >= 0 && !visited[left])
            {
                visited[left] = true;
                queue.Enqueue(left);
            }

            if (right < len && !visited[right])
            {
                visited[right] = true;
                queue.Enqueue(right);
            }
        }
        
        return false;
    }

    public bool CanReach(int[] arr, int start)
    {
        var visited = new bool[arr.Length];
        return DFS(arr, start, visited);
    }
    
    private bool DFS(int[] arr, int index, bool[] visited)
    {
        if (index < 0 || index >= arr.Length || visited[index]) 
            return false;
        
        if (arr[index] == 0)
            return true;
        
        visited[index] = true;
        
        return DFS(arr, index + arr[index], visited) || DFS(arr, index - arr[index], visited);
    }
}

public class JumpGame3Task_Tests
{
    [Test]
    [TestCase(new[] {4,2,3,0,3,1,2}, 5, true)]
    [TestCase(new[] {4,2,3,0,3,1,2}, 0, true)]
    [TestCase(new[] {3,0,2,1,2}, 2, false)]
    [TestCase(new[] {0,1}, 1, true)]
    public void Test(int[] arr, int start, bool expected)
    {
        var actual = new JumpGame3Task().CanReach(arr, start);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
