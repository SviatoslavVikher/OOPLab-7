using System;

class Date
{
    // Поля
    private int year, month, day, hours, minutes;

    // Властивості
    public int Year { get => year; set => year = value; }
    public int Month { get => month; set => month = value; }
    public int Day { get => day; set => day = value; }
    public int Hours { get => hours; set => hours = value; }
    public int Minutes { get => minutes; set => minutes = value; }

    // Конструктори
    public Date() { }

    public Date(int year, int month, int day, int hours, int minutes)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.hours = hours;
        this.minutes = minutes;
    }

    // Метод для введення дати
    public void ReadDate()
    {
        Console.Write("Рік: ");
        year = int.Parse(Console.ReadLine());
        Console.Write("Місяць: ");
        month = int.Parse(Console.ReadLine());
        Console.Write("День: ");
        day = int.Parse(Console.ReadLine());
        Console.Write("Години: ");
        hours = int.Parse(Console.ReadLine());
        Console.Write("Хвилини: ");
        minutes = int.Parse(Console.ReadLine());
    }

    // Перевизначення ToString
    public override string ToString()
    {
        return $"{day:D2}/{month:D2}/{year} {hours:D2}:{minutes:D2}";
    }
}

class Airplane
{
    // Поля
    private string departureCity;
    private string arrivalCity;
    private Date departureDate;
    private Date arrivalDate;
    private double distanceKm; // Дальність польоту в кілометрах

    // Властивості
    public string DepartureCity { get => departureCity; set => departureCity = value; }
    public string ArrivalCity { get => arrivalCity; set => arrivalCity = value; }
    public Date DepartureDate { get => departureDate; set => departureDate = value; }
    public Date ArrivalDate { get => arrivalDate; set => arrivalDate = value; }
    public double DistanceKm { get => distanceKm; set => distanceKm = value; }

    // Конструктор
    public Airplane()
    {
        departureDate = new Date();
        arrivalDate = new Date();
    }

    // Метод для введення даних рейсу
    public void ReadAirplane()
    {
        Console.Write("Місто відправлення: ");
        departureCity = Console.ReadLine();
        Console.Write("Місто прибуття: ");
        arrivalCity = Console.ReadLine();

        Console.WriteLine("Дата відправлення:");
        departureDate.ReadDate();

        Console.WriteLine("Дата прибуття:");
        arrivalDate.ReadDate();

        ReadDistance();
    }

    // Метод для введення дальності польоту
    public void ReadDistance()
    {
        Console.WriteLine("Оберіть одиниці вимірювання для введення дальності:");
        Console.WriteLine("1 - Кілометри\n2 - Метри\n3 - Мілі");
        Console.Write("Ваш вибір: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Введіть значення: ");
        double value = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                distanceKm = value;
                break;
            case 2:
                distanceKm = value / 1000.0;
                break;
            case 3:
                distanceKm = value / 0.621371;
                break;
            default:
                Console.WriteLine("Некоректний вибір. Дальність буде встановлена як 0.");
                distanceKm = 0;
                break;
        }
    }

    // Метод для виведення інформації про рейс
    public void PrintAirplane()
    {
        Console.WriteLine($"Відправлення: {departureCity} ({departureDate})");
        Console.WriteLine($"Прибуття: {arrivalCity} ({arrivalDate})");
        Console.WriteLine($"Дальність польоту: {distanceKm:F2} км, {distanceKm * 1000:F2} м, {distanceKm * 0.621371:F2} миль.");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість рейсів: ");
        int n = int.Parse(Console.ReadLine());

        Airplane[] airplanes = new Airplane[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Введення даних для рейсу {i + 1} ---");
            airplanes[i] = new Airplane();
            airplanes[i].ReadAirplane();
        }

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 - Вивести всі рейси");
            Console.WriteLine("2 - Вивести інформацію про конкретний рейс");
            Console.WriteLine("3 - Вийти");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- Усі рейси ---");
                    foreach (var airplane in airplanes)
                    {
                        airplane.PrintAirplane();
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.Write("Введіть номер рейсу (1 - {0}): ", n);
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < n)
                    {
                        Console.WriteLine($"\n--- Рейс {index + 1} ---");
                        airplanes[index].PrintAirplane();
                    }
                    else
                    {
                        Console.WriteLine("Некоректний номер рейсу.");
                    }
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
