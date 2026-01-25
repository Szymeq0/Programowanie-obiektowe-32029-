using Hurtownia_Elektryczna.Models;

namespace Hurtownia_Elektryczna.Services
{
    public class ZamowienieService
    {
        private readonly JsonService _json = new();
        private const string PATH = "Data/zamowienia.json";
        private List<Zamowienie> _zamowienia;

        public ZamowienieService()
        {
            _zamowienia = _json.Wczytaj<Zamowienie>(PATH);
        }

        public List<Zamowienie> Wszystkie() => _zamowienia;

        public void Dodaj(Zamowienie z)
        {
            z.Id = _zamowienia.Any() ? _zamowienia.Max(x => x.Id) + 1 : 1;
            _zamowienia.Add(z);
        }

        public void Zapisz() => _json.Zapisz(PATH, _zamowienia);
    }
}