using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Menu
    {
        public void runMenu()
        {
            StartGame runGame = new StartGame();

            Console.Title = "Tamagotchi";
            int menuChoises = 0;
            string menuChoisesString = "";

            while (menuChoises != 3) // Innehållet som finns i menyn.
            {
                Console.WriteLine("Välj ett alternativ!");
                Console.WriteLine("1. Starta spel!");
                Console.WriteLine("2. Hur funkar det?");
                menuChoisesString = Console.ReadLine();

                while (!int.TryParse(menuChoisesString, out menuChoises))       // Koden gör att den inte krashar om anvädaren inte följer instruktionerna.
                {
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Det där är inte ett giltigt svar.");
                    Console.WriteLine("Välj 1 eller 2, Försök igen!");
                    Console.Write("Okej, Jag väljer då: ");

                    menuChoisesString = Console.ReadLine();
                }

                Console.ReadLine();


            }

            Console.ReadLine();

        }
    }
}