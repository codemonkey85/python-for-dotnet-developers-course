using System;

namespace Ch3_Lang;

internal class ShapeOfCode
{
    public static void Run()
    {
        Console.Write("What is your name? ");
        var name = Console.ReadLine();
        SomeMethod(name);
    }

    private static void SomeMethod(string name)
    {
        if (name.ToLower().Trim() == "michael")
        {
            Console.WriteLine("Hello old friend");
        }
        else
        {
            Console.WriteLine($"Nice to meet you {name}.");
            Console.WriteLine("My name is C#!");
        }
    }
}
