using Hurtownia_Elektryczna.Models;
using Hurtownia_Elektryczna.Services;

namespace Hurtownia_Elektryczna.Menu
{
    public class MenuManager
    {
        private readonly ProduktService _produktService = new();
        private readonly KlientService _klientService = new();
        private readonly ZamowienieService _zamowienieService = new();

        //MENU GŁÓWNE (startowe)

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

        //MENU PRODUKTY

        private void MenuProdukty()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PRODUKTY ===");
                Console.WriteLine("1. Wyświetl produkty");
                Console.WriteLine("2. Dodaj produkt");
                Console.WriteLine("3. Usuń produkt");
                Console.WriteLine("4. Edytuj stan produktu");
                Console.WriteLine("0. Powrót");

                switch (Console.ReadLine())
                {
                    case "1":
                        WypiszProdukty();
                        Console.ReadKey();
                        break;
                    case "2":
                        DodajProdukt();
                        break;
                    case "3":
                        UsunProdukt();
                        break;
                    case "4":
                        EdytujStanProduktu();
                        break;
                    case "0":
                        return;
                }
            }
        }

        private void WypiszProdukty()
        {
            Console.Clear();
            Console.WriteLine("=== SPIS PRODUKTÓW ===");
            var produkty = _produktService.Wszystkie();

            if (!produkty.Any())
            {
                Console.WriteLine("Brak produktów.");
                return;
            }

            foreach (var p in produkty)
                Console.WriteLine($"{p.Id}: {p.Opis()}");
        }

        private void DodajProdukt()
        {
            Console.Clear();

            Console.WriteLine("=== DODAJ PRODUKT ===");
            Console.WriteLine("1. Przewód");
            Console.WriteLine("2. Osprzęt");
            Console.Write("Wybierz typ produktu: ");
            var typ = Console.ReadLine();

            Console.Write("Nazwa: ");
            var nazwa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nazwa)) return;

            Console.Write("Producent: ");
            var producent = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(producent)) return;

            Console.Write("Cena: ");
            if (!decimal.TryParse(Console.ReadLine(), out var cena)) return;

            if (typ == "1")
            {
                Console.Write("Długość w metrach: ");
                if (!int.TryParse(Console.ReadLine(), out var metry)) return;

                _produktService.Dodaj(new Przewod
                {
                    Nazwa = nazwa,
                    Producent = producent,
                    Cena = cena,
                    DlugoscWMetrtach = metry
                });

                Console.WriteLine("\nPrzewód został dodany.");
            }
            else if (typ == "2")
            {
                Console.Write("Ilość sztuk: ");
                if (!int.TryParse(Console.ReadLine(), out var ilosc)) return;

                _produktService.Dodaj(new Osprzet
                {
                    Nazwa = nazwa,
                    Producent = producent,
                    Cena = cena,
                    Ilosc = ilosc
                });

                Console.WriteLine("\nOsprzęt został dodany.");
            }
            else
            {
                Console.WriteLine("\nNieprawidłowy wybór.");
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić...");
            Console.ReadKey();
        }



        private void UsunProdukt()
        {
            WypiszProdukty();
            Console.Write("\nPodaj ID produktu: ");
            if (int.TryParse(Console.ReadLine(), out var id))
                _produktService.Usun(id);
        }

        private void EdytujStanProduktu()
        {
            WypiszProdukty();
            Console.WriteLine("\n=== EDYTUJ STAN PRODUKTU ===");
            Console.Write("\nPodaj ID produktu: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            Console.Write("Nowy stan (metry lub sztuki): ");
            if (!int.TryParse(Console.ReadLine(), out var nowyStan)) return;

            _produktService.AktualizujStan(id, nowyStan);
        }

        //MENU KLIENCI

        private void MenuKlienci()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== KLIENCI ===");
                Console.WriteLine("1. Wyświetl klientów");
                Console.WriteLine("2. Dodaj klienta");
                Console.WriteLine("3. Usuń klienta");
                Console.WriteLine("4. Edytuj klienta");
                Console.WriteLine("0. Powrót");

                switch (Console.ReadLine())
                {
                    case "1":
                        WypiszKlientow();
                        Console.ReadKey();
                        break;
                    case "2":
                        DodajKlienta();
                        break;
                    case "3":
                        UsunKlienta();
                        break;
                    case "4":
                        EdytujKlienta();
                        break;
                    case "0":
                        return;
                }
            }
        }

        private void WypiszKlientow()
        {
            Console.Clear();
            Console.WriteLine("=== SPIS KLIENTÓW ===");
            var klienci = _klientService.Wszystkie();

            if (!klienci.Any())
            {
                Console.WriteLine("Brak klientów.");
                return;
            }

            foreach (var k in klienci)
                Console.WriteLine(k);
        }

        private void DodajKlienta()
        {
            Console.Clear();
            Console.WriteLine("=== DODAJ KLIENTA ===");
            string imie = PobierzWymaganePole("Imię");
            string nazwisko = PobierzWymaganePole("Nazwisko");
            string email = PobierzWymaganePole("Email");

            Console.Write("NIP (opcjonalnie): ");
            var nip = Console.ReadLine();

            _klientService.Dodaj(new Klient
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Email = email,
                Nip = string.IsNullOrWhiteSpace(nip) ? null : nip
            });
        }

        private void EdytujKlienta()
        {
            WypiszKlientow();
            Console.Write("\nPodaj ID klienta: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            Console.Clear();
            Console.WriteLine("=== EDYCJA KLIENTA ===");

            string imie = PobierzWymaganePole("Nowe imię");
            string nazwisko = PobierzWymaganePole("Nowe nazwisko");
            string email = PobierzWymaganePole("Nowy email");

            Console.Write("Nowy NIP (opcjonalnie): ");
            var nip = Console.ReadLine();

            _klientService.Edytuj(
                id,
                imie,
                nazwisko,
                email,
                string.IsNullOrWhiteSpace(nip) ? null : nip
            );
        }

        private void UsunKlienta()
        {
            WypiszKlientow();
            Console.WriteLine("\n=== USUWANIE KLIENTÓW ===");
            Console.Write("\nPodaj ID klienta: ");
            if (int.TryParse(Console.ReadLine(), out var id))
                _klientService.Usun(id);
        }

        //MENU ZAMÓWIENIA 

        private void MenuZamowienia()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ZAMÓWIENIA ===");
                Console.WriteLine("1. Wyświetl zamówienia");
                Console.WriteLine("2. Utwórz zamówienie");
                Console.WriteLine("0. Powrót");

                switch (Console.ReadLine())
                {
                    case "1":
                        WyswietlZamowienia();
                        Console.ReadKey();
                        break;
                    case "2":
                        UtworzZamowienie();
                        break;
                    case "0":
                        return;
                }
            }
        }

        private void WyswietlZamowienia()
        {
            Console.Clear();
        
            var zamowienia = _zamowienieService.Wszystkie();
        
            if (!zamowienia.Any())
            {
                Console.WriteLine("Brak zamówień.");
                Console.ReadKey();
                return;
            }
        
            foreach (var z in zamowienia)
            {
                Console.WriteLine($"ZAMÓWIENIE #{z.Id}");
                Console.WriteLine($"Klient: {z.Klient.Imie} {z.Klient.Nazwisko}");
                Console.WriteLine($"Data: {z.Data:dd.MM.yyyy HH:mm}");
                Console.WriteLine("Pozycje:");
        
                decimal suma = 0;
        
                foreach (var p in z.Pozycje)
                {
                    Console.WriteLine(" - " + p.Opis());
                    suma += p.Wartosc;
                }
        
                Console.WriteLine($"SUMA: {suma:F2} zł");
                Console.WriteLine(new string('-', 40));
            }
        
            Console.ReadKey();
        }


        private void UtworzZamowienie()
        {
            WypiszKlientow();
            Console.Write("\nID klienta: ");
            if (!int.TryParse(Console.ReadLine(), out var idKlienta)) return;

            var klient = _klientService.Wszystkie().FirstOrDefault(k => k.Id == idKlienta);
            if (klient == null) return;

            var zamowienie = new Zamowienie { Klient = klient };

            while (true)
            {
                WypiszProdukty();
                Console.Write("\nID produktu (0 = koniec): ");
                if (!int.TryParse(Console.ReadLine(), out var id) || id == 0) break;

                var produkt = _produktService.Wszystkie().FirstOrDefault(p => p.Id == id);
                if (produkt == null) continue;

                Console.Write("Ilość / metry: ");
                if (!int.TryParse(Console.ReadLine(), out var wartosc)) continue;

                if (produkt is Przewod przewod)
                {
                    if (przewod.DlugoscWMetrtach < wartosc) continue;
                    przewod.DlugoscWMetrtach -= wartosc;
                }
                else if (produkt is Osprzet osprzet)
                {
                    if (osprzet.Ilosc < wartosc) continue;
                    osprzet.Ilosc -= wartosc;
                }

                zamowienie.Pozycje.Add(new PozycjaZamowienia
                {
                    ProduktId = produkt.Id,
                    NazwaProduktu = produkt.Nazwa,
                    CenaJednostkowa = produkt.Cena,
                    Ilosc = wartosc
                });


            }

            _zamowienieService.Dodaj(zamowienie);
        }

        // POBIERANIE 

        private string PobierzWymaganePole(string nazwa)
        {
            while (true)
            {
                Console.Write($"{nazwa}: ");
                var wartosc = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(wartosc))
                    return wartosc;

                Console.WriteLine($"{nazwa} jest wymagane.");
            }
        }
        
        //ZAPIS
        private void Zapisz()
        {
            _produktService.Zapisz();
            _klientService.Zapisz();
            _zamowienieService.Zapisz();
            Console.WriteLine("Zapisano dane.");
            Console.ReadKey();
        }
    }
}
