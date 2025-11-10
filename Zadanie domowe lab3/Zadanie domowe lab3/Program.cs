using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("- Weryfikacja dostępu do sklepu i zakupu karty SIM -");
        int wiek = 14;
        Console.WriteLine($"Sprawdzany wiek: {wiek} lat.\n");

        if (wiek >= 18)
        {
            Console.WriteLine("Dostęp do sklepu: akcpetacja");
            Console.WriteLine("Zakupy/rejestracja karty SIM: akceptacja");
        }
        else if (wiek >= 14)
        {
            Console.WriteLine("Dostęp do sklepu: akcpetacja");
            Console.WriteLine("Zakupy/rejestracja karty SIM: odrzucenie (Wymagany wiek 18 lat");
        }
        else
        {
            Console.WriteLine("Dostęp do sklepu: odrzucenie (Wymagany wiek 18 lat)");
            Console.WriteLine("Zakupy/rejestracja karty SIM: odrzucenie (Wymagany wiek 18 lat)");
        }
    }
}