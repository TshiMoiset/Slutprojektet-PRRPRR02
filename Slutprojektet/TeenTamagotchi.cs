using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class TeenTamagotchi : Tamagotchi
    {
        Menu goToMenu = new Menu();
        bool invalidWord = false;

        public TeenTamagotchi()
        { }
        string[] Salutations = { "Läget", "Tjena", "Morsning", "Tjingeling", "Tjenixen" };
        string[] TamagotchiNames = { "LEAH", "ELLIE", "MILA", "VINCENT", "MATTEO", "AUGUST" };

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

        // Ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        public override void tick()
        {
            Hunger += randomNumber.Next(2, 4);
            Boredom += randomNumber.Next(2, 3);
            if (Boredom > 10 || Hunger > 10)
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
    }
}