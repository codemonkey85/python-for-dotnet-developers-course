﻿using System;

namespace Ch3_Lang;

internal class Wizard
{
    public string Name { get; set; }
    public int Level { get; set; }

    public static Wizard Train(int baseLevel)
    {
        var w = new Wizard();
        w.Level = baseLevel;

        return w;
    }
}

internal class Typing
{
    public static void Run()
    {
        var gandolf = Wizard.Train(7);
        gandolf.Level++;

        Console.WriteLine($"The level of the wizard is {gandolf.Level}");
    }
}
