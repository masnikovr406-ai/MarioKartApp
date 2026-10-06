using System;
using MarioKart.Core;

namespace MarioKart.ConsoleApp
{
    internal class Program
    {
        private static readonly Logic _logic = new();

        static void Main(string[] args)
        {
            _logic.AddRacer("Mario", "Средний", 7, 15);
            _logic.AddRacer("Bowser", "Тяжелый", 9, 8);
            _logic.AddRacer("Toad", "Легкий", 5, 20);

            while (true)
            {
                Console.WriteLine("\n=== MARIO KART ROSTER ===");
                Console.WriteLine("1. Показать всех гонщиков");
                Console.WriteLine("2. Добавить гонщика");
                Console.WriteLine("3. Изменить параметры гонщика");
                Console.WriteLine("4. Удалить гонщика");
                Console.WriteLine("5. Фильтр по весу (Бизнес-функция 1)");
                Console.WriteLine("6. Кто самый быстрый? (Бизнес-функция 2)");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ShowAll(); break;
                    case "2": AddRacer(); break;
                    case "3": EditRacer(); break;
                    case "4": RemoveRacer(); break;
                    case "5": FilterRacers(); break;
                    case "6": ShowFastest(); break;
                    case "0": return;
                    default: Console.WriteLine("Неизвестная команда!"); break;
                }
            }
        }

        static void ShowAll()
        {
            var list = _logic.GetAllRacers();
            if (list.Count == 0) { Console.WriteLine("Список пуст."); return; }
            foreach (var r in list) Console.WriteLine(r);
        }

        static void AddRacer()
        {
            Console.Write("Имя персонажа: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Весовой класс (Легкий/Средний/Тяжелый): ");
            string weight = Console.ReadLine() ?? "Средний";
            Console.Write("Скорость (1-10): ");
            int.TryParse(Console.ReadLine(), out int speed);
            Console.Write("Монеты: ");
            int.TryParse(Console.ReadLine(), out int coins);

            _logic.AddRacer(name, weight, speed, coins);
            Console.WriteLine("Гонщик добавлен в заезд!");
        }


        static void EditRacer()
        {
            Console.Write("Введите ID гонщика для изменения: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("Новое имя: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Новый весовой класс: ");
            string weight = Console.ReadLine() ?? "";
            Console.Write("Новая скорость (1-10): ");
            int.TryParse(Console.ReadLine(), out int speed);
            Console.Write("Новые монеты: ");
            int.TryParse(Console.ReadLine(), out int coins);

            if (_logic.UpdateRacer(id, name, weight, speed, coins))
                Console.WriteLine("Гонщик обновлен.");
            else
                Console.WriteLine("Гонщик с таким ID не найден.");
        }

        static void RemoveRacer()
        {
            Console.Write("Введите ID гонщика для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (_logic.DeleteRacer(id)) Console.WriteLine("Гонщик удален.");
                else Console.WriteLine("ID не найден.");
            }
        }

        static void FilterRacers()
        {
            Console.Write("Какой класс показать (Легкий/Средний/Тяжелый): ");
            string weight = Console.ReadLine() ?? "";
            var filtered = _logic.FilterByWeight(weight);
            foreach (var r in filtered) Console.WriteLine(r);
        }


        static void ShowFastest()
        {
            var fastest = _logic.GetFastestRacer();
            if (fastest != null)
                Console.WriteLine($"Лидер по скорости: {fastest.Name} со скоростью {fastest.Speed}/10!");
            else
                Console.WriteLine("Гонщиков пока нет.");
        }
    }
}