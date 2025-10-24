using System;

namespace Ch4_OOP.Models;

public abstract class Car(string modelName, string engineType, int cylinders, float basePrice)
{
    public string ModelName { get; } = modelName;
    private string EngineType { get; } = engineType;
    public int Cylinders { get; } = cylinders;
    public float BasePrice { get; } = basePrice;

    public bool IsElectric => EngineType == "electric";

    public virtual void Drive()
    {
        Console.WriteLine($"Car: The {ModelName} goes vroom!");
    }

    public abstract void Refuel();
}
