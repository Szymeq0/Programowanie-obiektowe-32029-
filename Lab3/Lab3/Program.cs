//4. Klasa i obiekty

using System.Reflection.Metadata;

var osoba1 = new Osoba("Konrad");
var osoba2 = new Osoba("Kuba", )
var osoba3 = new Osoba("Jacek")
var osoba4 = new Osoba("Iwona")
class Osoba
{
    private string imie;
    private int wiek;
    public Osoba(string imie, int wiek)
    {
       this.imie = imie;
       this.wiek = wiek;
    }

    public void PrzedstawSie()
    {
        Console.WriteLine($"Nazywam się {imie} i mam {wiek}");
    }

}