namespace Hurtownia_Elektryczna.Models
{
    public class Osprzet : Produkt
    {
        public int Ilosc { get; set; }

        public override string Opis()
        {
            return $"[OSPRZĘT] {Nazwa}, {Producent}, {Cena} zł, ilość: {Ilosc}";
        }
    }
}