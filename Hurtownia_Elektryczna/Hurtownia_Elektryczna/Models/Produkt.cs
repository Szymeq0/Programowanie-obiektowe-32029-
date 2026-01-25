using System.Text.Json.Serialization;

namespace Hurtownia_Elektryczna.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Przewod), "przewod")]
    [JsonDerivedType(typeof(Osprzet), "osprzet")]
    public abstract class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = "";
        public string Producent { get; set; } = "";
        public decimal Cena { get; set; }

        public abstract string Opis();
    }
}