namespace Hurtownia_Elektryczna.Models
{
    public class Przewod : Produkt
    {
        public int DlugoscWMetrtach { get; set; }

        public override string Opis()
        {
            return $"[PRZEWÓD] {Nazwa}, {Producent}, {Cena} zł/m, długość: {DlugoscWMetrtach} m";
        }
    }
}