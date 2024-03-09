using System;
using System.Xml.Linq;

namespace tamagochi
{
    public class Pet
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Hunger { get; private set; }
        public int Fatigue { get; private set; }
        public int Happy {  get; private set; }

        public Pet(string name)
        {
            Name = name;
            Health = 10;
            Hunger = 10;
            Fatigue = 10;
            Happy = 10;
        }

        public void FeedPet()
        {
            if (Hunger == 10)
            {
                Health -= 1;
            }
            else
            {
                Hunger += 1;
            }
        }

        public void PlayPet()
        {
            if (Fatigue == 0)
            {
                Health -= 1;
                Hunger -= 1;
            }
            else
            {
                Fatigue -= 1;
            }

            if (Happy < 10)
            {
                Happy += 1;
            }
        }

        public void SleepPet()
        {
            Fatigue = 10;

            if (Hunger > 0)
            {
                Hunger -= 1;
            }

            if (Health != 10)
            {
                Health += 1;
            }
        }

        public void PetTreatment()
        {
            if (Health < 10)
            {
                Health += 1;
            }

            Happy -= 1;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Питомец {Name}: Здоровье - {Health}, Голод - {Hunger}, Усталость - {Fatigue}, Счастье = {Happy}");
        }
    }


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

            Pet pet = new Pet(PetName);

            pet.PrintStatus();

            while (pet.Health > 0)
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
                            pet.FeedPet();
                            break;
                        case 2:
                            pet.PlayPet();
                            break;
                        case 3:
                            pet.SleepPet();
                            break;
                        case 4:
                            pet.PetTreatment();
                            break;
                        case 5:
                            Console.WriteLine("Игра завершена.");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                            break;
                    }

                    pet.PrintStatus();
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                }
            }

            Console.WriteLine("Питомец заболел. Игра завершена.");
        }
    }
}