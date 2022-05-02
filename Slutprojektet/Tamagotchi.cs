using System.Reflection;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Tamagotchi
    {
        Menu goToMenu = new Menu();

        int hunger = 0;
        int boredom = 0;
        List<string> words = new List<string>();
        string[] salutations = { "Hej", "Hej hej", "Tjena", "Hallå", "Hejsan" };
        public string[] tamagotchiNames = { "LEAH", "ELLIE", "MILA", "VINCENT", "MATTEO", "AUGUST" };

        bool isAlive = true;
        bool invalidWord = false;

        public Random randomNumber = new Random();
        public string name;

        // Behövs för att sänka hungern när man matar tamagotchi.
        public void feed()
        {
            hunger -= randomNumber.Next(1, 3);
        }

        // Skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        public void hi()
        {
            int i = randomNumber.Next(salutations.Length);
            Console.WriteLine(salutations[i]);
            reduceBoredom();
        }

        // Lägger till ett ord i words, och anropar ReduceBoredom. 
        public void teach(string word)
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

        // Ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        public void tick()
        {
            hunger += randomNumber.Next(0, 5);
            boredom += randomNumber.Next(0, 5);
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
        private void reduceBoredom()
        {
            boredom -= randomNumber.Next(0, 2);
        }
    }
}
