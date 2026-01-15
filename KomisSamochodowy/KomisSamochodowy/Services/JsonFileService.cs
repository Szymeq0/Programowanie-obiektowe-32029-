using System.Text.Json;
using KomisSamochodowy.Models;

namespace KomisSamochodowy.Services;

public static class JsonFileService
{
    private const string FileName = "vehicles.json";

    public static void Save(List<Vehicle> vehicles)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(vehicles, options);
        File.WriteAllText(FileName, json);
    }

    public static List<Vehicle> Load()
    {
        if (!File.Exists(FileName))
            return new List<Vehicle>();

        var json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
    }
}