namespace Hurtownia_Elektryczna.Models
{
    public class PozycjaZamowienia
    {
        public int ProduktId { get; set; }
        public string NazwaProduktu { get; set; } = string.Empty;

        public decimal CenaJednostkowa { get; set; }

        // ILOŚĆ SZTUK LUB METRY
        public int Ilosc { get; set; }

        public decimal Wartosc
        {
            get { return Ilosc * CenaJednostkowa; }
        }

        public string Opis()
        {
            return $"{NazwaProduktu} | {Ilosc} x {CenaJednostkowa:F2} zł = {Wartosc:F2} zł";
        }
    }
}