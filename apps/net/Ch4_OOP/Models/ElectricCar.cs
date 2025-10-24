using System;

namespace Ch4_OOP.Models;

public class ElectricCar(string modeName, float basePrice) : Car(modeName, "electric", 0, basePrice)
{
    public override void Refuel()
    {
        Console.WriteLine($"ElectricCar: The {ModelName} is charging up.");
    }

    public override void Drive()
    {
        Console.WriteLine($"ElectricCar: The electric {ModelName} zooms silently along!");
    }
}
