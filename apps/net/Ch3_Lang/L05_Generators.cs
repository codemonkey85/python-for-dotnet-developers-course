using System;
using System.Collections.Generic;

namespace Ch3_Lang;

internal class Generators
{
    public static void Run()
    {
        Console.WriteLine("Generators");

        foreach (var n in Fibonacci())
        {
            if (n > 1000)
            {
                break;
            }

            Console.Write(n);
            Console.Write(", ");
        }

        Console.WriteLine();
    }

    private static IEnumerable<int> Fibonacci()
    {
        var current = 0;
        var next = 1;

        while (true)
        {
            var temp = current;
            current = next;
            next = temp + next;

            yield return current;
        }
        // ReSharper disable once IteratorNeverReturns
    }

    public static IEnumerable<int> Fibonacci(int count)
    {
        var nums = new List<int>();
        var current = 0;
        var next = 1;

        for (var i = 0; i < count; i++)
        {
            var temp = current;
            current = next;
            next = temp + next;

            nums.Add(current);
        }

        return nums;
    }
}
