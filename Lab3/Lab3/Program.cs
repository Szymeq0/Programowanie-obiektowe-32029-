//4. Klasa i obiekty

using System.Reflection.Metadata;

// public class Osoba
// {
//     private string Imie;
//     private int Wiek;
//     public Osoba(string imie, int wiek)
//     {
//         this.Imie = imie;
//         this.Wiek = wiek;
//     }
//
//     public void PrzedstawSie()
//     {
//         Console.WriteLine($"Nazywam się {Imie} i mam {Wiek} lat.");
//     }
// }
//
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Zadanie 4: ");
//
//         var osoba1 = new Osoba("Konrad", 18);
//         var osoba2 = new Osoba("Kuba", 27);
//         var osoba3 = new Osoba("Iwona", 35);
//         var osoba4 = new Osoba("Jacek", 45);
//         
//         Console.WriteLine("\nWywołanie metody PrzedstawSie() dla każdego obiektu: ");
//
//         osoba1.PrzedstawSie();
//         osoba2.PrzedstawSie();
//         osoba3.PrzedstawSie();
//         osoba4.PrzedstawSie();
//     }
// }


//5. Trzy filary programowania obiektowego

// public class KontoBankowe
// {
//     private double saldo = 0.0;
//
//     public void Wpłata(double kwota)
//     {
//         if (kwota > 0)
//         {
//             saldo += kwota;
//             Console.WriteLine($"Wpłacono: {kwota} zł. Nowe saldo: {saldo} zł.");
//         }
//     }
//     public double PobierzSaldo()
//     {
//         return saldo;
//     }
//
//     public bool Wypłata(double kwota)
//     {
//         if (kwota > 0 && kwota <= saldo)
//         {
//             saldo -= kwota;
//             Console.WriteLine($"Wypłacono: {kwota} zł. Nowe saldo: {saldo} zł.");
//             return true;
//         }
//         else
//         {
//             Console.WriteLine($"Błąd: Nie można wypłacić {kwota} zł.");
//             Console.WriteLine($"Dostępne saldo: {saldo} zł.");
//             return false;
//         }
//     }
// }
//
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Zadanie 5: Symulacja konta bnakowego");
//         KontoBankowe mojeKonto = new KontoBankowe();
//         
//         mojeKonto.Wpłata(600.00);
//         mojeKonto.Wpłata(350.00);
//         mojeKonto.Wypłata(500.00);
//         mojeKonto.Wpłata(150.00);
//         mojeKonto.Wypłata(300.00);
//         mojeKonto.Wypłata(400.00);
//         
//         Console.WriteLine($"\nKońcowe saldo konta: {mojeKonto.PobierzSaldo()} zł.");
//     }
// }

//6. Dziedziczenie
public class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierzę je.");
}

public class Pies : Zwierze
{
    public void Szczekaj() => Console.WriteLine("Hau hau!");
}

public class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("Miau!");
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Zadnie 6 - Dziedziczenie");
        
        Pies azor =  new Pies();
        Console.Write("Azor (Pies): ");
        azor.Szczekaj();
        Console.Write("Azor (Pies): ");
        azor.Jedz();
        
        Kot filemon = new Kot();
        Console.Write("\nFilemon (Kot): ");
        filemon.Miaucz();
        Console.WriteLine("Filemon (Kot): ");
        filemon.Jedz();
    }
}
