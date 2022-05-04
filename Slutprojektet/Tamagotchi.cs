using System.Reflection;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Tamagotchi
    {
        Menu goToMenu = new Menu();

        // Använder properties för att inte behöva skapa hunger/bordeom i de andra arven.
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

        protected bool isAlive;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }


        protected List<string> words;
        public List<string> Words
        {
            get { return words; }
            set { words = value; }
        }

        protected string[] salutations;
        public string[] Salutations
        {
            get { return salutations; }
            set { salutations = value; }
        }

        protected string[] tamagotchiNames;
        public string[] TamagotchiNames
        {
            get { return tamagotchiNames; }
            set { tamagotchiNames = value; }
        }

        public Random randomNumber = new Random();
        public string name;

        // Behövs för att sänka hungern när man matar tamagotchi.
        public void feed()
        {
            hunger -= randomNumber.Next(1, 2);
        }

        // Skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        public void hi()
        {
            int i = randomNumber.Next(salutations.Length);
            Console.WriteLine(salutations[i]);
            reduceBoredom();
        }

        public void showWords()
        {
            if (words.Count == 0)
            {
                Console.WriteLine("Du har inte lärt mig något!");
            }
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
        }

        public virtual void tick()
        {
            hunger += randomNumber.Next(0, 2);
            boredom += randomNumber.Next(0, 2);
            if (boredom > 10 || hunger > 10)
            {
                isAlive = false;
                Console.WriteLine();
                Console.WriteLine("Game over");
                Console.WriteLine("Din Tamagotchi har dött.");
                Console.WriteLine("Tryck på [ENTER] för att fortsätta");
                Console.ReadLine();
                Console.Clear();
                goToMenu.runMenu();
            }
        }

        // Skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
        public void printStats()
        {
            Console.WriteLine($"Tråkighet: {boredom} || Hunger: {hunger} || Vokabulär: {words.Count} || Vid Liv: {isAlive} ||");
        }

        // Returnerar värdet som isAlive har.
        public bool GetAlive()
        {
            return isAlive;
        }

        // Sänker boredom.
        public void reduceBoredom()
        {
            boredom -= randomNumber.Next(0, 2);
        }
    }
}
