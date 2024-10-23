using System;
using System.IO;
using System.Text.Json.Serialization;

public interface IEngine
{
    void StartEngine();
    void StopEngine();
}

public class PetrolEngine : IEngine
{
    public void StartEngine()
    {
        Console.WriteLine("Starting Petrol Engine...");
    }

    public void StopEngine()
    {
        Console.WriteLine("Stopping Petrol Engine...");
    }
}

public class ElectricEngine : IEngine
{
    public void StartEngine()
    {
        Console.WriteLine("Starting Electric Engine...");
    }

    public void StopEngine()
    {
        Console.WriteLine("Stopping Electric Engine...");
    }
}

public abstract class Vehicle
{
    protected IEngine engine;

    protected Vehicle(IEngine engine)
    {
        this.engine = engine;
    }

    public abstract void Drive();
    public abstract void Stop();
}

public class Car : Vehicle
{
    public Car(IEngine engine) : base(engine) { }

    public override void Drive()
    {
        Console.WriteLine("Car is driving...");
        engine.StartEngine();
    }

    public override void Stop()
    {
        Console.WriteLine("Car is stopping...");
        engine.StopEngine();
    }
}

public class Bike : Vehicle
{
    public Bike(IEngine engine) : base(engine) { }

    public override void Drive()
    {
        Console.WriteLine("Bike is driving...");
        engine.StartEngine();
    }

    public override void Stop()
    {
        Console.WriteLine("Bike is stopping...");
        engine.StopEngine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle PetrolCar = new Car(new PetrolEngine());
        PetrolCar.Drive();
        PetrolCar.Stop();

        Vehicle ectricleCar = new Car(new ElectricEngine());
        ectricleCar.Drive();
        ectricleCar.Stop();

        Vehicle electricBike = new Bike(new ElectricEngine());
        electricBike.Drive();
        electricBike.Stop();
        
    }
}
