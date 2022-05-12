using System.Security.Cryptography;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Tamagotchi
    {
        Menu goToMenu = new Menu();
        // Använder properties för att inte behöva skapa hunger, bordeom etc i de andra arven.
        // Protected gör så att åtkomsten är begränsad till den eller de typer som kommer från den innehållande klassen.
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

        protected string[] salutations;
        public string[] Salutations
        {
            get { return salutations; }
            set { salutations = value; }
        }

        protected List<string> words;
        public List<string> Words
        {
            get { return words; }
            set { words = value; }
        }

        bool invalidWord = false;
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

        // Skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
        public virtual void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Vid Liv: {isAlive} || ");
            //Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Vokabulär: {words.Count} || Vid Liv: {isAlive} ||");
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
                goToMenu.RunMenu();
            }
        }

        // Lägger till ett ord i words, och anropar ReduceBoredom. 
        public virtual void teach(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    invalidWord = true;
                }
            }

            if (invalidWord)
            {
                Console.WriteLine($"{name} kan bara lära sig ett ord åt gången.");
                Console.WriteLine("Försök igen nästa gång!");
            }

            else
            {
                reduceBoredom();
                words.Add(word);
                Console.WriteLine($"{name} har nu lärt sig ordet: {word}");
            }
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

        public virtual void showWords()
        {
            if (words.Count == 0)
            {

                Console.WriteLine("Du har inte lärt mig något!");
                tick();
            }

            else
            {
                Console.WriteLine($"{name} kan orden:");
                for (int i = 0; i < words.Count; i++)
                {
                    Console.WriteLine(words[i]);
                }
            }
        }
    }
}
