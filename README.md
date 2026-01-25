Programowanie obiektowe – C#

Temat: Aplikacja konsolowa – Hurtownia Elektryczna

1. Cel i zakres projektu

Celem projektu było zaprojektowanie oraz implementacja aplikacji konsolowej w języku C#, służącej do zarządzania hurtownią elektryczną.
Aplikacja umożliwia kompleksową obsługę produktów, klientów oraz zamówień, a także zapewnia trwały zapis danych w plikach JSON, co pozwala na zachowanie stanu aplikacji pomiędzy kolejnymi uruchomieniami.

Projekt rozwiązuje problem ręcznego i nieuporządkowanego zarządzania danymi poprzez zastosowanie zasad programowania obiektowego oraz wyraźnego podziału odpowiedzialności pomiędzy warstwy aplikacji.

2. Instrukcje warunkowe

Lokalizacja: `Menu/MenuManager.cs`

Instrukcje warunkowe zostały wykorzystane do sterowania logiką aplikacji oraz obsługi interakcji z użytkownikiem.
Główne menu programu jest realizowane za pomocą instrukcji `switch`, która na podstawie wyboru użytkownika uruchamia odpowiednie funkcjonalności aplikacji.
```csharp
public void Start()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== HURTOWNIA ELEKTRYCZNA ===");
        Console.WriteLine("1. Produkty");
        Console.WriteLine("2. Klienci");
        Console.WriteLine("3. Zamówienia");
        Console.WriteLine("4. Zapisz zmiany");
        Console.WriteLine("0. Wyjdź");

        switch (Console.ReadLine())
        {
            case "1": MenuProdukty(); break;
            case "2": MenuKlienci(); break;
            case "3": MenuZamowienia(); break;
            case "4": Zapisz(); break;
            case "0": return;
        }
    }
}
```
3. Pętle

Lokalizacja: `Menu/MenuManager.cs`

Pętle zostały użyte do zapewnienia ciągłego działania aplikacji oraz przetwarzania kolekcji danych.
Pętla `while` odpowiada za stałe wyświetlanie menu, natomiast pętla `foreach` umożliwia iterowanie po listach produktów, klientów i zamówień.
```csharp
while (true)
{
    Console.Clear();
    Console.WriteLine("=== PRODUKTY ===");
    Console.WriteLine("1. Wyświetl produkty");
    Console.WriteLine("2. Dodaj produkt");
    Console.WriteLine("0. Powrót");

    switch (Console.ReadLine())
    {
        case "1": WyswietlProdukty(); break;
        case "2": DodajProdukt(); break;
        case "0": return;
    }
}
```
```csharp
foreach (var produkt in _produktService.Wszystkie())
{
    Console.WriteLine(produkt.Opis());
}
```
4. Kolekcje generyczne (List<T>)

Lokalizacja: `Models/Zamowienie.cs`

W projekcie wykorzystano kolekcje generyczne `List<T>`, które umożliwiają przechowywanie dynamicznej liczby obiektów jednego typu.
Kolekcje te służą m.in. do przechowywania pozycji zamówień oraz umożliwiają wykonywanie operacji agregujących, takich jak obliczanie łącznej wartości zamówienia.
```csharp
public class Zamowienie
{
    public int Id { get; set; }
    public Klient Klient { get; set; } = null!;
    public DateTime DataUtworzenia { get; set; } = DateTime.Now;
    public List<PozycjaZamowienia> Pozycje { get; set; } = new();

    public decimal Lacznawartosc =>
        Pozycje.Sum(p => p.Wartosc);
}
```
5. Dziedziczenie

Lokalizacja: `Models/Produkt.cs`

Zastosowano dziedziczenie poprzez klasę abstrakcyjną `Produkt`, która definiuje wspólne cechy wszystkich produktów dostępnych w hurtowni.
Klasy pochodne `Przewod` oraz `Osprzet` rozszerzają klasę bazową o dodatkowe właściwości charakterystyczne dla danego typu produktu.
```csharp
public abstract class Produkt
{
    public int Id { get; set; }
    public string Nazwa { get; set; } = "";
    public string Producent { get; set; } = "";
    public decimal Cena { get; set; }

    public abstract string Opis();
}
```
```cshrap
public class Przewod : Produkt
{
    public int DlugoscWMetrtach { get; set; }

    public override string Opis()
    {
        return $"[PRZEWÓD] {Nazwa}, {Producent}, {Cena} zł/m, {DlugoscWMetrtach} m";
    }
}
```
```csharp
public class Osprzet : Produkt
{
    public int Ilosc { get; set; }

    public override string Opis()
    {
        return $"[OSPRZĘT] {Nazwa}, {Producent}, {Cena} zł/szt, ilość: {Ilosc}";
    }
}
```
6. Polimorfizm

