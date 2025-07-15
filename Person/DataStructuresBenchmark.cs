using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class DataStructuresBenchmark
{
    private const int NumberOfElements = 100000; // Number of elements to use for benchmarking

    public static void RunBenchmarks()
    {
        Console.WriteLine($"Benchmarking common C# Data Structures with {NumberOfElements} elements.\n");

        BenchmarkList();
        BenchmarkDictionary();
        BenchmarkHashSet();
        BenchmarkQueue();
        BenchmarkStack();
        BenchmarkLinkedList();
        BenchmarkSortedList();
        BenchmarkSortedDictionary();
        BenchmarkSortedSet();
    }

    private static void BenchmarkList()
    {
        Console.WriteLine("--- Benchmarking List<T> ---");
        var list = new List<int>();
        var stopwatch = new Stopwatch();

        // Add elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            list.Add(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Add {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Access elements by index
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            var item = list[i];
        }
        stopwatch.Stop();
        Console.WriteLine($"Access {NumberOfElements} elements by index: {stopwatch.ElapsedMilliseconds} ms");

        // Search for an element (middle)
        stopwatch.Restart();
        list.Contains(NumberOfElements / 2);
        stopwatch.Stop();
        Console.WriteLine($"Search for middle element: {stopwatch.ElapsedMilliseconds} ms");

        // Remove elements (from end)
        stopwatch.Restart();
        for (int i = NumberOfElements - 1; i >= 0; i--)
        {
            list.RemoveAt(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Remove {NumberOfElements} elements (from end): {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkDictionary()
    {
        Console.WriteLine("--- Benchmarking Dictionary<TKey, TValue> ---");
        var dictionary = new Dictionary<int, string>();
        var stopwatch = new Stopwatch();

        // Add elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            dictionary.Add(i, $"Value{i}");
        }
        stopwatch.Stop();
        Console.WriteLine($"Add {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Access elements by key
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            var item = dictionary[i];
        }
        stopwatch.Stop();
        Console.WriteLine($"Access {NumberOfElements} elements by key: {stopwatch.ElapsedMilliseconds} ms");

        // Search for a key
        stopwatch.Restart();
        dictionary.ContainsKey(NumberOfElements / 2);
        stopwatch.Stop();
        Console.WriteLine($"Search for middle key: {stopwatch.ElapsedMilliseconds} ms");

        // Remove elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            dictionary.Remove(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Remove {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkHashSet()
    {
        Console.WriteLine("--- Benchmarking HashSet<T> ---");
        var hashSet = new HashSet<int>();
        var stopwatch = new Stopwatch();

        // Add elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            hashSet.Add(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Add {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Check for existence
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            hashSet.Contains(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Check existence of {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Remove elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            hashSet.Remove(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Remove {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkQueue()
    {
        Console.WriteLine("--- Benchmarking Queue<T> ---");
        var queue = new Queue<int>();
        var stopwatch = new Stopwatch();

        // Enqueue elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            queue.Enqueue(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Enqueue {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Dequeue elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            queue.Dequeue();
        }
        stopwatch.Stop();
        Console.WriteLine($"Dequeue {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkStack()
    {
        Console.WriteLine("--- Benchmarking Stack<T> ---");
        var stack = new Stack<int>();
        var stopwatch = new Stopwatch();

        // Push elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            stack.Push(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Push {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Pop elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            stack.Pop();
        }
        stopwatch.Stop();
        Console.WriteLine($"Pop {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkLinkedList()
    {
        Console.WriteLine("--- Benchmarking LinkedList<T> ---");
        var linkedList = new LinkedList<int>();
        var stopwatch = new Stopwatch();

        // AddLast elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            linkedList.AddLast(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"AddLast {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Find element (middle)
        stopwatch.Restart();
        linkedList.Find(NumberOfElements / 2);
        stopwatch.Stop();
        Console.WriteLine($"Find middle element: {stopwatch.ElapsedMilliseconds} ms");

        // RemoveFirst elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            linkedList.RemoveFirst();
        }
        stopwatch.Stop();
        Console.WriteLine($"RemoveFirst {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkSortedList()
    {
        Console.WriteLine("--- Benchmarking SortedList<TKey, TValue> ---");
        var sortedList = new SortedList<int, string>();
        var stopwatch = new Stopwatch();

        // Add elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedList.Add(i, $"Value{i}");
        }
        stopwatch.Stop();
        Console.WriteLine($"Add {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Access elements by key
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            var item = sortedList[i];
        }
        stopwatch.Stop();
        Console.WriteLine($"Access {NumberOfElements} elements by key: {stopwatch.ElapsedMilliseconds} ms");

        // Remove elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedList.Remove(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Remove {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkSortedDictionary()
    {
        Console.WriteLine("--- Benchmarking SortedDictionary<TKey, TValue> ---");
        var sortedDictionary = new SortedDictionary<int, string>();
        var stopwatch = new Stopwatch();

        // Add elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedDictionary.Add(i, $"Value{i}");
        }
        stopwatch.Stop();
        Console.WriteLine($"Add {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Access elements by key
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            var item = sortedDictionary[i];
        }
        stopwatch.Stop();
        Console.WriteLine($"Access {NumberOfElements} elements by key: {stopwatch.ElapsedMilliseconds} ms");

        // Remove elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedDictionary.Remove(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Remove {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private static void BenchmarkSortedSet()
    {
        Console.WriteLine("--- Benchmarking SortedSet<T> ---");
        var sortedSet = new SortedSet<int>();
        var stopwatch = new Stopwatch();

        // Add elements
        stopwatch.Start();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedSet.Add(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Add {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Check for existence
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedSet.Contains(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Check existence of {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms");

        // Remove elements
        stopwatch.Restart();
        for (int i = 0; i < NumberOfElements; i++)
        {
            sortedSet.Remove(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Remove {NumberOfElements} elements: {stopwatch.ElapsedMilliseconds} ms\n");
    }
}