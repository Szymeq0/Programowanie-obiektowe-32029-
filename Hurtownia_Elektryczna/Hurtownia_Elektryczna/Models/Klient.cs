namespace Hurtownia_Elektryczna.Models
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; } = "";
        public string Nazwisko { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Nip { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Imie} {Nazwisko}, {Email}, NIP: {Nip ?? "brak"}";
        }
    }
}