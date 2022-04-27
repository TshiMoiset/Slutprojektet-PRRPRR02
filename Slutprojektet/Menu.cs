using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Menu
    {
        public void runMenu()
        {
            StartGame runGame = new StartGame();

            Console.Title = "Tamagotchi";       // Fönstrets namn. 
            int menuChoises = 0;
            string menuChoisesString = "";      // Tom string för att kunna svara.
            bool isItValid = false;

            // Loopen behövs för att menyn ska skrivas ut i konsolen. 
            while (menuChoises != 1)    // Så länge menuChoises inte är lika med 1 kommer loopen köras och menyn kommer skrivas ut. 
            {
                menuAlternatives();     // Skriver ut det som står i metoden, vilket är menyns val alternativ.
                menuChoisesString = Console.ReadLine();

                // Gör om string till en int och tvingar spelaren till att svara med en int. Går inte vidare i spelet annars.
                while (!int.TryParse(menuChoisesString, out menuChoises) || !isItValid)
                {
                    wrongMenuInput();       // Skriver ut det som står i metoden, vilket är ett medelande till spelaren om man gjort fel input.
                    menuChoisesString = Console.ReadLine();

                    /*if (menuChoisesString == "1" || menuChoisesString == "2")
                    {
                        isItValid = true;
                    }*/
                }

                //Om man svarar 1 fortsätter programmet till startgame klassen och kör koden där. 
                if (menuChoisesString == "1")
                {
                    Console.Clear();
                    runGame.lauchGame();
                }

                // Om man svarar 2 får man en förklaring till hur spelet fungerar. 
                else if (menuChoisesString == "2")
                {
                    gameInformation();
                }

                Console.WriteLine();
            }
        }

        void menuAlternatives()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Välkommen till Tamagotchi!");
            Console.WriteLine();
            Console.WriteLine("Välj alternativ 1 eller 2 och tryck [ENTER] för att fortsätta.");
            Console.WriteLine("1. Starta spel!");
            Console.WriteLine("2. Hur funkar det?");
            Console.WriteLine();
        }

        void wrongMenuInput()
        {
            Console.WriteLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Det där är inte ett giltigt svar!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Välj alternativ 1 eller 2, Försök igen!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Starta spel!");
            Console.WriteLine("2. Hur funkar det?");
            Console.WriteLine();
            Console.Write("Okej, Då väljer jag: ");
        }

        void gameInformation()
        {
            Console.Clear();
            Console.WriteLine("Spelet går ut på att hålla din Tamagotchi vid liv genom att");
            Console.WriteLine("välja mellan att lära den ett nytt ord, hälsa på den, mata den eller göra ingenting.");
            Console.WriteLine("Varje gång du gör ett val ökar hunger och boredom eller så sjunker de, och om någon av de blir över 10 så DÖR din Tamagotchi.");
            Console.WriteLine("DÖD TAMAGOTCHI = GAME OVER");
            Console.WriteLine("Lycka till!");
        }
    }
}
