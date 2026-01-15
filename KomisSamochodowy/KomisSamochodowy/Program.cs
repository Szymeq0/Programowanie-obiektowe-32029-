using KomisSamochodowy.Models;
using KomisSamochodowy.Services;

var dealership = new CarDealership();

//WCZYTANIE DANYCH Z JSON NA STARCIE
var loadedVehicles = JsonFileService.Load();
foreach (var vehicle in loadedVehicles)
{
    dealership.AddVehicle(vehicle);
}

Console.WriteLine($"Wczytano {loadedVehicles.Count} pojazdów z pliku JSON.");

while (true)
{
    Console.WriteLine("\n=== KOMIS SAMOCHODOWY ===");
    Console.WriteLine("1. Dodaj samochód");
    Console.WriteLine("2. Dodaj motocykl");
    Console.WriteLine("3. Wyświetl wszystkie pojazdy");
    Console.WriteLine("4. Modyfikuj pojazd");
    Console.WriteLine("5. Usuń pojazd");
    Console.WriteLine("0. Zapisz i wyjdź");
    Console.Write("Wybierz opcję: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
        {
            int carId;

            //Wymuszamy unikalne ID
            while (true)
            {
                Console.Write("ID: ");
                if (!int.TryParse(Console.ReadLine(), out carId))
                {
                    Console.WriteLine("ID musi być liczbą.");
                    continue;
                }

                if (dealership.ExistsId(carId))
                {
                    Console.WriteLine("Pojazd o takim ID już istnieje. Podaj inne ID.");
                    continue;
                }

                break; // ID poprawne
            }

            Console.Write("Silnik: ");
            string carEngine = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Rok: ");
            int year = int.Parse(Console.ReadLine());

            dealership.AddVehicle(new Car(carId, carEngine, model, year));
            Console.WriteLine("Samochód dodany poprawnie.");
            break;
        }


        case "2":
        {
            int bikeId;

            // Wymuszamy unikalne ID
            while (true)
            {
                Console.Write("ID: ");
                if (!int.TryParse(Console.ReadLine(), out bikeId))
                {
                    Console.WriteLine("ID musi być liczbą.");
                    continue;
                }

                if (dealership.ExistsId(bikeId))
                {
                    Console.WriteLine("Pojazd o takim ID już istnieje. Podaj inne ID.");
                    continue;
                }

                break; // ID poprawne
            }

            Console.Write("Silnik: ");
            string bikeEngine = Console.ReadLine();

            Console.Write("Typ motocykla: ");
            string type = Console.ReadLine();

            dealership.AddVehicle(new Bike(bikeId, bikeEngine, type));
            Console.WriteLine("Motocykl dodany poprawnie.");
            break;
        }


        case "3":
            dealership.ShowVehicles();
            break;

        case "4":
            Console.Write("ID pojazdu do modyfikacji: ");
            int editId = int.Parse(Console.ReadLine());

            if (!dealership.UpdateVehicle(editId))
                Console.WriteLine("Nie znaleziono pojazdu.");
            else
                Console.WriteLine("Pojazd zaktualizowany.");
            break;

        case "5":
            Console.Write("ID pojazdu do usunięcia: ");
            int removeId = int.Parse(Console.ReadLine());

            if (!dealership.RemoveVehicle(removeId))
                Console.WriteLine("Nie znaleziono pojazdu.");
            else
                Console.WriteLine("Pojazd usunięty.");
            break;

        case "0":
            // ZAPIS DO JSON PRZY WYJŚCIU
            JsonFileService.Save(dealership.GetAll());
            Console.WriteLine("Dane zapisane. Do widzenia!");
            return;

        default:
            Console.WriteLine("Nieprawidłowa opcja.");
            break;
    }
}
