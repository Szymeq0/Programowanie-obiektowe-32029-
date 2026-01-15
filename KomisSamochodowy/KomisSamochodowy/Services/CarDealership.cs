using KomisSamochodowy.Models;

namespace KomisSamochodowy.Services;

public class CarDealership
{
    private readonly List<Vehicle> _vehicles = new();

    
    public bool ExistsId(int id)
    {
        return _vehicles.Any(v => v.Id == id);
    }

    
    public bool AddVehicle(Vehicle vehicle)
    {
        if (ExistsId(vehicle.Id))
            return false;

        _vehicles.Add(vehicle);
        return true;
    }

    
    public bool RemoveVehicle(int id)
    {
        return _vehicles.RemoveAll(v => v.Id == id) > 0;
    }

    
    public bool UpdateVehicle(int id)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
            return false;

        Console.Write("Nowy silnik: ");
        string engine = Console.ReadLine();

        if (vehicle is Car car)
        {
            Console.Write("Nowy model: ");
            string model = Console.ReadLine();

            Console.Write("Nowy rok: ");
            int year = int.Parse(Console.ReadLine());

            car.Update(engine, model, year);
        }
        else if (vehicle is Bike bike)
        {
            Console.Write("Nowy typ motocykla: ");
            string type = Console.ReadLine();

            bike.Update(engine, type);
        }

        return true;
    }

    
    public void ShowVehicles()
    {
        if (_vehicles.Count == 0)
        {
            Console.WriteLine("Brak pojazdów w komisie.");
            return;
        }

        foreach (var v in _vehicles)
            v.ShowInfo();
    }

    public List<Vehicle> GetAll() => _vehicles;
}