using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    // Класс питомец
    public class Pet
    {
        public string Name { get; private set; }  // Имя питомца
        public int Health { get; private set; }   // Здоровье
        public int Hunger { get; private set; }   // Голод
        public int Fatigue { get; private set; }  // Усталость
        public int Happy { get; private set; }    // Счастье

        // Соответствующие максимальные показатели по баллам
        private int MaxHealth { get; set; }
        private int MaxHunger { get; set; }
        private int MaxFatigue { get; set; }
        private int MaxHappy { get; set; }

        // Создание нового питомца с указанным именем и макс и мин значениями для его атрибутов
        public Pet(string name, int maxHealth, int maxHunger, int maxFatigue, int maxHappy)
        {
            Name    = name;
            Health  = maxHealth;  //->  0-больной        max-здоровый
            Hunger  = 0;          //<-  0-переел         max-очень голодный
            Fatigue = 0;          //<-  0-полон сил      max-очень устал
            Happy   = maxHappy;   //->  0-не счастливый  max-счастливый

            MaxHealth = maxHealth;
            MaxHunger = maxHunger;
            MaxFatigue = maxFatigue;
            MaxHappy = maxHappy;
        }

        // Кормление питомца снижает уровень его голода. Перекармливание нанесит вред здоровью
        public void Feed()
        {
            if (Hunger == 0)  // переел
                Health -= 1;  // вредно для здоровья
            else
                Hunger -= 1;    
        }

        // Игра с питомцем увеличивает его усталость, но увеличивает счастье
        public void Play()
        {
            if (Fatigue == MaxFatigue) // устал
            {
                Health -= 1;
                Hunger += 1;
            }
            else
                Fatigue += 1;

            if (Happy < MaxHappy)
                Happy += 1;
        }

        // Сон устраняет усталость питомца, но увеличивает чувство голода и здоровье
        public void Sleep()
        {
            Fatigue = 0;

            if (Hunger < MaxHunger)
            {
                Hunger += 1;
            }

            if (Health < MaxHealth)
            {
                Health += 1;
            }
        }

        // Лечение питомца улучшает его здоровье, но уменьшает радость
        public void Treatment()
        {
            if (Health < MaxHealth)
            {
                Health += 1;
            }

            Happy -= 1;
        }

        // Если здоровье питомца на нуле, то он заблолел
        public bool isHealthy()
        {
            return Health != 0;
        }
    }
}
