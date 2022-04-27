using System.Reflection;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Tamagotchi
    {
        int hunger = 0;
        int boredom = 0;
        List<string> words = new List<string>();
        bool isAlive = true;

        Random randomNumber = new Random();
        public string name;

        // Feed behövs för att sänka hungern när man matar tamagotchi.
        public void feed()
        {
            hunger -= 1;
        }

        // Skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        public void hi()
        {
            int i = randomNumber.Next(words.Count);
            if (words.Count < 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(words[i]);
            }
            reduceBoredom();
        }

        // Lägger till ett ord i words, och anropar ReduceBoredom.
        public void teach(string word)
        {
            printStats();
            words.Add(word);
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
            reduceBoredom();
        }

        public void showWords()
        {
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
                Console.WriteLine("GAME OVER");
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
