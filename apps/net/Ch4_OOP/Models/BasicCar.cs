﻿using System;

namespace Ch4_OOP.Models;

public class BasicCar(string modeName, string engineType, int cylinders, float basePrice)
    : Car(modeName, engineType, cylinders, basePrice)
{
    public override void Refuel()
    {
        Console.WriteLine("BasicCar: Basic cars takes any old fuel.");
    }
}
