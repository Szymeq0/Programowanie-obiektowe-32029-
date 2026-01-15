namespace KomisSamochodowy.Models;

public class Car : Vehicle
{
    public string Model { get; private set; }
    public int Year { get; private set; }

    public Car(int id, string engine, string model, int year)
        : base(id, engine)
    {
        Model = model;
        Year = year;
    }

    public void Update(string engine, string model, int year)
    {
        Engine = engine;
        Model = model;
        Year = year;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[CAR] Id: {Id}, Model: {Model}, Year: {Year}, Engine: {Engine}");
    }
}