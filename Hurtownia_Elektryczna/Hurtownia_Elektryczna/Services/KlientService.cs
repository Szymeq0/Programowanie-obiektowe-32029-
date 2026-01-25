using Hurtownia_Elektryczna.Models;

namespace Hurtownia_Elektryczna.Services
{
    public class KlientService
    {
        private readonly JsonService _json = new();
        private const string PATH = "Data/klienci.json";

        private readonly List<Klient> _klienci;
        private int _nextId = 1;

        public KlientService()
        {
            _klienci = _json.Wczytaj<Klient>(PATH);

            if (_klienci.Any())
                _nextId = _klienci.Max(k => k.Id) + 1;
        }

        public List<Klient> Wszystkie() => _klienci;

        public void Dodaj(Klient klient)
        {
            klient.Id = _nextId++;
            _klienci.Add(klient);
        }

        public void Usun(int id)
        {
            var k = _klienci.FirstOrDefault(x => x.Id == id);
            if (k != null)
                _klienci.Remove(k);
        }

        public void Edytuj(int id, string imie, string nazwisko, string email, string? nip)
        {
            var k = _klienci.FirstOrDefault(x => x.Id == id);
            if (k == null) return;

            k.Imie = imie;
            k.Nazwisko = nazwisko;
            k.Email = email;
            k.Nip = nip;
        }

        public void Zapisz()
        {
            _json.Zapisz(PATH, _klienci);
        }
    }
}