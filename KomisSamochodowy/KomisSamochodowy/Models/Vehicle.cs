using System.Text.Json.Serialization;

namespace KomisSamochodowy.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Car), "car")]
[JsonDerivedType(typeof(Bike), "bike")]
public abstract class Vehicle
{
    public int Id { get; protected set; }
    public string Engine { get; protected set; }

    protected Vehicle(int id, string engine)
    {
        Id = id;
        Engine = engine;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started");
    }

    public abstract void ShowInfo();
}