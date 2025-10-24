namespace Ch3_Lang;

internal class Iteration
{
    public static void Run()
    {
        Console.WriteLine("C# Iteration Demo");
        // while
        while (true)
        {
            Console.Write("What is your name? ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.WriteLine($"Nice to meet you {name}!");
        }

        // foreach
        int[] nums = [1, 5, 8, 10, 7, 2];
        foreach (var n in nums)
        {
            Console.WriteLine($"The next number is {n}.");
        }

        // for
        for (var idx = 0; idx < nums.Length; idx++)
        {
            var n = nums[idx];
            Console.WriteLine($"The {idx + 1}th number is {n}.");
        }
    }
}
