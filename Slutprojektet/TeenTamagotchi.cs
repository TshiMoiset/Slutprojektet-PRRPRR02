using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class TeenTamagotchi : Tamagotchi
    {
        Menu goToMenu = new Menu();
        bool invalidWord = false;

        List<string> words = new List<string>();

        string[] Salutations = { "Läget", "Tjena", "Morsning", "Tjingeling", "Tjenixen" };

        // Skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
        public override void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Vokabulär: {words.Count} || Ålder: Tonåring || Vid Liv: {isAlive} || ");
        }

        // Kollar ifall att man skriver ett ord när man lär tamagotchin ett ord, samt lägger till den i listan. 
        public override void teach(string word)
        {
            // Kör igenom ordet man skrivit för att kontrollera om användaren har tryck på space. 
            //Spelet kommer tolka det som att man skrivit 2 ord och hindra spelaren från att köra vidare. 
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

        // Ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        public override void tick()
        {
            // Adderar hunger och boredom med en random siffra. 
            Hunger += randomNumber.Next(2, 4);
            Boredom += randomNumber.Next(2, 3);

            // Om boredom och hunger är större än 10 är spelet slut. 
            if (Boredom > 10 || Hunger > 10)
            {
                IsAlive = false;
                Console.WriteLine();
                Console.WriteLine("Game over");
                Console.WriteLine("Din Tamagotchi har dött.");
                Console.WriteLine("Tryck på [ENTER] för att fortsätta");
                Console.ReadLine();
                Console.Clear();
                goToMenu.RunMenu();
            }
        }

        // Visar vilka ord tamagotchin kan.
        public override void showWords()
        {
            // Om listan med ord är tom, d.v.s
            if (words.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har inte lärt mig något!");
                Console.ForegroundColor = ConsoleColor.White;
                tick();
            }

            // Om tamagotchin kan ord, körs for loopen igenom metoden och skriver ur de. 
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
        }

        // Skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        public void hi()
        {
            int pickedSalutation = randomNumber.Next(Salutations.Length);
            Console.WriteLine(Salutations[pickedSalutation]);
            reduceBoredom();
        }
    }
}