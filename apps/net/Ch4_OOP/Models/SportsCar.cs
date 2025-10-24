﻿using System;

namespace Ch4_OOP.Models;

public class SportsCar : Car
{
    public SportsCar(string modeName, string engineType, int cylinders, float basePrice) :
        base(modeName, engineType, cylinders, basePrice)
    {
    }

    public override void Refuel()
    {
        Console.WriteLine($"SportsCar: The {ModelName} only wants the best gas.");
    }

    public override void Drive()
    {
        Console.WriteLine($"SportsCar: The {ModelName} tears along the highway!");
    }
}
