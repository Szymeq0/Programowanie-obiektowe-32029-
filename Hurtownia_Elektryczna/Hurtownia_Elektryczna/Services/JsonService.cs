using System.Text.Json;

namespace Hurtownia_Elektryczna.Services
{
    public class JsonService
    {
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        public List<T> Wczytaj<T>(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
        }

        public void Zapisz<T>(string path, List<T> dane)
        {
            var folder = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var json = JsonSerializer.Serialize(dane, _options);
            File.WriteAllText(path, json);
        }
    }
}