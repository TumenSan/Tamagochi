using System;
using System.Data;
using System.Xml.Linq;

namespace Tamagochi
{
    class Program
    {
        // Словарь действий
        public static Dictionary<CommandType, string> CommandNames = new Dictionary<CommandType, string>()
        {
            { CommandType.Feed, "Кормить" },
            { CommandType.Play, "Играть" },
            { CommandType.Sleep, "Укачивать" },
            { CommandType.Treatment, "Лечить" },
            { CommandType.GameOver, "Выйти из игры" },
        };

        static void Main(string[] args)
        {
            string? PetName = "";

            // Ввод пользователем имени питомца
            while (string.IsNullOrEmpty(PetName))
            {
                Console.WriteLine("Введите имя вашего питомца:");
                PetName = Console.ReadLine();

                if (string.IsNullOrEmpty(PetName))
                {
                    Console.WriteLine("Имя не может быть пустым. Попробуйте снова.\n" + "");
                }
            }

            // Максимальные значения статуса
            const int maxHealth = 10;
            const int maxHunger = 10;
            const int maxFatigue = 10;
            const int maxHappy = 10;

            // Создание питомца
            Pet pet = new Pet(PetName, maxHealth, maxHunger, maxFatigue, maxHappy);

            // Вывод статуса питомца
            PrintStatusPet(pet);

            // Пока питомец здоровый, игра продолжается
            while (pet.isHealthy())
            {
                // Вывод возможных действий
                PrintCommands();

                // Чтение команды
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    CommandType commandType = (CommandType)choice;

                    try
                    {
                        // Выполнение команды
                        ExecCommand(pet, commandType);
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Команда неверная
                        Console.WriteLine(ex.Message);
                    }

                    // Вывод статуса
                    PrintStatusPet(pet);
                }
                else
                {
                    Console.WriteLine("\nНеверный выбор. Попробуйте еще раз.\n");
                }
            }

            Console.WriteLine("Питомец заболел. Игра завершена.");
        }

        // Выполнение команд с питомцем
        private static void ExecCommand(Pet pet, CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Feed:
                    pet.Feed();
                    break;
                case CommandType.Play:
                    pet.Play();
                    break;
                case CommandType.Sleep:
                    pet.Sleep();
                    break;
                case CommandType.Treatment:
                    pet.Treatment();
                    break;
                case CommandType.GameOver:
                    Console.WriteLine("Игра завершена.");
                    System.Environment.Exit(0);
                    return;
                default:
                    throw new InvalidOperationException("Неверная команда.");
            }
        }

        // Вывод возможных действий
        private static void PrintCommands()
        {
            Console.WriteLine("Выберите действие:");
            foreach (var item in CommandNames)
            {
                Console.WriteLine((int)item.Key + ". " + item.Value);
            }
        }

        // Вывод статуса питомца
        private static void PrintStatusPet(Pet pet)
        {
            Console.WriteLine($"\nПитомец {pet.Name}: \n" +
                $"Здоровье  - {pet.Health}\n" +
                $"Голод     - {pet.Hunger}\n" +
                $"Усталость - {pet.Fatigue}\n" +
                $"Счастье   - {pet.Happy}\n");
        }
    }
}