namespace Hurtownia_Elektryczna.Models
{
    public class Zamowienie
    {
        public int Id { get; set; }
        public Klient Klient { get; set; } = null!;
        public DateTime Data { get; set; } = DateTime.Now;
        public List<PozycjaZamowienia> Pozycje { get; set; } = new();

        public decimal Lacznawartosc =>
            Pozycje.Sum(p => p.Wartosc);
    }
}