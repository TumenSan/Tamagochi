using System;
using System.Xml.Linq;

namespace Tamagochi
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<CommandType, string> CommandNames = new Dictionary<CommandType, string>()
            {
                { CommandType.Feed, "Кормить" },
                { CommandType.Play, "Играть" },
                { CommandType.Sleep, "Укачивать" },
                { CommandType.Treatment, "Лечить" },
                { CommandType.GameOver, "Выйти из игры" },
            };

            string? PetName = "";

            while (string.IsNullOrEmpty(PetName))
            {
                Console.WriteLine("Введите имя вашего питомца:");
                PetName = Console.ReadLine();

                if (string.IsNullOrEmpty(PetName))
                {
                    Console.WriteLine("Имя не может быть пустым. Попробуйте снова.");
                }
            }

            const int maxHealth = 10;
            const int maxHunger = 10;
            const int maxFatigue = 10;
            const int maxHappy = 10;

            Pet pet = new Pet(PetName, maxHealth, maxHunger, maxFatigue, maxHappy);

            Console.WriteLine($"Питомец {pet.Name}: Здоровье - {pet.Health}, Голод - {pet.Hunger}, Усталость - {pet.Fatigue}, Счастье = {pet.Happy}");

            while (pet.isHealthy())
            {
                Console.WriteLine("Выберите действие:");
                foreach(var item  in CommandNames)
                {
                    Console.WriteLine((int)item.Key + ". " + item.Value);
                }

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    CommandType commandType = (CommandType)choice;

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
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                            break;
                    }

                    Console.WriteLine($"Питомец {pet.Name}: Здоровье - {pet.Health}, Голод - {pet.Hunger}, Усталость - {pet.Fatigue}, Счастье = {pet.Happy}");
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                }
            }

            Console.WriteLine("Питомец заболел. Игра завершена.");
        }


        private void PrintStatus(Pet pet)
        {
            Console.WriteLine($"Питомец {pet.Name}: Здоровье - {pet.Health}, Голод - {pet.Hunger}, Усталость - {pet.Fatigue}, Счастье = {pet.Happy}");
        }
    }
}