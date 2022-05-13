using System.Security.Cryptography;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Tamagotchi : Creature
    {
        Menu goToMenu = new Menu();
        // Använder properties för att inte behöva skapa hunger, bordeom etc i de andra arven.
        // Protected gör så att åtkomsten är begränsad till den eller de typer som kommer från den innehållande klassen.
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

        // Kollar ifall att man skriver ett ord när man lär tamagotchin ett ord, samt lägger till den i listan. 
        public virtual void teach(string word)
        {
            // Kör igenom ordet man skrivit för att kontrollera om användaren har tryck på space. 
            //Spelet kommer tolka det som att man skrivit 2 ord och hindra spelaren från att köra 
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    invalidWord = true;
                }
            }

            // När invalidWord är true körs koden och tamagotchin lär sig inte ett nytt ord. 
            if (invalidWord)
            {
                Console.WriteLine($"{name} kan bara lära sig ett ord åt gången.");
                Console.WriteLine("Försök igen nästa gång!");
                invalidWord = false;
            }

            // Om inte invalidWord inte är true körs koden och tamagotchin lär sig ett nytt ord.  
            else
            {
                reduceBoredom();
                words.Add(word);
                Console.WriteLine($"{name} har nu lärt sig ordet: {word}");
            }
        }

        public override void tick()
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

        // Skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
        public override void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Vokabulär: {words.Count} || Ålder: Tonåring || Vid Liv: {isAlive} || ");
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
