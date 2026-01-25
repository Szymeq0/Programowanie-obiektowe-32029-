using Hurtownia_Elektryczna.Models;

namespace Hurtownia_Elektryczna.Services
{
    public class ProduktService
    {
        private readonly JsonService _json = new();
        private const string PATH = "Data/produkty.json";

        private readonly List<Produkt> _produkty;
        private int _nextId = 1;

        public ProduktService()
        {
            _produkty = _json.Wczytaj<Produkt>(PATH);

            if (_produkty.Any())
                _nextId = _produkty.Max(p => p.Id) + 1;
        }

        public List<Produkt> Wszystkie() => _produkty;

        public void Dodaj(Produkt produkt)
        {
            produkt.Id = _nextId++;
            _produkty.Add(produkt);
        }

        public void Usun(int id)
        {
            var p = _produkty.FirstOrDefault(x => x.Id == id);
            if (p != null)
                _produkty.Remove(p);
        }

        public void AktualizujStan(int id, int nowyStan)
        {
            var p = _produkty.FirstOrDefault(x => x.Id == id);
            if (p == null) return;

            if (p is Przewod przewod)
                przewod.DlugoscWMetrtach = nowyStan;
            else if (p is Osprzet osprzet)
                osprzet.Ilosc = nowyStan;
        }

        public void Zapisz()
        {
            _json.Zapisz(PATH, _produkty);
        }
    }
}