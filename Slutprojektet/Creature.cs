using System;

namespace Slutprojektet
{
    public class Creature
    {
        public Random randomNumber = new Random();
        public string name;

        protected int hunger;
        public int Hunger
        {
            get { return hunger; }
            set { hunger = value; }
        }

        protected int boredom;
        public int Boredom
        {
            get { return boredom; }
            set { boredom = value; }
        }

        protected bool isAlive = true;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        // Returnerar värdet som isAlive har.
        public bool GetAlive()
        {
            return isAlive;
        }

        // Sänker boredom.
        public void reduceBoredom()
        {
            boredom -= randomNumber.Next(1, 2);
        }

        // Behövs för att sänka hungern när man matar tamagotchi.
        public void feed()
        {
            hunger -= randomNumber.Next(1, 3);
        }

        // Skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
        public virtual void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Ålder: Tonåring || Vid Liv: {isAlive} || ");
        }

        // Ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        public virtual void tick()
        {
            hunger += randomNumber.Next(0, 2);
            boredom += randomNumber.Next(0, 2);
        }
    }
}