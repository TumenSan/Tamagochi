using System;
using System.Xml.Linq;

namespace Tamagochi
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("1. Покормить");
                Console.WriteLine("2. Поиграть");
                Console.WriteLine("3. Укачать");
                Console.WriteLine("4. Лечить");
                Console.WriteLine("5. Выйти из игры");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            pet.Feed();
                            break;
                        case 2:
                            pet.Play();
                            break;
                        case 3:
                            pet.Sleep();
                            break;
                        case 4:
                            pet.Treatment();
                            break;
                        case 5:
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