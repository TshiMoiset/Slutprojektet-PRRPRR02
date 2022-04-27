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

            // Loopen behövs för att menyn ska skrivas ut. Den ser också till att skriva ut menyn en
            while (menuChoises != 1)    // menuChoises != 1 gör så att kod blocket körs en gång när man trycker på val 1. 
            {
                //Console.Clear();
                menuAlternatives();
                menuChoisesString = Console.ReadLine();

                if (menuChoisesString == "1" || menuChoisesString == "2")
                {
                    isItValid = true;

                }

                // Gör om string till en int och tvingar spelaren till att svara med en int. Går inte vidare i spelet annars.
                while (!int.TryParse(menuChoisesString, out menuChoises) || !isItValid)
                {
                    wrongMenuInput();
                    menuChoisesString = Console.ReadLine();

                    if (menuChoisesString == "1" || menuChoisesString == "2")
                    {
                        isItValid = true;
                    }
                }

                //Om man svarar 1 fortsätter programmet till startgame klassen och kör koden där. 
                if (menuChoisesString == "1")
                {
                    Console.Clear();
                    runGame.lauchGame();
                }

                // Om man svarar 2 får man en förklaring till hur spelt funkar. 
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
            Console.ForegroundColor = ConsoleColor.White;
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
