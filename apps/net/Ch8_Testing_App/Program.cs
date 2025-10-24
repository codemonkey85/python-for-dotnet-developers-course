using System;
using Ch8_Testing;

namespace Ch8_Testing_App;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the guitar app!");
        var lib = new Lib();
        while (true)
        {
            Console.Write("What style of guitar do you want to see? ");
            var style = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(style))
            {
                Console.WriteLine("Bye!");
                break;
            }

            var guitars = lib.AllGuitars(style);

            Console.WriteLine($"We found {guitars.Length} guitars of type {style}");
            var idx = 0;
            foreach (var g in guitars)
            {
                idx++;
                Console.WriteLine($"{idx}. {g.Name} for ${g.Price} ({g.Style})");
            }
        }
    }
}
