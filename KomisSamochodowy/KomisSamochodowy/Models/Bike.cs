namespace KomisSamochodowy.Models;

public class Bike : Vehicle
{
    public string BikeType { get; private set; }

    public Bike(int id, string engine, string bikeType)
        : base(id, engine)
    {
        BikeType = bikeType;
    }

    public void Update(string engine, string bikeType)
    {
        Engine = engine;
        BikeType = bikeType;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[BIKE] Id: {Id}, Type: {BikeType}, Engine: {Engine}");
    }
}