Lokalizacja: `Menu/MenuManager.cs`

Polimorfizm został zrealizowany poprzez nadpisanie metody `Opis()` w klasach dziedziczących po klasie `Produkt`.
Dzięki temu możliwe jest wywoływanie tej samej metody dla różnych typów obiektów, przy zachowaniu ich specyficznego zachowania.
```csharp
private void WyswietlProdukty()
{
    Console.Clear();

    foreach (var produkt in _produktService.Wszystkie())
    {
        Console.WriteLine(produkt.Opis());
    }

    Console.ReadKey();
}
```
7. Hermetyzacja

Lokalizacja: `Models/Klient.cs`

Hermetyzacja została zapewniona poprzez zamknięcie danych klienta w klasie oraz udostępnienie ich wyłącznie za pomocą właściwości.
Takie podejście chroni dane przed niekontrolowanym dostępem i ułatwia dalszą rozbudowę aplikacji.
```csharp
public class Klient
{
    public int Id { get; set; }
    public string Imie { get; set; } = "";
    public string Nazwisko { get; set; } = "";
    public string Email { get; set; } = "";
    public string? Nip { get; set; }
}
```
8. Logika biznesowa w serwisach

Lokalizacja: `Services/ProduktService.cs`

Logika biznesowa została oddzielona od warstwy interfejsu użytkownika i umieszczona w dedykowanych klasach serwisowych.
Takie rozwiązanie zwiększa czytelność kodu, ułatwia testowanie oraz wspiera zasadę pojedynczej odpowiedzialności.
```csharp
public void Dodaj(Produkt produkt)
{
    produkt.Id = _nextId++;
    _produkty.Add(produkt);
}
```
```csharp
public void AktualizujStan(int id, int nowyStan)
{
    var p = _produkty.FirstOrDefault(x => x.Id == id);
    if (p is Przewod przewod)
        przewod.DlugoscWMetrtach = nowyStan;
    else if (p is Osprzet osprzet)
        osprzet.Ilosc = nowyStan;
}
```
9. Zapis i odczyt danych (JSON)

Lokalizacja: `Services/JsonService.cs`

Aplikacja umożliwia trwały zapis oraz odczyt danych do plików JSON przy użyciu biblioteki `System.Text.Json`.
Dane klientów, produktów oraz zamówień są zapisywane w osobnych plikach, co zapewnia ich trwałość pomiędzy kolejnymi uruchomieniami programu.
```csharp
public List<T> Wczytaj<T>(string path)
{
    if (!File.Exists(path))
        return new List<T>();

    var json = File.ReadAllText(path);
    return JsonSerializer.Deserialize<List<T>>(json, _options)
           ?? new List<T>();
}

public void Zapisz<T>(string path, List<T> dane)
{
    var folder = Path.GetDirectoryName(path);
    if (!Directory.Exists(folder))
        Directory.CreateDirectory(folder);

    File.WriteAllText(path,
        JsonSerializer.Serialize(dane, _options));
}
```
10. Obliczenia wartości zamówień

Lokalizacja: `Models/PozycjaZamowienia.cs`

System automatycznie oblicza wartość każdej pozycji zamówienia na podstawie ilości oraz ceny jednostkowej produktu.
Dodatkowo łączna wartość zamówienia jest obliczana dynamicznie na podstawie sumy wartości wszystkich pozycji.
```csharp
public class PozycjaZamowienia
{
    public int ProduktId { get; set; }
    public string NazwaProduktu { get; set; } = "";
    public decimal CenaJednostkowa { get; set; }
    public int Ilosc { get; set; }

    public decimal Wartosc
    {
        get { return Ilosc * CenaJednostkowa; }
    }
}
```
11. Podsumowanie końcowe

Zrealizowany projekt spełnia wszystkie wymagania zaliczeniowe przedmiotu programowanie obiektowe.
Aplikacja wykorzystuje instrukcje warunkowe, pętle, kolekcje generyczne, pełne zasady programowania obiektowego (dziedziczenie, polimorfizm, hermetyzację) oraz trwały zapis i odczyt danych w formacie JSON.

Projekt działa poprawnie, jest czytelny strukturalnie oraz gotowy do dalszej rozbudowy.
