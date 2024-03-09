using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    public class Pet
    {
        public string Name { get; private set; }
        
        public int Health { get; private set; }
        public int Hunger { get; private set; }
        public int Fatigue { get; private set; }
        public int Happy { get; private set; }
       
        private int MaxHealth { get; set; }
        private int MaxHunger { get; set; }
        private int MaxFatigue { get; set; }
        private int MaxHappy { get; set; }

        public Pet(string name, int maxHealth, int maxHunger, int maxFatigue, int maxHappy)
        {
            Name    = name;
            Health  = maxHealth;  //->  0-больной max-здоровый
            Hunger  = 0;          //<-  0-переел max-очень голодный
            Fatigue = 0;          //<-  0-полон сил max-очень устал
            Happy   = maxHappy;   //->  0-не счастливый max-счастливый

            MaxHealth = maxHealth;
            MaxHunger = maxHunger;
            MaxFatigue = maxFatigue;
            MaxHappy = maxHappy;
        }

        public void Feed()
        {
            if (Hunger == 0)  // переел
                Health -= 1;  // вредно для здоровья
            else
                Hunger -= 1;    
        }

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

        public void Treatment()
        {
            if (Health < MaxHealth)
            {
                Health += 1;
            }

            Happy -= 1;
        }

        public bool isHealthy()
        {
            return Health != 0;
        }
    }
}
